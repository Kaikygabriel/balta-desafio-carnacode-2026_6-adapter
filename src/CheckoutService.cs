using src.Interfaces;
using src.Services.Request;

namespace src;

public class CheckoutService
{
    private readonly IPaymentProcessor _paymentProcessor;

    public CheckoutService(IPaymentProcessor paymentProcessor)
    {
        _paymentProcessor = paymentProcessor;
    }

    public void CompleteOrder(string customerEmail, decimal amount, string cardNumber)
    {
        Console.WriteLine($"\n=== Finalizando Pedido ===");
        Console.WriteLine($"Cliente: {customerEmail}");
        Console.WriteLine($"Valor: {amount:C}\n");

        var request = new PaymentRequest
        {
            CustomerEmail = customerEmail,
            Amount = 1,
            CreditCardNumber = cardNumber,
            Cvv = 123,
            ExpirationDate = new DateTime(2026, 12, 31),
            Description = "Compra de produtos"
        };

        var result = _paymentProcessor.ProcessPayment(request,1,2);

        if (result.Success)
        {
            Console.WriteLine($"✅ Pedido aprovado! ID: {result.TransactionId}");
        }
        else
        {
            Console.WriteLine($"❌ Pagamento recusado: {result.Message}");
        }
    }
}
