﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WcfService.Utilities
{
    public interface IDataAccess
    {
        Album ReadData_Album(int id);
        Album ReadData_Album(string artistName, string albumName);
        Album[] ReadData_Albums();
        bool SaveData_Album(string artistName, string albumName);

        User ReadData_User(int id);
        User ReadData_User(string username, string password);
        User ReadData_User(string username);
        User[] ReadData_Users();
        bool SaveData_User(User user);

        Rating ReadData_Rating(int id);
        Rating[] ReadData_Ratings();
        Rating[] ReadData_Ratings(int IdUser);
        bool SaveData_Rating(Rating rating);

        bool UpdateData_User(User user);
        bool UpdateData_Rating(Rating rating);
        bool UpdateData_Rating(int ratingId, int? rating);
        bool UpdateData_Album(Album album);
        
        bool DeleteData_Album(int id);
        bool DeleteData_User(int id);
        bool DeleteData_Rating(int id);
    }
}
