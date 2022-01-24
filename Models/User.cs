namespace WpfProjetFinal.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class User
    {

        [StringLength(450)]
        public string Id { get; set; }

        [Required]
        public string Nom { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public bool IsProfessional { get; set; }

        [Required]
        public string Picture { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }

        public virtual ICollection<Recipe> Recipes { get; set; }
    }
}
