﻿using FlickClick_ClassLibary.DataAccess;
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

        public static int CreateUser(string firstname, string lastname, string password, string email, string tlfnr, string img)
        {

            UserModel data = new UserModel
            {
                FirstName = firstname,
                LastName = lastname,
                Password = password,
                Email = email,
                TlfNr = tlfnr,
                ProfilePicture = img
            };

            string sql = @"INSERT INTO flick_click.users(FirstName, LastName, Password, Email, TlfNr, ProfilePicture, Group_ID) VALUES(@FirstName, @LastName, @Password, @Email, @TlfNr, @ProfilePicture, @Group_ID);";

            return SqlDataAccess.SaveData(sql, data);
        }

        public static List<UserModel> LoadUser()
        {
            string sql = @"SELECT ID, FirstName, LastName, Email, TlfNr, Group_ID FROM users;";

            return SqlDataAccess.LoadData<UserModel>(sql);
        }

        public static List<UserModel> LoadUsersEmail()
        {
            string sql = @"SELECT Email FROM users;";

            return SqlDataAccess.LoadData<UserModel>(sql);
        }

        public static List<UserModel> LoadAllUsers()
        {
            string sql = @"SELECT users.ID, FirstName, LastName, Email, TlfNr, groups.`Group` FROM users INNER JOIN groups ON users.Group_ID = groups.ID ;";

            return SqlDataAccess.LoadData<UserModel>(sql);
        }

        // ID is giving from frontend model.ID
        public static int Deleteuser(int ID)
        {
            string sql = $"DELETE FROM users WHERE ID = {ID}";

            return SqlDataAccess.DeleteData(sql);
        }

        //Compares the Email and Password that the user input with data in the database
        public static List<UserModel> SignInValidator(string Email, string Password)
        {
            string sql = $"SELECT ID, FirstName, LastName, Group_ID FROM users WHERE Email='{Email}' AND Password='{Password}'";

            return SqlDataAccess.LoadData<UserModel>(sql);
        }
    }
}
