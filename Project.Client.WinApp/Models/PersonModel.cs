
using Project.Client.WinApp.Domain.Entities;
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
            var fileNameParam = new SqlParameter("@FileName", SqlDbType.Text, 80)
            {
                Value = ""
            };
            var t = this.GetValue(
                commandText: "SELECT * From ",
                parameters: new[]
                {
                    fileNameParam
                }
            );
            return null;
            
        }
    }
}
