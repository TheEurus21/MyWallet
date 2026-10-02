namespace Kif;

public class Wallet
{
    public Guid Id { get; private set; }
    public decimal Balance { get; private set; }

    private Wallet()
    {
    }
    private Wallet(Guid id, decimal balance)
    {
        Id = id;
        Balance = balance;
    }

    public static Wallet Create(decimal initBalance = 0)
    {
        return new Wallet
            (Guid.CreateVersion7(), initBalance);

    }
    public void AddBalance(decimal amount)
    {
        Balance += amount;
    }

}
