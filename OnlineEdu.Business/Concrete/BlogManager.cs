using OnlineEdu.Business.Abstract;
using OnlineEdu.DataAccess.Abstract;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.Business.Concrete
{
    public class BlogManager : GenericManager<Blog>, IBlogService
    {
        private readonly IBlogRepository blogRepository;
        public BlogManager(IRepository<Blog> repository, IBlogRepository blogRepository) : base(repository)
        {
            this.blogRepository = blogRepository;
        }

        public List<Blog> TGetBlogsWithCategories()
        {
            return blogRepository.GetBlogsWithCategories();
        }
    }
}
