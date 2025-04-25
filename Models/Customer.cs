namespace SistemaLab.Models
{
    public class Customer
    {
        public string Name {get; set;}
        public string Email {get; set;}
        public int Id {get; set;}

        public Customer(string Name, string Email, int Id)
        {
            this.Name = Name;
            this.Email = Email;
            this.Id = Id;
        }
    }
}