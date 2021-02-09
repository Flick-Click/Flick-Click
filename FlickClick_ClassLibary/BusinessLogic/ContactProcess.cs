﻿using FlickClick_ClassLibary.DataAccess;
using FlickClick_ClassLibary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlickClick_ClassLibary.BusinessLogic
{
    public class ContactProcess
    {
        public static int CreateNews(string name, string email, string message)
        {
            ContactModel data = new ContactModel
            {
                Name = name,
                Email = email,
                Message = message
            };

            string sql = @"INSERT INTO contacts (Name, Email, Message) VALUES (@Name, @Email, @Message);";

            return SqlDataAccess.SaveData(sql, data);
        }

        public static List<ContactModel> LoadContacts()
        {
            string sql = @"SELECT * FROM contacts;";

            return SqlDataAccess.LoadData<ContactModel>(sql);
        }

        // ID is giving from frontend model.ID
        public static int DeleteContact(int ID)
        {
            string sql = @"DELETE FROM Contacts WHERE ID = @ID";

            return SqlDataAccess.DeleteData(sql);
        }
    }
}
