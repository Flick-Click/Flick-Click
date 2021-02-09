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
        public static void CreatePeople(List<PeopleModel> NewPeople)
        {
            foreach(var row in NewPeople)
            {
                PeopleModel data = new PeopleModel
                {
                    FirstName = row.FirstName,
                    LastName = row.LastName
                };

                string sql = @"INSERT INTO people (FirstName, LastName) VALUES (@FistName, @LastName)";

                SqlDataAccess.SaveData(sql, data);
            }
        }

        public static List<PeopleModel> LoadPeople()
        {
            string sql = @"SELECT * FROM people";

            return SqlDataAccess.LoadData<PeopleModel>(sql);
        }

    }
}
