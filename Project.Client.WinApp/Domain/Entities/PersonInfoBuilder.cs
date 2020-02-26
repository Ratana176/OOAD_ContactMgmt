using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Client.WinApp.Domain.Entities
{
    public class PersonInfoBuilder<T> :  PersonBuilder where T: PersonInfoBuilder<T>
    {
        public T HasId(int id)
        {
            person.Id = id;
            return (T)this;
        }
        public T HasName(string name)
        {
            person.Name = name;
            return (T)this;
        }
        public T HasEmail(string email)
        {
            person.Email = email;
            return (T)this;
        }
        public T HasPhone(string phone)
        {
            person.Phone = phone;
            return (T)this;
        }
        public T HasImage(string image)
        {
            person.ImageUrl = image;
            return (T)this;
        }
    }
}
