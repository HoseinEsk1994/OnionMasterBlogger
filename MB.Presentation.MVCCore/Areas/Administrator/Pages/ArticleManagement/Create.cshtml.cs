using MB.Application.Contracts.Article;
using MB.Application.Contracts.ArticleCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace MB.Presentation.MVCCore.Areas.Administrator.Pages.ArticleManagement
{
    public class CreateModel : PageModel
    {
        public List<SelectListItem> ArticleCategories;
        public readonly IArticleCategoryApplication _articleCategoryApplication;

        public CreateArticle Article { get; set; }

        public IArticleApplication _articleApplication;

        public CreateModel(IArticleApplication articleApplication, IArticleCategoryApplication articleCategoryApplication)
        {
            _articleApplication = articleApplication;
            _articleCategoryApplication = articleCategoryApplication;
        }

        public void OnGet()
        {
            ArticleCategories = _articleApplication.GetList().Select(x => new SelectListItem
                                                            (text: x.Title, value: x.Id.ToString())).ToList();
        }

        public RedirectToPageResult OnPost(CreateArticle command) 
        {
            _articleApplication.Create(command);
            return RedirectToPage("./List");

        }
    }
}
