using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Client.WinApp.Domain.Entities
{
    public abstract class PersonBuilder
    {
        protected Person person;

        protected PersonBuilder()
        {
            person = new Person();
        }
        public Person Builder() => person;
        public static implicit operator Person(PersonBuilder personBuilder) => personBuilder.person;

    }
}
