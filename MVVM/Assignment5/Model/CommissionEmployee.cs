using System;

namespace Assignment5.Model
{
    /// <summary>
    /// Internal class CommisionEmployee derives from base class Employee
    /// </summary>
    internal class CommissionEmployee : Employee
    {
        private decimal grossSales; // gross weekly sales
        private decimal commissionRate; // commission percentage

        /// <summary>
        /// five-parameter constructor
        /// </summary>
        /// <param name="first"></param>
        /// <param name="last"></param>
        /// <param name="ssn"></param>
        /// <param name="sales"></param>
        /// <param name="rate"></param>
        public CommissionEmployee(string first, string last, string ssn, decimal sales, decimal rate) : base(first, last, ssn)
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
                    throw new ArgumentOutOfRangeException("GrossSales", value, "GrossSales must be >= 0");
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
                    throw new ArgumentOutOfRangeException("CommissionRate", value, "CommissionRate must be > 0 and < 1");
            } // end set
        } // end property CommissionRate

        /// <summary>
        /// calculate earnings; override abstract method GetPaymentAmount in Employee
        /// </summary>
        /// <returns> Decimal as total payment amount</returns>
        public override decimal GetPaymentAmount()
        {
            return CommissionRate * GrossSales;
        } // end method GetPaymentAmount              

        /// <summary>
        /// return string representation of CommissionEmployee object
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("{0}: {1}\n{2}: {3:C}\n{4}: {5:F2}", "commission employee", base.ToString(), "gross sales", GrossSales, "commission rate", CommissionRate);
        } // end method ToString 
    }
}