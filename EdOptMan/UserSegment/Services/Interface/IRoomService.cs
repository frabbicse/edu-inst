using UserSegment.Models;

namespace UserSegment.Services.Interface
{
    public interface IRoomService
    {
       Task<IList<RoomEntryModel>> GetRooms();
        Task<bool> SaveRoom (RoomEntryModel roomEntry);
        Task<RoomEntryModel> GetRoomById (int id);
        Task<bool> UpdateRoom (RoomEntryModel classEntry);
        Task<bool > DeleteRoom (int id);
    }
}
