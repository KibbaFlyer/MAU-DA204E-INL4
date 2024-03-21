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
        private Recipe? _savedRecipeSelection = null;
        private ObservableCollection<Recipe> _recipes = new ObservableCollection<Recipe>();
        #endregion
        #region Public fields
        public Recipe CurrentRecipe
        {
            get => _currentRecipe;
            set
            {
                if (_currentRecipe != value)
                {
                    _currentRecipe = value;
                    OnPropertyChanged(nameof(CurrentRecipe));
                }
            }
        }
        public Recipe? SavedRecipeSelection
        {
            get => _savedRecipeSelection;
            set
            {
                if (_savedRecipeSelection != value)
                {
                    _savedRecipeSelection = value;
                    OnPropertyChanged(nameof(SavedRecipeSelection));
                }
            }
        }
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
        public List<FoodCategory> Categories { get; }
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
        public BaseICommand<object> EditSelected { get; }
        public BaseICommand<object> Delete { get; }
        public BaseICommand<object> ClearSelection { get; }
        #endregion

        public RecipeBookViewModel() 
        {
            AddIngredients = new BaseICommand<object>(AddIngredientsAction, CanAddIngredients);
            AddRecipe = new BaseICommand<object>(AddRecipeAction, CanAddRecipe);
            EditSelected = new BaseICommand<object>(EditSelectedAction, CanClearSelection);
            Delete = new BaseICommand<object>(DeleteAction, CanDelete);
            ClearSelection = new BaseICommand<object>(ClearSelectionAction, CanClearSelection);
            Categories = Enum.GetValues(typeof(FoodCategory)).Cast<FoodCategory>().ToList();
        }
        #region Methods
        private void AddIngredientsAction(object parameter)
        {
            var ingredientViewModel = new IngredientViewModel();
            if (_currentRecipe.Ingredients != null)
            {
                ingredientViewModel.SavedIngredients = new ObservableCollection<string>(_currentRecipe.Ingredients);
            }
            _dialogService.ShowDialog(
                "IngredientView",
               ingredientViewModel,
                (viewModelResult, dialogResult) =>
                {

                    if (dialogResult.ToString() == "True" && viewModelResult is IngredientViewModel ingredientsData)
                    {
                        if (ingredientsData != null && ingredientsData.SavedIngredients != null && ingredientsData.SavedIngredients.Count > 0)
                        {
                            if (_savedRecipeSelection != null && _currentRecipe.Name == _savedRecipeSelection.Name)
                            {

                                int index = _recipes.IndexOf(_savedRecipeSelection);
                                Recipe chosenRecipe = _recipes[index];
                                Recipes[index].Ingredients = ingredientsData.SavedIngredients;
                            }
                            else
                            {
                                CurrentRecipe.Ingredients = ingredientsData.SavedIngredients;
                            }
                            
                        }
                    }
                }
                );
        }

        private void AddRecipeAction(object parameter)
        {
            if(_savedRecipeSelection != null && _currentRecipe.Name == _savedRecipeSelection.Name)
            {
                int index = _recipes.IndexOf(_savedRecipeSelection);
                Recipe chosenRecipe = _recipes[index];
                Recipes[index] = _currentRecipe;
            }
            else
            {
                Recipes.Add(_currentRecipe);
                CurrentRecipe = new Recipe();
            }
        }
        private void EditSelectedAction(object parameter)
        {
            if (_savedRecipeSelection != null)
                CurrentRecipe = _savedRecipeSelection;
        }
        private void DeleteAction(object parameter)
        {
            if (_savedRecipeSelection != null) 
                Recipes.Remove(_savedRecipeSelection);
            SavedRecipeSelection = null;
            CurrentRecipe = new Recipe();
        }
        private void ClearSelectionAction(object parameter)
        {
            SavedRecipeSelection = null;
            CurrentRecipe = new Recipe();
        }
        private bool CanAddIngredients(object parameter)
        {
            return true;
        }
        private bool CanAddRecipe(object parameter)
        {
            return _currentRecipe.Name != null && _savedRecipeSelection == null && !_recipes.Any(item => item.Name == _currentRecipe.Name);
        }
        private bool CanDelete(object parameter)
        {
            return _savedRecipeSelection != null;
        }
        private bool CanClearSelection(object parameter)
        {
            return true;
        }

        #endregion

    }
}
