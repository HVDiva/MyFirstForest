using Forest.Data;
using Forest.Models;
using Forest.Services.IService;
using Forest.Services.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Forest.Controllers
{
    public class CartController : Controller
    {
        public List<CartMusic> cart;
        private Forest.Services.IService.IMusicService _musicService;
        public ActionResult IncreaseQuantity(int id)
        {
            //declare and get the cart object
            var cart = (List<CartMusic>)Session["cart"];
            //declare the carItem and create it by finding the object in cart
            CartMusic cartItem = cart.Find(obj => obj.ID == id);
            //remove the cartItem from the cart
            cart.Remove(cartItem);
            //increase the quantity property of cartItem
            cartItem.Quantity += 1;
            //add the cartitem to cart
            cart.Add(cartItem);
            //overwrite the cart in the session
            Session["cart"] = cart;
            //redirect to displaycart action
            return RedirectToAction("DisplayCart");
        }
        public ActionResult DecreaseQuantity(int id)
        {
            //declare and get the cart object
            var cart = (List<CartMusic>)Session["cart"];
            //declare the carItem and create it by finding the object in cart
            CartMusic cartItem = cart.Find(obj => obj.ID == id);
            //remove the cartItem from the cart
            cart.Remove(cartItem);
            //increase the quantity property of cartItem
            cartItem.Quantity -= 1;
            if (cartItem.Quantity == 0)
            {
                Session["cart"] = cart;
                //redirect to displaycart action
                return RedirectToAction("DisplayCart");
            }
            else {
                //add the cartitem to cart
                cart.Add(cartItem);
                //overwrite the cart in the session
                Session["cart"] = cart;
                //redirect to displaycart action
                return RedirectToAction("DisplayCart");
            }
            
        }
        public ActionResult RemoveFromCart(int id)
        {
            var cart = (List<CartMusic>)Session["cart"];
            CartMusic cartItem = cart.Find(obj => obj.ID == id);
            cart.Remove(cartItem);
            //overwrite the cart in the session
            Session["cart"] = cart;
            //redirect to DisplayCart action
            return RedirectToAction("DisplayCart");
            
            
        }

        public ActionResult DisplayCart()
        {
            //get cart from session
            var cart = (List<CartMusic>)Session["cart"];
            //return cart view
            
            if (cart.Count == 0)
            {
                return RedirectToAction("GetGenres", new { Controller = "Genre" });
            }
            else
            {
                return View(cart);
            }
        }
        public ActionResult AddToCart(int id)
        {
            CartMusic cartItem = new CartMusic();
            _musicService = new MusicService();
            Music music = _musicService.GetMusic(id);
            cartItem.Quantity = 1;
            cartItem.ID = music.ID;
            cartItem.Title = music.Title;
            cartItem.num_track = music.num_track;
            cartItem.duration = music.duration;
            cartItem.DateReleased = music.DateReleased;
            cartItem.Price = music.Price;
            cartItem.Artist_ID = music.Artist_ID;
            cartItem.Genre_ID = music.Genre_ID;
            cartItem.User_ID = music.User_ID;
            if (Session["cart"] == null)
            {
                cart = new List<CartMusic>();
                cart.Add(cartItem);
                Session["cart"] = cart;
            }
            else
            {
                var cart = (List<CartMusic>)Session["cart"];
                cart.Add(cartItem);
                Session["cart"] = cart;
            }
            return RedirectToAction("DisplayCart");
        }
        // GET: Cart
        public ActionResult Index()
        {
            return View();
        }

        // GET: Cart/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Cart/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cart/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Cart/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Cart/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Cart/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Cart/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
