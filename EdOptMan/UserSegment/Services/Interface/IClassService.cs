using UserSegment.Models;

namespace UserSegment.Services.Interface
{
    public interface IClassService
    {
       Task<IList<ClassEntryModel>> GetClass();
        Task<bool> SaveClass (ClassEntryModel classEntry);
        Task<ClassEntryModel> GetClassById (int id);
        Task<bool> UpdateClass (ClassEntryModel classEntry);
        Task<bool > DeleteClass (int id);
    }
}
