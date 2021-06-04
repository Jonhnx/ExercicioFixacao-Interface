using Entities;
using System;

namespace Services
{
    public class ContractService
    {
        private Contract Contract { get; set; }

        private IOnlinePaymentService _onlinePaymentService;

        public ContractService(Contract contract, IOnlinePaymentService onlinePaymentService, int installmentQuantity)
        {
            Contract = contract;
            _onlinePaymentService = onlinePaymentService;
            ProcessContract(Contract, installmentQuantity);
        }

        public void ProcessContract(Contract contract, int mounths)
        {
            double basicValue = contract.TotalValue / mounths;
            DateTime date = contract.Date;
            for (int i = 1; i <= mounths; i++)
            {
                date = date.AddMonths(1);
                DateTime dueDate = date;
                double installmentValue = _onlinePaymentService.InstallmentValue(basicValue, i);
                Installment installment = new Installment(dueDate, installmentValue);
                Contract.Installments.Add(installment);
            }
        }
    }
}