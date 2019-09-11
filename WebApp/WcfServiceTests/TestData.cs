using System;
using System.Collections.Generic;
using System.Text;
using WcfService;

namespace WcfServiceTests
{
    public static class TestData
    {
        //const string test = SampleString(30).ToString();
        public const string SampleString_Above30Characters = "abcdefghijklmnoprstuwyzABCDEFGHIJK";

        public static List<Album> SampleAlbumData(int sampleSize)
        {
            var data = new List<Album>();
            for (int i = 1; i <= sampleSize; i++)
            {
                data.Add(new Album
                {
                    ArtistName = "Artist" + i.ToString(),
                    AlbumName = "Album" + i.ToString(),
                    IdAlbum = i
                });
            }

            return data;
        }


        public static List<User> SampleUserData(int sampleSize)
        {
            var data = new List<User>();
            for (int i = 1; i <= sampleSize; i++)
            {
                data.Add(new User
                {
                    Username = "user" + i.ToString(),
                    Password = "password" + i.ToString(),
                    Rank = "rank" + i.ToString(),
                    IdUser = i
                });
            }

            return data;
        }

        public static List<Rating> SampleRatingData(int sampleSize)
        {
            var data = new List<Rating>();
            for (int i = 1; i <= sampleSize; i++)
            {
                var album = new Album { IdAlbum = i, AlbumName = "album" + i.ToString(), ArtistName = "artist" + i.ToString() };
                var user = new User
                {
                    Username = "user" + i.ToString(),
                    Password = "Password" + i.ToString(),
                    Rank = "rank" + i.ToString(),
                    IdUser = i
                };

                data.Add(new Rating { Album = album, User = user, Rating1 = i });
            }


            return data;
        }

        private static string SampleString(int length)
        {
            char[] output = new char[length];
            for (int i = 0; i < length; i++)
            {
                output[i] = 't';
            }

            return output.ToString();
        }

    }

}
