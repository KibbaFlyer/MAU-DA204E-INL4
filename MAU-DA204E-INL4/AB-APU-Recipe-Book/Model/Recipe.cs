using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AB_APU_Recipe_Book.Model
{
    internal class Recipe
    {
        internal string Name { get; set; }
        internal string Description { get; set; }
        internal FoodCategory Category { get; set; }
        internal List<string> Ingredients { get; set; }

    }
}
