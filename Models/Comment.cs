namespace WpfProjetFinal.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Comment
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(450)]
        public string RecipeId { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(450)]
        public string UserId { get; set; }

        public string Id { get; set; }

        [Required]
        public string Content { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime CreationDate { get; set; }

        public virtual Recipe Recipe { get; set; }

        public virtual User User { get; set; }
    }
}
