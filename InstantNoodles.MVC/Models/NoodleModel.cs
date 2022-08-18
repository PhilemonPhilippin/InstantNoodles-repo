using System.ComponentModel.DataAnnotations;

namespace InstantNoodles.MVC.Models;

public class NoodleModel
{
    public int NoodleID { get; set; }
    public string Name { get; set; }
    public string Meat { get; set; }
    public string Vegetable { get; set; }
    public bool Sauce { get; set; }
}
public class NoodleFormModel
{
    [Required]
    public string Name { get; set; }
    [Required]
    public string Meat { get; set; }
    [Required]
    public string Vegetable { get; set; }
    [Required]
    public bool Sauce { get; set; }
}