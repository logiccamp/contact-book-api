﻿namespace ContactAPI.Models
{
    public class AddContactRequest
    {
        public String Fullname { get; set; }
        public String Email { get; set; }
        public long Phone { get; set; }
        public string Address { get; set; }
    }
}
