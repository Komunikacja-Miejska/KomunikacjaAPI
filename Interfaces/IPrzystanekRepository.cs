using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos;
using api.Helpers;
using api.Models;

namespace api.Interfaces
{
    public interface IPrzystanekRepository
    {
        Task<List<Przystanek>> GetAllAsync(PrzystanekQuery query);
        Task<Przystanek?> GetByIdAsync(int id);
        Task<List<KursyPrzystanek>> GetDeparturesByIdAsync(int id, DateTime? godzina);
        Task<Przystanek> CreateAsync(Przystanek przystanekModel);
        Task<Przystanek?> UpdateAsync(int id, UpdatePrzystanekDto updateDto);
        Task<Przystanek?> DeleteAsync(int id);
        Task<bool> PrzystanekExists(int id);
    }
}