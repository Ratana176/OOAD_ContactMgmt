using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Client.WinApp.Domain.Entities
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Position { get; set; }
        //addresss
        public string CompanyName { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string Phone { get; set; }
        public string ImageUrl { get; set; }

        public override string ToString()
        {
            return $"{nameof(Name)}: {Name}, {nameof(Email)}: {Email}, {nameof(Position)}: {Position}, {nameof(Phone)}: {Phone}, {nameof(CompanyName)}: {CompanyName}, {nameof(StreetAddress)}: {StreetAddress}, {nameof(City)}: {City}, {nameof(ImageUrl)}: {ImageUrl}";
        }
    }
}
