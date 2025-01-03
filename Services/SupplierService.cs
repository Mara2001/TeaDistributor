using Microsoft.EntityFrameworkCore;
using TeaDistributor.DTO;
using TeaDistributor.Models;

namespace TeaDistributor.Services
{
    public class SupplierService
    {
        public ApplicationDbContext dbContext;

        public SupplierService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<TeaSupplierDTO>> GetAllSuppliers()
        {
            var teaSuppliers = await dbContext.TeaSuppliers.ToListAsync();
            var teaSuppliersDTOs = new List<TeaSupplierDTO>();
            foreach (var teaSupplier in teaSuppliers)
            {
                teaSuppliersDTOs.Add(modelToDto(teaSupplier));
            }
            return teaSuppliersDTOs;
        }

        public async Task Create(TeaSupplierDTO teaSupplierDTO)
        {
            await dbContext.TeaSuppliers.AddAsync(dtoToModel(teaSupplierDTO));
            await dbContext.SaveChangesAsync();
        }

        public async Task<TeaSupplierDTO> GetById(int id)
        {
            var teaSupplier = await dbContext.TeaSuppliers.FirstOrDefaultAsync(opts => opts.Id == id);
            if (teaSupplier == null)
            {
                throw new KeyNotFoundException($"TeaSupplier with ID {id} was not found.");
            }
            return modelToDto(teaSupplier);
        }

        public async Task<TeaSupplierDTO> Edit(int id, TeaSupplierDTO teaSupplierDTO)
        {
            dbContext.Update(dtoToModel(teaSupplierDTO));
            await dbContext.SaveChangesAsync();
            return teaSupplierDTO;
        }
        
        public async Task Delete(int id)
        {
            var teaSupplier = await dbContext.TeaSuppliers.FirstOrDefaultAsync(opts => opts.Id == id);
            if (teaSupplier == null)
            { throw new KeyNotFoundException($"TeaSupplier with ID {id} was not found."); }
            dbContext.TeaSuppliers.Remove(teaSupplier);
            await dbContext.SaveChangesAsync();
        }

        private TeaSupplierDTO modelToDto(TeaSupplier teaSupplier)
        {
            return new TeaSupplierDTO()
            {
                Id = teaSupplier.Id,
                Name = teaSupplier.Name,
                Phone = teaSupplier.Phone,
                Email = teaSupplier.Email,
                Address = teaSupplier.Address
            };
        }
        private TeaSupplier dtoToModel(TeaSupplierDTO teaSupplierDTO)
        {
            return new TeaSupplier()
            {
                Id = teaSupplierDTO.Id,
                Name = teaSupplierDTO.Name,
                Phone = teaSupplierDTO.Phone,
                Email = teaSupplierDTO.Email,
                Address = teaSupplierDTO.Address
            };
        }
    }
}
