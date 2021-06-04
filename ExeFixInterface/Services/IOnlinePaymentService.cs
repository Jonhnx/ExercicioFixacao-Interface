namespace Services
{
    public interface IOnlinePaymentService
    {
        double InstallmentValue(double installment, int mounthNumber);
    }
}
