using FlickClick_ClassLibary.DataAccess;
using FlickClick_ClassLibary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlickClick_ClassLibary.BusinessLogic
{
    public static class UserProcess
    {
        public static int CreateUser(string firstname, string lastname, string password, string email, string tlfnr)
        {
            UserModel data = new UserModel
            {
                FirstName = firstname,
                LastName = lastname,
                Password = password,
                EmailAddress = email,
                TelefonNummer = tlfnr,
                IsMember = true
            };

            string sql = @"INSERT INTO flick_click.users (FirstName, LastName, Password, Email, TlfNr, ProfilePicture, Group_ID) VALUES (@FirstName, @LastName, @Password, @EmailAddress, @TelefonNummer, '~/Content/Pictures/img-person-placeholder.png', @IsMember);";

            return SqlDataAccess.SaveData(sql, data);
        }

        public static List<UserModel> LoadUsers()
        {
            string sql = @"SELECT ID, FirstName, LastName, Email, TlfNr, Group_ID FROM flick_click.users;";

            return SqlDataAccess.LoadData<UserModel>(sql);
        }

    }
}
