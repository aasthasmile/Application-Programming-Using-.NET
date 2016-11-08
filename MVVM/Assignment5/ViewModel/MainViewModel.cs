using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.ComponentModel;
using Assignment5.Commands;
using Assignment5.Model;
using System.Windows.Input;

using System.Collections.ObjectModel;


namespace Assignment5.ViewModel
{
    class MainViewModel : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

        public ICommand SortByLastNameDesc { get; private set; }
        public ICommand SortBySSN { get; private set; }
        public ICommand SortBySalaryEmp { get; private set; }
        public ICommand Reloadbtn { get; private set; }
        IPayable[] payableObjects;

        public ObservableCollection<Employee> SortedList { get; set; }
        public SortingOrder SelectedOrder { get; set; }
        
        public ObservableCollection<SortingOrder> Sort
        {
            get
            {
                ObservableCollection<SortingOrder> s = new ObservableCollection<SortingOrder>();
                s.Add(new SortingOrder { DisplayName = "Ascending" });
                s.Add(new SortingOrder { DisplayName = "Descending" });
                SelectedOrder = s.First();
                return s;
            }
        } 

        public MainViewModel()
        {
            SortedList = new ObservableCollection<Employee>();
            payableObjects = new IPayable[8];
        
            SortByLastNameDesc = new DelegateCommand((p) => SortByLastNameFxn(p));
            SortBySSN = new DelegateCommand((p) => SortBySSNFxn(p));
            SortBySalaryEmp = new DelegateCommand((p) => SortBySalaryEmpFxn(p));
            Reloadbtn = new DelegateCommand((p) => Reload(p));
        }

        private void Reload(object p)
        {
            SortedList.Clear();
            int i = 0;
            string uri = @"Employees.xml"; // your big XML file
            foreach (var employee in XmlHelper.StreamEmployees(uri))
            {

                ((Employee)employee).PayAmount = ((Employee)employee).GetPaymentAmount();
                SortedList.Add(employee);
                payableObjects[i] = employee;
                i++;
            }
        }

        private void SortBySalaryEmpFxn(object p)
        {
            Reload(p);
            if (SelectedOrder.DisplayName == "Ascending")
            {
                SortedList.Clear();
                Array.Sort(payableObjects, Employee.sortPayAmountAscending());
                foreach (var emp in payableObjects)
                {
                    SortedList.Add((Employee)emp);
                }
            }
            else if (SelectedOrder.DisplayName == "Descending")
            {
                SortedList.Clear();
                Array.Sort(payableObjects, Employee.sortPayAmountAscending());
                foreach (var emp in payableObjects)
                {
                    SortedList.Insert(0, (Employee)emp);
                }
            }

        }

        private void SortBySSNFxn(object p)
        {
            Reload(p);
            if (SelectedOrder.DisplayName == "Ascending")
            {
                SortedList.Clear();
                SelectionSort(payableObjects, NumericallyGreaterThan);
                foreach (var emp in payableObjects)
                {
                    SortedList.Insert(0, (Employee)emp);
                }
            }
            else if (SelectedOrder.DisplayName == "Descending")
            {
                SortedList.Clear();
                SelectionSort(payableObjects, NumericallyGreaterThan);
                foreach (var emp in payableObjects)
                {
                    SortedList.Add((Employee)emp);
                }
            }

        }

        private void SortByLastNameFxn(object p)
        {
            Reload(p);
            if (SelectedOrder.DisplayName == "Ascending")
            {
                SortedList.Clear();
                Array.Sort<IPayable>(payableObjects);
                foreach (var emp in payableObjects)
                {
                    SortedList.Insert(0, (Employee)emp);
                }
            }
            else if (SelectedOrder.DisplayName == "Descending")
            {
                SortedList.Clear();
                Array.Sort<IPayable>(payableObjects);
                foreach (var emp in payableObjects)
                {
                    SortedList.Add((Employee)emp);
                }
            }
        }

        /// <summary>
        /// Static SelectionSort method to implement Selection sort of given collection
        /// </summary>
        /// <param name="payableObjects"></param>
        /// <param name="comparisonMethod"></param>
        public static void SelectionSort(IPayable[] payableObjects, ComparisonHandler comparisonMethod)
        {
            int min_key;
            IPayable tmp;
            for (int j = 0; j < payableObjects.Length - 1; j++)
            {
                min_key = j;

                for (int k = j + 1; k < payableObjects.Length; k++)
                {
                    if (comparisonMethod(payableObjects[k], payableObjects[min_key]))
                    {
                        min_key = k;
                    }
                }

                tmp = payableObjects[min_key];
                payableObjects[min_key] = payableObjects[j];
                payableObjects[j] = tmp;
            }
        }

        /// <summary>
        /// Delegate to return comparision result between two objects of collection
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <returns>Boolean</returns>
        public delegate bool ComparisonHandler(IPayable first, IPayable second);

        /// <summary>
        /// Function of class Program to return boolean of comparision
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <returns>Boolean</returns>
        public static bool GreaterThan(IPayable first, IPayable second)
        {
            return int.Parse(((Employee)first).SocialSecurityNumber) > int.Parse(((Employee)second).SocialSecurityNumber);
        }

        /// <summary>
        /// Delegate function implementation
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <returns>Boolean</returns>
        public static bool NumericallyGreaterThan(IPayable first, IPayable second)
        {
            int comparison;
            comparison = (((Employee)first).SocialSecurityNumber.ToString().CompareTo(((Employee)second).SocialSecurityNumber.ToString()));
            return comparison > 0;
        }

    }
}
