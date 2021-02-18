using FlickClick_ClassLibary.DataAccess;
using FlickClick_ClassLibary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlickClick_ClassLibary.BusinessLogic
{
    public class GenreProcess
    {
        public static int Creategenre(string genre)
        {
            GenreModel data = new GenreModel
            {
                Genre = genre
            };

            string sql = @"INSERT INTO genres (Genre) VALUES (@Genre)";

            return SqlDataAccess.SaveData(sql, data);
        }

        public static List<GenreModel> Loadgenre()
        {
            string sql = @"SELECT * FROM genres";

            return SqlDataAccess.LoadData<GenreModel>(sql);
        }
    }
}
