using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstantNoodles.DAL.Models;

public class NoodleModel
{
    public int NoodleID { get; set; }
    public string Name { get; set; }
    public string Meat { get; set; }
    public string Vegetable { get; set; }
    public bool Sauce { get; set; }

}
