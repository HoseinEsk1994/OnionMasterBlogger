using MB.Application.Contracts.ArticleCategory;
using MB.Domain.ArticleCategoryAgg;
using MB.Domain.ArticleCategoryAgg.Sevices;
using MB.Infrastructure.EFcore.Repository;
using System.Collections.Generic;
using System.Globalization;

namespace MB.Application
{
    public class ArticleCategoryApplication : IArticleCategoryApplication
    {
        private readonly ArticleCategoryRepository articleCategoryRepository;
        private readonly IArticleCategoryValidatorService _articleCategoryValidatorService;

        public ArticleCategoryApplication(ArticleCategoryRepository articleCategoryRepository, IArticleCategoryValidatorService articleCategoryValidatorService)
        {
            articleCategoryRepository = articleCategoryRepository;
            _articleCategoryValidatorService = articleCategoryValidatorService;
        }

        public void Activate(long id)
        {
            var articleCategory = articleCategoryRepository.Get(id);
            articleCategory.Activate();
            articleCategoryRepository.SaveChanges();
        }

        public void Create(CreateArticleCategory command)
        {
            ArticleCategory articleCategory = new ArticleCategory(command.Title, _articleCategoryValidatorService);
            articleCategoryRepository.Add(articleCategory);
        }

        public void Edit(RenameArticleCategory command)
        {
            var result = articleCategoryRepository.Get(command.Id);
            if (result != null) {
                result.Rename(command.Title);
            }
            //result?.Rename(command.Title);
            articleCategoryRepository.SaveChanges();
        }

        public RenameArticleCategory Get(long id)
        {
            var articleCategory = articleCategoryRepository.Get(id);
            return new RenameArticleCategory
            {
                Id = articleCategory.Id,
                Title = articleCategory.Title,
            };
        }

        public List<ArticleCategoryViewModel> List()
        {
            var articleCategories = articleCategoryRepository.GetAll();
            var result = new List<ArticleCategoryViewModel>();
            foreach (var articleCategory in articleCategories)
            {
                result.Add(new ArticleCategoryViewModel
                {
                    Title = articleCategory.Title,
                    Id = articleCategory.Id,
                    IsDeleted = articleCategory.IsDeleted,
                    CreationDate = articleCategory.CreationDate.ToString(CultureInfo.InvariantCulture)
                });
            }
            return result;
        }

        public void Remove(long id)
        {
            var articleCategory = articleCategoryRepository.Get(id);
            articleCategory.Remove();
            articleCategoryRepository.SaveChanges();
        }
    }
}
