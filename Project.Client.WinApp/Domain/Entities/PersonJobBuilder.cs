using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Client.WinApp.Domain.Entities
{
    public class PersonJobBuilder<T> : PersonAddressBuilder<PersonJobBuilder<T>> where T : PersonJobBuilder<T>
    {
        public T WorkedWith(string companyName)
        {
            person.CompanyName = companyName;
            return (T)this;
        }
        public T AsA(string position)
        {
            person.Position = position;
            return (T)this;
        }
    }
}
