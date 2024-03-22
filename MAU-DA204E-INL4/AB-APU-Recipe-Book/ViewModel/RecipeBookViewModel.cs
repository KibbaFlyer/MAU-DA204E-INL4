using AB_APU_Recipe_Book.Commands;
using AB_APU_Recipe_Book.Model;
using AB_APU_Recipe_Book.Services;
using Microsoft.VisualBasic;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AB_APU_Recipe_Book.ViewModel
{
    /// <summary>
    /// The Main ViewModel of the 
    /// </summary>
    internal class RecipeBookViewModel : ViewModelBase
    {
        #region Private fields
        private string _windowName = "Apu Recipe Book By Kristoffer Flygare";
        private IDialogService _dialogService = new DialogService();
        private Recipe _currentRecipe = new Recipe();
        private Recipe? _savedRecipeSelection = null;
        // Here I would have chosen to have an ObservableCollection, but the requirements stated an Array was required
        private Recipe[] _recipes = Array.Empty<Recipe>();
        private string _groupBoxBackground = "Transparent";
        private string _groupBoxName = "Add new recipe";
        #endregion
        #region Public fields
        // These properties are public in order for Views to be able to bind to them
        public string GroupBoxBackground 
        {
            get => _groupBoxBackground;
            set
            {
                if (_groupBoxBackground != value)
                {
                    _groupBoxBackground = value;
                    OnPropertyChanged(nameof(GroupBoxBackground));
                }
            }
        }
        public string GroupBoxName
        {
            get => _groupBoxName;
            set
            {
                if (_groupBoxName != value)
                {
                    _groupBoxName = value;
                    OnPropertyChanged(nameof(GroupBoxName));
                }
            }
        }
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
        public Recipe[] Recipes
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
                if (_windowName != value)
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
        public BaseICommand<object> LeftDoubleClick { get; }
        #endregion

        public RecipeBookViewModel() 
        {
            AddIngredients = new BaseICommand<object>(AddIngredientsAction, CanAddIngredients);
            AddRecipe = new BaseICommand<object>(AddRecipeAction, CanAddRecipe);
            EditSelected = new BaseICommand<object>(EditSelectedAction, CanClearSelection);
            LeftDoubleClick = new BaseICommand<object>(LeftDoubleClickAction, CanLeftDoubleClick);
            Delete = new BaseICommand<object>(DeleteAction, CanDelete);
            ClearSelection = new BaseICommand<object>(ClearSelectionAction, CanClearSelection);
            Categories = Enum.GetValues(typeof(FoodCategory)).Cast<FoodCategory>().ToList();
        }
        #region Methods
        /// <summary>
        /// Opens up a dialog with its own ViewModel that reports back its values to this ViewModel upon close.
        /// The logic is handled through the DialogService, so that when a user presses Cancel - the values are not passed along.
        /// Please look at the Code-behind of the View in order to see the Button-click logic
        /// Inspired by Brian Lagunas: https://www.youtube.com/watch?v=S8hEjLahNtU
        /// </summary>
        /// <param name="parameter">Is always Null in the current implementation</param>
        private void AddIngredientsAction(object parameter)
        {
            var ingredientViewModel = new IngredientViewModel();
            if (_currentRecipe.Ingredients != null)
            {
                ingredientViewModel.SavedIngredients = _currentRecipe.Ingredients;
            }
            _dialogService.ShowDialog(
                "IngredientView",
                _currentRecipe.Name + " - Add Ingredients",
               ingredientViewModel,
                (viewModelResult, dialogResult) =>
                {
                    if (dialogResult.ToString() == "True" && viewModelResult is IngredientViewModel ingredientsData)
                    {
                        if (ingredientsData != null && ingredientsData.SavedIngredients != null)
                        {
                            CurrentRecipe.Ingredients = ingredientsData.SavedIngredients;
                            CurrentRecipe.IngredientCount = ingredientsData.SavedIngredients?.Length ?? 0;
                        }
                    }
                }
                );
        }
        /// <summary>
        /// Adds a recipe to the Recipes array
        /// </summary>
        /// <param name="parameter">Is always Null in the current implementation</param>
        private void AddRecipeAction(object parameter)
        {
            // Prevously I used a ObservableCollection, which also works very well and makes for a easy-to-read code.
            Recipe[] newRecipes = new Recipe[_recipes.Length + 1];
            _recipes.CopyTo(newRecipes, 0);
            int indexToAdd = _recipes.Length;
            newRecipes[indexToAdd] = _currentRecipe;
            Recipes = newRecipes;
            CurrentRecipe = new Recipe();
        }
        /// <summary>
        /// Edits a recipe of the Recipes array
        /// Changes some UI-colors in order to provide context for the user - I am unsure of the UI data should be handled in the View only perhaps.
        /// </summary>
        /// <param name="parameter">Is always Null in the current implementation</param>
        private void EditSelectedAction(object parameter)
        {
            if (_savedRecipeSelection != null)
            {
                CurrentRecipe = _savedRecipeSelection;
                GroupBoxBackground = "LightBlue";
                GroupBoxName = "Edit recipe";
            }
        }
        /// <summary>
        /// Deletes a recipe of the Recipes array
        /// Resets the selection and current recipe
        /// </summary>
        /// <param name="parameter">Is always Null in the current implementation</param>
        private void DeleteAction(object parameter)
        {
            if (_savedRecipeSelection != null)
            {
                int indexToDelete = Array.IndexOf(_recipes, _savedRecipeSelection);
                Recipe[] newRecipes = MoveElementsInArray(indexToDelete, _recipes);
                Recipes = newRecipes;
            }
            GroupBoxBackground = "Transparent";
            GroupBoxName = "Add new recipe";
            SavedRecipeSelection = null;
            CurrentRecipe = new Recipe();
        }
        /// <summary>
        /// Clears the selected item and resets the UI colors for better user context
        /// </summary>
        /// <param name="parameter">Is always Null in the current implementation</param>
        private void ClearSelectionAction(object parameter)
        {
            SavedRecipeSelection = null;
            CurrentRecipe = new Recipe();
            GroupBoxBackground = "Transparent";
            GroupBoxName = "Add new recipe";
        }
        /// <summary>
        /// Double click opens a message box for the user. This could of course be done with a View instead, but I felt a MessageBox was enough
        /// </summary>
        /// <param name="parameter">Is always Null in the current implementation</param>
        private void LeftDoubleClickAction(object parameter)
        {
            string ingredients = _savedRecipeSelection.Ingredients != null ? string.Join(Environment.NewLine, _savedRecipeSelection.Ingredients) : "";
            MessageBox.Show($"Ingredients:\n" +
                $"{ingredients}\n\n"+
                "Instructions:\n" +
                _savedRecipeSelection.Description,$"Cooking instructions for {_savedRecipeSelection.Name}");
        }
        /// <summary>
        /// Checks if the object can be added, to limit risks of exceptions
        /// </summary>
        /// <param name="parameter">Is always Null in the current implementation</param>
        /// <returns>True if user is allowed to edit</returns>
        private bool CanAddIngredients(object parameter)
        {
            return _currentRecipe.IngredientCount < 50;
        }
        /// <summary>
        /// Checks if the object can be added, to limit risks of exceptions
        /// </summary>
        /// <param name="parameter">Is always Null in the current implementation</param>
        /// <returns>True if user is allowed to edit</returns>
        private bool CanAddRecipe(object parameter)
        {
            return _currentRecipe.Name != null && !_recipes.Any(item => item.Name == _currentRecipe.Name) && _recipes.Length < 200;
        }
        /// <summary>
        /// Checks if the object can be deleted, to limit risks of exceptions
        /// </summary>
        /// <param name="parameter">Is always Null in the current implementation</param>
        /// <returns>True if user is allowed to edit</returns>
        private bool CanDelete(object parameter)
        {
            return _savedRecipeSelection != null && Array.IndexOf(_recipes, _savedRecipeSelection) != -1;
        }
        /// <summary>
        /// Checks if the ClearSelection can be run
        /// </summary>
        /// <param name="parameter">Is always Null in the current implementation</param>
        /// <returns>True if user is allowed to edit</returns>
        private bool CanClearSelection(object parameter)
        {
            return true;
        }
        /// <summary>
        /// Checks if there is an object selected, to limit risks of exceptions
        /// </summary>
        /// <param name="parameter">Is always Null in the current implementation</param>
        /// <returns>True if user is allowed to edit</returns>
        private bool CanLeftDoubleClick(object parameter)
        {
            return _savedRecipeSelection != null;
        }
        /// <summary>
        /// Moves elements in an array to the top in order to get rid of Null positions
        /// </summary>
        /// <param name="index">Index of the position to remove</param>
        /// <param name="array">The array to edit</param>
        /// <returns>An edited array with the index removed and a length = length - 1</returns>
        private Recipe[] MoveElementsInArray(int index, Recipe[] array)
        {
            for (int i = index; i < array.Length-1; i++)
            {
                array[i] = array[i+1];
            }
            if(array.Length > 0)
                array[array.Length - 1] = null;
            Array.Resize(ref array, array.Length - 1);
            return array;
        }
        #endregion

    }
}
