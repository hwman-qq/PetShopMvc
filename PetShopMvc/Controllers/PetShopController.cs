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
        private const string ACTION_CREATE = "create";
        private const string ACTION_UPDATE = "update";
        private const string ACTION_SIGN_IN = "signIn";
        private const string TITLE_CREATE = "Create Account";
        private const string TITLE_UPDATE = "Edit Account";
        private const string TITLE_SIGN_IN = "Sign In";
        private const string MSG_CREATE = "Your account was successfully created.";
        private const string MSG_UPDATE = "Your account was successfully updated.";
        private const string MSG_SIGN_IN = "Welcome to the .NET Pet Shop Demo.";

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

        [HttpPost]
        public ActionResult SignIn(string UserId, string Password)
        {
            AccountController accountController = new AccountController();

            if (!accountController.ProcessLogin(UserId, Password))
            {

                // If we fail to login let the user know
                return new HttpNotFoundResult();
            }

            return Redirect("/PetShop/Index");
        }

        public ActionResult SignOut()
        {
            return View();
        }

        public ActionResult CreateAccount()
        {
            AccountInfo account = new AccountInfo();
            return View(account);
        }

        public ActionResult MyAccount(string Action)
        {
            switch (Action)
            {
                case ACTION_CREATE:
                    ViewBag.Message = MSG_CREATE;
                    break;

                case ACTION_UPDATE:
                    ViewBag.Message = MSG_UPDATE;
                    break;

                case ACTION_SIGN_IN:
                    ViewBag.Message = MSG_SIGN_IN;
                    break;
            }
            return View();
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

        [HttpPost]
        public ActionResult ShoppingCart()
        {
            return View();
        }

        public ActionResult Checkout()
        {
            CartController cartController = new CartController();

            return View(cartController.GetCart(false));
        }
    }
}