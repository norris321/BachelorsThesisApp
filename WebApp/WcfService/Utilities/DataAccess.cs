﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WcfService.Utilities;

namespace WcfService.Utilities
{
    public class DataAccess : IDataAccess
    {
        public Album ReadData_Album(int id)
        {
            using (var context = new MusicDatabaseEntities())
            {
                try
                {
                    var albumChecked = (from a in context.Albums where a.IdAlbum == id select a).SingleOrDefault();

                    if (albumChecked == null)
                        return null;

                    return albumChecked;
                }
                catch(Exception)
                {
                    return null;
                }
            }
        }

        public Album ReadData_Album(string artistName, string albumName)
        {
            using (var context = new MusicDatabaseEntities())
            {
                try
                {
                    var albumChecked = (from a in context.Albums where a.ArtistName == artistName && a.AlbumName == albumName select a).SingleOrDefault();

                    if (albumChecked == null)
                        return null;

                    return albumChecked;
                }
                catch (Exception)
                {
                    return null;
                }
            }
        }

        public Album[] ReadData_Albums()
        {
            Album[] query;
            using (var context = new MusicDatabaseEntities())
            {
                try
                {
                    query = (from a in context.Albums select a).ToArray();
                    return query;
                }
                catch (Exception)
                {
                    return null;
                }
            }
        }

        public Rating ReadData_Rating(int id)
        {
            using (var context = new MusicDatabaseEntities())
            {
                try
                {
                    var checkRating = (from a in context.Ratings where a.IdRating == id select a).SingleOrDefault();
                    if (checkRating == null)
                    {
                        return null;
                    }
                    else
                    {

                        var query = (from r in context.Ratings
                                     join a in context.Albums on r.IdAlbum equals a.IdAlbum
                                     join u in context.Users on r.IdUser equals u.IdUser
                                     where r.IdRating == id         
                                     select r).SingleOrDefault();

                        Rating output = new Rating
                        {
                            Album = query.Album,
                            IdAlbum = query.IdAlbum,
                            User = query.User,
                            IdUser = query.IdUser,
                            IdRating = query.IdRating,
                            Rating1 = query.Rating1
                        };

                        return output;

                    }

                }
                catch (Exception)
                {
                    return null;
                }
            }
        }

        public Rating[] ReadData_Ratings()
        {
            using (var context = new MusicDatabaseEntities())
            {
                try
                {
                    var query = (from r in context.Ratings
                                 join a in context.Albums on r.IdAlbum equals a.IdAlbum
                                 join u in context.Users on r.IdUser equals u.IdUser
                                 select r).ToArray();

                    Rating[] output = new Rating[query.Length];

                    for(int i = 0; i < query.Length; i++)
                    {
                        output[i] = new Rating
                        {
                            Album = query[i].Album,
                            IdAlbum = query[i].IdAlbum,
                            User = query[i].User,
                            IdUser = query[i].IdUser,
                            IdRating = query[i].IdRating,
                            Rating1 = query[i].Rating1
                        };
                    }


                    return output;
                }
                catch (Exception e)
                {
                    return null;
                }
            }
        }

        public User ReadData_User(int id)
        {
            using (var context = new MusicDatabaseEntities())
            {
                try
                {
                    var checkUser = (from u in context.Users where u.IdUser == id select u).SingleOrDefault();

                    if (checkUser == null)
                        return null;

                    return checkUser;
                }
                catch (Exception)
                {
                    return null;
                }
            }
        }

        public User ReadData_User(string username, string password)
        {
            using (var context = new MusicDatabaseEntities())
            {
                try
                {
                    User userFound = ReadData_User(username);

                    if (password == userFound.Password)
                        return userFound;

                    string userGuid = userFound.UserGuid.ToString();
                    string hashedPassword = HashData.Security.HashSHA1(password + userGuid);

                    if(hashedPassword == userFound.Password)
                        return userFound;

                    return null;
                }
                catch (Exception e)
                {
                    return null;
                }
            }
        }

        public User ReadData_User(string username)
        {
            using (var context = new MusicDatabaseEntities())
            {
                try
                {
                    var checkUser = (from u in context.Users
                                 where u.Username == username
                                 select u).SingleOrDefault();

                    if (checkUser == null)
                        return null;

                    return checkUser;
                }
                catch (Exception e)
                {
                    return null;
                }
            }
        }

        public User[] ReadData_Users()
        {
            using (var context = new MusicDatabaseEntities())
            {
                try
                {
                    var query = (from u in context.Users select u).ToArray();
                    return query;
                }
                catch (Exception)
                {
                    return null;
                }
            }
        }

        public bool SaveData_Album(string artistName, string albumName)
        {
            using (var context = new MusicDatabaseEntities())
            {
                try
                {
                    var isAlbumAlreadySaved = (from a in context.Albums where a.ArtistName == artistName && a.AlbumName == albumName select a).SingleOrDefault();
                    if (isAlbumAlreadySaved != null)
                        return false;

                    context.Albums.Add(new Album {ArtistName = artistName, AlbumName = albumName });
                    context.SaveChanges();
                    return true;
                }
                catch (Exception e)
                {
                    return false;
                }
            }
        }

        public bool SaveData_Rating(Rating rating)
        {
            using (var context = new MusicDatabaseEntities())
            {
                try
                {
                    var checkIfRatingExist = (from c in context.Ratings where c.IdAlbum == rating.IdAlbum && c.IdUser == rating.IdUser select c).SingleOrDefault();
                    if (checkIfRatingExist == null)
                    {
                        context.Ratings.Add(rating);
                        context.SaveChanges();
                        return true;
                    }
                    else
                    {
                       return UpdateData_Rating(rating);
                    }
                    
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        public bool SaveData_User(User user)
        {
            using (var context = new MusicDatabaseEntities())
            {
                var isUserAlreadySaved = (from u in context.Users
                                          where user.Username == u.Username select u).SingleOrDefault();

                if (isUserAlreadySaved != null)
                    return false;

                try
                {
                    Guid userGuid = System.Guid.NewGuid();

                    string hashedPassword = HashData.Security.HashSHA1
                        (user.Password + userGuid.ToString());

                    user.Password = hashedPassword;
                    user.UserGuid = userGuid;

                    context.Users.Add(user);
                    context.SaveChanges();

                    return true;
                }
                catch (Exception e)
                {
                    return false;
                }
            }
        }


        public bool UpdateData_Album(Album album)
        {
            using (var context = new MusicDatabaseEntities())
            {
                var actualRecord = ReadData_Album(album.IdAlbum);

                if(string.IsNullOrEmpty(album.ArtistName))
                {
                    album.ArtistName = actualRecord.ArtistName;
                }

                if (string.IsNullOrEmpty(album.AlbumName))
                {
                    album.AlbumName = actualRecord.AlbumName;
                }

                try
                {
                    var record = context.Albums.Where(a => a.IdAlbum == album.IdAlbum).FirstOrDefault();
                    record.AlbumName = album.AlbumName;
                    record.ArtistName = album.ArtistName;
                    record.IdAlbum = album.IdAlbum;
                    context.SaveChanges();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        public bool UpdateData_Rating(Rating rating)
        {
            using (var context = new MusicDatabaseEntities())
            {
                try
                {
                    var record = context.Ratings.SingleOrDefault(r => r.IdAlbum == rating.IdAlbum && r.IdUser == rating.IdUser);

                    record.Rating1 = rating.Rating1;
                    record.IdUser = rating.IdUser;
                    record.IdAlbum = rating.IdAlbum;
                    context.SaveChanges();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }
        
        public bool UpdateData_Rating(int ratingId, int? rating)
        {
            using (var context = new MusicDatabaseEntities())
            {
                try
                {
                    var record = context.Ratings.SingleOrDefault(r => r.IdRating == ratingId);

                    record.Rating1 = rating;
                    context.SaveChanges();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        public bool UpdateData_User(User user)
        {
            using (var context = new MusicDatabaseEntities())
            {
                try
                {
                    var record = context.Users.Where(u => u.IdUser == user.IdUser).FirstOrDefault();

                    if (record == null)
                        return false;
                    

                    if (user.Username != null)
                    {
                        record.Username = user.Username;
                    }
                    if (user.Rank != null)
                    {
                        record.Rank = user.Rank;
                    }
                    if (user.Password != null)
                    {
                        //actualRecord.Password = user.Password;
                        Guid userGuid = System.Guid.NewGuid();

                        string hashedPassword = HashData.Security.HashSHA1
                            (user.Password + userGuid.ToString());

                        record.Password = hashedPassword;
                        record.UserGuid = userGuid;
                    }

                    context.SaveChanges();
                    /*var actualRecord = ReadData_User(user.IdUser);
                    if(user.Username == null)
                    {
                        user.Username = actualRecord.Username;
                    }

                    if (user.Password == null)
                    {
                        user.Password = actualRecord.Password;
                    }

                    if (user.Rank == null)
                    {
                        user.Rank = actualRecord.Rank;
                    }

                    var record = context.Users.Where(u => u.IdUser == user.IdUser).FirstOrDefault();

                    record.IdUser = user.IdUser;
                    record.Password = user.Password;
                    record.Username = user.Username;
                    record.Rank = user.Rank;
                    context.SaveChanges();*/
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        public bool DeleteData_Album(int id)
        {
            using (var context = new MusicDatabaseEntities())
            {
                try
                {
                    var album = context.Albums.Find(id);
                    context.Entry(album).State = System.Data.Entity.EntityState.Deleted;
                    context.SaveChanges();
                    return true;
                }
                catch (Exception e)
                {
                    return false;
                }
            }
        }

        public bool DeleteData_User(int id)
        {
            using (var context = new MusicDatabaseEntities())
            {
                try
                {
                    var user = context.Users.Find(id);
                    context.Entry(user).State = System.Data.Entity.EntityState.Deleted;
                    context.SaveChanges();
                    return true;
                }
                catch (Exception e)
                {
                    return false;
                }
            }
        }

        public bool DeleteData_Rating(int id)
        {
            using (var context = new MusicDatabaseEntities())
            {
                try
                {
                    var rating = context.Ratings.Find(id);
                    context.Entry(rating).State = System.Data.Entity.EntityState.Deleted;
                    context.SaveChanges();
                    return true;
                }
                catch (Exception e)
                {
                    return false;
                }
            }
        }

        public Rating[] ReadData_Ratings(int IdUser)
        {
            using (var context = new MusicDatabaseEntities())
            {
                try
                {
                    var query = (from r in context.Ratings
                                 join a in context.Albums on r.IdAlbum equals a.IdAlbum
                                 join u in context.Users on r.IdUser equals u.IdUser
                                 where r.IdUser == IdUser
                                 select r).ToList();

                    if (query.Count == 0)
                        return null;

                    Rating[] output = new Rating[query.Count];

                    for (int i = 0; i < query.Count; i++)
                    {
                        output[i] = new Rating
                        {
                            Album = query[i].Album,
                            IdAlbum = query[i].IdAlbum,
                            User = query[i].User,
                            IdUser = query[i].IdUser,
                            IdRating = query[i].IdRating,
                            Rating1 = query[i].Rating1
                        };
                    }


                    return output;
                }
                catch (Exception e)
                {
                    return null;
                }
            }
        }

    }
}
