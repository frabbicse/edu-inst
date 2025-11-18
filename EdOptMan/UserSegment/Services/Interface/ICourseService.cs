using UserSegment.Models;

namespace UserSegment.Services.Interface
{
    public interface ICourseService
    {
       Task<IList<CourseEntryModel>> GetCourse();
        Task<bool> SaveCourse(CourseEntryModel courseEntry);
        Task<CourseEntryModel> GetCourseById(int id);
        Task<bool> UpdateCourse(CourseEntryModel courseEntry);
        Task<bool > DeleteCourse(int id);
    }
}
