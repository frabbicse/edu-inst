namespace UserSegment.Models
{
    public class HomeModel
    {
        // Current User
        public string CurrentUser { get; set; } = string.Empty;

        // Students
        public int TotalStudents { get; set; } = 0;
        public int NewStudentsThisMonth { get; set; } = 0;
        // Teachers
        public int TotalTeachers { get; set; }
        public int NewTeachersThisMonth { get; set; } = 0;

        // Courses
        public int TotalCourses { get; set; } = 0;
        public double ActiveCoursesPercentage { get; set; } = 0;// e.g., 75.5

        // Staff
        public int TotalStaff { get; set; } = 0;
        public int DepartmentsCount { get; set; } = 0;
    }
}
