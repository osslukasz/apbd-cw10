namespace WebApplication2.DTOs;

public class PcWithComponentsDto : PcDto
{
    public List<ComponentAmountDto> Components { get; set; } = new List<ComponentAmountDto>();
}