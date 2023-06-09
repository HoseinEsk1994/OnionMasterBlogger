﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MB.Domain.ArticleCategoryAgg
{
    public interface IArticleCategoryRepository
    {

        List<ArticleCategory> GetAll();

        ArticleCategory Get(long id);

        void Add(ArticleCategory entity);

        bool Exists(string title);


        void SaveChanges();
    }
}
