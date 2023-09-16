using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services.Contracts;
using StoreApp.Infrastructure.Extensions;

namespace StoreApp.Pages
{
    public class CartModel : PageModel
    {
        private readonly IServiceManager _manager;
       
        public Cart Cart { get; set; } // IoC
        public string ReturnUrl { get; set; } = "/";

        public CartModel(IServiceManager manager, Cart cartService)
        {
            _manager = manager;
            Cart = cartService;
        }


        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
            //AddSingleton ile olusturulan Cart nesnesi, her request icin ayni nesneyi kullanir.
            //AddScoped ile olusturulan Cart nesnesi, her request icin farkli bir nesne olusturur.
            //AddScoped a gectikten sonra cartta surekli tek nesne olusturuluyordu, o hatanin onune gecmek icin
            // Cart = HttpContext.Session.GetJson<Cart>("Cart") ?? new Cart(); //cartServiceten sonra bu ifadeye gerek yok
        }

        public IActionResult OnPost(int productId, string returnUrl)
        {
            Product? product = _manager
                .ProductService
                .GetOneProduct(productId,false);

            if(product is not null)
            {
                //ilgili ifadeyi sessiona kaydetmis olduk.
                //sessioncart calistigi icin buna gerek yok artik
                // Cart = HttpContext.Session.GetJson<Cart>("Cart") ?? new Cart(); //GetJson deserialize islemi yapar.
                Cart.AddItem(product,1);
                //sessionCart calistigi icin buna da gerek yok artik
                // HttpContext.Session.SetJson("Cart",Cart);
            }
            return Page(); // returnUrl
        }

        public IActionResult OnPostRemove(int id, string returnUrl)
        {
            //sessionCart calistigi icin buna da gerek yok artik
            // Cart = HttpContext.Session.GetJson<Cart>("Cart") ?? new Cart();
            Cart.RemoveLine(Cart.Lines.First(cl => cl.Product.ProductId.Equals(id)).Product);
            // HttpContext.Session.SetJson("Cart",Cart); //sessionCart calistigi icin buna da gerek yok artik
            return Page(); 
        }
    }
}