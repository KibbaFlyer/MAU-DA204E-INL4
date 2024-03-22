using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AB_APU_Recipe_Book.Model
{
    /// <summary>
    /// The base Recipe model
    /// Implements the BaseModel in order to provide updates to the host View upon change.
    /// </summary>
    internal class Recipe : BaseModel
    {
        private string _name;
        private string _description;
        private FoodCategory _category;
        // Here I would have chosen to have an ObservableCollection, but the requirements stated an Array was required
        private string[] _ingredients;
        private int _ingredientCount;

        public string Name
        {
            get => _name;
            set
            {
                if (_name != value)
                {
                    _name = value;
                    OnPropertyChanged(nameof(Name));
                }
            }
        }
        public string Description
        {
            get => _description;
            set
            {
                if (_description != value)
                {
                    _description = value;
                    OnPropertyChanged(nameof(Description));
                }
            }
        }
        public FoodCategory Category
        {
            get => _category;
            set
            {
                if (_category != value)
                {
                    _category = value;
                    OnPropertyChanged(nameof(Category));
                }
            }
        }
        public string[] Ingredients
        {
            get => _ingredients;
            set
            {
                if (_ingredients != value)
                {
                    _ingredients = value;
                    OnPropertyChanged(nameof(Ingredients));
                }
            }
        }
        public int IngredientCount
        {
            get => _ingredientCount;
            set
            {
                if (_ingredientCount != value)
                {
                    _ingredientCount = value;
                    OnPropertyChanged(nameof(IngredientCount));
                }
            }
        }
    }
}
