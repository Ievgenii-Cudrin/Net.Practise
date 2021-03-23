using FluentValidation;
using PhoneBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBook.ModelsView.Validators
{
    public class RegisterModelValidator : AbstractValidator<RegisterModel>
    {
        public RegisterModelValidator()
        {
            RuleFor(x => x.Name).MinimumLength(3).MaximumLength(50);
            RuleFor(x => x.Password)
                .MinimumLength(4)
                .Equal(customer => customer.ConfirmPassword)
                .When(customer => !String.IsNullOrWhiteSpace(customer.Password));
        }
    }
}
