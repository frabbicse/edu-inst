using UserSegment.Models;

namespace UserSegment.Services.Interface
{
    public interface ITeacherService
    {
        Task<IList<TeacherEntryModel>> GetTeachers();
        Task<bool> SaveTeacher(TeacherEntryModel TeacherEntry);
        Task<TeacherEntryModel> GetTeacherById(int id);
        Task<bool> UpdateTeacher(TeacherEntryModel TeacherEntry);
        Task<bool> DeleteTeacher(int id);
    }
}
