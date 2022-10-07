using System.ComponentModel.DataAnnotations;

namespace InstantNoodles.MVC.Models;

public class DifferentNoodleModel
{
    public int IdNouille { get; set; }
    public string Nom { get; set; }
    public string Viande { get; set; }
    public string Legume { get; set; }
    public bool Sauce { get; set; }
}

public class DifferentNoodleFormModel
{
    [Required]
    public string Nom { get; set; }
    [Required]
    public string Viande { get; set; }
    [Required]
    public string Legume { get; set; }
    [Required]
    public bool Sauce { get; set; }
}
