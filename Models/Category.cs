using System.ComponentModel.DataAnnotations;

namespace VyTrongQuy_5405_Tuan2.Models
{
    public class Category
    {
        public int Id { get; set; }
        [Required, StringLength(50)]
        public string Name { get; set; }
    }
}
