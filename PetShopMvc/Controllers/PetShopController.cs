using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PetShop.Model;
using PetShop.BLL;
using PetShop.Web;
using PetShop.Web.ProcessFlow;
using PetShop.Web.WebComponents;

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
            CartItem bo = new CartItem();
            return View(bo.GetItemsByProduct(id));
        }

        public ActionResult ItemDetails(string id)
        {
            CartItem bo = new CartItem();
            return View(bo.GetItem(id));

        }

        public ActionResult Help()
        {
            return View();
        }

        public ActionResult SignIn()
        {
            return View(new AccountInfo());
        }

        public ActionResult ShoppingCart(string Id)
        {
            CartController cartController = new CartController();
            Cart myCart = cartController.GetCart(true);

            AccountController accountController = new AccountController();

            //Get the user's favourite category
            string favCategory = accountController.GetFavouriteCategory();

            //If we have a favourite category, render the favourites list
            ViewBag.Favourite = favCategory;

            if (Id != null)
            {
                // Clean the input string
                Id = CleanString.InputText(Id, 50);
                myCart.Add(Id);
                cartController.StoreCart(myCart);

            }

            return View(myCart);
        }
    }
}