using System.ComponentModel.DataAnnotations;

namespace Hastanevs.Models
{
    public class Bolum
    {
        [Key] // primary keydir
        public int id { get; set; }
        [Required] //null olamaz
        public string BolumAdi { get; set; }

    }
}
