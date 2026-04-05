using FluentValidation;
using OnlineEdu.WebUI.DTOs.BlogCategoryDTOs;

namespace OnlineEdu.WebUI.Validators
{
    public class BlogCategoryValidator : AbstractValidator<CreateBlogCategoryDto>
    {
        public BlogCategoryValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Blog Kategori adı boş geçilemez.");
            RuleFor(x => x.Name).MaximumLength(30).WithMessage("Blog Kategori adı 30 karakterden uzun olamaz.");

        }
    }
}
