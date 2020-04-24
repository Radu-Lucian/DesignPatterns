using CarServiceManagement.State;
using CarServiceManagement.Util;

namespace CarServiceManagement.Model
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public EUserType Type { get; set; }
        public Car Car { get; set; }

        public User(int id, string username, string password, EUserType type)
        {
            this.Id = id;
            this.Username = username;
            this.Password = password;
            this.Type = type;
        }

        public override string ToString()
        {
            return $"Id: {Id}, Username: {Username}, Password: {Password}, Type: {Type} \n Car: {Car}";
        }
    }
}
