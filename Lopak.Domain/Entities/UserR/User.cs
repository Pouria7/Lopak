using System;
using System.Collections.Generic;
using System.Text;

namespace Lopak.Domain.Entities.UserR
{
    public class User
    {
        public User()
        {
            UserRoles = new HashSet<UserRole>();
        }

        public int Id { get; set; }

        public string Username { get; set; }

        public string DisplayName { get; set; }

        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }

        public bool IsActive { get; set; }

        public DateTimeOffset? LastLoggedIn { get; set; }

        /// <summary>
        /// every time the user changes his Password,
        /// or an admin changes his Roles or stat/IsActive,
        /// create a new `SerialNumber` GUID and store it in the DB.
        /// </summary>
        public string SerialNumber { get; set; }

        public  ICollection<UserRole> UserRoles { get; set; }


        //not Use yet
        public UserType UserType { get; set; }
    }

    public enum UserType
    {
        Admin,
        Commercial,
        Peronal,
        Driver
    }
}
