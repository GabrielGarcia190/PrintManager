namespace Optima.API.Models.Requests;

public class CreteOrderRequest
{
    public Guid UserId { get; set; }
    public decimal TotalOrder { get; set; }
    public DateTime DateOrder { get; set; }
}