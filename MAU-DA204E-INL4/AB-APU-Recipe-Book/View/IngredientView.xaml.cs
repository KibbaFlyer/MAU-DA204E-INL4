using AB_APU_Recipe_Book.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Serialization;

namespace AB_APU_Recipe_Book.View
{
    /// <summary>
    /// Interaction logic for IngredientView.xaml
    /// Implements button click logic for DialogResult for the parent Window
    /// in order to check for canceled operations
    /// Is a UserControl and meant to be hosted in a parent Window
    /// </summary>
    public partial class IngredientView : UserControl
    {
        public IngredientView()
        {
            InitializeComponent();
        }

        private void Ok_Button_Click(object sender, RoutedEventArgs e)
        {
            var window = this.Parent as Window;
            window.DialogResult = true;
        }
        private void Cancel_Button_Click(object sender, RoutedEventArgs e)
        {
            var window = this.Parent as Window;
            window.DialogResult = false;
        }
    }
}
