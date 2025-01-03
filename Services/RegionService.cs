using Microsoft.EntityFrameworkCore;
using TeaDistributor.DTO;
using TeaDistributor.Models;

namespace TeaDistributor.Services
{
    public class RegionService
    {
        public ApplicationDbContext dbContext;

        public RegionService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<TeaRegionDTO>> GetAllRegions()
        {
            var teaRegions = await dbContext.TeaRegions.ToListAsync();
            var teaRegionsDTOs = new List<TeaRegionDTO>();
            foreach (var teaRegion in teaRegions)
            {
                teaRegionsDTOs.Add(modelToDto(teaRegion));
            }
            return teaRegionsDTOs;
        }

        public async Task Create(TeaRegionDTO teaRegionDTO)
        {
            await dbContext.TeaRegions.AddAsync(dtoToModel(teaRegionDTO));
            await dbContext.SaveChangesAsync();
        }

        public async Task<TeaRegionDTO> GetById(int id)
        {
            var teaRegion = await dbContext.TeaRegions.FirstOrDefaultAsync(opts => opts.Id == id);
            if (teaRegion == null)
            {
                throw new KeyNotFoundException($"TeaRegion with ID {id} was not found.");
            }
            return modelToDto(teaRegion);
        }

        public async Task<TeaRegionDTO> Edit(int id, TeaRegionDTO teaRegionDTO)
        {
            dbContext.Update(dtoToModel(teaRegionDTO));
            await dbContext.SaveChangesAsync();
            return teaRegionDTO;
        }

        public async Task Delete(int id)
        {
            var teaRegion = await dbContext.TeaRegions.FirstOrDefaultAsync(opts => opts.Id == id);
            if (teaRegion == null)
            { throw new KeyNotFoundException($"TeaRegion with ID {id} was not found."); }
            dbContext.TeaRegions.Remove(teaRegion);
            await dbContext.SaveChangesAsync();
        }

        private TeaRegionDTO modelToDto(TeaRegion teaRegion)
        {
            return new TeaRegionDTO()
            {
                Id = teaRegion.Id,
                Name = teaRegion.Name,
                District = teaRegion.District,
                Description = teaRegion.Description,
                Characteristics = teaRegion.Characteristics
            };
        }
        private TeaRegion dtoToModel(TeaRegionDTO teaRegionDTO)
        {
            return new TeaRegion()
            {
                Id = teaRegionDTO.Id,
                Name = teaRegionDTO.Name,
                District = teaRegionDTO.District,
                Description = teaRegionDTO.Description,
                Characteristics = teaRegionDTO.Characteristics
            };
        }
    }
}
