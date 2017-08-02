﻿namespace StockTracker.DataAccess
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string EmailAddress { get; set; }

        public User(string name)
        {
            this.Name = name;
        }
    }
}
