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
        public string Name { get; set; }
        public string Description { get; set; }
        public FoodCategory Category { get; set; }
        public ObservableCollection<string> Ingredients { get; set; }

    }
}
