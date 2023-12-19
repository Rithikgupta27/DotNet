using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookWebApplication.Models;

public partial class TblBook
{
    [Key]
    public int BookId { get; set; }

    [Required(ErrorMessage ="not given book name")]
    public string BookName { get; set; } = null!;

    [Required(ErrorMessage ="not given book Author name")]
    public string BookAuthor { get; set; } = null!;

    [Required(ErrorMessage ="not set book price")]
    public decimal BookPrice { get; set; }
}
