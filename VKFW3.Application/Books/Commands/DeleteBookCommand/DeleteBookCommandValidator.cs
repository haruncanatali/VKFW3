using FluentValidation;

namespace VKFW3.Application.Books.Commands.DeleteBookCommand;

public class DeleteBookCommandValidator : AbstractValidator<DeleteBookCommand>
{
    public DeleteBookCommandValidator()
    {
        RuleFor(c => c.Id)
            .NotNull().WithMessage("Id boş olamaz.");
    }
}