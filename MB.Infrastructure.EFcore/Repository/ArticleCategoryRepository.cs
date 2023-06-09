﻿using MB.Domain.ArticleCategoryAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MB.Infrastructure.EFcore.Repository
{
    public class ArticleCategoryRepository : IArticleCategoryRepository
    {
        private readonly MasterBloggerContext _context;

        public ArticleCategoryRepository(MasterBloggerContext context)
        {
            _context = context;
        }

        public void Add(ArticleCategory entity)
        {
            _context.ArticleCategories.Add(entity);
            SaveChanges();
        }

        public bool Exists(string title)
        {
            return _context.ArticleCategories.Any(x => x.Title == title);
        }

        public ArticleCategory Get(long id)
        {
            return _context.ArticleCategories.FirstOrDefault(x => x.Id == id);
            
        }

        public List<ArticleCategory> GetAll()
        {
            return _context.ArticleCategories.OrderByDescending(x => x.Id).ToList();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
