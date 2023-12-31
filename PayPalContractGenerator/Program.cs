using PayPalContractGenerator.Entties;
using PayPalContractGenerator.Services;
using System.Globalization;

namespace PayPalContractGenerator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // - ENTRADA DE DADOS  
            Console.WriteLine("Enter contract data");

            Console.Write("Number: ");
            int number = int.Parse(Console.ReadLine());

            Console.Write("Date (dd/MM/yyyy): ");
            DateTime dateContract = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", CultureInfo.InvariantCulture);

            Console.Write("Contract Value: ");
            double price = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            // quantidade de parcelas da lista 
            Console.Write("Enter number of installments: ");
            int months = int.Parse(Console.ReadLine());

            // - PROCESSAMENTO DE DADOS 
            Contract myContract = new Contract(number, dateContract, price);

            ContractService contractService = new ContractService(new PaypalService());

            contractService.CalculateAmountsInstallments(myContract, months);

            // SAIDA DE DADOS 
            Console.WriteLine("Installments: ");
            foreach (Installment installment in myContract.Installment)
            {
                Console.WriteLine(installment);
            }
        }
    }
}
