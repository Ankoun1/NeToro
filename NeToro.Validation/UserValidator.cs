using System.Linq;
using FluentValidation;
using NeToro.Interfaces.Inputs.User;
using static NeToro.Validation.Constants.DataImportConstants.UserConst;

namespace NeToro.Validation
{
    public class UserValidator : AbstractValidator<UserInputModel>
    {
        public UserValidator()
        {           
            RuleFor(x => x.Username)
                .NotEmpty()
                .Length(MinLengthUsername, MaxLengthUsername);                            
        
            RuleFor(x => x.Password)
                .NotEmpty()
                .Length(MinLengthPassword, MaxLengthPassword);                                                               
        }      
    }
}
