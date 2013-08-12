using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
using System.Windows.Threading;

namespace WPF45_LiveShapping
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //The dispatcher times which will 
        //Update Price property after specific duration 
        DispatcherTimer dispTimer = new DispatcherTimer();

        ObservableCollection<Product> lstProducts = new ObservableCollection<Product>();

        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Code for showing product information in DataGrid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var productCollection = new  ProductCollection();
            dgproducts.ItemsSource =productCollection;

            Random random = new Random();

            var Products = new ProductCollection();

            //Code for updating Price

            foreach (var item in Products)
            {
                lstProducts.Add(new Product()
                {
                    ProductId = item.ProductId,
                    ProductName = item.ProductName,
                    Price = item.Price
                });
            }

            dgproducts.ItemsSource = lstProducts;
        }

        void dispTimer_Tick(object sender, EventArgs e)
        {
            Random random = new Random();
            foreach (var pc in lstProducts)
            {
                pc.Price += random.Next(100) - 5;
            }
        }

        /// <summary>
        /// On the click on the button the 
        /// Sorting will started. It uses below programming featutes
        /// 1.ICollectionView: Enable collections to apply Custom Sorting, Filtering and Grouping
        /// 2.ICollectionViewLiveShaping: Defining Sorting, Grouping, Filtering on ColectionView in Real Time 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnlivesort_Click(object sender, RoutedEventArgs e)
        {
            ICollectionView pView = CollectionViewSource.GetDefaultView(lstProducts);
            pView.SortDescriptions.Add(new SortDescription("Price", ListSortDirection.Ascending));
            var productview = (ICollectionViewLiveShaping)CollectionViewSource.GetDefaultView(lstProducts);
            productview.IsLiveSorting = true;

            dispTimer.Interval = TimeSpan.FromMilliseconds(600);
            dispTimer.Tick += dispTimer_Tick;

            dispTimer.Start();
        }
    }


}

