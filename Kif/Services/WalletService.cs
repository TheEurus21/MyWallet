using Kif.Data;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Kif.Services;

public class WalletService
{
   private readonly AppDbContext _context;
    private readonly decimal _taxRate;

    public WalletService(AppDbContext context, IOptions<TaxSettings>options)
    {
        _context = context;
        _taxRate = options.Value.Rate;
    }
    public async Task<ChargeTransaction> ChargeTransactionAsync(ChargeRequestDTO charge)
    {

        var x = await _context.ChargeTransactions.FirstOrDefaultAsync(x => x.ReferenceId == charge.RefrenceId);
        if (x is not null)return x;
        var wallet = await _context.Wallets.FirstOrDefaultAsync(w => w.Id == charge.WalletId);
        if (wallet == null) throw new Exception("کیف پول یافت نشد.");
        decimal taxAmount = charge.Amount * _taxRate;
        var netAmount = charge.Amount - taxAmount;
        wallet.AddBalance(netAmount);
        var ne = ChargeTransaction.Create(
            charge.WalletId,
            charge.RefrenceId,
            charge.Amount,
            netAmount,
            taxAmount);
        _context.ChargeTransactions.Add(ne);
        await _context.SaveChangesAsync();
        return ne;
    }
    
}
