namespace WpfProjetFinal.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Recipe
    {

        [StringLength(450)]
        public string Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Category { get; set; }

        [Required]
        public string Instruction { get; set; }

        public int PreparationTime { get; set; }

        public int CookingTime { get; set; }

        [Required]
        public string Picture { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime CreationDate { get; set; }

        [Required]
        [StringLength(450)]
        public string UserId { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }

        public virtual User User { get; set; }

        public virtual ICollection<Ingredient> Ingredients { get; set; }
    }
}
