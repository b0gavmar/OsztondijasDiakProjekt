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
    }
}
