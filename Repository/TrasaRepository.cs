using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Trasa;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class TrasaRepository : ITrasaRepository
    {
        private readonly ApplicationDBContext _context;
        public TrasaRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<Trasa> CreateAsync(Trasa trasaModel)
        {
            await _context.Trasy.AddAsync(trasaModel);
            await _context.SaveChangesAsync();
            return trasaModel;
        }

        public async Task<Trasa?> DeleteAsync(int id)
        {
            var trasaModel = await _context.Trasy.FirstOrDefaultAsync(t => t.Id == id);

            if (trasaModel == null) return null;

            _context.Remove(trasaModel);
            await _context.SaveChangesAsync();
            return trasaModel;
        }

        public async Task<List<Trasa>> GetAllAsync()
        {
            return await _context.Trasy.ToListAsync();
        }

        public async Task<Trasa?> GetByIdAsync(int id)
        {
            var trasaModel = await _context.Trasy.Include(k => k.Kursy).FirstOrDefaultAsync(t => t.Id == id);
            return trasaModel;
        }

        public async Task<Trasa?> GetByKursIdAsync(int kursId)
        {
            var kursModel = await _context.Kursy.FirstOrDefaultAsync(k => k.Id == kursId);
            var trasaModel = await _context.Trasy.FirstOrDefaultAsync(t => t.Id == kursModel.TrasaId);
            return trasaModel;
        }

        public Task<bool> TrasaExists(int id)
        {
            return _context.Trasy.AnyAsync(t => t.Id == id);
        }

        public async Task<Trasa?> UpdateAsync(int id, UpdateTrasaDto updateDto)
        {
            var trasaModel = await _context.Trasy.FirstOrDefaultAsync(t => t.Id == id);

            if (trasaModel == null) return null;

            trasaModel.NazwaLinii = updateDto.NazwaLinii;
            trasaModel.Opis = updateDto.Opis;

            await _context.SaveChangesAsync();
            return trasaModel;
        }
    }
}