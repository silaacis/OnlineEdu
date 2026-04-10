using OnlineEdu.DataAccess.Abstract;
using OnlineEdu.DataAccess.Context;
using OnlineEdu.DataAccess.Repositories;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.DataAccess.Concrete
{
    public class CourseRepository : GenericRepository<Course>, ICourseRepository
    {
        public CourseRepository(OnlineEduContext context) : base(context)
        {
        }

        public void HideOnHome(int id)
        {
            var value = context.Courses.Find(id);
            value.IsShown = false;
            context.SaveChanges();
        }

        public void ShowOnHome(int id)
        {
            var value = context.Courses.Find(id);
            value.IsShown = true;
            context.SaveChanges();
        }
    }
}
