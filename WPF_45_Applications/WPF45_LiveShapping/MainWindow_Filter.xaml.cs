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
    /// Interaction logic for MainWindow_Filter.xaml
    /// </summary>
    public partial class MainWindow_Filter : Window
    {
        EmployeeInfoCollection Emplyees;
        List<string> Departments;
        public string DeptName { get; set; }
        public MainWindow_Filter()
        {
            InitializeComponent();
        }

        /// <summary>
        /// The selection changed event on the ListBox to enable 
        /// Filtering on the DeptName. It uses the below API
        /// 1. ListCollectionView: Represents collection View for collections implementing IList
        /// 2. Define Filter for DeptName to find the Match.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lstdept_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListCollectionView empView = CollectionViewSource.GetDefaultView(dgemp.ItemsSource) as ListCollectionView;
            // Enable Live Filtering of the ListViewCollection
            empView.IsLiveFiltering = true;
            // Enable the filtering on DeptName
            empView.LiveFilteringProperties.Add("DeptName");
            DeptName = lstdept.SelectedItem.ToString();
            // Filter based upon DeptName
            empView.Filter = new Predicate<object>(IsMatchFound);
            // Refresh Collection
            empView.Refresh();
        }

        /// <summary>
        /// Helper method to check if
        /// the DeptName matches
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>

        bool IsMatchFound(object d)
        {
            bool res = false;
            EmployeeInfo emp = d as EmployeeInfo;
            
                if (emp.DeptName == DeptName)
                {
                    res = true;
                }
            
            return res;
        }


        /// <summary>
        /// Displays Employee information in the DataGrid
        /// and DeptName in ListBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Emplyees = new EmployeeInfoCollection();
            dgemp.ItemsSource = Emplyees;

            Departments = Emplyees.Select(d => d.DeptName).Distinct().ToList();
            lstdept.ItemsSource = Departments;
            
        }
    }
}
