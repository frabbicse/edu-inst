using Microsoft.EntityFrameworkCore;
using UserSegment.Data;
using UserSegment.Models;
using UserSegment.Services.Interface;

namespace UserSegment.Services.Implementation
{
    public class StudentService : IStudentService
    {
        private readonly AppDbContext _dbContext;
        private readonly ILogger<StudentService> _logger; 

        public StudentService(AppDbContext dbContext, ILogger<StudentService> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public async Task<bool> DeleteStudent(int id)
        {
            try
            {
                var studentToDelete = await _dbContext.StudentEntryModels.FirstOrDefaultAsync(c => c.Id == id);
                //if (classToDelete != null)
                studentToDelete.CreateDate = DateTime.Now;
                studentToDelete.CreateBy = "system";
                studentToDelete.UpdateDate = DateTime.Now;
                studentToDelete.UpdateBy = "system";
                studentToDelete.IsDeleted = true;
                     _dbContext.StudentEntryModels.Update(studentToDelete); 
                var delete = await _dbContext.SaveChangesAsync();
                return delete > 0;

            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception in student details operation {ex.Message}::{ex.StackTrace}");
                throw;
            }
        }

        public async Task<IList<StudentEntryModel>> GetStudents()
        {
            var students = await _dbContext.StudentEntryModels.Where(t=>t.IsDeleted == false).ToListAsync();
            return students;
        }

        public async Task<StudentEntryModel> GetStudentById(int id)
        {
            try
            {
                var studentEntry = await _dbContext.StudentEntryModels.FirstOrDefaultAsync(c => c.Id == id);
                return studentEntry; ;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception in student details operation {ex.Message}::{ex.StackTrace}");
                throw;
            }
        }

        public async Task<bool> SaveStudent(StudentEntryModel studentEntry)
        {
            try
            {
                studentEntry.CreateDate = DateTime.Now;
                studentEntry.CreateBy = "system";
                studentEntry.UpdateDate = DateTime.Now;
                studentEntry.UpdateBy = "system";
                var result = _dbContext.StudentEntryModels.Add(studentEntry);
                var rs = await _dbContext.SaveChangesAsync();

                return rs > 0;
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Error saving student entry");
                throw;
            }
        }

        public async Task<bool> UpdateStudent(StudentEntryModel studentEntry)
        {
            try
            {
                studentEntry.CreateBy = "system";
                studentEntry.CreateDate = DateTime.Now;
                studentEntry.UpdateBy = "system";
                studentEntry.UpdateDate = DateTime.Now;
                _dbContext.Update(studentEntry);
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
