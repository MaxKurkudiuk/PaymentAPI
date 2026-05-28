using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PaymentAPI.Models;

[Route("api/[controller]")]
[ApiController]
public class PaymentDetailController : ControllerBase
{
    private readonly PaymentDetailContext _context;
    public PaymentDetailController(PaymentDetailContext context)
    {
        _context = context;
    }

    // GET: api/PaymentDetail
    [HttpGet]
    public async Task<ActionResult<IEnumerable<PaymentDetail>>> GetPaymentDetail()
    {
        return await _context.PaymentDetails.ToListAsync();
    }

    // GET: api/PaymentDetail/5
    [HttpGet("{paymentdetailid}")]
    public async Task<ActionResult<PaymentDetail>> GetPaymentDetail(int paymentdetailid)
    {
        var paymentdetail = await _context.PaymentDetails.FindAsync(paymentdetailid);

        if (paymentdetail == null)
        {
            return NotFound();
        }

        return paymentdetail;
    }

    // PUT: api/PaymentDetail/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{paymentdetailid}")]
    public async Task<IActionResult> PutPaymentDetail(int? paymentdetailid, PaymentDetail paymentdetail)
    {
        if (paymentdetailid != paymentdetail.PaymentDetailId)
        {
            return BadRequest();
        }

        _context.Entry(paymentdetail).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!PaymentDetailExists(paymentdetailid))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }

    // POST: api/PaymentDetail
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<PaymentDetail>> PostPaymentDetail(PaymentDetail paymentdetail)
    {
        _context.PaymentDetails.Add(paymentdetail);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetPaymentDetail", new { paymentdetailid = paymentdetail.PaymentDetailId }, paymentdetail);
    }

    // DELETE: api/PaymentDetail/5
    [HttpDelete("{paymentdetailid}")]
    public async Task<IActionResult> DeletePaymentDetail(int? paymentdetailid)
    {
        var paymentdetail = await _context.PaymentDetails.FindAsync(paymentdetailid);
        if (paymentdetail == null)
        {
            return NotFound();
        }

        _context.PaymentDetails.Remove(paymentdetail);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool PaymentDetailExists(int? paymentdetailid)
    {
        return _context.PaymentDetails.Any(e => e.PaymentDetailId == paymentdetailid);
    }
}
