using UserSegment.Models;

namespace UserSegment.Services.Interface
{
    public interface IStudentService
    {
        Task<IList<StudentEntryModel>> GetStudents();
        Task<bool> SaveStudent(StudentEntryModel studentEntry);
        Task<StudentEntryModel> GetStudentById(int id);
        Task<bool> UpdateStudent(StudentEntryModel studentEntry);
        Task<bool> DeleteStudent(int id);
    }
}
