using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WcfService.DataContracts
{
    [DataContract]
    public class UserContract
    {
        [DataMember]
        public int IdUser { set; get; }

        [DataMember]
        public string Username { set; get; }

        //[DataMember]
        //public string Password { set; get; }

        [DataMember]
        public string Rank { set; get; }

        public UserContract(User user)
        {
            IdUser = user.IdUser;
            Username = user.Username;
            //Password = user.Password;
            Rank = user.Rank;
        }

        public UserContract()
        {
        }

        public User ToUser()
        {
            //var user = new User { IdUser = IdUser, Username = Username, Password = Password, Rank = Rank };
            var user = new User { IdUser = IdUser, Username = Username, Rank = Rank };

            return user;
        }
    }
}
