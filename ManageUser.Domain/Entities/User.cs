using ManageUser.Core.Exceptions;
using ManageUser.Domain.Validators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageUser.Domain.Entities
{
    public class User : Base
    {
        public string? Name { get; private set; }
        public string? Email { get; private set; }
        public string? Password { get; private set; }

        protected User()
        {}

        public User(string name, string email, string password)
        {
            Name = name;
            Email = email;
            Password = password;
        }

        public void ChangeName(string name)
        {
            Name = name ;
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
                throw new DomainException("Alguns campos estão inválidos. Corrija-os: ", _errors);
            }

            return true;
        }
    }
}
