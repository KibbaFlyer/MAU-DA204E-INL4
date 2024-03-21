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
    internal class IngredientViewModel: ViewModelBase
    {
        #region Private fields
        private string _newIngredient = "";
        private string _selectedIngredient = "";
        private ObservableCollection<string> _savedIngredients = new ObservableCollection<string>();
        #endregion
        #region Public fields
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
        public ObservableCollection<string> SavedIngredients
        {
            get => _savedIngredients;
            set
            {
                if (_savedIngredients != value)
                {
                    _savedIngredients = value;
                    OnPropertyChanged(nameof(SavedIngredients));
                    OnPropertyChanged(nameof(NewIngredient));
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
        private bool CanAdd(object parameter)
        {
            return _newIngredient != "" && !_savedIngredients.Contains(_newIngredient);
        }
        private bool CanEdit(object parameter)
        {
            return _selectedIngredient != null && _newIngredient != "" && _newIngredient != _selectedIngredient && !_savedIngredients.Contains(_newIngredient);
        }
        private bool CanDelete(object parameter)
        {
            return _selectedIngredient != null;
        }
        private void AddAction(object parameter)
        {
            SavedIngredients.Add(_newIngredient);
            NewIngredient = "";
        }
        private void EditAction(object parameter)
        {
            int index = _savedIngredients.IndexOf(_selectedIngredient);
            SavedIngredients[index] = _newIngredient;
            NewIngredient = "";
        }
        private void DeleteAction(object parameter)
        {
            SavedIngredients.Remove(_selectedIngredient);
        }
        #endregion
    }
}
