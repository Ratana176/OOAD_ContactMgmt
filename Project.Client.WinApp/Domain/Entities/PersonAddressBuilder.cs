using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Client.WinApp.Domain.Entities
{
    public class PersonAddressBuilder<T> : PersonInfoBuilder<PersonAddressBuilder<T>> where T : PersonAddressBuilder<T>
    {
        public T At(string streetAddress)
        {
            person.StreetAddress = streetAddress;
            return (T)this;
        }
        public T In(string city)
        {
            person.City = city;
            return (T)this;
        }
    }

}
