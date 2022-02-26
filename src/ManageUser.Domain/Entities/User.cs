using ManageUser.Domain.Validators;

namespace ManageUser.Domain.Entities
{
    public class User : BaseClass
    {
        public User(string name, string email, string password)
        {
            Name = name;
            Email = email;
            Password = password;
        }

        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }

        public void ChangeName(string name)
        {
            Name = name;
            Validate();
        }

        public void ChangeEmail(string email)
        {
            Email = email;
            Validate();
        }

        public void ChangePassword(string pass)
        {
            Password = pass;
            Validate();
        }

        public override bool Validate()
        {
            var validator = new UserValidator();
            var validation = validator.Validate(this);

            if (!validation.IsValid)
            {
                foreach (var error in validation.Errors)
                {
                    _errors.Add(error.ErrorMessage);
                }
                throw new ApplicationException($"Alguns campos estão inválidos. Corrija-os: {string.Join(",", _errors)}");
            }

            return true;
        }
    }
}
