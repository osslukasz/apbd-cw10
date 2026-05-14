namespace WebApplication2.Services;
using WebApplication2.DTOs;



public interface IPcService
{
    Task<List<PcDto>> GetAllPcsAsync();
    Task<PcWithComponentsDto?> GetPcWithComponentsAsync(int id);
    Task<PcDto> AddPcAsync(PcCreateUpdateDto dto);
    Task<bool> UpdatePcAsync(int id, PcCreateUpdateDto dto);
    Task<bool> DeletePcAsync(int id);
}