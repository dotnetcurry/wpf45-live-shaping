using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF45_LiveShapping
{
    /// <summary>
    /// The class implement INotifyPropertyChanged interface. 
    /// This is used for the Properties value changes.
    /// </summary>
    public class Product : INotifyPropertyChanged
    {
        int _ProductId;

        public int ProductId
        {
            get { return _ProductId; }
            set 
            {
                _ProductId = value;
                OnPropertychanged("ProductId");
            }
        }

        string _ProductName;

        public string ProductName
        {
            get { return _ProductName; }
            set 
            {
                _ProductName = value;
                OnPropertychanged("ProductName");
            }
        }

        int _Price;

        public int Price
        {
            get { return _Price; }
            set 
            {
                _Price = value;
                OnPropertychanged("Price");
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertychanged(string pName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this,new PropertyChangedEventArgs(pName));
            }
        }
    }


    public class ProductCollection : ObservableCollection<Product>
    {
        public ProductCollection()
        {
            Add(new Product() { ProductId = 1, ProductName = "Mobile-Single-SIM", Price = 2300 });
            Add(new Product() { ProductId = 2, ProductName = "Mobile-Duel-SIM", Price = 2300 });
            Add(new Product() { ProductId = 3, ProductName = "Tablet-Single-SIM", Price = 2300 });
            Add(new Product() { ProductId = 4, ProductName = "Tablet-Calling-Facility", Price = 2300 });
            Add(new Product() { ProductId = 5, ProductName = "WiFi Router", Price = 2300 });
            Add(new Product() { ProductId = 6, ProductName = "Blooth", Price = 2300 });
            Add(new Product() { ProductId = 7, ProductName = "Mobile-Pouch", Price = 2300 });
            Add(new Product() { ProductId = 8, ProductName = "Mobile-Scratch-Guard", Price = 2300 });
            Add(new Product() { ProductId = 9, ProductName = "Mobile-Data-Card", Price = 2300 });
        }
    }

    /// <summary>
    /// The class implement INotifyPropertyChanged interface. 
    /// This is used for the Properties value changes.
    /// </summary>
    public class EmployeeInfo : INotifyPropertyChanged
    {
        int _EmpNo;

        public int EmpNo
        {
            get { return _EmpNo; }
            set 
            {
                _EmpNo = value;
                OnPropertychanged("Salary");
            }
        }
        string _EmpName;

        public string EmpName
        {
            get { return _EmpName; }
            set 
            {
                _EmpName = value;
                OnPropertychanged("Salary");
            }
        }
        string _DeptName;

        public string DeptName
        {
            get { return _DeptName; }
            set 
            {
                _DeptName = value;
                OnPropertychanged("Salary");
            }
        }
        int _Salary;

        public int Salary
        {
            get { return _Salary; }
            set 
            {
                _Salary = value;
                OnPropertychanged("Salary");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;


        void OnPropertychanged(string pName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(pName));
            }
        }
    }

    public class EmployeeInfoCollection : ObservableCollection<EmployeeInfo>
    {
        public EmployeeInfoCollection()
        {
            Add(new EmployeeInfo() {EmpNo=1,EmpName="Mahesh",DeptName="Purchase",Salary=34000 });
            Add(new EmployeeInfo() { EmpNo = 2, EmpName = "Amit", DeptName = "Purchase", Salary = 44000 });
            Add(new EmployeeInfo() { EmpNo = 3, EmpName = "Ajay", DeptName = "HRD", Salary = 14000 });
            Add(new EmployeeInfo() { EmpNo = 4, EmpName = "Kishor", DeptName = "HRD", Salary = 24000 });
            Add(new EmployeeInfo() { EmpNo = 5, EmpName = "Sudhir", DeptName = "Accounts", Salary = 54000 });
            Add(new EmployeeInfo() { EmpNo = 6, EmpName = "Deepak", DeptName = "Accounts", Salary = 44000 });
            Add(new EmployeeInfo() { EmpNo = 7, EmpName = "Vikas", DeptName = "Sales", Salary = 74000 });
            Add(new EmployeeInfo() { EmpNo = 8, EmpName = "Prashant", DeptName = "Sales", Salary = 84000 });
        }
    }
}
