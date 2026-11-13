using System.ComponentModel.DataAnnotations;

namespace WebApplication3.Models
{
    public class Personel
    {
        [Key]
        [Required(ErrorMessage ="Bu Alan Boş Bırakılamaz...")]
        public int Id { get; set; }
        [Required(ErrorMessage = "Bu Alan Boş Bırakılamaz...")]
        public string Ad { get; set; } = string.Empty;
        [Required(ErrorMessage = "Bu Alan Boş Bırakılamaz...")]
        public string Soyad { get; set; } = string.Empty;
        [Required(ErrorMessage = "Bu Alan Boş Bırakılamaz...")]
        public string Departman { get; set; } = string.Empty;
        [Required(ErrorMessage = "Bu Alan Boş Bırakılamaz...")]
        public decimal ? Maas { get; set; }
    }
}
