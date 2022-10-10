using BasicInformation.Application.InputModel;
using FluentValidation; 

namespace BasicInformation.Application.Validator
{
    public class BaseLocationInputModelValidator : BaseEntityValidator<BaseLocationInputModel> /*AbstractValidator<BaseLocationInputModel>*/
    { 
        //public BaseLocationInputModelValidator()
        //{ 
        //    RuleFor(x => x.Title)
        //        .NotEmpty()
        //        .WithMessage("عنوان نمی تواند خالی باشد"); 
        //} 
    }


    public class BaseEntityValidator<T> : AbstractValidator<T> where T : BaseEntity
    {
        public BaseEntityValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty()
                .WithMessage("عنوان نمی تواند خالی باشد");
        }
    }
}
