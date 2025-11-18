using Microsoft.EntityFrameworkCore;
using UserSegment.Data;
using UserSegment.Models;
using UserSegment.Services.Interface;

namespace UserSegment.Services.Implementation
{
    public class RoomService : IRoomService
    {
        private readonly AppDbContext _dbContext;
        private readonly ILogger<RoomService> _logger;

        public RoomService(AppDbContext dbContext, ILogger<RoomService> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public async Task<bool> DeleteRoom(int id)
        {
            try
            {
                var roomToDelete = await _dbContext.RoomEntryModels.FirstOrDefaultAsync(c => c.Id == id);
                //if (classToDelete != null)
                roomToDelete.CreateDate = DateTime.Now;
                roomToDelete.CreateBy = "system";
                roomToDelete.UpdateDate = DateTime.Now;
                roomToDelete.UpdateBy = "system";
                roomToDelete.IsDeleted = true;
                     _dbContext.RoomEntryModels.Update(roomToDelete); 
                var delete = await _dbContext.SaveChangesAsync();
                return delete > 0;

            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception in room details operation {ex.Message}::{ex.StackTrace}");
                throw;
            }
        }

        public async Task<IList<RoomEntryModel>> GetRooms()
        {
            var rooms = await _dbContext.RoomEntryModels.Where(t=>t.IsDeleted == false).ToListAsync();
            return rooms;
        }

        public async Task<RoomEntryModel> GetRoomById(int id)
        {
            try
            {
                var roomEntry = await _dbContext.RoomEntryModels.FirstOrDefaultAsync(c => c.Id == id);
                return roomEntry; ;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception in room details operation {ex.Message}::{ex.StackTrace}");
                throw;
            }
        }

        public async Task<bool> SaveRoom(RoomEntryModel roomEntry)
        {
            try
            {
                roomEntry.CreateDate = DateTime.Now;
                roomEntry.CreateBy = "system";
                roomEntry.UpdateDate = DateTime.Now;
                roomEntry.UpdateBy = "system";
                var result = _dbContext.RoomEntryModels.Add(roomEntry);
                var rs = await _dbContext.SaveChangesAsync();

                return rs > 0;
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Error saving Room entry");
                throw;
            }
        }

        public async Task<bool> UpdateRoom(RoomEntryModel roomEntry)
        {
            try
            {
                roomEntry.CreateBy = "system";
                roomEntry.CreateDate = DateTime.Now;
                roomEntry.UpdateBy = "system";
                roomEntry.UpdateDate = DateTime.Now;
                _dbContext.Update(roomEntry);
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
