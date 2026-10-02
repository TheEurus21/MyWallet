using Kif.Data;
using Kif.Services;
using Microsoft.AspNetCore.Mvc;

namespace Kif;

[ApiController]
[Route("api/[controller]")]
public class WalletController:ControllerBase
{
    private readonly WalletService _walletService;
    private readonly AppDbContext _appDbContext;
    public WalletController(WalletService walletService, AppDbContext appDbContext)
    {
        _walletService = walletService;
        _appDbContext = appDbContext;
    }
    [HttpPost]
    public async Task <IActionResult> Create(ChargeRequestDTO requestDTO)
    {
        var x = await _walletService.ChargeTransactionAsync(requestDTO);
        return Ok(x);
    }
    [HttpGet("info")]
    public IActionResult GetInfo()
    {
        return Ok(_appDbContext.Wallets.ToList());
    }

}
