using Assignment5.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment5.Utility
{
    class SelectionSortClass
    {
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
