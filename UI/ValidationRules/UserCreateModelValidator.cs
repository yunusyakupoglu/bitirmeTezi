using FluentValidation;
using UI.Models;

namespace UI.ValidationRules
{
    public class UserCreateModelValidator : AbstractValidator<UserCreateModel>
    {

        //[Obsolete]
        public UserCreateModelValidator()
        {
            //CascadeMode = CascadeMode.StopOnFirstFailure;
            RuleFor(x => x.Password).NotEmpty().WithMessage("Parola boş geçilemez.");
            RuleFor(x => x.ConfirmPassword).NotEmpty().WithMessage("Parola tekrarı boş geçilemez.");
            RuleFor(x => x.Password).MinimumLength(3).WithMessage("Parola en az 3 karakterden oluşmalıdır.");
            RuleFor(x => x.Password).Equal(x => x.ConfirmPassword).WithMessage("Girdiğiniz parolalar uyuşmamaktadır.");
            RuleFor(x => x.UserName).MinimumLength(5).WithMessage("Kullanıcı adı minimum 5 karakterden oluşmalıdır.");
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Kullanıcı adı boş geçilemez.");
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("Adınız boş geçilemez.");
            RuleFor(x => x.SurName).NotEmpty().WithMessage("Soyadınız boş geçilemez.");
            RuleFor(x => x.Email).NotEmpty().WithMessage("E-mail adresi boş geçilemez.");
            RuleFor(x => x.PhoneNumber).NotEmpty().WithMessage("Telefon numarası boş geçilemez.");
        }
    }
}
