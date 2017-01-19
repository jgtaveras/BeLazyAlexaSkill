
namespace MegsoftBounty.Models.Harvest 
{
    public class HarvestCredentials
    {
        public string Username { get; set; }
        public string Password {get;set;}

        public HarvestCredentials(string username, string password)
        {
            Username = username;
            Password = password;
        }

        public string Base64Encode(){
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes($"{Username}:{Password}");
            return System.Convert.ToBase64String(plainTextBytes);
        }
    }
}