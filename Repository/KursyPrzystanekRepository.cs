using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using api.Data;
using api.Helpers;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class KursyPrzystanekRepository : IKursyPrzystanekRepository
    {
        private readonly ApplicationDBContext _context;
        public KursyPrzystanekRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<KursyPrzystanek?> CreateAsync(KursyPrzystanek kursyPrzystanekModel)
        {
            await _context.KursyPrzystanki.AddAsync(kursyPrzystanekModel);
            await _context.SaveChangesAsync();
            return kursyPrzystanekModel;
        }

        public async Task<KursyPrzystanek?> DeleteAsync(int id)
        {
            var kursyPrzystanekModel = await _context.KursyPrzystanki.FirstOrDefaultAsync(kp => kp.Id == id);

            if (kursyPrzystanekModel == null) return null;

            _context.KursyPrzystanki.Remove(kursyPrzystanekModel);
            await _context.SaveChangesAsync();
            return kursyPrzystanekModel;
        }

        public async Task<List<KursyPrzystanek>?> DeleteByFkAsync(DeleteKursyPrzystanekQuery query)
        {
            var kursyPrzystanki = _context.KursyPrzystanki.AsQueryable();

            if (query.KursId != null || query.PrzystanekId != null)
            {
                if (query.KursId != null)
                {
                    kursyPrzystanki = kursyPrzystanki.Where(kp => kp.KursId == query.KursId);
                }
                if (query.PrzystanekId != null)
                {
                    kursyPrzystanki = kursyPrzystanki.Where(kp => kp.PrzystanekId == query.PrzystanekId);
                }
            }
            else
                return null;

            _context.KursyPrzystanki.RemoveRange(kursyPrzystanki);
            await _context.SaveChangesAsync();
            return new List<KursyPrzystanek>();
        }

        public async Task<List<KursyPrzystanek>> GetAllAsync(KursyPrzystanekQuery query)
        {
            var kursyPrzystanki = _context.KursyPrzystanki.AsQueryable();

            if (query.KursId != null)
            {
                kursyPrzystanki = kursyPrzystanki.Where(kp => kp.KursId == query.KursId);
            }

            if (query.PrzystanekId != null)
            {
                kursyPrzystanki = kursyPrzystanki.Where(kp => kp.PrzystanekId == query.PrzystanekId);
            }

            return await kursyPrzystanki.ToListAsync();
        }

        public async Task<KursyPrzystanek?> GetByIdAsync(int id)
        {
            return await _context.KursyPrzystanki.FirstOrDefaultAsync(kp => kp.Id == id);
        }
    }
}