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
    public interface IDialogService
    {
        void ShowDialog(string name, object viewModel, Action<object, object> callback);
    }
    class DialogService : IDialogService
    {
        public void ShowDialog(string name, object viewModel, Action<object, object> callback)
        {
            var dialog = new DialogView();

            EventHandler closeEventHandler = null;

            closeEventHandler = (s, e) =>
            {
                callback(viewModel, dialog.ToString());
                dialog.Closed -= closeEventHandler;
            };

            dialog.Closed += closeEventHandler;

            var viewType = Type.GetType($"AB_APU_Recipe_Book.View.{name}");

            var viewInstance = Activator.CreateInstance(viewType) as FrameworkElement;

            viewInstance.DataContext = viewModel;

            dialog.Content = viewInstance;

            dialog.ShowDialog();
        }
    }
}
