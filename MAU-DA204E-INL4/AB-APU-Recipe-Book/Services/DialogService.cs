using AB_APU_Recipe_Book.View;
using AB_APU_Recipe_Book.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Automation.Provider;

namespace AB_APU_Recipe_Book.Services
{
    /// <summary>
    /// IDialogService is an interface to show a dialog from a ViewModel
    /// This is order to decouple dialogs from the parent ViewModel
    /// Inspired by Brian Lagunas: https://www.youtube.com/watch?v=S8hEjLahNtU
    /// </summary>
    public interface IDialogService
    {
        void ShowDialog(string name, string windowTitle, object viewModel, Action<object, object> callback);
    }
    /// <summary>
    /// The DialogService implements the logic for a dialog and the callback of it as it closes
    /// Inspired by Brian Lagunas: https://www.youtube.com/watch?v=S8hEjLahNtU
    /// </summary>
    class DialogService : IDialogService
    {
        public void ShowDialog(string name, string windowTitle, object viewModel, Action<object, object> callback)
        {
            var dialog = new DialogView();

            EventHandler closeEventHandler = null;

            closeEventHandler = (s, e) =>
            {
                callback(viewModel, dialog.DialogResult.ToString());
                dialog.Closed -= closeEventHandler;
            };

            dialog.Closed += closeEventHandler;

            var viewType = Type.GetType($"AB_APU_Recipe_Book.View.{name}");

            var viewInstance = Activator.CreateInstance(viewType) as FrameworkElement;

            viewInstance.DataContext = viewModel;

            dialog.Title = windowTitle;

            dialog.Content = viewInstance;

            dialog.ShowDialog();
        }
    }
}
