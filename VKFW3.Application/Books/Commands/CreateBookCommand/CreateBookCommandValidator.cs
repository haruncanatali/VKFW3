using FluentValidation;
using VKFW3.Domain.Entities;

namespace VKFW3.Application.Books.Commands.CreateBookCommand;

public class CreateBookCommandValidator : AbstractValidator<CreateBookCommand>
{
    public CreateBookCommandValidator()
    {
        RuleFor(c => c.Name)
            .NotEmpty().WithMessage("Kitap adı boş olamaz.")
            .MaximumLength(100).WithMessage("Kitap adı max 100 karakter olmak zourndadır.");
        RuleFor(c => c.PageCount)
            .NotNull().WithMessage("Sayfa sayısı boş olamaz.");
        RuleFor(c => c.PublishedDate)
            .NotNull().WithMessage("Yayınlanma zamanı boş olamaz.");
        RuleFor(c => c.ISBN)
            .NotEmpty().WithMessage("ISBN boş olamaz.");
    }
}