using src;
using src.Legacy;
using src.Services;

Console.WriteLine("=== Sistema de Checkout ===\n");

// Funciona bem com o processador moderno
var modernProcessor = new ModernPaymentProcessor(new LegacyPaymentSystem());
var checkoutWithModern = new CheckoutService(modernProcessor);
checkoutWithModern.CompleteOrder("cliente@email.com", 150.00m, "4111111111111111");

Console.WriteLine("\n" + new string('-', 60) + "\n");

// Problema: Como usar o sistema legado sem modificar CheckoutService?
var legacySystem = new LegacyPaymentSystem();
            
// ISSO NÃO FUNCIONA - Interfaces incompatíveis
// var checkoutWithLegacy = new CheckoutService(legacySystem); // ERRO DE COMPILAÇÃO!

Console.WriteLine("⚠️ PROBLEMA: Sistema legado não implementa IPaymentProcessor");
Console.WriteLine("   - Assinaturas de métodos incompatíveis");
Console.WriteLine("   - Estruturas de dados diferentes");
Console.WriteLine("   - Não podemos modificar o código legado");
Console.WriteLine("   - Não queremos modificar CheckoutService");

// Tentativa ingênua: criar wrapper manualmente em cada lugar
Console.WriteLine("\n--- Tentativa de uso direto (código duplicado) ---\n");
            
var cardNumber = "4111111111111111";
var cvv = 123;
var expDate = new DateTime(2026, 12, 31);
var amount = 200.00m;

// Conversões manuais repetidas em cada lugar do código
var legacyResponse = legacySystem.AuthorizeTransaction(
    cardNumber,
    cvv,
    expDate.Month,
    expDate.Year,
    (double)(amount * 100),
    "cliente2@email.com"
);

if (legacyResponse.ResponseCode == "00")
{
    Console.WriteLine($"✅ Transação aprovada! Ref: {legacyResponse.TransactionRef}");
}