using Microsoft.SqlServer.Server;

namespace SistemaLab.Models
{
    public class HomePage
    {
        public string UserType { get; set; }
        public HomePage(string UserType) 
        {
            this.UserType = UserType;
        }
    }
}
