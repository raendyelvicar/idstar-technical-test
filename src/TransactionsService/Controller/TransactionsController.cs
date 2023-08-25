using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TransactionsService.Entities;

namespace TransactionsService.Controllers;

[Route("api/transactions")]
[ApiController]
public class TransactionsController : ControllerBase
{
    private readonly ITransactionsRepository _transactionsRepository;

    public TransactionsController(ITransactionsRepository transactionsRepository)
    {
        _transactionsRepository = transactionsRepository;
    }

    [HttpGet]
    public async Task<IActionResult> GetTransactions()
    {
        try
        {
            var transactions = await _transactionsRepository.GetAll();
            return Ok(transactions);
        }
        catch (Exception ex)
        {
            //log error
            return StatusCode(500, ex.Message);
        }
    }

    [Authorize]
    [HttpPost]
    public async Task<IActionResult> CreateTransactions(TransactionsHistory transactionsHistory)
    {     
        Guid id = Guid.NewGuid();
        transactionsHistory.Id = id; 
        var claim = ((ClaimsIdentity)User.Identity).FindFirst(ClaimTypes.NameIdentifier);
        
        if(claim != null) transactionsHistory.UserId = claim.Value; 
        else return StatusCode(500, "Use ID is not found");

        try
        {
            var transactions = await _transactionsRepository.CreateTransactions(transactionsHistory);
            return Ok(transactions);
        }
        catch (Exception ex)
        {
            //log error
            return StatusCode(500, ex.Message);
        }
    }
}
