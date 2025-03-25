using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OsztondijasDiakProjekt.Models
{
    public class ScholarshipApplicant
    {
        private double _scholarshipAmount;
        private string _email;

        public ScholarshipApplicant(int scholarshipAmount, string email, string name)
        {
            _scholarshipAmount = scholarshipAmount;
            _email = email;
            Name = name;
        }

        public string Name { get; set; }
        public string Email { get => _email; set => _email = value; }
        public double ScholarshipAmount { get => _scholarshipAmount; set => _scholarshipAmount = value; }
    
        public void IncreaseAmount(double increase)
        {
            _scholarshipAmount += increase;
        }

        public override string ToString()
        {
            return $"{Name} ({Email}) => {ScholarshipAmount}Ft";
        }
    }
}
