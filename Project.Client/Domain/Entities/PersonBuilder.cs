using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Client.Domain.Entities
{
    public abstract class PersonBuilder
    {
        protected Person person = new Person();
        public PersonJobBuilder Works => new PersonJobBuilder(person);
        public PersonAddressBuilder Lives => new PersonAddressBuilder(person);
        public static implicit operator Person(PersonBuilder personBuilder) => personBuilder.person;

    }
}
