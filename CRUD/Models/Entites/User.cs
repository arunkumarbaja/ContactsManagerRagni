﻿using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace CRUD.Models.Entites
{
    public class User : IdentityUser
    {

        [MaxLength(100)]
        public string FirstName { get; set; }

        [MaxLength(100)]
        public string LastName { get; set; }

        public DateTime DateRegistered { get; set; } = DateTime.UtcNow;



    }
}
