using System;
using System.Collections.Generic; 

namespace PayPalContractGenerator.Services
{
    internal class PaypalService : IOnlinePaymentService
    {
        private const double FeePercentage = 0.02;
        private const double Month1yInterest = 0.01; 

        public double Interest(double amount, int months)
        {
            return amount * Month1yInterest * months; 
        }

        public double PaymentFee(double amount)
        {
            return amount * FeePercentage;  
        }

    }
}
