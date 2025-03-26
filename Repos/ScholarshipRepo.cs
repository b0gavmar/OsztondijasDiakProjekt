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
    }
}
