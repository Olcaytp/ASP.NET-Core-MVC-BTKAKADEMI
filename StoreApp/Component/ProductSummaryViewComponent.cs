using Microsoft.AspNetCore.Mvc;
using Repositories;
using Services.Contracts;

namespace StoreApp.Components
{
    public class ProductSummaryViewComponent : ViewComponent
    {
       /**
        private readonly RepositoryContext _context; //! This is a bad practice, but it's just for the example

        public ProductSummary(RepositoryContext context)
        {
            _context = context;
        }
        */

        private readonly IServiceManager _manager;

        public ProductSummaryViewComponent(IServiceManager manager)
        {
            _manager = manager;
        }

        public string Invoke()
        {
            return _manager.ProductService.GetAllProducts(false).Count().ToString();
            // return _context.Products.Count().ToString(); //! This is a bad practice, but it's just for the example
        }
    }
}