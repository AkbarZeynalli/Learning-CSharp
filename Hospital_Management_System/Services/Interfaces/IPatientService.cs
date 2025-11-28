using Hospital_Management_System.Dtos;

namespace Hospital_Management_System.Services.Interfaces
{
    public interface IPatientService
    {
        Task<List<PatientDto>> GetAllAsync();
        Task<PatientDto> GetByIdAsync(int id);
        Task AddAsync(PatientDto dto);
        Task UpdateAsync(int id, PatientDto dto);
        Task DeleteAsync(int id);
    }
}
