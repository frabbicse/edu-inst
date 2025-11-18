using Microsoft.EntityFrameworkCore;
using UserSegment.Data;
using UserSegment.Models;
using UserSegment.Services.Interface;

namespace UserSegment.Services.Implementation
{
    public class CourseService : ICourseService
    {
        private readonly AppDbContext _dbContext;
        private readonly ILogger<CourseService> _logger;

        public CourseService(AppDbContext dbContext, ILogger<CourseService> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public async Task<bool> DeleteCourse(int id)
        {
            try
            {
                var courseToDelete = await _dbContext.CourseEntryModels.FirstOrDefaultAsync(c => c.Id == id);
                //if (classToDelete != null)
                courseToDelete.CreateDate = DateTime.Now;
                courseToDelete.CreateBy = "system";
                courseToDelete.UpdateDate = DateTime.Now;
                courseToDelete.UpdateBy = "system";
                courseToDelete.IsDeleted = true;
                     _dbContext.CourseEntryModels.Update(courseToDelete); 
                var delete = await _dbContext.SaveChangesAsync();
                return delete > 0;

            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception in Class details operation {ex.Message}::{ex.StackTrace}");
                throw;
            }
        }

        public async Task<IList<CourseEntryModel>> GetCourse()
        {
            var classes = await _dbContext.CourseEntryModels.Where(t=>t.IsDeleted == false).ToListAsync();
            return classes;
        }

        public async Task<CourseEntryModel> GetCourseById(int id)
        {
            try
            {
                var classEntry = await _dbContext.CourseEntryModels.FirstOrDefaultAsync(c => c.Id == id);
                return classEntry; ;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception in Class details operation {ex.Message}::{ex.StackTrace}");
                throw;
            }
        }

        public async Task<bool> SaveCourse(CourseEntryModel courseEntry)
        {
            try
            {
                courseEntry.CreateDate = DateTime.Now;
                courseEntry.CreateBy = "system";
                courseEntry.UpdateDate = DateTime.Now;
                courseEntry.UpdateBy = "system";
                var result = _dbContext.CourseEntryModels.Add(courseEntry);
                var rs = await _dbContext.SaveChangesAsync();

                return rs > 0;
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Error saving class entry");
                throw;
            }
        }

        public async Task<bool> UpdateCourse(CourseEntryModel courseEntry)
        {
            try
            {
                courseEntry.CreateBy = "system";
                courseEntry.CreateDate = DateTime.Now;
                courseEntry.UpdateBy = "system";
                courseEntry.UpdateDate = DateTime.Now;
                _dbContext.Update(courseEntry);
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
