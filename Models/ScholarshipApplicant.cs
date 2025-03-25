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

        public ScholarshipApplicant (string email, string name)
        {
            if(string.IsNullOrEmpty(name) || string.IsNullOrEmpty(email))
            {
                throw new ArgumentNullException("A név és email nem lehet üres");
            }
            _scholarshipAmount = 0;
            _email = email;
            Name = name;
        }

        public string Name { get; set; }
        public string Email { get => _email; set => _email = value; }
        public double ScholarshipAmount { get => _scholarshipAmount; set => _scholarshipAmount = value; }
    
        public void IncreaseAmount(double increase)
        {
            if(increase < 0)
            {
                throw new ArgumentException("Az összeg nem lehet negatív");
            }
            _scholarshipAmount += increase;
        }

        public override string ToString()
        {
            return $"{Name} ({Email}) => {ScholarshipAmount}Ft";
        }
    }
}
