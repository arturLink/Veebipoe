﻿namespace Veebipoe.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string PersonCode { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Password { get; set; }
        public bool Admin { get; set; }
    }
}
