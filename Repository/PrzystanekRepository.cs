using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos;
using api.Helpers;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class PrzystanekRepository : IPrzystanekRepository
    {
        private readonly ApplicationDBContext _context;

        public PrzystanekRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<Przystanek> CreateAsync(Przystanek przystanekModel)
        {
            await _context.Przystanki.AddAsync(przystanekModel);
            await _context.SaveChangesAsync();
            return przystanekModel;
        }

        public async Task<Przystanek?> DeleteAsync(int id)
        {
            var przystanekModel = await _context.Przystanki.FirstOrDefaultAsync(p => p.Id == id);

            if (przystanekModel == null) return null;

            _context.Remove(przystanekModel);
            await _context.SaveChangesAsync();

            return przystanekModel;
        }

        public async Task<List<Przystanek>> GetAllAsync(PrzystanekQuery query)
        {
            var przystanki = _context.Przystanki.Include(k => k.KursyPrzystanki).AsQueryable();

            if (!string.IsNullOrWhiteSpace(query.Nazwa))
            {
                przystanki = przystanki.Where(n => n.Nazwa.Contains(query.Nazwa));
            }

            return await przystanki.ToListAsync();
        }

        public async Task<Przystanek?> GetByIdAsync(int id)
        {
            return await _context.Przystanki.Include(k => k.KursyPrzystanki).FirstOrDefaultAsync(p => p.Id == id);
        }

        public Task<bool> PrzystanekExists(int id)
        {
            return _context.Przystanki.AnyAsync(p => p.Id == id);
        }

        public async Task<Przystanek?> UpdateAsync(int id, UpdatePrzystanekDto updateDto)
        {
            var existingPrzystanek = await _context.Przystanki.FirstOrDefaultAsync(p => p.Id == id);

            if (existingPrzystanek == null) return null;

            existingPrzystanek.Nazwa = updateDto.Nazwa;
            existingPrzystanek.Opis = updateDto.Opis;

            await _context.SaveChangesAsync();
            return existingPrzystanek;
        }
    }
}