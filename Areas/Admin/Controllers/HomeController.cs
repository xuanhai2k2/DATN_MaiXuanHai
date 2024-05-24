using Microsoft.AspNetCore.Mvc;
using BCrypt.Net;
using devpro_project.Areas.Admin.Attributes;
using devpro_project.Models;

namespace devpro_project.Areas.Admin.Controllers
{
    [Area("Admin")]
    [CheckLogin]
    public class HomeController : Controller
    {
        MyDbContext db = new MyDbContext();
        //phải đặt tag sau vào các controller của Area = Admin
        public IActionResult Index(double sum1=0, double sum2 = 0, double sum3 = 0, double sum4 = 0, double sum5 = 0, double sum6 = 0, double sum7 = 0, double sum8 = 0, double sum9 = 0, double sum10 = 0, double sum11 = 0, double sum12 = 0)
        {
            //string passwordHash = BCrypt.Net.BCrypt.HashPassword("123");
            //return Content(passwordHash);
            var query = from item_order in db.Orders join item_orderdetail in db.OrdersDetail on item_order.Id equals item_orderdetail.OrderId where item_order.Create.Month == 1 && item_order.Status == 1  select item_orderdetail;
            foreach (var item in query)
            {
                sum1 += item.Quantity+item.Price;
            }
            ViewBag.sum1 = sum1;
            var query2 = from item_order in db.Orders join item_orderdetail in db.OrdersDetail on item_order.Id equals item_orderdetail.OrderId where item_order.Create.Month == 2 && item_order.Status == 1 select item_orderdetail;
            foreach (var item in query2)
            {
                sum2 += item.Quantity + item.Price;
            }
            ViewBag.sum2 = sum2;
            var query3 = from item_order in db.Orders join item_orderdetail in db.OrdersDetail on item_order.Id equals item_orderdetail.OrderId where item_order.Create.Month == 3 && item_order.Status == 1 select item_orderdetail;
            foreach (var item in query3)
            {
                sum3 += item.Quantity + item.Price;
            }
            ViewBag.sum3 = sum3;
            var query4 = from item_order in db.Orders join item_orderdetail in db.OrdersDetail on item_order.Id equals item_orderdetail.OrderId where item_order.Create.Month == 4 && item_order.Status == 1 select item_orderdetail;
            foreach (var item in query4)
            {
                sum4 += item.Quantity + item.Price;
            }
            ViewBag.sum4 = sum4;
            var query5 = from item_order in db.Orders join item_orderdetail in db.OrdersDetail on item_order.Id equals item_orderdetail.OrderId where item_order.Create.Month == 5 && item_order.Status == 1 select item_orderdetail;
            foreach (var item in query5)
            {
                sum5 += item.Quantity + item.Price;
            }
            ViewBag.sum5 = sum5;
            var query6 = from item_order in db.Orders join item_orderdetail in db.OrdersDetail on item_order.Id equals item_orderdetail.OrderId where item_order.Create.Year == 2024 && item_order.Create.Month == 6 && item_order.Status == 1 select item_orderdetail;
            foreach (var item in query6)
            {
                sum6 += item.Quantity + item.Price;
            }
            ViewBag.sum6 = sum6;
            var query7 = from item_order in db.Orders join item_orderdetail in db.OrdersDetail on item_order.Id equals item_orderdetail.OrderId where item_order.Create.Year == 2024 && item_order.Create.Month == 7 && item_order.Status == 1 select item_orderdetail;
            foreach (var item in query)
            {
                sum7 += item.Quantity + item.Price;
            }
            ViewBag.sum7 = sum7;
            var query8 = from item_order in db.Orders join item_orderdetail in db.OrdersDetail on item_order.Id equals item_orderdetail.OrderId where item_order.Create.Year == 2024 && item_order.Create.Month == 8 && item_order.Status == 1 select item_orderdetail;
            foreach (var item in query8)
            {
                sum8 += item.Quantity + item.Price;
            }
            ViewBag.sum8 = sum8;
            var query9 = from item_order in db.Orders join item_orderdetail in db.OrdersDetail on item_order.Id equals item_orderdetail.OrderId where item_order.Create.Year == 2024 && item_order.Create.Month == 9 && item_order.Status == 1 select item_orderdetail;
            foreach (var item in query9)
            {
                sum9 += item.Quantity + item.Price;
            }
            ViewBag.sum9 = sum9;
            var query10 = from item_order in db.Orders join item_orderdetail in db.OrdersDetail on item_order.Id equals item_orderdetail.OrderId where item_order.Create.Year == 2024 && item_order.Create.Month == 10 && item_order.Status == 1 select item_orderdetail;
            foreach (var item in query10)
            {
                sum10 += item.Quantity + item.Price;
            }
            ViewBag.sum10 = sum10;
            var query11 = from item_order in db.Orders join item_orderdetail in db.OrdersDetail on item_order.Id equals item_orderdetail.OrderId where item_order.Create.Year == 2024 && item_order.Create.Month == 11 && item_order.Status == 1 select item_orderdetail;
            foreach (var item in query11)
            {
                sum11 += item.Quantity + item.Price;
            }
            ViewBag.sum11 = sum11;
            var query12 = from item_order in db.Orders join item_orderdetail in db.OrdersDetail on item_order.Id equals item_orderdetail.OrderId where item_order.Create.Year == 2024 && item_order.Create.Month == 12 && item_order.Status == 1 select item_orderdetail;
            foreach (var item in query12)
            {
                sum12 += item.Quantity + item.Price;
            }
            ViewBag.sum12 = sum12;
            return View();
        }
    }
}
