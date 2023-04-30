namespace ContactAPI.Models
{
    public class Contact
    {
        public Guid id { get; set; }
        public String Fullname { get; set; }
        public String Email { get; set; }
        public long Phone { get; set; }
        public String Address { get; set; }
    }
}
