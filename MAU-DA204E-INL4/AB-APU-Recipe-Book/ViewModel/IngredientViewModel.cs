using AB_APU_Recipe_Book.Commands;
using AB_APU_Recipe_Book.Services;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AB_APU_Recipe_Book.ViewModel
{
    internal class IngredientViewModel: ViewModelBase
    {
        #region Private fields
        private string _newIngredient;
        private List<string> _savedIngredients;
        #endregion
        #region Public fields
        public int NumberOfIngredients
        {
            get => _savedIngredients.Count;
        }
        public string NewIngredient
        {
            get => _newIngredient;
            set
            {
                if (NewIngredient != value)
                {
                    _newIngredient = value;
                    OnPropertyChanged(nameof(NewIngredient));
                }
            }
        }
        public List<string> SavedIngredients
        {
            get => _savedIngredients;
            set
            {
                if (SavedIngredients != value)
                {
                    _savedIngredients = value;
                    OnPropertyChanged(nameof(SavedIngredients));
                }
            }
        }

        public BaseICommand Add { get; }
        public BaseICommand Edit { get; }
        public BaseICommand Delete { get; }
        public BaseICommand Ok { get; }
        public BaseICommand Cancel { get; }
        #endregion
        public IngredientViewModel() 
        {
            Add = new BaseICommand(AddAction, CanAdd);
            Edit = new BaseICommand(EditAction, CanEdit);
            Delete = new BaseICommand(DeleteAction, CanDelete);
            Ok = new BaseICommand(OkAction, CanOk);
            Cancel = new BaseICommand(CancelAction, CanCancel);
        }
        #region Methods
        private bool CanAdd()
        {
            return true;
        }
        private bool CanEdit()
        {
            return true;
        }
        private bool CanDelete()
        {
            return true;
        }
        private bool CanOk()
        {
            return true;
        }
        private bool CanCancel()
        {
            return true;
        }
        private void AddAction()
        {

        }
        private void EditAction()
        {

        }
        private void DeleteAction()
        {

        }
        private void OkAction()
        {

        }
        private void CancelAction()
        {
 
        }
        #endregion
    }
}
