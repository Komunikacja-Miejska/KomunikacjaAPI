using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Trasa;
using api.Helpers;
using api.Models;

namespace api.Interfaces
{
    public interface ITrasaRepository
    {
        Task<List<Trasa>> GetAllAsync(TrasaQuery query);
        Task<Trasa?> GetByIdAsync(int id);
        Task<Trasa?> UpdateAsync(int id, UpdateTrasaDto updateDto);
        Task<Trasa> CreateAsync(Trasa trasaModel);
        Task<Trasa?> DeleteAsync(int id);
        Task<bool> TrasaExists(int id);
    }
}