using Application.CartItems;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;

namespace Infrastructure.Services
{
    public sealed class CartService : ICartItemsService
    {
        private ApplicationDbContext _context;

        public CartService(ApplicationDbContext context)
        {
            _context = context;

        }


        public CartItem AddCartLineItems(LineItem lineItem, int CartId)
        {
            CartItem cartItem = null;

            cartItem = _context.CartItems.Include(l => l.Products).FirstOrDefault(i => i.Id == CartId);
            if (cartItem == null)
                cartItem = addnewitem(CartId);
            if (cartItem.OrderStatus == "Confirmed")
                cartItem = addnewitem(CartId);

            CartId = cartItem.Id;


            if (cartItem.Products.Any(i => i.Id == lineItem.Id))
            {
                var needtoupdate = _context.LineItems.FirstOrDefault(i => i.Id == lineItem.Id && i.CartId == cartItem.Id);
                needtoupdate.quantity += 1;
                _context.Entry(needtoupdate).State = EntityState.Modified;
                _context.SaveChanges();
            }
            else
            {
                lineItem.quantity = 1;
                lineItem.CartId = cartItem.Id;
                _context.LineItems.Add(lineItem);

                _context.SaveChanges();
            }
            cartItem = _context.CartItems.Include(l => l.Products).FirstOrDefault(i => i.Id == CartId);
            return cartItem;
        }

        private CartItem addnewitem(int CartId)
        {
            CartItem cartItem = new CartItem { Products = new List<LineItem>() };
            cartItem.OrderStatus = "Addedtocart";
            _context.CartItems.Add(cartItem);
            _context.SaveChanges();
            return cartItem;
        }

        public CartItem CheckOut(int CartId)
        {

            var cartItem = GetCartItems(CartId);
            cartItem.OrderStatus = "Confirmed";
            _context.SaveChanges();
            using (var httpClient = new HttpClient())
            {
                var item = new
                {
                    orderStatus = cartItem.OrderStatus,
                    totalPrice = cartItem.TotalAmount,
                    products = cartItem.Products.Select(o => new
                    {
                        Id = o.Id,
                        title = o.title,
                        price = o.price,
                        quantity = o.quantity
                    }).ToList()
                };
                var content = new StringContent(JsonConvert.SerializeObject(item), Encoding.UTF8, "application/json");
                var result = httpClient.PostAsync("https://ordercart.requestcatcher.com/test", content).Result;
            }
            return cartItem;

        }

        public CartItem GetCartItems(int CartId)
        {
            return _context.CartItems.Include(i => i.Products).FirstOrDefault(_i => _i.Id == CartId);
        }

        public CartItem RemoveCartLineItems(int CartId, int ProductId)
        {
            throw new NotImplementedException();
        }
    }
}
