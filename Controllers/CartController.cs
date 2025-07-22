using Microsoft.AspNetCore.Mvc;
using AlchemyAndAura.Models; 
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using System.Text.Json; 

namespace AlchemyAndAura.Controllers
{
    public class CartController : Controller
    {
        private const string CartSessionKey = "Cart";
        
        private List<CartItem> GetCart()
        {
            var cartJson = HttpContext.Session.GetString(CartSessionKey);
            if (string.IsNullOrEmpty(cartJson))
            {
                return new List<CartItem>();
            }
            // Você pode adicionar opções de serialização se precisar de mais controle
            return JsonSerializer.Deserialize<List<CartItem>>(cartJson); 
        }

        // Método para salvar o carrinho na sessão
        private void SaveCart(List<CartItem> cart)
        {
            HttpContext.Session.SetString(CartSessionKey, JsonSerializer.Serialize(cart));
        }

        // Exibe o conteúdo do carrinho
        public IActionResult Index()
        {
            var cart = GetCart();
            return View(cart);
        }

        // Adiciona um item ao carrinho
        [HttpPost]
        public IActionResult AddToCart(int potionId, int quantity = 1)
        {
            
            var potion = GetMockPotion(potionId); 
            
            if (potion == null)
            {
                return NotFound(); // Poção não encontrada
            }

            var cart = GetCart();
            var existingItem = cart.FirstOrDefault(item => item.Potion.Id == potionId);

            if (existingItem != null)
            {
                existingItem.Quantity += quantity;
            }
            else
            {
                cart.Add(new CartItem { Potion = potion, Quantity = quantity });
            }

            SaveCart(cart);
            return RedirectToAction("Index"); // Redireciona para a página do carrinho
        }

        // Remove um item do carrinho
        [HttpPost]
        public IActionResult RemoveFromCart(int potionId)
        {
            var cart = GetCart();
            var itemToRemove = cart.FirstOrDefault(item => item.Potion.Id == potionId);

            if (itemToRemove != null)
            {
                cart.Remove(itemToRemove);
                SaveCart(cart);
            }
            return RedirectToAction("Index");
        }
        
        // Exemplo de poção mockada para testes 
        private Potion GetMockPotion(int id)
        {
            
            return new List<Potion>
            {
                 new Potion { Id = 1, Name = "Healing Potion", Description = "Restores health.", Price = 10.00m, ImageUrl = "/images/healing_potion.png" },
                new Potion { Id = 2, Name = "Mana Potion", Description = "Restores mana.", Price = 12.50m, ImageUrl = "/images/mana_potion.png" },
                new Potion { Id = 3, Name = "Strength Potion", Description = "Increases strength temporarily.", Price = 15.00m, ImageUrl = "/images/strength_potion.png" },
                new Potion { Id = 4, Name = "Love Potion By Ellen", Description = "Potion of true love.", Price = 25.00m, ImageUrl = "/images/love_potion.png" },
                new Potion { Id = 5, Name = "Wisdom Potion", Description = "Grants temporary insight and knowledge.", Price = 30.00m, ImageUrl = "/images/wisdom_potion.png" },
                new Potion { Id = 6, Name = "Poison Vial", Description = "A deadly concoction. Use with caution!", Price = 50.00m, ImageUrl = "/images/poison_vial.png" },
                new Potion { Id = 7, Name = "Stink Bomb Potion", Description = "Emits a truly foul odor, useful for distractions.", Price = 8.00m, ImageUrl = "/images/stink_bomb_potion.png" },
                new Potion { Id = 8, Name = "Invisibility Potion", Description = "Renders the drinker completely unseen for a short duration.", Price = 75.00m, ImageUrl = "/images/invisibility_potion.png" },
                new Potion {Id = 9, Name = "Fire Resistance Potion", Description = "Resistance fire or a volcano.", Price = 80.25m, ImageUrl = "/images/fire_resistance_potion.png" },
                new Potion {Id = 10, Name = "Night Vision Potion", Description = "See through the darkness.", Price = 27.98m, ImageUrl = "/images/night_vision_potion.png" },
                new Potion {Id = 11, Name = "Gomu No Mi Potion", Description = "Stretch your bones by Pedrita.", Price = 27.98m, ImageUrl = "/images/gomu_no_mi_potion.jpeg" },
                new Potion {Id = 12, Name = "Froggy Brew Potion", Description = "Turn into a frog by Bela.", Price = 27.98m, ImageUrl = "/images/froggy_brew_potion.png" },
                new Potion {Id = 13, Name = "Jump Boost", Description = "Jump like a rabbit.", Price = 27.98m, ImageUrl = "/images/jump_boost_potion.png" },
                new Potion {Id = 14, Name = "Liritus Mindus", Description = "Read everyone's mind by Gotort.", Price = 27.98m, ImageUrl = "/images/liritus_mindus_potion.png" },
                new Potion { Id = 15,Name = "Teleport Potion", Description = "by Lívia", Price = 375.98m, ImageUrl = "/images/teleport_potion.png" }
               
                
            }.FirstOrDefault(p => p.Id == id);
        }
    }
}