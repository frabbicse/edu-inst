using Microsoft.EntityFrameworkCore;
using UserSegment.Data;
using UserSegment.Models;
using UserSegment.Services.Interface;

namespace UserSegment.Services.Implementation
{
    public class StaffService : IStaffService
    {
        private readonly AppDbContext _dbContext;
        private readonly ILogger<StaffService> _logger;

        public StaffService(AppDbContext dbContext, ILogger<StaffService> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public async Task<bool> DeleteStaff(int id)
        {
            try
            {
                var staffToDelete = await _dbContext.StaffEntryModels.FirstOrDefaultAsync(c => c.Id == id);
                //if (classToDelete != null)
                staffToDelete.CreateDate = DateTime.Now;
                staffToDelete.CreateBy = "system";
                staffToDelete.UpdateDate = DateTime.Now;
                staffToDelete.UpdateBy = "system";
                staffToDelete.IsDeleted = true;
                     _dbContext.StaffEntryModels.Update(staffToDelete); 
                var delete = await _dbContext.SaveChangesAsync();
                return delete > 0;

            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception in Class details operation {ex.Message}::{ex.StackTrace}");
                throw;
            }
        }

        public async Task<IList<StaffEntryModel>> GetStaffs()
        {
            var staffs = await _dbContext.StaffEntryModels.Where(t=>t.IsDeleted == false).ToListAsync();
            return staffs;
        }

        public async Task<StaffEntryModel> GetStaffById(int id)
        {
            try
            {
                var staffEntry = await _dbContext.StaffEntryModels.FirstOrDefaultAsync(c => c.Id == id);
                return staffEntry; ;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception in Class details operation {ex.Message}::{ex.StackTrace}");
                throw;
            }
        }

        public async Task<bool> SaveStaff(StaffEntryModel staffEntry)
        {
            try
            {
                staffEntry.CreateDate = DateTime.Now;
                staffEntry.CreateBy = "system";
                staffEntry.UpdateDate = DateTime.Now;
                staffEntry.UpdateBy = "system";
                var result = _dbContext.StaffEntryModels.Add(staffEntry);
                var rs = await _dbContext.SaveChangesAsync();

                return rs > 0;
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Error saving class entry");
                throw;
            }
        }

        public async Task<bool> UpdateStaff(StaffEntryModel staffEntry)
        {
            try
            {
                staffEntry.CreateBy = "system";
                staffEntry.CreateDate = DateTime.Now;
                staffEntry.UpdateBy = "system";
                staffEntry.UpdateDate = DateTime.Now;
                _dbContext.Update(staffEntry);
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
