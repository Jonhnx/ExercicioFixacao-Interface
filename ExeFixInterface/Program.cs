using System;
using Entities;
using Services;

namespace ExeFixInterface
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter contract data");
            Console.Write("Number: ");
            int number = int.Parse(Console.ReadLine());
            Console.Write("Date(dd / MM / yyyy): ");
            DateTime date = DateTime.Parse(Console.ReadLine());
            Console.Write("Contract value: ");
            double totalValue = double.Parse(Console.ReadLine());

            Contract contract = new Contract(number, date, totalValue);

            Console.Write("Enter number of installments: ");
            int installmentsQuantity = int.Parse(Console.ReadLine());

            ContractService cs = new ContractService(contract, new PaypalService(), installmentsQuantity);

            Console.WriteLine("Installments: ");
            foreach (Installment installment in contract.Installments)
            {
                Console.WriteLine(installment);
            }
        }
    }
}
