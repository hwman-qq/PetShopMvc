using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PetShop.Model;
using PetShop.BLL;

namespace PetShopMvc.Controllers
{
    public class PetShopController : Controller
    {
        // GET: PetShop
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Category(string id)
        {
            ProductBO productBO = new ProductBO();
            ViewBag.Category = id;
            return View(productBO.GetProductsByCategory(id));
        }

        public ActionResult Items(string id)
        {
            ItemBO bo = new ItemBO();
            return View(bo.GetItemsByProduct(id));
        }


    }
}