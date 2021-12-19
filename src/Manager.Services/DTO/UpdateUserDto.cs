using System;

namespace Manager.Services.DTO
{
    public class UpdateUserDTO
    {
        public UpdateUserDTO()
        {
        }

        public UpdateUserDTO(Guid userId, 
            string name,
            string email, 
            string password,
            string confirmPassword)
        {
            UserId = userId;
            Name = name;
            Email = email;
            Password = password;
            ConfirmPassword = confirmPassword;
        }

        public Guid UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}