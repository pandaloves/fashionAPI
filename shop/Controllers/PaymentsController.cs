using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using shop.Data;
using shop.Entities;


namespace shop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {
        private readonly DataContext _context;

        public PaymentsController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Payment>>> GetPayments()
        {
            List<Payment> payments = await _context.Payments.ToListAsync();

            return Ok(payments);
        }

        [HttpPost("create-payment")]
        public async Task<IActionResult> CreatePayment([FromBody] PaymentDto paymentDto)
        {
            if (paymentDto == null)
            {
                return BadRequest("Invalid payment data.");
            }

            // Create a Payment entity based on the paymentDto
            var payment = new Payment
            {
                FirstName = paymentDto.FirstName,
                LastName = paymentDto.LastName,
                Email = paymentDto.Email,
                Address = paymentDto.Address,
                City = paymentDto.City,
                ZipCode = paymentDto.ZipCode,
                CardNumber = paymentDto.CardNumber,
                NameOnCard = paymentDto.NameOnCard,
                ExpirationDate = paymentDto.ExpirationDate,
                CVV = paymentDto.CVV,
                OrderId = paymentDto.OrderId

        };

                // Add the payment to the database
                _context.Payments.Add(payment);
                await _context.SaveChangesAsync();

                // Return the newly created payment as a response
                return CreatedAtAction(nameof(CreatePayment), new { paymentId = payment.PaymentId }, payment);
            
        }

        [HttpDelete("{PaymentId}")]
        public async Task<ActionResult<List<Payment>>> DeletePayments(int PaymentId)
        {
            var dbPayment = await _context.Payments.FindAsync(PaymentId);
            if (dbPayment == null)
            {
                return BadRequest("Payment not found.");
            }

            _context.Payments.Remove(dbPayment);
            await _context.SaveChangesAsync();

            return Ok(new { Success = true, Message = "Delete payment successfully" });
        }
    }
}
