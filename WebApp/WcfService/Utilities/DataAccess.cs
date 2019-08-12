using System;
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
                    var query = (from a in context.Albums where a.IdAlbum == id select a).SingleOrDefault();
                    if (query == null)
                        return new Album();

                    Album output = new Album { ArtistName = query.ArtistName, AlbumName = query.AlbumName, IdAlbum = query.IdAlbum };
                    return output;
                }
                catch(Exception)
                {
                    return new Album();
                }
            }
        }

        public Album[] ReadData_Albums()
        {
            using (var context = new MusicDatabaseEntities())
            {
                try
                {
                    var query = (from a in context.Albums select a).ToArray();
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
                        return new Rating
                        {
                            Album = new Album(),
                            IdAlbum = 0,
                            User = new User(),
                            IdUser =0,
                            IdRating = 0,
                            Rating1 = 0
                        };
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
                                 select r).ToList();
                    /*var query = (from r in context.Ratings
                                 join a in context.Albums on r.IdAlbum equals a.IdAlbum
                                 join u in context.Users on r.IdUser equals u.IdUser
                                 group a by a.IdAlbum into grp
                                 select new 
                                 {
                                     IdAlbum = grp.Key,
                                     Average
                                 } ).ToList();*/

                    Rating[] output = new Rating[query.Count];

                    for(int i = 0; i < query.Count;i++)
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
                    var query = (from u in context.Users where u.IdUser == id select u).SingleOrDefault();
                    if (query == null)
                        return new User();

                    User output = new User { IdUser = query.IdUser, Username = query.Username, Password = query.Password, Rank = query.Rank };
                    return output;
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
                    var query = (from u in context.Users where u.Username == username 
                                 && u.Password == password
                                 select u).SingleOrDefault();
                    if (query == null)
                        return new User();

                    User output = new User { IdUser = query.IdUser, Username = query.Username, Password = query.Password, Rank = query.Rank };
                    return output;
                }
                catch (Exception)
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
                    var query = (from u in context.Users
                                 where u.Username == username
                                 select u).SingleOrDefault();
                    if (query == null)
                        return new User();

                    User output = new User { IdUser = query.IdUser, Username = query.Username, Password = query.Password, Rank = query.Rank };
                    return output;
                }
                catch (Exception)
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

        public bool SaveData_Album(Album album)
        {
            using (var context = new MusicDatabaseEntities())
            {
                try
                {
                    var isAlbumAlreadySaved = (from a in context.Albums where a.ArtistName == album.ArtistName && a.AlbumName == album.AlbumName select a).SingleOrDefault();
                    if (isAlbumAlreadySaved != null)
                        return false;

                    context.Albums.Add(album);
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
                var isUserAlreadySaved = (from u in context.Users where user.Username == u.Username select u).SingleOrDefault();
                if (isUserAlreadySaved != null)
                    return false;

                try
                {
                    context.Users.Add(user);
                    context.SaveChanges();
                    return true;
                }
                catch (Exception)
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
                    //var record = context.Ratings.Where(r => r.IdAlbum == rating.IdAlbum && r.IdUser == rating.IdUser).FirstOrDefault();
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

        public bool UpdateData_User(User user)
        {
            using (var context = new MusicDatabaseEntities())
            {
                try
                {
                    var actualRecord = ReadData_User(user.IdUser);
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
                    context.SaveChanges();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }
    }
}
