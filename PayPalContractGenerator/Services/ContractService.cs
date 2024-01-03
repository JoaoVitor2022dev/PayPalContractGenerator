using PayPalContractGenerator.Entties;
using System;

namespace PayPalContractGenerator.Services
{
    internal class ContractService
    {

        private IOnlinePaymentService _onlinePaymentService;

        public ContractService(IOnlinePaymentService onlinePaymentService)
        {
            _onlinePaymentService = onlinePaymentService;
        }

        public void CalculateAmountsInstallments(Contract contract, int months)
        {
            // quota 
            double basicQuota = contract.TotalValue / months; 

            for (int i = 1; i <= months; i++)
            {
                // modificando os dados da data 
                DateTime date = contract.Date.AddMonths(i);

                double updateQuota = basicQuota + _onlinePaymentService.Interest(basicQuota, i);

                double fullQuota = updateQuota + _onlinePaymentService.PaymentFee(updateQuota);

                contract.AddInstallment(new Installment(date, fullQuota));
            }
        }
    }
}
