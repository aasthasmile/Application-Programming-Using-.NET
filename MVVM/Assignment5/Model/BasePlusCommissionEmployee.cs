using System;


namespace Assignment5.Model
{
    /// <summary>
    /// Internal class BasePlusCommisionEmployee derives from base class CommissionEmployee
    /// </summary>
    internal class BasePlusCommissionEmployee : CommissionEmployee
    {
        // base salary per week
        private decimal baseSalary;

        /// <summary>
        /// the basic BasePlusCommissionEmployee class constructor
        /// six-parameter constructor
        /// </summary>
        /// <param name="first"></param>
        /// <param name="last"></param>
        /// <param name="ssn"></param>
        /// <param name="sales"></param>
        /// <param name="rate"></param>
        /// <param name="salary"></param>
        public BasePlusCommissionEmployee(string first, string last, string ssn, decimal sales, decimal rate, decimal salary) : base( first, last, ssn, sales, rate)
        {
            // validate base salary via property
            BaseSalary = salary; 
        } // end six-parameter BasePlusCommissionEmployee constructor

        /// <summary>
        /// BaseSalary property of BasePlusCommissionEmployee class storing the base salary of the employee
        /// property that gets and sets 
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
        /// calculate earnings; override method GetPaymentAmount in CommissionEmployee
        /// </summary>
        /// <returns>Decimal BaseSalary + Commision Salary</returns>
        public override decimal GetPaymentAmount()
        {
            return BaseSalary + base.GetPaymentAmount();
        } // end method GetPaymentAmount               

        /// <summary>
        /// return string representation of BasePlusCommissionEmployee object
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("base-salaried {0}; base salary: {1:C}", base.ToString(), BaseSalary);
        } // end method ToString 
    }
}