using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using TeaDistributor.DTO;
using TeaDistributor.Models;
using TeaDistributor.ViewModels;

namespace TeaDistributor.Services
{
    public class ItemService
    {
        public ApplicationDbContext dbContext;

        public ItemService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<TeaItem>> GetAllTeas()
        {
            //var teaItems = await dbContext.TeaItems.ToListAsync();
            var teaItems = await dbContext.TeaItems
                                    .Include(t => t.Type)
                                    .Include(t => t.Region)
                                    .Include(t => t.Supplier)
                                    .ToListAsync();            
            return teaItems;
        }

        public async Task Create(TeaItemDTO teaItemDTO)
        {            
            await dbContext.TeaItems.AddAsync(dtoToModel(teaItemDTO));
            await dbContext.SaveChangesAsync();
        }

        public async Task<TeaItemDTO> GetById(int id)
        {
            var teaItem = await dbContext.TeaItems
                                            .Include(t => t.Type)
                                            .Include(t => t.Region)
                                            .Include(t => t.Supplier)
                                            .FirstOrDefaultAsync(item => item.Id == id);
            if (teaItem == null)
            {
                throw new KeyNotFoundException($"TeaItem with ID {id} was not found.");
            }
            return modelToDto(teaItem);
        }

        public async Task<TeaItemDTO> Edit(int id, TeaItemDTO teaItemDTO)
        {
            dbContext.Update(dtoToModel(teaItemDTO));
            await dbContext.SaveChangesAsync();
            return teaItemDTO;
        }

        public async Task Delete(int id)
        {
            var teaItem = await dbContext.TeaItems.FirstOrDefaultAsync(item => item.Id == id);
            if (teaItem == null)
            { throw new KeyNotFoundException($"TeaItem with ID {id} was not found."); }
            dbContext.TeaItems.Remove(teaItem);
            await dbContext.SaveChangesAsync();
        }

        private TeaItemDTO modelToDto(TeaItem teaItem)
        {
            return new TeaItemDTO()
            {
                Id = teaItem.Id,
                Name = teaItem.Name,
                TypeId = teaItem.Type.Id,
                RegionId = teaItem.Region.Id,
                Quality = teaItem.Quality,
                SupplierId = teaItem.Supplier.Id,
                Description = teaItem.Description,
                SteepingTime = teaItem.SteepingTime
            };
        }
        private TeaItem dtoToModel(TeaItemDTO teaItemDTO)
        {           
            return new TeaItem()
            {
                Id = teaItemDTO.Id,
                Name = teaItemDTO.Name,
                Type = dbContext.TeaTypes.FirstOrDefault(type => type.Id == teaItemDTO.TypeId),
                //Type = dbContext.TeaTypes.First(type => type.Id == teaItemDTO.TypeId),
                Region = dbContext.TeaRegions.FirstOrDefault(region => region.Id == teaItemDTO.RegionId),
                //Region = dbContext.TeaRegions.First(region => region.Id == teaItemDTO.RegionId),
                Quality = teaItemDTO.Quality,
                Supplier = dbContext.TeaSuppliers.FirstOrDefault(supplier => supplier.Id == teaItemDTO.SupplierId),         
                //Supplier = dbContext.TeaSuppliers.First(supplier => supplier.Id == teaItemDTO.SupplierId),                
                Description = teaItemDTO.Description,
                SteepingTime = teaItemDTO.SteepingTime
            };
        }

        public async Task<TeaItemDropdownsVM> GetTeaItemDropdownsValues()
        {
            var teaItemDropdownsValues = new TeaItemDropdownsVM()
            {
                Types = await dbContext.TeaTypes.OrderBy(opts => opts.Name).ToListAsync(),
                Regions = await dbContext.TeaRegions.OrderBy(opts => opts.Name).ToListAsync(),
                Suppliers = await dbContext.TeaSuppliers.OrderBy(opts => opts.Name).ToListAsync(),
            };
            return teaItemDropdownsValues;
        }
    }
}
