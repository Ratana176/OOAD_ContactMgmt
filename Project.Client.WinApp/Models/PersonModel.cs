
using Project.Client.WinApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Project.Client.WinApp.Models
{

    public class PersonModel : Model
    {
        public PersonModel() : base()
        {
        }

        public List<Person> All()
        {
            var people = new List<Person>();
            var persons = this.GetValue(commandText: "SELECT * From person");
            while(persons.Read())
            {
                people.Add(PersonFromResult(persons));
            }
            this.Close(this.DatabaseConnection.Connection);
            return people;
            
        }

        public Person FindById(int id)
        {
            var Id = new SqlParameter("@id", SqlDbType.Int)
            {
                Value = id
            };

            var result = this.GetValue(
                commandText: "SELECT * FROM person WHERE id = @id",
                parameters: new[] {Id}
                );

            Person person = null;
            if(result.Read())
            {
                person = PersonFromResult(reader: result);
            }
            this.Close(this.DatabaseConnection.Connection);
            return person;
        }

        public int Save(Person person)
        {
            return this.Execute(
                commandText: "INSERT INTO person (id, name, phone, email, position, company_name, street_address, city, image_url) VALUES(null,@Name,@Phone,@Email,@Position, @CompanyName,@StreetAddress,@City, @ImageUrl);",
                parameters: Parameters(person)
                );
        }

        public int Update(Person person)
        {
           
            return this.Execute(
                commandText: "UPDATE person SET name=@Name, phone=@Phone, email=@Email, position=@Position, company_name=@CompanyName, street_address=@StreetAddress, city=@City, image_url=@ImageUrl WHERE id=@Id",
                parameters: Parameters(person)
                );
        }

        private static SqlParameter[] Parameters(Person person)
        {
            var Id = new SqlParameter("@Id", SqlDbType.Int) { Value = person.Id };
            var Name = new SqlParameter("@Name", SqlDbType.NVarChar, 100) { Value = person.Name };
            var Email = new SqlParameter("@Email", SqlDbType.NVarChar, 50) { Value = person.Email };
            var Position = new SqlParameter("@Position", SqlDbType.NVarChar, 100) { Value = person.Position };
            var CompanyName = new SqlParameter("@CompanyName", SqlDbType.NVarChar, 100) { Value = person.CompanyName };
            var StreetAddress = new SqlParameter("@StreetAddress", SqlDbType.NVarChar, 200) { Value = person.StreetAddress };
            var City = new SqlParameter("@City", SqlDbType.NVarChar, 50) { Value = person.City };
            var Phone = new SqlParameter("@Phone", SqlDbType.NVarChar, 20) { Value = person.Phone };
            var ImageUrl = new SqlParameter("@ImageUrl", SqlDbType.NVarChar, 100) { Value = person.ImageUrl };
            return new SqlParameter[] { Id, Name, Email, Position, CompanyName, StreetAddress, City, Phone, ImageUrl};
        }

        private static Person PersonFromResult(SqlDataReader reader)
        {
            return new Person
            {
                Id = Int32.Parse(reader["id"].ToString()),
                Name = reader["name"].ToString(),
                Email = reader["email"].ToString(),
                Position = reader["position"].ToString(),
                Phone = reader["phone"].ToString(),
                CompanyName = reader["company_name"].ToString(),
                StreetAddress = reader["street_address"].ToString(),
                City = reader["city"].ToString(),
                ImageUrl = reader["image_url"].ToString(),
            };
        }
    }
}
