using OnlineEdu.Entity.Entities;

namespace OnlineEdu.DataAccess.Abstract
{
    public interface ICourseRepository : IRepository<Course>
    {
        void ShowOnHome(int id);
        void HideOnHome(int id);
    }
}
