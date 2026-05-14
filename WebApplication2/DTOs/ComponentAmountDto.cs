namespace WebApplication2.DTOs;

public class ComponentAmountDto
{
    public int Amount { get; set; }
    public ComponentDetailsDto Component { get; set; } = null!;
}