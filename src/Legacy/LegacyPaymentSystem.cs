using src.Legacy.Response;

namespace src.Legacy;

public class LegacyPaymentSystem
{
    // Métodos com assinaturas incompatíveis
    public LegacyTransactionResponse AuthorizeTransaction(
        string cardNum,
        int cvvCode,
        int expMonth,
        int expYear,
        double amountInCents,
        string customerInfo)
    {
        Console.WriteLine($"[Sistema Legado] Autorizando transação...");
        Console.WriteLine($"Cartão: {cardNum}");
        Console.WriteLine($"Valor: {amountInCents / 100:C}");
            
        // Simulação de processamento
        var response = new LegacyTransactionResponse
        {
            AuthCode = Guid.NewGuid().ToString().Substring(0, 8).ToUpper(),
            ResponseCode = "00",
            ResponseMessage = "TRANSACTION APPROVED",
            TransactionRef = $"LEG{DateTime.Now.Ticks}"
        };

        return response;
    }
}