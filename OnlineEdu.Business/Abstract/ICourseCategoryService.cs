using OnlineEdu.Entity.Entities;

namespace OnlineEdu.Business.Abstract
{
    public interface ICourseCategoryService : IGenericService<CourseCategory>
    {
        void TShowOnHome(int id);
        void THideOnHome(int id);
    }
}
