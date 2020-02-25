using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Client.Domain.Entities
{
    public class Person
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public float AnnualIncome { get; set; }
        //addresss
        public string CompanyName { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }

        public override string ToString()
        {
            return $"{nameof(Name)}: {Name}, {nameof(Position)}: {Position}, {nameof(AnnualIncome)}: {AnnualIncome}, {nameof(CompanyName)}: {CompanyName}, {nameof(StreetAddress)}: {StreetAddress}, {nameof(City)}: {City},";
        }
    }
}
