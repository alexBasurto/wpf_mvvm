using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfAppMiBiblioteca.Views;

namespace WpfAppMiBiblioteca
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void AbrirAutores_Click(object sender, RoutedEventArgs e)
        {
            // Crea una instancia de la ventana AutoresView y ábrela
            var autoresView = new AutoresView();
            autoresView.ShowDialog();
        }
    }
}