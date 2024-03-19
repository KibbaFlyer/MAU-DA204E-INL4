using AB_APU_Recipe_Book.Commands;
using AB_APU_Recipe_Book.Model;
using AB_APU_Recipe_Book.Services;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AB_APU_Recipe_Book.ViewModel
{
    internal class RecipeBookViewModel : ViewModelBase
    {
        #region Private fields
        private string _windowName = "Apu Recipe Book By Kristoffer Flygare";
        IDialogService _dialogService = new DialogService();
        private List<Recipe> _recipes;
        private string _recipeName;
        #endregion
        #region Public fields
        public List<FoodCategory> Categories { get; }
        public List<Recipe> Recipes
        {
            get => _recipes;
            set
            {
                if (_recipes != value)
                {
                    _recipes = value;
                    OnPropertyChanged(nameof(Recipes));
                }
            }
        }
        public string RecipeName
        {
            get => _recipeName;
            set
            {
                if (RecipeName != value)
                {
                    _recipeName = value;
                    OnPropertyChanged(nameof(RecipeName));
                }
            }
        }
        public string WindowName
        {
            get => _windowName;
            set
            {
                if (WindowName != value)
                {
                    _windowName = value;
                    OnPropertyChanged(nameof(WindowName));
                }
            }
        }
        public BaseICommand AddIngredients { get; }
        public BaseICommand AddRecipe { get; }
        #endregion

        public RecipeBookViewModel() 
        {
            AddIngredients = new BaseICommand(AddIngredientsAction, CanAddIngredients);
            AddRecipe = new BaseICommand(AddRecipeAction, CanAddRecipe);
            Categories = Enum.GetValues(typeof(FoodCategory)).Cast<FoodCategory>().ToList();
        }
        #region Methods
        private void AddIngredientsAction()
        {
            _dialogService.ShowDialog("IngredientView");
        }

        private void AddRecipeAction()
        {
            
        }
        private bool CanAddIngredients()
        {
            return true;
        }
        private bool CanAddRecipe()
        {
            return true;
        }

        #endregion

    }
}
