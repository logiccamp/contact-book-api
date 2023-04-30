namespace ContactAPI.Models
{
    public class UpdateContactRequest
    {
        public String Fullname { get; set; }
        public String Email { get; set; }
        public long Phone { get; set; }
        public string Address { get; set; }
    }
}
