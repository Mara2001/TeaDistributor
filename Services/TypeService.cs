using Microsoft.EntityFrameworkCore;
using TeaDistributor.DTO;
using TeaDistributor.Models;

namespace TeaDistributor.Services
{
    public class TypeService
    {
        public ApplicationDbContext dbContext;

        public TypeService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<TeaTypeDTO>> GetAllTypes()
        {
            var teaTypes = await dbContext.TeaTypes.ToListAsync();
            var teaTypeDTOs = new List<TeaTypeDTO>();
            foreach (var teaType in teaTypes)
            {
                teaTypeDTOs.Add(modelToDto(teaType));
            }
            return teaTypeDTOs;
        }

        public async Task Create(TeaTypeDTO teaTypeDTO)
        {
            await dbContext.TeaTypes.AddAsync(dtoToModel(teaTypeDTO));
            await dbContext.SaveChangesAsync();
        }

        public async Task<TeaTypeDTO> GetById(int id)
        {
            var teaType = await dbContext.TeaTypes.FirstOrDefaultAsync(opts => opts.Id == id);
            if (teaType == null)
            {
                throw new KeyNotFoundException($"TeaType with ID {id} was not found.");
            }
            return modelToDto(teaType);
        }

        public async Task<TeaTypeDTO> Edit(int id, TeaTypeDTO teaTypeDTO)
        {
            dbContext.Update(dtoToModel(teaTypeDTO));
            await dbContext.SaveChangesAsync();
            return teaTypeDTO;
        }

        public async Task Delete(int id)
        {
            var teaType = await dbContext.TeaTypes.FirstOrDefaultAsync(opts => opts.Id == id);
            if (teaType == null)
            { throw new KeyNotFoundException($"TeaType with ID {id} was not found."); }
            dbContext.TeaTypes.Remove(teaType);
            await dbContext.SaveChangesAsync();
        }

        private TeaTypeDTO modelToDto(TeaType teaType)
        {
            return new TeaTypeDTO()
            {
                Id = teaType.Id,
                Name = teaType.Name                
            };
        }
        private TeaType dtoToModel(TeaTypeDTO teaTypeDTO)
        {
            return new TeaType()
            {
                Id = teaTypeDTO.Id,
                Name = teaTypeDTO.Name                
            };
        }
    }
}
