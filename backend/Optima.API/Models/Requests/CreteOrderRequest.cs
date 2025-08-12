namespace Optima.API.Models.Requests;

public class CreateOrderRequest
{
    public Guid UserId { get; set; }
    public decimal TotalOrder { get; set; }
}