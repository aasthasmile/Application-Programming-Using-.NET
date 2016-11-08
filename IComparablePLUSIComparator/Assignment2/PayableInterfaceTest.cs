using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    /// <summary>
    /// Ipayable is the interface .It has a method of GetPaymentAmount() which is extended by Employee abstract class.
    /// </summary>
    public interface IPayable
    {
        decimal GetPaymentAmount();
        /// <summary>
        /// calculate payment; no implementation
        /// </summary>   

    } 
    // end interface IPayable

    /// <summary>
    /// This is the abstract class EMPLOYEE.It extends IPayable interface and IComparable interface in order
    /// to perform sorting operation on the data.
    /// </summary>
    public abstract class Employee : IPayable ,IComparable
    {
        /// <summary>
        /// read-only property that gets employee's first name
        /// </summary>

        public string FirstName { get; private set; }

        /// <summary>
        ///  read-only property that gets employee's last name
        /// </summary>
        public string LastName { get; private set; }

        /// <summary>
        ///  read-only property that gets employee's social security number
        /// </summary>
        public string SocialSecurityNumber { get; private set; }

        /// <summary>
        /// three-parameter constructor
        /// </summary>
        /// <param name="first">First Name</param>
        /// <param name="last">Last Name</param>
        /// <param name="ssn">SSN </param>

        public Employee(string first, string last, string ssn)
        {
            FirstName = first;
            LastName = last;
            SocialSecurityNumber = ssn;
        } // end three-parameter Employee constructor

        /// <summary>
        ///  return string representation of Employee object, using properties
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("{0} {1}\nsocial security number: {2}",
               FirstName, LastName, SocialSecurityNumber);
        } // end method ToString

        /// <summary>
        /// Method GetPaymentAmount extended from interface IPayable
        /// </summary>
        /// <returns></returns>
        public abstract decimal GetPaymentAmount();

        /// <summary>
        /// IComparable CompareTo method in order to compare the last name of 
        /// the employee and then sort them in descending order using this method.
        /// </summary>
        /// <param name="obj">obj specifies the LastName which need to be compared</param>
        /// <returns>It returns an integer value of 0,1,-1 depending on value is equalto,greaterthan or lessthan</returns>
        public int CompareTo(object obj)
        {
            Employee emp = (Employee)obj;
            return String.Compare(this.LastName, emp.LastName);

        }

    } // end abstract class Employee

    /// <summary>
    /// sortPayAmountbyDescendingOrder is the class created in order to apply Icomparer method Compare.
    /// Icomparer.compare ethod requires a tertiary comparison. 1, 0, or -1 is returned depending on 
    /// whether one value is greater than, equal to, or less than the other. The sort order (ascending or descending)
    /// can be changed by switching the logical operators in this method.
    /// </summary>
    public class sortPayAmountbyDescendingOrder : IComparer
    {
        /// <summary>
        /// IComparer to compare two Employee objects
        /// </summary>
        /// <param name="x">object 1</param>
        /// <param name="y">object 2</param>
        /// <returns>Returns a tertiary comparison. 1, 0, or -1 </returns>
        int IComparer.Compare(object x, object y)
        {
           Employee emp1 = (Employee)x;
           Employee emp2 = (Employee)y;
            if (emp1.GetPaymentAmount() > emp2.GetPaymentAmount())
                return 1;
            if (emp1.GetPaymentAmount() < emp2.GetPaymentAmount())
                return -1;
            else
                return 0;
        }
    }

    /// <summary>
    /// Hourly Emloyee signify employee paid on the basis of 2 paremeters:
    /// wage :wage per hour AND hours :no of hours worked for the week
    /// It extends the base class Employee.
    /// </summary>
    public class HourlyEmployee : Employee
    {
        /// <summary>
        /// wage per hour
        /// </summary>
        private decimal wage;
        /// <summary>
        ///  hours worked for the week
        /// </summary>
        private decimal hours;

        /// <summary>
        /// five-parameter constructor with base class as Employee extending Employee constructor.
        /// </summary>

        public HourlyEmployee(string first, string last, string ssn,
           decimal hourlyWage, decimal hoursWorked)
           : base(first, last, ssn)
        {
            Wage = hourlyWage; // validate hourly wage via property
            Hours = hoursWorked; // validate hours worked via property
        } // end five-parameter HourlyEmployee constructor

        /// <summary>
        ///  property that gets and sets hourly employee's wage
        /// </summary>
        public decimal Wage
        {
            get
            {
                return wage;
            } // end get
            set
            {
                if (value >= 0) // validation
                    wage = value;
                else
                    throw new ArgumentOutOfRangeException("Wage", value, "Wage must be >= 0");
            } // end set
        } // end property Wage

        /// <summary>
        /// 
        /// </summary>
                 
        public decimal Hours
        {
            get
            {
                return hours;
            } // end get
            set
            {
                if (value >= 0 && value <= 168) // validation
                    hours = value;
                else
                    throw new ArgumentOutOfRangeException("Hours", value, "Hours must be >= 0 and <= 168");
            } // end set
        } // end property Hours

        /// <summary>
        ///  calculate earnings; override Employee’s abstract method Earnings
        /// </summary>
        /// <returns> Payment Amount</returns>
        public override decimal GetPaymentAmount()
        {
            if (Hours <= 40) // no overtime                          
                return Wage * Hours;
            else
                return (40 * Wage) + ((Hours - 40) * Wage * 1.5M);
        } // end method Earnings                                      

        /// <summary>
        ///  return string representation of HourlyEmployee object
        /// </summary>
        /// <returns>String for hourly employee in term of wages and hours</returns>
        public override string ToString()
        {
            return string.Format(
               "hourly employee: {0}\n{1}: {2:C}; {3}: {4:F2}",  //????
               base.ToString(), "hourly wage", Wage, "hours worked", Hours);
        } // end method ToString                                            
    } // end class HourlyEmployee

    /// <summary>
    /// Commmission Employee is being paid on 2 parameters :
    /// 1.grossSale : the amount of weekly sales 2.Commission Percentage : The commisssion amount that should be used.
    /// </summary>
    public class CommissionEmployee : Employee
    {
        private decimal grossSales; // gross weekly sales
        private decimal commissionRate; // commission percentage

        /// <summary>
        /// five-parameter constructor
        /// </summary>
        /// <param name="first">First Name</param>
        /// <param name="last">Last Name</param>
        /// <param name="ssn">Social Security Number</param>
        /// <param name="sales">Gross Sales</param>
        /// <param name="rate">Commission Rate</param>


        public CommissionEmployee(string first, string last, string ssn,
           decimal sales, decimal rate) : base(first, last, ssn)
        {
            GrossSales = sales; // validate gross sales via property
            CommissionRate = rate; // validate commission rate via property
        } // end five-parameter CommissionEmployee constructor

        /// <summary>
        /// property that gets and sets commission employee's gross sales
        /// </summary>
           public decimal GrossSales
        {
            get
            {
                return grossSales;
            } // end get
            set
            {
                if (value >= 0)
                    grossSales = value;
                else
                    throw new ArgumentOutOfRangeException(
                       "GrossSales", value, "GrossSales must be >= 0");
            } // end set
        } // end property GrossSales

        /// <summary>
        /// property that gets and sets commission employee's commission rate
        /// </summary>

        public decimal CommissionRate
        {
            get
            {
                return commissionRate;
            } // end get
            set
            {
                if (value > 0 && value < 1)
                    commissionRate = value;
                else
                    throw new ArgumentOutOfRangeException("CommissionRate",
                       value, "CommissionRate must be > 0 and < 1");
            } // end set
        } // end property CommissionRate

        /// <summary>
        /// calculate earnings; override abstract method Earnings in Employee
        /// </summary>
        /// <returns>CommisionRate * GrossSales</returns>

        public override decimal GetPaymentAmount()
        {
            return CommissionRate * GrossSales;
        } // end method Earnings              

        /// <summary>
        /// return string representation of CommissionEmployee object
        /// </summary>
        /// <returns>String to show Commission Employee : Gross Sales and ComisssionRate</returns>

        public override string ToString()
        {
            return string.Format("{0}: {1}\n{2}: {3:C}\n{4}: {5:F2}",
               "commission employee", base.ToString(),
               "gross sales", GrossSales, "commission rate", CommissionRate);
        } // end method ToString 


        /// <summary>
        /// The application should increase the BasePlusCommissionEmployee’s base salary by 10%. 
        /// </summary>
        public class BasePlusCommissionEmployee : CommissionEmployee
        {
            /// <summary>
            ///  base salary per week
            /// </summary>
            private decimal baseSalary;

            /// <summary>
            ///  six-parameter constructor
            /// </summary>
            /// <param name="first">First Name</param>
            /// <param name="last">Last Name</param>
            /// <param name="ssn">Social Security Number</param>
            /// <param name="sales">Gross Sales</param>
            /// <param name="rate">Commission Rate</param>
            /// <param name="salary">Base Salary</param>
            public BasePlusCommissionEmployee(string first, string last,
               string ssn, decimal sales, decimal rate, decimal salary) : base(first, last, ssn, sales, rate)

            {
                BaseSalary = salary; // validate base salary via property
            } // end six-parameter BasePlusCommissionEmployee constructor

            /// <summary>
            ///  property that gets and sets 
            /// base-salaried commission employee's base salary
            /// </summary>
            public decimal BaseSalary
            {
                get
                {
                    return baseSalary;
                } // end get
                set
                {
                    if (value >= 0)
                        baseSalary = value;
                    else
                        throw new ArgumentOutOfRangeException("BaseSalary", value, "BaseSalary must be >= 0");
                } // end set
            } // end property BaseSalary

            /// <summary>
            /// calculate earnings; override method Earnings in CommissionEmployee
            /// </summary>
            /// <returns>BaseSalary plus Payment Amount</returns>

            public override decimal GetPaymentAmount()
            {
                return BaseSalary + base.GetPaymentAmount();
            } // end method Earnings               

            /// <summary>
            /// return string representation of BasePlusCommissionEmployee object
            /// </summary>
            /// <returns></returns>
            public override string ToString()
            {
                return string.Format("base-salaried {0}; base salary: {1:C}",
                   base.ToString(), BaseSalary);
            } /// end method ToString                                            
        } // end class BasePlusCommissionEmployee


        /// <summary>
        /// SalariedEmployee extends the baseclass Employee.
        /// Salaried employee calculates the weekly salary .
        /// </summary>
        public class SalariedEmployee : Employee
        {
            private decimal weeklySalary;

            /// <summary>
            ///  four-parameter constructor
            /// </summary>
            public SalariedEmployee(string first, string last, string ssn,
               decimal salary) : base(first, last, ssn)
            {
                WeeklySalary = salary; // validate salary via property
            } // end four-parameter SalariedEmployee constructor

            /// <summary>
            /// property that gets and sets salaried employee's salary
            /// </summary>

            public decimal WeeklySalary
            {
                get
                {
                    return weeklySalary;
                } // end get
                set
                {
                    if (value >= 0) // validation
                        weeklySalary = value;
                    else
                        throw new ArgumentOutOfRangeException("WeeklySalary",
                           value, "WeeklySalary must be >= 0");
                } // end set
            } // end property WeeklySalary

            /// <summary>
            /// calculate earnings; override abstract method Earnings in Employee
            /// </summary>
            /// <returns>Decimal WeeklySalary</returns>

            public override decimal GetPaymentAmount()
            {
                return WeeklySalary;
            } // end method Earnings          

            /// <summary>
            /// return string representation of SalariedEmployee object
            /// </summary>
            /// <returns>String to display weekly salary</returns>

            public override string ToString()
            {
                return string.Format("salaried employee: {0}\n{1}: {2:C}", base.ToString(), "weekly salary", WeeklySalary);
            } // end method ToString                                      
        } // end class SalariedEmployee



        public class PayrollSystemTest
        {
           /*public static void Main(string[] args)
            {
                // create derived class objects
                SalariedEmployee salariedEmployee =
                   new SalariedEmployee("John", "Smith", "111-11-1111", 800.00M);
                HourlyEmployee hourlyEmployee =
                   new HourlyEmployee("Karen", "Price",
                   "222-22-2222", 16.75M, 40.0M);
                CommissionEmployee commissionEmployee =
                   new CommissionEmployee("Sue", "Jones",
                   "333-33-3333", 10000.00M, .06M);
                BasePlusCommissionEmployee basePlusCommissionEmployee =
                   new BasePlusCommissionEmployee("Bob", "Lewis",
                   "444-44-4444", 5000.00M, .04M, 300.00M);

                Console.WriteLine("Employees processed individually:\n");

                Console.WriteLine("{0}\nearned: {1:C}\n",
                   salariedEmployee, salariedEmployee.GetPaymentAmount());
                Console.WriteLine("{0}\nearned: {1:C}\n",
                   hourlyEmployee, hourlyEmployee.GetPaymentAmount());
                Console.WriteLine("{0}\nearned: {1:C}\n",
                   commissionEmployee, commissionEmployee.GetPaymentAmount());
                Console.WriteLine("{0}\nearned: {1:C}\n",
                   basePlusCommissionEmployee,
                   basePlusCommissionEmployee.GetPaymentAmount());

                // create four-element Employee array
                Assignment2.Employee[] employees = new Assignment2.Employee[4];

                // initialize array with Employees of derived types
                employees[0] = salariedEmployee;
                employees[1] = hourlyEmployee;
                employees[2] = commissionEmployee;
                employees[3] = basePlusCommissionEmployee;

                Console.WriteLine("Employees processed polymorphically:\n");

                // generically process each element in array employees
                foreach (Assignment2.Employee currentEmployee in employees)
                {
                    Console.WriteLine(currentEmployee); // invokes ToString

                    // determine whether element is a BasePlusCommissionEmployee
                    if (currentEmployee is BasePlusCommissionEmployee)
                    {
                        // downcast Employee reference to 
                        // BasePlusCommissionEmployee reference
                        BasePlusCommissionEmployee employee =
                           (BasePlusCommissionEmployee)currentEmployee;

                        employee.BaseSalary *= 1.10M;
                        Console.WriteLine(
                           "new base salary with 10% increase is: {0:C}",
                           employee.BaseSalary);
                    } // end if

                    Console.WriteLine(
                       "earned {0:C}\n", currentEmployee.GetPaymentAmount());
                } // end foreach

                // get type name of each object in employees array
                for (int j = 0; j < employees.Length; j++)
                    Console.WriteLine("Employee {0} is a {1}", j,
                       employees[j].GetType());
                Console.ReadLine();
            } // end Main*/
        } // end class PayrollSystemTest


        /// <summary>
        /// Payable Interface Test performs the operation of 
        /// performing selection sort and the menu to select
        /// one of three options :
        /// 1.sorting lastName
        /// 2.sorting payAmount
        /// 3.Sorting SSN
        /// </summary>
        public class PayableInterfaceTest
        {
            IPayable[] payableObjects = new IPayable[8];
            
           
            private static IPayable[] payableobjects;

            public delegate int sortingSSN(Object payable1,Object payable2);

            public static void selectionSort(Object payable,sortingSSN sortDelegate)
            {
                IPayable[] payableObjects = payableobjects as IPayable[];
                for(int i=0;i< payableObjects.GetLength(0)-2; i++)
                {
                    int amin =i;
                    for(int j=i+1;j< payableObjects.GetLength(0) - 1; j++)
                    {
                        if ( sortDelegate(payableObjects[amin] ,  payableObjects[j]) > 0)
                        {
                            amin = j;
                        }
                    /*   if(String.Compare(((Employee)payableObjects[amin]).SocialSecurityNumber ,((Employee)payableObjects[j]).SocialSecurityNumber )>0){
                           amin = j;
                       }*/
                    }
                    if (amin != i)
                    {
                        IPayable temp = payableObjects[amin];
                        payableObjects[amin] = payableObjects[i];
                        payableObjects[i] = temp;
                    }

                }

            }
            public PayableInterfaceTest() { 
                payableObjects[0] = new SalariedEmployee("John", "Smith", "111-11-1111", 700M);
                payableObjects[1] = new SalariedEmployee("Antonio", "Smith", "555-55-5555", 800M);
                payableObjects[2] = new SalariedEmployee("Victor", "Smith", "444-44-4444", 600M);
                payableObjects[3] = new HourlyEmployee("Karen", "Price", "222-22-2222", 16.75M, 40M);
                payableObjects[4] = new HourlyEmployee("Ruben", "Zamora", "666-66-6666", 20.00M, 40M);
                payableObjects[5] = new CommissionEmployee("Sue", "Jones", "333-33-3333", 10000M, .06M);
                payableObjects[6] = new BasePlusCommissionEmployee("Bob", "Lewis", "777-77-7777", 5000M, .04M, 300M);
                payableObjects[7] = new BasePlusCommissionEmployee("Lee", "Duarte", "888-88-8888", 5000M, .04M, 300M);
            }
            
            public static void Main(String[] args)
            {
                Console.ReadLine();
                Console.WriteLine("Menu: ");
                Console.WriteLine("\n1.Sort last name in descending order using IComparable");
                Console.WriteLine("2.Sort pay amount in ascending order using IComparer");
                Console.WriteLine("3.Sort by social security number in descending order using a selection sort and delegate");
                Console.WriteLine("4.Enter -1 to exit\n\n");

                PayableInterfaceTest obj = new PayableInterfaceTest();

                sortingSSN ssn_sorting = new sortingSSN( selectionSort);

                int input = 0;
                while (input != -1)
                {
                    Console.Write("\n\n Enter your choice :");
                    input = Convert.ToInt32(Console.ReadLine());
                    
                    switch (input)
                    {
                        case 1:
                            Console.WriteLine("\nSorting Last name by descending order : \n");
                            Array.Sort(obj.payableObjects);
                            for (int i = obj.payableObjects.GetLength(0) - 1; i >= 0; i--)
                            {
                                Console.WriteLine(((Employee)obj.payableObjects[i]).LastName + "\t" + ((Employee)obj.payableObjects[i]).FirstName + "\t" + ((Employee)obj.payableObjects[i]).SocialSecurityNumber);
                            }
                            break;
                        case 2:
                            Console.WriteLine("\nSorting Pay Amount in ascending order : ");
                            Array.Sort(obj.payableObjects, new sortPayAmountbyDescendingOrder());
                            for (int i = 0; i < obj.payableObjects.GetLength(0); i++)
                            {
                                Console.WriteLine(((Employee)obj.payableObjects[i]).GetPaymentAmount() + "\t" + ((Employee)obj.payableObjects[i]).FirstName +" "+ ((Employee)obj.payableObjects[i]).LastName+ "\t" + ((Employee)obj.payableObjects[i]).SocialSecurityNumber);
                            }
                            break;
                        case 3:Console.WriteLine("\nSorting SSN by descending order : ");
                            ssn_sorting(obj.payableObjects);
                            for (int i = 0; i < obj.payableObjects.GetLength(0); i++)
                            {
                                Console.WriteLine(((Employee)obj.payableObjects[i]).SocialSecurityNumber + "\t" + ((Employee)obj.payableObjects[i]).FirstName + " " + ((Employee)obj.payableObjects[i]).LastName + "\t");
                            }
                            break;
                        default:
                            Console.WriteLine("Wrong Input ! Enter 1 or 2 or 3 !!!");
                            break;

                    }
                    
                }
                Console.WriteLine("Employees processed polymorphically:\n");

                // generically process each element in array employees
                foreach (IPayable currentEmployee in obj.payableObjects)
                {
                    Console.WriteLine(currentEmployee); // invokes ToString

                    // determine whether element is a BasePlusCommissionEmployee
                    if (currentEmployee is BasePlusCommissionEmployee)
                    {
                        // downcast Employee reference to 
                        // BasePlusCommissionEmployee reference
                        BasePlusCommissionEmployee employee = (BasePlusCommissionEmployee)currentEmployee;
                        employee.BaseSalary *= 1.10M;
                        Console.WriteLine("new base salary with 10% increase is: {0:C}", employee.BaseSalary);
                    } // end if

                    Console.WriteLine("earned {0:C}\n", currentEmployee.GetPaymentAmount());
                } // end foreach

                // get type name of each object in employees array
                for (int j = 0; j < obj.payableObjects.Length; j++)
                    Console.WriteLine("Employee {0} is a {1}", j, obj.payableObjects[j].GetType());
                Console.ReadLine();
                
            }

        }


    }




}
