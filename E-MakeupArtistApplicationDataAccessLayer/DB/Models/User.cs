﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_MakeupArtistApplicationDataAccessLayer.DB.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }    

        public string Email { get; set; }

        public string User_Type { get; set; }

        public int Is_Approved { get; set; }

        public virtual List<Admin> Admin { get; set; }

        public virtual List<Artist> Artist { get; set; }

        public virtual List<Customer> Customer { get; set; }

        public virtual List<Payment> Payment { get; set; }

        public virtual List<Feedback> Feedback { get; set; }

        public virtual List<Token> Token { get; set; }

        public User()
        {
            Admin = new List<Admin>();
            Artist = new List<Artist>();
            Customer = new List<Customer>();
            Payment = new List<Payment>();
            Feedback = new List<Feedback>();
            Token = new List<Token>();

        }
    }
}
