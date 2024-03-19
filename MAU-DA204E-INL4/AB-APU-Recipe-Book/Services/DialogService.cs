using AB_APU_Recipe_Book.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Automation.Provider;

namespace AB_APU_Recipe_Book.Services
{
    public interface IDialogService
    {
        void ShowDialog(string name);
    }
    class DialogService : IDialogService
    {
        public void ShowDialog(string name)
        {
            var dialog = new DialogView();

            var type = Type.GetType($"AB_APU_Recipe_Book.View.{name}");

            dialog.Content = Activator.CreateInstance(type);

            dialog.ShowDialog();
        }
    }
}
