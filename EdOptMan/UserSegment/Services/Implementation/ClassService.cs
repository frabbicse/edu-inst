using Microsoft.EntityFrameworkCore;
using UserSegment.Data;
using UserSegment.Models;
using UserSegment.Services.Interface;

namespace UserSegment.Services.Implementation
{
    public class ClassService : IClassService
    {
        private readonly AppDbContext _dbContext;
        private readonly ILogger<ClassService> _logger;

        public ClassService(AppDbContext dbContext, ILogger<ClassService> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public async Task<bool> DeleteClass(int id)
        {
            try
            {
                var classToDelete = await _dbContext.ClassEntryModels.FirstOrDefaultAsync(c => c.Id == id);
                //if (classToDelete != null)
                classToDelete.CreateDate = DateTime.Now;
                classToDelete.CreateBy = "system";
                classToDelete.UpdateDate = DateTime.Now;
                classToDelete.UpdateBy = "system";
                classToDelete.IsDeleted = true;
                     _dbContext.ClassEntryModels.Update(classToDelete); 
                var delete = await _dbContext.SaveChangesAsync();
                return delete > 0;

            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception in Class details operation {ex.Message}::{ex.StackTrace}");
                throw;
            }
        }

        public async Task<IList<ClassEntryModel>> GetClass()
        {
            var classes = await _dbContext.ClassEntryModels.Where(t=>t.IsDeleted == false).ToListAsync();
            return classes;
        }

        public async Task<ClassEntryModel> GetClassById(int id)
        {
            try
            {
                var classEntry = await _dbContext.ClassEntryModels.FirstOrDefaultAsync(c => c.Id == id);
                return classEntry; ;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception in Class details operation {ex.Message}::{ex.StackTrace}");
                throw;
            }
        }

        public async Task<bool> SaveClass(ClassEntryModel classEntry)
        {
            try
            {
                classEntry.CreateDate = DateTime.Now;
                classEntry.CreateBy = "system";
                classEntry.UpdateDate = DateTime.Now;
                classEntry.UpdateBy = "system";
                var result = _dbContext.ClassEntryModels.Add(classEntry);
                var rs = await _dbContext.SaveChangesAsync();

                return rs > 0;
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Error saving class entry");
                throw;
            }
        }

        public async Task<bool> UpdateClass(ClassEntryModel classEntry)
        {
            try
            {
                classEntry.CreateBy = "system";
                classEntry.CreateDate = DateTime.Now;
                classEntry.UpdateBy = "system";
                classEntry.UpdateDate = DateTime.Now;
                _dbContext.Update(classEntry);
                var update = await _dbContext.SaveChangesAsync();
                return await Task.FromResult(update > 0);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception in Update operation: {ex.Message}: {ex.StackTrace}");
                throw;
            }
        }
    }
}
