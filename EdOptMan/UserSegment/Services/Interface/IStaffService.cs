using UserSegment.Models;

namespace UserSegment.Services.Interface
{
    public interface IStaffService
    {
       Task<IList<StaffEntryModel>> GetStaffs();
        Task<bool> SaveStaff(StaffEntryModel staffEntry);
        Task<StaffEntryModel> GetStaffById (int id);
        Task<bool> UpdateStaff (StaffEntryModel staffEntry);
        Task<bool > DeleteStaff (int id);
    }
}
