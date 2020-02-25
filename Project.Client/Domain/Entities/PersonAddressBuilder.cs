using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Client.Domain.Entities
{
    public class PersonAddressBuilder : PersonBuilder
    {
        public PersonAddressBuilder(Person person)
        {
            this.person = person;
        }
        public PersonAddressBuilder At(string streetAddress)
        {
            person.StreetAddress = streetAddress;
            return this;
        }
        public PersonAddressBuilder In(string city)
        {
            person.City = city;
            return this;
        }
    }
}
