using System;

namespace Assignment5.Model
{
    /// <summary>
    /// Internal HourlyEmployee class that is derived from Employee class
    /// </summary>
    internal class HourlyEmployee : Employee
    {
        private decimal wage; // wage per hour
        private decimal hours; // hours worked for the week

        /// <summary>
        /// five-parameter constructor
        /// </summary>
        /// <param name="first"></param>
        /// <param name="last"></param>
        /// <param name="ssn"></param>
        /// <param name="hourlyWage"></param>
        /// <param name="hoursWorked"></param>
        public HourlyEmployee(string first, string last, string ssn, decimal hourlyWage, decimal hoursWorked) : base(first, last, ssn)
        {
            Wage = hourlyWage; // validate hourly wage via property
            Hours = hoursWorked; // validate hours worked via property
        } // end five-parameter HourlyEmployee constructor

        /// <summary>
        /// property that gets and sets hourly employee's wage
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
        /// property that gets and sets hourly employee's hours
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
        /// calculate earnings; override Employee’s abstract method GetPaymentAmount
        /// </summary>
        /// <returns>Decimal value of Hourly Employee payment</returns>
        public override decimal GetPaymentAmount()
        {
            if (Hours <= 40) // no overtime                          
                return Wage * Hours;
            else
                return (40 * Wage) + ((Hours - 40) * Wage * 1.5M);
        } // end method GetPaymentAmount                                      

        /// <summary>
        /// return string representation of HourlyEmployee object
        /// </summary>
        /// <returns>String representation of employee work hours and wage</returns>
        public override string ToString()
        {
            return string.Format(
               "hourly employee: {0}\n{1}: {2:C}; {3}: {4:F2}", base.ToString(), "hourly wage", Wage, "hours worked", Hours);
        } // end method ToString       
    }
}