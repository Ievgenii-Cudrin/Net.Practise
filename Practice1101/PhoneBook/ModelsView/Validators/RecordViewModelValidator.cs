using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PhoneBook.ModelsView.Validators
{
    public class RecordViewModelValidator : AbstractValidator<RecordViewModel>
    {
        public RecordViewModelValidator()
        {
            RuleFor(x => x.FullName).MinimumLength(3).MaximumLength(60);
            RuleFor(x => x.Email).EmailAddress();
            RuleFor(x => x.Address).MinimumLength(10);
            RuleFor(x => x.PhoneNumber).Matches(new Regex(@"^[0-9]{10}$")).WithMessage("Phone numbers must have only ten digits.");

        }
    }
}
