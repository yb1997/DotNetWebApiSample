using System.Runtime.Serialization;

namespace PracticeWebApi.Business.Models
{
    [DataContract]
    public class User
    {
        [DataMember]
        public int UserId { get; set; }

        [DataMember]
        public string FirstName { get; set; } = string.Empty;

        [DataMember]
        public string LastName { get; set; } = string.Empty;

        [DataMember]
        public DateTime BirthDate { get; set; }
    }
}
