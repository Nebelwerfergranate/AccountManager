﻿using System;

namespace Account_Manager
{
    [Serializable]
    public class Account
    {
        // Constructors
        public Account()
        {

        }

        public Account(string firstName, string lastName, byte? age, string position, string email, uint? salary)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            Position = position;
            Email = email;
            Salary = salary;
        }


        // Properties
        public uint Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public byte? Age { get; set; }
        public string Position { get; set; }
        public string Email { get; set; }
        public uint? Salary { get; set; }

        
        // Methods
        public override string ToString()
        {
            string info = "";
            info += "ID: " + Id + "\n";
            info += "First Name: " + FirstName + "\n";
            info += "Last Name: " + LastName + "\n";
            info += "Age: " + Age + "\n";
            info += "Position: " + Position + "\n";
            info += "Email: " + Email + "\n";
            if (Salary == null)
            {
                info += "Salary: " + Salary + "\n";
            }
            else
            {
                info += "Salary: " + Salary + "$\n"; 
            }
            return info;
        }
    }
}
