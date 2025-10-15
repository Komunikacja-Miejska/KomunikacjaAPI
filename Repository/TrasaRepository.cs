using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Quic;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Trasa;
using api.Helpers;
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

            var kursy = _context.Kursy.Where(k => k.TrasaId == id);

            _context.RemoveRange(kursy);
            _context.Remove(trasaModel);
            await _context.SaveChangesAsync();
            return trasaModel;
        }

        public async Task<List<Trasa>> GetAllAsync(TrasaQuery query)
        {
            var trasy = _context.Trasy.AsQueryable();
            if (query.KursId != null)
            {
                trasy = trasy.Where(t => t.Kursy.Any(k => k.Id == query.KursId));
            }

            if (query.NazwaLinii != null)
            {
                trasy = trasy.Where(t => t.NazwaLinii.Equals(query.NazwaLinii));
            }

            if (query.Opis != null)
            {
                trasy = trasy.Where(t => t.Opis.Equals(query.Opis));
            }

            return await trasy.ToListAsync();
        }

        public async Task<Trasa?> GetByIdAsync(int id)
        {
            var trasaModel = await _context.Trasy.Include(k => k.Kursy).FirstOrDefaultAsync(t => t.Id == id);
            return trasaModel;
        }

        public async Task<List<Kurs>> GetKursyById(int id)
        {
            var kursy = _context.Kursy.Where(k => k.TrasaId == id);
            return await kursy.ToListAsync();
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