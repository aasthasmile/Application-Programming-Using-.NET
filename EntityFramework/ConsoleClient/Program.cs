using Mm.BusinessLayer;
using Mm.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            IBusinessLayer businessLayer = new BuinessLayer();

            Console.WriteLine("\n.Choose one of the option :");
            Console.WriteLine("\n1.Create new Student.\n2.Update the existing student.\n3.Delete a existing student\n4.Display all standard table\n5. Press 5 to skip.\n");
            Console.WriteLine("User Input(Choose 1-5) :");
            int read = int.Parse(Console.ReadLine());
            switch (read)
            {
                case 1:
                    Console.WriteLine("\nEnter Standard Name : ");
                    Standard create = new Standard() { StandardName = Console.ReadLine(), StandardId = businessLayer.GetAllStandards().Count };
                    Console.WriteLine("\nEnter Standard Description : ");
                    create.Description = Console.ReadLine();
                    businessLayer.AddStandard(create);
                    Console.WriteLine("\n\tStudent Name\n\t Student Id\n\t Standard Description");
                    Console.WriteLine("--------------------------------------------------------");
                    Console.WriteLine("\n\t{0}\n\t {1}\n\t{2}", create.StandardName, create.StandardId, create.Description);
                     break;
                case 2:
                    Console.WriteLine("\n 1.Search by Standard Id\t\t 2.Search by Standard Name");
                    int upd = int.Parse(Console.ReadLine());
                    switch (upd)
                    {
                        case 1:
                            
                            break;
                        case 2:
                            break;

                    }
                    break;
                case 3:
                    break;
                case 4:
                    break;

            }
        }
    }
}
