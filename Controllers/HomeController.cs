using Microsoft.AspNetCore.Mvc;
using AlchemyAndAura.Models; 
using System.Collections.Generic;
using System.Diagnostics;
using WebApplication1.Models;

namespace AlchemyAndAura.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            //lista de poções 
            var potions = new List<Potion>
            {
                new Potion { Id = 1, Name = "Healing Potion", Description = "Restores health.", Price = 10.00m, ImageUrl = "/images/healing_potion.png" },
                new Potion { Id = 2, Name = "Mana Potion", Description = "Restores mana.", Price = 12.50m, ImageUrl = "/images/mana_potion.png" },
                new Potion { Id = 3, Name = "Strength Potion", Description = "Increases strength temporarily.", Price = 15.00m, ImageUrl = "/images/strength_potion.png" },
                new Potion { Id = 4, Name = "Love Potion By Ellen", Description = "Potion of true love.", Price = 25.00m, ImageUrl = "/images/love_potion.png" },
                new Potion { Id = 5, Name = "Wisdom Potion", Description = "Grants temporary insight and knowledge.", Price = 30.00m, ImageUrl = "/images/wisdom_potion.png" },
                new Potion { Id = 6, Name = "Poison Vial", Description = "A deadly concoction. Use with caution!", Price = 50.00m, ImageUrl = "/images/poison_vial.png" },
                new Potion { Id = 7, Name = "Stink Bomb Potion", Description = "Emits a truly foul odor, useful for distractions.", Price = 8.00m, ImageUrl = "/images/stink_bomb_potion.png" },
                new Potion { Id = 8, Name = "Invisibility Potion", Description = "Renders the drinker completely unseen by Julia.", Price = 75.00m, ImageUrl = "/images/invisibility_potion.png" },
                new Potion { Id = 9, Name = "Fire Resistance Potion", Description = "Resistance fire or a volcano.", Price = 80.25m, ImageUrl = "/images/fire_resistance_potion.png" },
                new Potion { Id = 10,Name = "Night Vision Potion", Description = "See through the darkness.", Price = 18.65m, ImageUrl = "/images/night_vision_potion.png" },
                new Potion { Id = 11,Name = "Gomu No Mi Potion", Description = "Stretch your bones.", Price = 102.00m, ImageUrl = "/images/gomu_no_mi_potion.jpeg" },
                new Potion { Id = 12,Name = "Froggy Brew Potion", Description = "Turn into a frog by Bela.", Price = 27.98m, ImageUrl = "/images/froggy_brew_potion.png" },
                new Potion { Id = 13,Name = "Jump Boost", Description = "Jump like a rabbit.", Price = 23.48m, ImageUrl = "/images/jump_boost_potion.png" },
                new Potion { Id = 14,Name = "Liritus Mindus", Description = "Read everyone's mind by Gotort.", Price = 174.75m, ImageUrl = "/images/liritus_mindus_potion.png" }
                // tp by Lívia
            };
            return View(potions);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}