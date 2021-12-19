using Manager.Domain.Validators;
using Manager.Shared.Exceptions;

namespace Manager.Domain.Entities
{
    public class User : Base
    {
        private User()
        {
        }

        public User(string name,
            string email,
            string password)
        {
            Name = name;
            Email = email;
            Password = password;
            _errors = new();

            Validate();
        }

        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }

        public void ChangeName(string name)
        {
            Name = name;
            Validate();
        }

        public void ChangePassword(string password)
        {
            Password = password;
            Validate();
        }

        public void ChangeEmail(string email)
        {
            Email = email;
            Validate();
        }


        public override bool Validate()
        {
            var validator = new UserValidator();
            var validation = validator.Validate(this);

            if (validation.IsValid) return true;
            
            validation.Errors.ForEach(x => _errors.Add(x.ErrorMessage));

            throw new DomainException($"Some fields are invalid, please fix it", _errors); 
        }
    }
}
