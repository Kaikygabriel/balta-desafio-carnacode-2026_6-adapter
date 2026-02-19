using src.Legacy;
using IPaymentProcessor = src.Interfaces.IPaymentProcessor;
using PaymentRequest = src.Services.Request.PaymentRequest;
using PaymentResult = src.Services.Result.PaymentResult;

namespace src.Services;

public class ModernPaymentProcessor : IPaymentProcessor
{
    private readonly LegacyPaymentSystem _legacyPaymentSystem;

    public ModernPaymentProcessor(LegacyPaymentSystem legacyPaymentSystem)
    {
        _legacyPaymentSystem = legacyPaymentSystem;
    }

    public PaymentResult ProcessPayment(PaymentRequest request,int expMonth,int expYear)
    {
        var response = _legacyPaymentSystem.AuthorizeTransaction(request.CreditCardNumber,request.Cvv,expMonth,expYear,request.Amount,request.Description);
        return new PaymentResult
        {
            Success = true,
            TransactionId = Guid.NewGuid().ToString(),
            Message = response.ResponseMessage
        };
        
    }

    public bool RefundPayment(string transactionId, decimal amount)
    {
        Console.WriteLine($"[Processador Moderno] Reembolsando {amount:C}");
        return true;
    }

    public EPaymentStatus CheckStatus(string transactionId)
    {
        return EPaymentStatus.Approved;
    }
}
