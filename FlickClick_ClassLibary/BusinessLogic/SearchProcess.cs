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
        public static List<MovieModel> LoadSearchedMovies(string Search)
        {
            string sql = $"SELECT ID, Title, Picture_Path FROM movies WHERE Title LIKE '%{Search}%';";

            return SqlDataAccess.LoadData<MovieModel>(sql);
        }
    }
}
