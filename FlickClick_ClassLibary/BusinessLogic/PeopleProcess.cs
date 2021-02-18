using FlickClick_ClassLibary.DataAccess;
using FlickClick_ClassLibary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlickClick_ClassLibary.BusinessLogic
{
    public class PeopleProcess
    {
        // Should only be called with a list of people that does not already exist!!!
        public static void Createpeople(string firstname, string lastname)
        {
                PeopleModel data = new PeopleModel
                {
                    FirstName = firstname,
                    LastName = lastname
                };

                string sql = @"INSERT INTO people (FirstName, LastName) VALUES (@FirstName, @LastName)";

                SqlDataAccess.SaveData(sql, data);
        }

        public static List<PeopleModel> LoadPeople()
        {
            string sql = @"SELECT * FROM people";

            return SqlDataAccess.LoadData<PeopleModel>(sql);
        }
    }
}
