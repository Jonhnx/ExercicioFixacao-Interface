namespace Services
{
    public class PaypalService : IOnlinePaymentService
    {
        private double Interest = 0.01;
        private double Fee = 0.02;

        public double InstallmentValue(double installment, int mounthNumber)
        {
            double value = installment + (installment * Interest * mounthNumber);
            return value += (value * Fee);
        }
    }
}
