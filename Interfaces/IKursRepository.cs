using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;

namespace api.Interfaces
{
    public interface IKursRepository
    {
        Task<List<Kurs>> GetAllAsync();
        Task<Kurs?> GetByIdAsync(int id);
        Task<Kurs> CreateAsync(Kurs kursModel);
        Task<Kurs?> DeleteAsync(int id);
        Task<List<Kurs>?> DeleteByFkAsync(int TrasaId);

    }
}