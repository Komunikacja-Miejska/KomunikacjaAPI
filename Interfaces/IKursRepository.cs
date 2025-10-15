using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Helpers;
using api.Models;

namespace api.Interfaces
{
    public interface IKursRepository
    {
        Task<List<Kurs>> GetAllAsync();
        Task<Kurs?> GetByIdAsync(int id);
        Task<List<KursyPrzystanek>?> GetDeparturesByIdAsync(int kursId, TimeSpan? godzina);
        Task<Kurs> CreateAsync(Kurs kursModel);
        Task<Kurs?> UpdateAsync(int id, int trasaId);
        Task<Kurs?> AddPrzystanekAsync(int id, int przystanekId, TimeSpan godzina);
        Task<KursyPrzystanek?> DeletePrzystanekAsync(int id, int przystanekId);
        Task<Kurs?> DeleteAsync(int id);
        Task<List<Kurs>?> DeleteByFkAsync(int TrasaId);

    }
}