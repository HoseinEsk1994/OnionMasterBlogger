using MB.Domain.ArticleCategoryAgg.Exceptions;
using System;

namespace MB.Domain.ArticleCategoryAgg.Sevices
{
    public class ArticleCategoryValidatorService : IArticleCategoryValidatorService
    {
        private readonly IArticleCategoryRepository _articleCategoryRepository;

        public ArticleCategoryValidatorService(IArticleCategoryRepository articleCategoryRepository)
        {
            _articleCategoryRepository = articleCategoryRepository;
        }

        public void CheckThatThisRecordAlreadyExists(string title)
        {
            if (_articleCategoryRepository.Exists(title))
            {
                throw new DuplicatedRecordException("This record already exists in database.");
            }
        }
    }
}
