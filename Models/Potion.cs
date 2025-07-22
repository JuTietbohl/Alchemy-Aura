// Models/Potion.cs
namespace AlchemyAndAura.Models
{
    public class Potion
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; } // Para a imagem da poção
    }
}