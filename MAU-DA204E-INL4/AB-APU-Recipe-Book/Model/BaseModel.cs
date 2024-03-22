using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AB_APU_Recipe_Book.Model
{
    /// <summary>
    /// Implements INotifyPropertyChanged for Models, such that nested properties can trigger changes for the parent
    /// Without this, the Recips ingredients won't update in the View upon edit
    /// </summary>
    internal class BaseModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
