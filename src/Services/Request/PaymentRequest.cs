namespace src.Services.Request;

public class PaymentRequest
{
    public string CustomerEmail { get; set; }
    public double Amount { get; set; }
    public string CreditCardNumber { get; set; }
    public int Cvv { get; set; }
    public DateTime ExpirationDate { get; set; }
    public string Description { get; set; }
}