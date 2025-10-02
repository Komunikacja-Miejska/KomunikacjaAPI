using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Helpers;
using api.Models;

namespace api.Interfaces
{
    public interface IKursyPrzystanekRepository
    {
        Task<List<KursyPrzystanek>> GetAllAsync(KursyPrzystanekQuery query);
        Task<KursyPrzystanek?> GetByIdAsync(int id);
        Task<KursyPrzystanek?> CreateAsync(KursyPrzystanek kursyPrzystanekModel);
        Task<KursyPrzystanek?> DeleteAsync(int id);
        Task<List<KursyPrzystanek>?> DeleteByFkAsync(DeleteKursyPrzystanekQuery query);
    }
}