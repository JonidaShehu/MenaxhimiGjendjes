namespace MenaxhimiGjendjes.Models
{
    public class Guest
    {
        public int Id { get; set; }
        public string Email { get; set; } = null!;
        public string Username { get; set; } = null!;   
        public int? Mosha { get; set; }  
    }
}
