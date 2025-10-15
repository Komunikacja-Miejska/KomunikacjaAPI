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

        public async Task<Kurs?> AddPrzystanekAsync(int id, int przystanekId, TimeSpan godzina)
        {
            var kursModel = await _context.Kursy.FirstOrDefaultAsync(k => k.Id == id);
            var przystanekModel = await _context.Przystanki.FirstOrDefaultAsync(p => p.Id == przystanekId);
            if (kursModel == null || przystanekModel == null)
                return null;

            bool exists = await _context.KursyPrzystanki.AnyAsync(kp => kp.KursId == id && kp.PrzystanekId == przystanekId && godzina == kp.Godzina);

            if (exists) return null;

            var kursyPrzystanekModel = new KursyPrzystanek
            {
                KursId = id,
                PrzystanekId = przystanekId,
                Godzina = godzina
            };

            await _context.KursyPrzystanki.AddAsync(kursyPrzystanekModel);
            await _context.SaveChangesAsync();

            return kursModel;
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

            var kursyPrzystanki = _context.KursyPrzystanki.Where(kp => kp.KursId == id);

            _context.KursyPrzystanki.RemoveRange(kursyPrzystanki);
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
        public async Task<KursyPrzystanek?> DeletePrzystanekAsync(int id, int przystanekId)
        {
            var kursyPrzystanekModel = await _context.KursyPrzystanki.FirstOrDefaultAsync(kp => kp.KursId == id && kp.PrzystanekId == przystanekId);

            if (kursyPrzystanekModel == null) return null;
            _context.KursyPrzystanki.Remove(kursyPrzystanekModel);
            await _context.SaveChangesAsync();
            return kursyPrzystanekModel;
        }

        public async Task<List<Kurs>> GetAllAsync()
        {
            return await _context.Kursy.ToListAsync();
        }

        public async Task<Kurs?> GetByIdAsync(int id)
        {
            return await _context.Kursy.Include(k => k.KursyPrzystanki).FirstOrDefaultAsync(k => k.Id == id);
        }

        public async Task<List<KursyPrzystanek>?> GetDeparturesByIdAsync(int kursId, TimeSpan? godzina = null)
        {
            var kursyPrzystanki = _context.KursyPrzystanki.Where(kp => kp.KursId == kursId).OrderBy(kp => kp.Godzina).AsQueryable();

            if (godzina != null)
            {
                kursyPrzystanki = kursyPrzystanki.Where(kp => kp.Godzina > godzina);
            }

            return await kursyPrzystanki.ToListAsync();
        }

        public async Task<Kurs?> UpdateAsync(int id, int trasaId)
        {
            var existingKurs = await _context.Kursy.FirstOrDefaultAsync(k => k.Id == id);
            if (existingKurs == null) return null;

            existingKurs.TrasaId = trasaId;

            await _context.SaveChangesAsync();
            return existingKurs;
        }
    }
}