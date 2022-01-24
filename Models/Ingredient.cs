namespace WpfProjetFinal.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Ingredient
    {

        [StringLength(450)]
        public string Id { get; set; }

        [Required]
        public string Name { get; set; }

        public int Quantity { get; set; }

        [Required]
        public string Unity { get; set; }

        public virtual ICollection<Recipe> Recipes { get; set; }
    }
}
