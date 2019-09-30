using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WcfService.DataContracts
{
    [DataContract]
    public class UserLoginContract : IUserLoginContract
    {
        [DataMember]
        public int ID { set; get; }
        [DataMember]
        public string Username { set; get; }
        [DataMember]
        public string Password { set; get; }
        [DataMember]
        public string Rank { get; set; }

        public User ToUser()
        {
            return new User { Username = this.Username, Password = this.Password, Rank = this.Rank, IdUser = ID };
        }
    }
}
