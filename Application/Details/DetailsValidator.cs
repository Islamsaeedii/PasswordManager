using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using FluentValidation;

namespace Application.Users
{
    public class DetailsValidator : AbstractValidator<Information>
    {
        public DetailsValidator()
        {
            RuleFor(x => x.Email).EmailAddress().NotEmpty();
            RuleFor(x=> x.Url).NotEmpty();
            RuleFor(x=>x.Description).NotEmpty();
        }
    }
}