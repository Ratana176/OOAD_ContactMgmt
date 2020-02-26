using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Client.WinApp.Domain.Entities
{
    public abstract class PersonBuilder
    {
        protected Person person = new Person();
        public class Builder: PersonBuilder { }

        public static readonly Builder New = new Builder();
        public Person Info => person;
        public PersonJobBuilder Works => new PersonJobBuilder(person);
        public PersonAddressBuilder Lives => new PersonAddressBuilder(person);
        public static implicit operator Person(PersonBuilder personBuilder) => personBuilder.person;

    }
}
