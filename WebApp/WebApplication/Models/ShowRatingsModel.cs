using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication.ServiceReference;

namespace WebApplication.Models
{
    public class ShowRatingsModel
    {
        public RatingModel[] Ratings
        {
            get
            {
                //return null;
                return GetRatings();
                //return ratings;
            }
        }

        //private RatingContract[] ratings { set; get; }

        private  RatingModel[] GetRatings()
        {
            try
            {
                using (var client = new MusicServiceClient())
                {
                    RatingContract[] array = client.GetRatings();
                    var dictionary = new Dictionary<int, RatingModel>();

                    foreach(var a in array)
                    {
                        if(dictionary.ContainsKey(a.IdAlbum))
                        {
                            //dictionary.Add(a.IdAlbum, )
                            //dictionary[a.IdAlbum].Rating += a.Rating;
                            dictionary[a.IdAlbum].Add(a.Rating);
                        }
                        else
                        {
                            dictionary.Add(a.IdAlbum, new RatingModel
                            { ArtisName = a.ArtistName, AlbumName = a.AlbumName, Rating = (int)a.Rating });
                        }
                    }

                    RatingModel[] output = new RatingModel[dictionary.Count];

                    //for(int i =0; i < dictionary.Count; i++)
                    //    output[i] = dictionary
                    int i = 0;
                    foreach(KeyValuePair<int, RatingModel> entry in dictionary)
                    {
                        output[i] = entry.Value;
                        i++;
                    }

                    return output;
                }
            }
            catch(Exception)
            {
                return null;
            }
        }



        public class RatingModel
        {
            public string ArtisName { set; get; }
            public string AlbumName { set; get; }
            public decimal? Rating
            {
                set
                {
                    if(ratings.Count == 0)
                        ratings.Add((int)value);
                }

                get
                {
                    decimal? output = 0;
                    foreach (var r in ratings)
                        output += r;

                    return output / ratings.Count;
                }
            }

            private List<int?> ratings = new List<int?>();

            public RatingModel()
            {
                //ratings = new List<int>();
            }

            public void Add(int? val)
            {
                ratings.Add(val);
            }

        }
    }
}