namespace Kif;

public class ChargeTransaction
{
    public Guid Id { get; private set; }
    public Guid WalletId { get; private set; }
    public string ReferenceId { get; private set; }
    public decimal Amount { get; private set; }
    public decimal NetAmount { get; private set; }
    public decimal TaxAmount { get; private set; }
    public DateTimeOffset CreatedAt { get; private set; }

    private ChargeTransaction() { }
    private ChargeTransaction(Guid id, Guid walletId, string referenceId, decimal amount, decimal netAmount, decimal taxAmount, DateTimeOffset createdAt)
    {
        Id = id;
        WalletId = walletId;
        ReferenceId = referenceId;
        Amount = amount;
        NetAmount = netAmount;
        TaxAmount = taxAmount;
        CreatedAt = createdAt;
    }
    public static ChargeTransaction Create(Guid walletId, string refrenceId, decimal amount, decimal netAmount, decimal taxAmount)
    {
        return new ChargeTransaction
            (
            id: Guid.CreateVersion7(),
            walletId: walletId,
            referenceId: refrenceId,
            amount: amount,
            netAmount: netAmount,
            taxAmount: taxAmount,
            createdAt: DateTimeOffset.UtcNow);
    }
}
