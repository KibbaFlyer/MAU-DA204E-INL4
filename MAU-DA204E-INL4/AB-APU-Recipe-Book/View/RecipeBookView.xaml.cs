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

namespace AB_APU_Recipe_Book.View
{
    /// <summary>
    /// Interaction logic for RecipeBookView.xaml
    /// Is a UserControl and meant to be hosted in a parent Window
    /// </summary>
    public partial class RecipeBookView : UserControl
    {
        public RecipeBookView()
        {
            // Sets up the ViewModel
            DataContext = new ViewModel.RecipeBookViewModel();
            InitializeComponent();
        }
    }
}
