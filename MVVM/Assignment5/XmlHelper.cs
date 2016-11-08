using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Assignment5.Model;

namespace Assignment5
{
    class XmlHelper
    {
        public static IEnumerable<Employee> StreamEmployees(string uri)
        {
            using (XmlReader reader = XmlReader.Create(uri))
            {
                string firstName = null;
                string lastName = null;
                string ssn = null;
                decimal salary = 0;
                decimal hourlyWage = 0;
                decimal hoursWorked = 0;
                decimal sales = 0;
                decimal rate = 0;

                reader.MoveToContent();
                while (reader.Read())
                {
                    #region SalariedEmployee
                    if (reader.NodeType == XmlNodeType.Element
                        && reader.Name == "SalariedEmployee")
                    {
                        while (reader.Read())
                        {
                            if (reader.NodeType == XmlNodeType.Element &&
                                reader.Name == "FirstName")
                            {
                                firstName = reader.ReadString().Replace("\n", "").Replace("\t", "");
                                break;
                            }
                        }
                        while (reader.Read())
                        {
                            if (reader.NodeType == XmlNodeType.Element &&
                                reader.Name == "LastName")
                            {
                                lastName = reader.ReadString().Replace("\n", "").Replace("\t", "");
                                break;
                            }
                        }
                        while (reader.Read())
                        {
                            if (reader.NodeType == XmlNodeType.Element &&
                                reader.Name == "SSN")
                            {
                                ssn = reader.ReadString().Replace("\n", "").Replace("\t", "");
                                break;
                            }
                        }
                        while (reader.Read())
                        {
                            if (reader.NodeType == XmlNodeType.Element &&
                                reader.Name == "Salary")
                            {
                                salary = decimal.Parse(reader.ReadString());
                                break;
                            }
                        }
                        yield return new SalariedEmployee(firstName, lastName, ssn, salary);
                    }
                    #endregion
                    
                    #region HourlyEmployee
                    if (reader.NodeType == XmlNodeType.Element
                        && reader.Name == "HourlyEmployee")
                    {
                        while (reader.Read())
                        {
                            if (reader.NodeType == XmlNodeType.Element &&
                                reader.Name == "FirstName")
                            {
                                firstName = reader.ReadString().Replace("\n", "").Replace("\t", "");
                                break;
                            }
                        }
                        while (reader.Read())
                        {
                            if (reader.NodeType == XmlNodeType.Element &&
                                reader.Name == "LastName")
                            {
                                lastName = reader.ReadString().Replace("\n", "").Replace("\t", "");
                                break;
                            }
                        }
                        while (reader.Read())
                        {
                            if (reader.NodeType == XmlNodeType.Element &&
                                reader.Name == "SSN")
                            {
                                ssn = reader.ReadString().Replace("\n", "").Replace("\t", "");
                                break;
                            }
                        }
                        while (reader.Read())
                        {
                            if (reader.NodeType == XmlNodeType.Element &&
                                reader.Name == "HourlyWage")
                            {
                                hourlyWage = decimal.Parse(reader.ReadString());
                                break;
                            }
                        }
                        while (reader.Read())
                        {
                            if (reader.NodeType == XmlNodeType.Element &&
                                reader.Name == "HoursWorked")
                            {
                                hoursWorked = decimal.Parse(reader.ReadString());
                                break;
                            }
                        }
                        yield return new HourlyEmployee(firstName, lastName, ssn, hourlyWage, hoursWorked);
                    }
                    #endregion

                    #region CommissionEmployee
                    if (reader.NodeType == XmlNodeType.Element
                        && reader.Name == "CommissionEmployee")
                    {
                        while (reader.Read())
                        {
                            if (reader.NodeType == XmlNodeType.Element &&
                                reader.Name == "FirstName")
                            {
                                firstName = reader.ReadString().Replace("\n", "").Replace("\t", "");
                                break;
                            }
                        }
                        while (reader.Read())
                        {
                            if (reader.NodeType == XmlNodeType.Element &&
                                reader.Name == "LastName")
                            {
                                lastName = reader.ReadString().Replace("\n", "").Replace("\t", "");
                                break;
                            }
                        }
                        while (reader.Read())
                        {
                            if (reader.NodeType == XmlNodeType.Element &&
                                reader.Name == "SSN")
                            {
                                ssn = reader.ReadString().Replace("\n", "").Replace("\t", "");
                                break;
                            }
                        }
                        while (reader.Read())
                        {
                            if (reader.NodeType == XmlNodeType.Element &&
                                reader.Name == "Sales")
                            {
                                sales = decimal.Parse(reader.ReadString());
                                break;
                            }
                        }
                        while (reader.Read())
                        {
                            if (reader.NodeType == XmlNodeType.Element &&
                                reader.Name == "Rate")
                            {
                                rate = decimal.Parse(reader.ReadString());
                                break;
                            }
                        }
                        yield return new CommissionEmployee(firstName, lastName, ssn, sales, rate);
                    }
                    #endregion

                    #region BasePlusCommissionEmployee
                    if (reader.NodeType == XmlNodeType.Element
                        && reader.Name == "BasePlusCommissionEmployee")
                    {
                        while (reader.Read())
                        {
                            if (reader.NodeType == XmlNodeType.Element &&
                                reader.Name == "FirstName")
                            {
                                firstName = reader.ReadString().Replace("\n", "").Replace("\t", "");
                                break;
                            }
                        }
                        while (reader.Read())
                        {
                            if (reader.NodeType == XmlNodeType.Element &&
                                reader.Name == "LastName")
                            {
                                lastName = reader.ReadString().Replace("\n", "").Replace("\t", "");
                                break;
                            }
                        }
                        while (reader.Read())
                        {
                            if (reader.NodeType == XmlNodeType.Element &&
                                reader.Name == "SSN")
                            {
                                ssn = reader.ReadString().Replace("\n", "").Replace("\t", "");
                                break;
                            }
                        }
                        while (reader.Read())
                        {
                            if (reader.NodeType == XmlNodeType.Element &&
                                reader.Name == "Sales")
                            {
                                sales = decimal.Parse(reader.ReadString());
                                break;
                            }
                        }
                        while (reader.Read())
                        {
                            if (reader.NodeType == XmlNodeType.Element &&
                                reader.Name == "Rate")
                            {
                                rate = decimal.Parse(reader.ReadString());
                                break;
                            }
                        }
                        while (reader.Read())
                        {
                            if (reader.NodeType == XmlNodeType.Element &&
                                reader.Name == "Salary")
                            {
                                salary = decimal.Parse(reader.ReadString());
                                break;
                            }
                        }
                        yield return new BasePlusCommissionEmployee(firstName, lastName, ssn, sales, rate, salary);
                    }
                    #endregion
                }
            }
        }
    }
}
