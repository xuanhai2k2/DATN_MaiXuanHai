using Microsoft.AspNetCore.Mvc;
using devpro_project.Models;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Authorization;
using devpro_project.Service;

namespace devpro_project.Controllers
{
    public class CartController : Controller
    {
        MyDbContext db = new MyDbContext();
        private readonly IVnPayService _vnPayservice;

        //hiển thị danh sách các sản phẩm trong giỏ hàng
        public CartController(IVnPayService vnPayservice)
        {
            _vnPayservice = vnPayservice;
        }
        public IActionResult Index()
        {
            List<Item> shopping_cart = new List<Item>();
            string json_cart = HttpContext.Session.GetString("cart");
            if (!string.IsNullOrEmpty(json_cart))
            {
                shopping_cart = JsonConvert.DeserializeObject<List<Item>>(json_cart);
            }

            return View(shopping_cart);
        }
        //thêm sản phẩm vào giỏ hàng
        public IActionResult Buy(int id)
        {
            Cart.CartAdd(HttpContext.Session, id);
            return RedirectToAction("Index");
        }
        //xóa sản phẩm khỏi giỏ hàng
        public IActionResult Remove(int id)
        {
            Cart.CartRemove(HttpContext.Session, id);
            return RedirectToAction("Index");
        }
        //update gio hang
        public IActionResult Update()
        {
            List<Item> shopping_cart = new List<Item>();
            string json_cart = HttpContext.Session.GetString("cart");
            if (!string.IsNullOrEmpty(json_cart))
            {
                shopping_cart = JsonConvert.DeserializeObject<List<Item>>(json_cart);
            }
            foreach (Item cart_item in shopping_cart)
            {
                int new_quantity = Convert.ToInt32(Request.Form["product_" + cart_item.ProductRecord.Id]);
                //goị hàm cập nhật số lượng sản phẩm
                Cart.CartUpdate(HttpContext.Session, cart_item.ProductRecord.Id, new_quantity);
            }
            return RedirectToAction("Index");
        }
        //Xóa toàn bộ sản phẩm trong giỏ hàng
        public IActionResult Destroy()
        {
            Cart.CartDestroy(HttpContext.Session);
            return Redirect("/Cart/Index/?notify=destroy-success");
        }
        //thanh toán giỏ hàng

        public IActionResult CheckOut()
        {
            //nếu user chưa đang nhập di chuyển đến url đăng nhập
            if (String.IsNullOrEmpty(HttpContext.Session.GetString("customer-id")))
            {
                return Redirect("/Account/Login");
            }
            else
            {
                var product = db.Products.OrderByDescending(item => item.Id).ToList();
                List<Item> shopping_cart = new List<Item>();
                string json_cart = HttpContext.Session.GetString("cart");
                if (!string.IsNullOrEmpty(json_cart))
                {
                    shopping_cart = JsonConvert.DeserializeObject<List<Item>>(json_cart);
                }
                foreach (Item cart_item in shopping_cart)
                {
                    foreach (var item in product)
                    {
                        if (item.Id == cart_item.ProductRecord.Id)
                        {
                            item.Quantity = cart_item.ProductRecord.Quantity - cart_item.Quantity;
                            db.Update(item);
                            db.SaveChanges();
                        }

                    }

                }
                //laays id customer
                int customer_id = Convert.ToInt32(HttpContext.Session.GetString("customer-id"));
                Cart.CartCheckOut(HttpContext.Session, customer_id);
            }



            return Redirect("/Cart/Index/?notify=checkout-success");
        }
        public IActionResult CheckOutVnPay()
        {
            var vnPaymodel = new VnPaymentRequestModel
            {
                Amount = 10000000,
                CreatedDate = DateTime.Now,
                FullName = "Nguyen Van A",
                OrderId = new Random().Next(1000, 10000)
            };
            return Redirect(_vnPayservice.CreatePaymentUrl(HttpContext, vnPaymodel));
        }
        [Authorize]
        public IActionResult PaymentCallBack()
        {
            return View();
        }
    }
}
