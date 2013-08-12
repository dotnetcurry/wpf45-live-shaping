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

namespace WPF45_LiveShapping
{
    /// <summary>
    /// Interaction logic for Shell.xaml
    /// </summary>
    public partial class Shell : Window
    {
        public Shell()
        {
            InitializeComponent();
        }

        private void btnlivesorting_Click(object sender, RoutedEventArgs e)
        {
            var winSort = new  MainWindow();
            winSort.Show();
        }

        private void btnliveFiltering_Click(object sender, RoutedEventArgs e)
        {
            var winFilter = new MainWindow_Filter();
            winFilter.Show();
        }

    }
}
