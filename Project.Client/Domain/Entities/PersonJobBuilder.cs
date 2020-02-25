using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Client.Domain.Entities
{
    public class PersonJobBuilder : PersonBuilder
    {
        public PersonJobBuilder(Person person)
        {
            this.person = person;
        }

        public PersonJobBuilder At(string companyName)
        {
            person.CompanyName = companyName;
            return this;
        }
        public PersonJobBuilder AsA(string position)
        {
            person.Position = position;
            return this;
        }
        public PersonJobBuilder Earning(float AnnualIncome)
        {
            person.AnnualIncome = AnnualIncome;
            return this;
        }
    }
}
