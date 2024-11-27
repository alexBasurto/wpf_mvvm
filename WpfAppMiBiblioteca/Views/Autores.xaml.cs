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
using System.Windows.Shapes;
using WpfAppMiBiblioteca.Models;
using WpfAppMiBiblioteca.Services;
using WpfAppMiBiblioteca.ViewModels;

namespace WpfAppMiBiblioteca.Views
{
    /// <summary>
    /// Lógica de interacción para Window1.xaml
    /// </summary>
    public partial class AutoresView : Window
    {
        public AutoresView()
        {
            InitializeComponent();

            // Crea instancia del DAL
            var dbContext = new MiBibliotecaContext();
            var dal = new DAL(dbContext);

            // Configura el viewModel como DataContext
            DataContext = new AutoresViewModel(dal);
        }
    }
}
