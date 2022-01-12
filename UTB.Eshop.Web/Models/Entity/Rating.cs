using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UTB.Eshop.Web.Models.Identity;

namespace UTB.Eshop.Web.Models.Entity
{
    [Table(nameof(Rating))]
    public class Rating
    {
        [Key]
        [Required]
        public int ID { get; set; }

        [ForeignKey(nameof(Product))]
        public int ProductID { get; set; }

        [ForeignKey(nameof(User))]
        public int UserID { get; set; }


        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime DateTimeCreated { get; protected set; }

        [Range(1, 5)]
        public int Stars { get; set; }

        [StringLength(1000)]
        public string Comment { get; set; }

        public bool IsVisible { get; set; }


    }
}
