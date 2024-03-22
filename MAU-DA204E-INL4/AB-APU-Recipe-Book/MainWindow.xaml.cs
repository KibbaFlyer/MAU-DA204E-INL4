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

namespace AB_APU_Recipe_Book
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            // I have chosen a MVVM workflow for this assignment. For that reason I have had to take a bit of a different angle towards solving the assignment.
            // I have asked Farid and I got the OK to use MVVM, Please let me know if not and I will redo it with another solution
            // I believe I have gotten the same functionality that is requested, as it comes to the Features and requirements listed in 4:
            // 4.1 I have chosen to ommit the Edit-Begin and Edit-Finish buttons and instead have only one "Edit" button, and changes are saved automatically to the recipe
            // This is of course a bit of a differnce for the end-user, but I believe it is easier with fewer clicks. If I were to do it exactly like the two buttons I would in my 
            // ViewModel instead create a new _currentRecipe (instead of settings it to the _selectedRecipe of the Recipes collection). And then on finish set the _selectedRecipe to 
            // be that of _currentRecipe.
            // 4.2 Clears the selection (changes are saved automatically)
            // 4.3 I use the BaseICommands "CanExecute" in my ViewModel to validate entries and disabling buttons when necessary, I hope this is okay and as requested. 
            // I believe it gives the user good feedback in what they can do. An addition might be a popup that tells them why they cannot save their recipe/ingredient
            // 4.4 Using MVVM I need to have public properties in order for the view to bind to them, I hope this is okay.
            // 4.5 Using MVVM, Using Arrays needs a lot more code to update the views (I need to recreate the whole array every time). Otherwise I would (and have in an early solution)
            // done it with ObservableCollections
            // 4.6 I have chosen to add this to the CanExecute functions of my ICommands.
            // 4.7 I believe it is functioning without exceptions or bugs
            // 4.8 I have the same functionality, except using an ItemSource (because of MVVM) and IsEditable = false
            InitializeComponent();
        }
    }
}
