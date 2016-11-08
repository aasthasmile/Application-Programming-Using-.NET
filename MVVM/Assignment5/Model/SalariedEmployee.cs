using System;

namespace Assignment5.Model
{
    /// <summary>
    /// Internal HourlyEmployee class that is derived from Employee class
    /// </summary>
    internal class SalariedEmployee : Employee
    {
        private decimal weeklySalary;

        /// <summary>
        /// four-parameter constructor
        /// </summary>
        /// <param name="first"></param>
        /// <param name="last"></param>
        /// <param name="ssn"></param>
        /// <param name="salary"></param>
        public SalariedEmployee(string first, string last, string ssn, decimal salary) : base(first, last, ssn)
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
                    throw new ArgumentOutOfRangeException("WeeklySalary", value, "WeeklySalary must be >= 0");
            } // end set
        } // end property WeeklySalary

        /// <summary>
        /// calculate earnings; override abstract method GetPaymentAmount in Employee
        /// </summary>
        /// <returns>Decimal value for calculating employee salary</returns>
        public override decimal GetPaymentAmount()
        {
            return WeeklySalary;
        } // end method GetPaymentAmount          

        /// <summary>
        /// return string representation of SalariedEmployee object
        /// </summary>
        /// <returns>String</returns>
        public override string ToString()
        {
            return string.Format("salaried employee: {0}\n{1}: {2:C}", base.ToString(), "weekly salary", WeeklySalary);
        } // end method ToString                 
    }
}