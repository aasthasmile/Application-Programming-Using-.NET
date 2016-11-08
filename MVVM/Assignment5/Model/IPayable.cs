using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment5.Model
{
    /// <summary>
    /// Ipayable interface using Icomparable as base class
    /// </summary>
    interface IPayable : IComparable<IPayable>
    {
        decimal GetPaymentAmount(); // calculate payment; no implementation
    }
}
