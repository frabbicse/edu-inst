using Microsoft.EntityFrameworkCore;
using UserSegment.Data;
using UserSegment.Models;
using UserSegment.Services.Interface;

namespace UserSegment.Services.Implementation
{
    public class TeacherService : ITeacherService
    {
        private readonly AppDbContext _dbContext;
        private readonly ILogger<TeacherService> _logger; 

        public TeacherService(AppDbContext dbContext, ILogger<TeacherService> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public async Task<bool> DeleteTeacher(int id)
        {
            try
            {
                var teacherToDelete = await _dbContext.TeacherEntryModels.FirstOrDefaultAsync(c => c.Id == id);
                //if (classToDelete != null)
                teacherToDelete.CreateDate = DateTime.Now;
                teacherToDelete.CreateBy = "system";
                teacherToDelete.UpdateDate = DateTime.Now;
                teacherToDelete.UpdateBy = "system";
                teacherToDelete.IsDeleted = true;
                     _dbContext.TeacherEntryModels.Update(teacherToDelete); 
                var delete = await _dbContext.SaveChangesAsync();
                return delete > 0;

            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception in Teacher details operation {ex.Message}::{ex.StackTrace}");
                throw;
            }
        }

        public async Task<IList<TeacherEntryModel>> GetTeachers()
        {
            var teachers = await _dbContext.TeacherEntryModels.Where(t=>t.IsDeleted == false).ToListAsync();
            return teachers;
        }

        public async Task<TeacherEntryModel> GetTeacherById(int id)
        {
            try
            {
                var teacherEntry = await _dbContext.TeacherEntryModels.FirstOrDefaultAsync(c => c.Id == id);
                return teacherEntry; ;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception in Teacher details operation {ex.Message}::{ex.StackTrace}");
                throw;
            }
        }

        public async Task<bool> SaveTeacher(TeacherEntryModel teacherEntry)
        {
            try
            {
                teacherEntry.CreateDate = DateTime.Now;
                teacherEntry.CreateBy = "system";
                teacherEntry.UpdateDate = DateTime.Now;
                teacherEntry.UpdateBy = "system";
                var result = _dbContext.TeacherEntryModels.Add(teacherEntry);
                var rs = await _dbContext.SaveChangesAsync();

                return rs > 0;
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Error saving Teacher entry");
                throw;
            }
        }

        public async Task<bool> UpdateTeacher(TeacherEntryModel teacherEntry)
        {
            try
            {
                teacherEntry.CreateBy = "system";
                teacherEntry.CreateDate = DateTime.Now;
                teacherEntry.UpdateBy = "system";
                teacherEntry.UpdateDate = DateTime.Now;
                _dbContext.Update(teacherEntry);
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
