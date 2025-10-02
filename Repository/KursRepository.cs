using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class KursRepository : IKursRepository
    {
        private readonly ApplicationDBContext _context;

        public KursRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<Kurs> CreateAsync(Kurs kursModel)
        {
            await _context.Kursy.AddAsync(kursModel);
            await _context.SaveChangesAsync();
            return kursModel;
        }

        public async Task<Kurs?> DeleteAsync(int id)
        {
            var kursModel = await _context.Kursy.FirstOrDefaultAsync(k => k.Id == id);

            if (kursModel == null) return null;

            _context.Kursy.Remove(kursModel);
            await _context.SaveChangesAsync();
            return kursModel;
        }

        public async Task<List<Kurs>?> DeleteByFkAsync(int TrasaId)
        {
            var kursy = _context.Kursy.Where(k => k.TrasaId == TrasaId);

            if (kursy == null) return null;

            _context.Kursy.RemoveRange(kursy);
            await _context.SaveChangesAsync();
            return new List<Kurs>();
        }

        public async Task<List<Kurs>> GetAllAsync()
        {
            return await _context.Kursy.ToListAsync();
        }

        public async Task<Kurs?> GetByIdAsync(int id)
        {
            return await _context.Kursy.FirstOrDefaultAsync(k => k.Id == id);
        }
    }
}