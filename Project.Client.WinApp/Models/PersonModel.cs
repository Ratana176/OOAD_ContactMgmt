
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
                commandText: "INSERT INTO person (name, phone, email, position, company_name, street_address, city, image_url) VALUES(@Name,@Phone,@Email,@Position, @CompanyName,@StreetAddress,@City, @ImageUrl);",
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
            var Name = new SqlParameter("@Name", SqlDbType.NVarChar) { Value = person.Name };
            var Email = new SqlParameter("@Email", SqlDbType.NVarChar) { Value = person.Email };
            var Position = new SqlParameter("@Position", SqlDbType.NVarChar) { Value = person.Position };
            var CompanyName = new SqlParameter("@CompanyName", SqlDbType.NVarChar) { Value = person.CompanyName };
            var StreetAddress = new SqlParameter("@StreetAddress", SqlDbType.NVarChar) { Value = person.StreetAddress };
            var City = new SqlParameter("@City", SqlDbType.NVarChar) { Value = person.City };
            var Phone = new SqlParameter("@Phone", SqlDbType.NVarChar) { Value = person.Phone };
            var ImageUrl = new SqlParameter("@ImageUrl", SqlDbType.NVarChar) { Value = Helper.GetDataValue(person.ImageUrl) };
            return new SqlParameter[] { Id, Name, Email, Position, CompanyName, StreetAddress, City, Phone, ImageUrl};
        }

        private static Person PersonFromResult(SqlDataReader reader)
        {
            return PersonBuilderDirector.Create()
                .HasId(Int32.Parse(reader["id"].ToString()))
                .HasName(reader["name"].ToString())
                .HasEmail(reader["email"].ToString())
                .HasPhone(reader["phone"].ToString())
                .HasImage(reader["image_url"].ToString())
                .At(reader["street_address"].ToString())
                .AsA(reader["position"].ToString())
                .WorkedWith(reader["company_name"].ToString())
                .In(reader["city"].ToString())
                .Builder();
        }
    }
}
