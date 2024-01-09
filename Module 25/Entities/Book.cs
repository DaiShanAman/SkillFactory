﻿namespace Module_25.Entities
{
    internal class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int Year { get; set; }
        public string Genre { get; set; }
        public int Quantity { get; set; }

        public List<User> Users { get; set; } = new List<User>();
        

    }
}
