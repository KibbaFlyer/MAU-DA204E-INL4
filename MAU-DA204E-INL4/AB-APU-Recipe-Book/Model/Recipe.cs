using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        internal ObservableCollection<string> Ingredients { get; set; }

    }
}
