using AB_APU_Recipe_Book.Commands;
using AB_APU_Recipe_Book.Model;
using AB_APU_Recipe_Book.Services;
using AB_APU_Recipe_Book.View;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Media3D;

namespace AB_APU_Recipe_Book.ViewModel
{
    /// <summary>
    /// The ViewModel to hold the Ingredients of a Dialog
    /// </summary>
    internal class IngredientViewModel: ViewModelBase
    {
        #region Private fields
        private string _newIngredient = "";
        private string _selectedIngredient = "";
        // Here I would have chosen to have an ObservableCollection, but the requirements stated an Array was required
        private string[] _savedIngredients = Array.Empty<string>();
        #endregion
        #region Public fields
        // These properties are public in order for Views to be able to bind to them
        public string NewIngredient
        {
            get => _newIngredient;
            set
            {
                if (_newIngredient != value)
                {
                    _newIngredient = value;
                    OnPropertyChanged(nameof(NewIngredient));
                }
            }
        }
        public string[] SavedIngredients
        {
            get => _savedIngredients;
            set
            {
                if (_savedIngredients != value)
                {
                    _savedIngredients = value;
                    OnPropertyChanged(nameof(SavedIngredients));
                }
            }
        }
        public string SelectedIngredient
        {
            get => _selectedIngredient;
            set
            {
                if (_selectedIngredient != value)
                {
                    _selectedIngredient = value;
                    OnPropertyChanged(nameof(SelectedIngredient));
                }
            }
        }

        public BaseICommand<object> Add { get; }
        public BaseICommand<object> Edit { get; }
        public BaseICommand<object> Delete { get; }
        #endregion
        public IngredientViewModel() 
        {
            Add = new BaseICommand<object>(AddAction, CanAdd);
            Edit = new BaseICommand<object>(EditAction, CanEdit);
            Delete = new BaseICommand<object>(DeleteAction, CanDelete);
        }
        #region Methods
        /// <summary>
        /// Checks if the object can be added, to limit risks of exceptions
        /// </summary>
        /// <param name="parameter">Is always Null in the current implementation</param>
        /// <returns>True if user is allowed to edit</returns>
        private bool CanAdd(object parameter)
        {
            return _newIngredient != "" && !_savedIngredients.Contains(_newIngredient) && _savedIngredients.Length < 50;
        }
        /// <summary>
        /// Checks if the object can be edited, to limit risks of exceptions
        /// </summary>
        /// <param name="parameter">Is always Null in the current implementation</param>
        /// <returns>True if user is allowed to edit</returns>
        private bool CanEdit(object parameter)
        {
            return _selectedIngredient != null && _newIngredient != "" && _newIngredient != _selectedIngredient && Array.IndexOf(_savedIngredients, _selectedIngredient) != -1;
        }
        /// <summary>
        /// Checks if the object can be deleted, to limit risks of exceptions
        /// </summary>
        /// <param name="parameter">Is always Null in the current implementation</param>
        /// <returns>True if user is allowed to edit</returns>
        private bool CanDelete(object parameter)
        {
            return _selectedIngredient != null && Array.IndexOf(_savedIngredients, _selectedIngredient) != -1;
        }
        /// <summary>
        /// Adds an ingredient to the saved ingredients
        /// Recreates the array in order to update the parent
        /// </summary>
        /// <param name="parameter">Is always Null in the current implementation</param>
        private void AddAction(object parameter)
        {
            string[] newIngredients = new string[_savedIngredients.Length + 1];
            _savedIngredients.CopyTo(newIngredients, 0);
            int indexToAdd = _savedIngredients.Length;
            newIngredients[indexToAdd] = _newIngredient;
            SavedIngredients = newIngredients;
            NewIngredient = "";
        }
        /// <summary>
        /// Edits an ingredient of the saved ingredients
        /// Recreates the array in order to update the parent
        /// </summary>
        /// <param name="parameter">Is always Null in the current implementation</param>
        private void EditAction(object parameter)
        {
            string[] newIngredients = new string[_savedIngredients.Length];
            _savedIngredients.CopyTo(newIngredients, 0);
            int index = Array.IndexOf(_savedIngredients, _selectedIngredient);
            newIngredients[index] = _newIngredient;
            SavedIngredients = newIngredients;
            NewIngredient = "";
        }
        /// <summary>
        /// Removes an ingredient from the saved ingredients
        /// Recreates the array in order to update the parent
        /// </summary>
        /// <param name="parameter">Is always Null in the current implementation</param>
        private void DeleteAction(object parameter)
        {
            int indexToDelete = Array.IndexOf(_savedIngredients, _selectedIngredient);
            string[] newIngredients = MoveElementsInArray(indexToDelete, _savedIngredients);
            SavedIngredients = newIngredients;
        }
        /// <summary>
        /// Moves elements in an array to the top in order to get rid of Null positions
        /// </summary>
        /// <param name="index">Index of the position to remove</param>
        /// <param name="array">The array to edit</param>
        /// <returns>An edited array with the index removed and a length = length - 1</returns>
        private string[] MoveElementsInArray(int index, string[] array)
        {
            for (int i = index; i < array.Length - 1; i++)
            {
                array[i] = array[i + 1];
            }
            if (array.Length > 0)
                array[array.Length - 1] = null;
            Array.Resize(ref array, array.Length - 1);
            return array;
        }
        #endregion
    }
}
