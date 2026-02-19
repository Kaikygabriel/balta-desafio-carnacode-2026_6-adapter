
using src.Services;
using src.Services.Request;
using src.Services.Result;

namespace src.Interfaces;

public interface IPaymentProcessor
{
    PaymentResult ProcessPayment(PaymentRequest request,int expMonth,int expYear);
    bool RefundPayment(string transactionId, decimal amount);
    EPaymentStatus CheckStatus(string transactionId);
}