using AB_APU_Recipe_Book.Commands;
using AB_APU_Recipe_Book.Model;
using AB_APU_Recipe_Book.Services;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AB_APU_Recipe_Book.ViewModel
{
    internal class RecipeBookViewModel : ViewModelBase
    {
        #region Private fields
        private string _windowName = "Apu Recipe Book By Kristoffer Flygare";
        private IDialogService _dialogService = new DialogService();
        private Recipe _currentRecipe = new Recipe();
        private ObservableCollection<Recipe> _recipes = new ObservableCollection<Recipe>();
        #endregion
        #region Public fields
        public ObservableCollection<string> Ingredients
        {
            get => _currentRecipe.Ingredients;
            set
            {
                if(_currentRecipe.Ingredients != value)
                {
                    _currentRecipe.Ingredients = value;
                    OnPropertyChanged(nameof(Ingredients));
                }
            }
        }
        public List<FoodCategory> Categories { get; }
        public ObservableCollection<Recipe> Recipes
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
            get => _currentRecipe.Name;
            set
            {
                if (_currentRecipe.Name != value)
                {
                    _currentRecipe.Name = value;
                    OnPropertyChanged(nameof(RecipeName));
                }
            }
        }
        public string Description
        {
            get => _currentRecipe.Description;
            set
            {
                if (_currentRecipe.Description != value)
                {
                    _currentRecipe.Description = value;
                    OnPropertyChanged(nameof(Description));
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
        public BaseICommand<object> AddIngredients { get; }
        public BaseICommand<object> AddRecipe { get; }
        #endregion

        public RecipeBookViewModel() 
        {
            AddIngredients = new BaseICommand<object>(AddIngredientsAction, CanAddIngredients);
            AddRecipe = new BaseICommand<object>(AddRecipeAction, CanAddRecipe);
            Categories = Enum.GetValues(typeof(FoodCategory)).Cast<FoodCategory>().ToList();
        }
        #region Methods
        private void AddIngredientsAction(object parameter)
        {
            _dialogService.ShowDialog("IngredientView", new IngredientViewModel(), result =>
            {
                if (result is IngredientViewModel ingredientsData)
                {
                    if (ingredientsData != null && ingredientsData.SavedIngredients != null && ingredientsData.SavedIngredients.Count > 0)
                    {
                        _currentRecipe.Ingredients = ingredientsData.SavedIngredients;
                    }
                }
            });
        }

        private void AddRecipeAction(object parameter)
        {
            Recipes.Add(_currentRecipe);
            _currentRecipe = new Recipe();
            RecipeName = null;

        }
        private bool CanAddIngredients(object parameter)
        {
            return true;
        }
        private bool CanAddRecipe(object parameter)
        {
            return true;
        }

        #endregion

    }
}
