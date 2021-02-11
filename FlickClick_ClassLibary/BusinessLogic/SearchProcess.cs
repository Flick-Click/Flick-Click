using FlickClick_ClassLibary.DataAccess;
using FlickClick_ClassLibary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlickClick_ClassLibary.BusinessLogic
{
    public class SearchProcess
    {
        public static List<MovieModel> LoadMovies(string GSearch)
        {
            string sql = $"SELECT * FROM movie WHERE title LIKE %{GSearch}%;";

            return SqlDataAccess.LoadData<MovieModel>(sql);
        }
    }
}
