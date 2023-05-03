using MB.Domain.ArticleAgg;
using MB.Domain.ArticleCategoryAgg.Sevices;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;

namespace MB.Domain.ArticleCategoryAgg
{
    public class ArticleCategory
    {
        public long Id { get; private set; }

        public string Title  { get; private set; }

        public bool IsDeleted { get; private set; }

        public DateTime CreationDate { get; private set; }

        public ICollection<Article> Articles { get; private set; }

        protected ArticleCategory()
        {
            
        }


        public ArticleCategory(string title, IArticleCategoryValidatorService validatorService)
        {
            GaurdAgaintEmptyTitle(title);
            validatorService.CheckThatThisRecordAlreadyExists(title);
            Title = title;
            IsDeleted = false;
            CreationDate = DateTime.Now;
            Articles = new List<Article>();
        }



        public void Rename(string title)
        {
            GaurdAgaintEmptyTitle(title);
            Title = title;
        }

        public void Remove()
        {
            IsDeleted= true;
        }

        public void Activate()
        {
            IsDeleted = false;
        }

        private static void GaurdAgaintEmptyTitle(string title)
        {
            if (string.IsNullOrEmpty(title))
                throw new ArgumentNullException();
        }
    }


}
