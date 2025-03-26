using Microsoft.EntityFrameworkCore;
using OsztondijasDiakProjekt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OsztondijasDiakProjekt.Repos
{
    public class ScholarshipRepo
    {
        private readonly ScholarshipContext _context;

        public ScholarshipRepo(ScholarshipContext context)
        {
            _context = context;
        }

        public Task<int> GetNumberOfScholarshipApplicants()
        {
            return _context.Scholarships.CountAsync();
        }

        public Task<List<ScholarshipApplicant>> GetAll()
        {
            return _context.Scholarships.ToListAsync();
        }

        public async Task<List<ScholarshipApplicant>> GetScholarshipApplicantsWithGreaterAmountThan(int amount)
        {
            return await _context.Scholarships.Where(s => s.ScholarshipAmount > amount).ToListAsync();
        }

        public Task<List<ScholarshipApplicant>> GetAllOrderedByAmount()
        {
            return _context.Scholarships.OrderBy(s => s.ScholarshipAmount).ToListAsync();
        }

        public Task Add(string email, string name, int scholarshipAmount)
        {
            var applicant = new ScholarshipApplicant(email,name);

            applicant.IncreaseAmount(scholarshipAmount);

            if(_context.Scholarships.Any(s => s.Email == email))
            {
                throw new ArgumentException("Már van ilyen email című jelentkező");
            }
            _context.Scholarships.Add(applicant);
            return _context.SaveChangesAsync();
        }

        public Task ChangeAmount(string email, int newAmount)
        {
            var applicant = _context.Scholarships.FirstOrDefault(s => s.Email == email);
            if(applicant == null)
            {
                throw new ArgumentException("Nincs ilyen email című jelentkező");
            }
            applicant.ChangeAmount(newAmount);
            return _context.SaveChangesAsync();
        }

        public Task Remove(string email)
        {
            var applicant = _context.Scholarships.FirstOrDefault(s => s.Email == email);
            if(applicant == null)
            {
                throw new ArgumentException("Nincs ilyen email című jelentkező");
            }
            _context.Scholarships.Remove(applicant);
            return _context.SaveChangesAsync();
        }

        public void AverageAndSum()
        {
            double average = _context.Scholarships.Average(s => s.ScholarshipAmount);
            double sum = _context.Scholarships.Sum(s => s.ScholarshipAmount);

            Console.WriteLine($"Az összes kiosztott ösztöndíj: {sum} Ft\nÁtlagos ösztöndíj: {average} Ft");
        }

        public async Task<List<ScholarshipGroup>> GroupedBy()
        {
            var allCategories = new List<ScholarshipGroup>
            {
                new() { Category = "1500 Ft alatti", Count = 0 },
                new() { Category = "1500 - 2000 Ft közötti", Count = 0 },
                new() { Category = "2000 Ft feletti", Count = 0 },
            };

            var scholarships = await _context.Scholarships.ToListAsync();

            foreach (var scholarship in scholarships)
            {
                if (scholarship.ScholarshipAmount < 1500)
                {
                    allCategories[0].Count++;
                }
                else if (scholarship.ScholarshipAmount <= 2000)
                {
                    allCategories[1].Count++;
                }
                else
                {
                    allCategories[2].Count++;
                }
            }   

            return allCategories;

            /*return await _context.Scholarships
                .GroupBy(s => s.ScholarshipAmount < 1500 ? "1500 Ft alatti ösztöndíjasok" :
                              s.ScholarshipAmount <= 2000 ? "1500 - 2000 Ft közötti ösztöndíjasok" :
                              "2000 Ft feletti ösztöndíjasok")
                .Select(g => new ScholarshipGroup
                {
                    Category = g.Key,
                    Count = g.Count()
                })
                .ToListAsync();*/
        }
    }
}
