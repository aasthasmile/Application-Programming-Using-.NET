using System;
using System.Collections;

namespace Assignment5.Model
{
    /// <summary>
    /// Internal abstract class BasePlusCommisionEmployee derives from base class CommissionEmployee
    /// </summary>
    internal abstract class Employee : IPayable
    {
        // read-only property that gets employee's first name
        public string FirstName { get; private set; }

        // read-only property that gets employee's last name
        public string LastName { get; private set; }

        // read-only property that gets employee's social security number
        public string SocialSecurityNumber { get; private set; }

        // read-only property that gets employee's Pay amount
        public decimal PayAmount { get; set; }

        /// <summary>
        /// three-parameter constructors
        /// </summary>
        /// <param name="first"></param>
        /// <param name="last"></param>
        /// <param name="ssn"></param>
        public Employee(string first, string last, string ssn)
        {
            FirstName = first;
            LastName = last;
            SocialSecurityNumber = ssn;
        } // end three-parameter Employee constructor

        /// <summary>
        /// return string representation of Employee object, using properties
        /// </summary>
        /// <returns>String representation of the Employee object</returns>
        public override string ToString()
        {
            return string.Format("{0} {1}\nsocial security number: {2}", FirstName, LastName, SocialSecurityNumber);
        } // end method ToString

        public abstract decimal GetPaymentAmount();

        /// <summary>
        /// Sorting class implementing IComparer
        /// </summary>
        private class sortPayAmountAscendingHelper : IComparer
        {
            int IComparer.Compare(object a, object b)
            {
                Employee c1 = (Employee)a;
                Employee c2 = (Employee)b;

                if (c1.GetPaymentAmount() > c2.GetPaymentAmount())
                    return 1;

                if (c1.GetPaymentAmount() < c2.GetPaymentAmount())
                    return -1;

                else
                    return 0;
            }
        }

        /// <summary>
        /// Compare function for IComparable implementation
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public int CompareTo(IPayable other)
        {
            Employee c = (Employee)other;
            return -(string.Compare(LastName, c.LastName));
        }

        /// <summary>
        /// Method to return IComparer object for sort helper.
        /// </summary>
        /// <returns>Delegate sortPayAmountAscendingHelper</returns>
        public static IComparer sortPayAmountAscending()
        {
            return new sortPayAmountAscendingHelper();
        }
    }
}