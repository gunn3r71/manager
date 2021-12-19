using System;

namespace Manager.Services.DTO
{
    public class CreateUserDto
    {
        public CreateUserDto()
        {
        }

        public CreateUserDto(string name,
            string email,
            string password, 
            string confirmPassword)
        {
            Name = name;
            Email = email;
            Password = password;
            ConfirmPassword = confirmPassword;
        }

        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
