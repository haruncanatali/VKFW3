using MediatR;
using Microsoft.AspNetCore.Mvc;
using VKFW3.Application.Books.Commands.CreateBookCommand;
using VKFW3.Application.Books.Commands.DeleteBookCommand;
using VKFW3.Application.Books.Commands.UpdateBookCommand;
using VKFW3.Application.Books.Queries.Dtos;
using VKFW3.Application.Books.Queries.GetBook;
using VKFW3.Application.Books.Queries.GetBooks;

namespace VKFW3.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class BookController : BaseController
{
    [HttpGet("{id}")]
    public async Task<ActionResult<BookDto>> Get(long id)
    {
        return Ok(await Mediator.Send(new GetBookQuery{Id = id}));
    }
    
    [HttpGet]
    public async Task<ActionResult<List<BookDto>>> Get([FromQuery]GetBooksQuery query)
    {
        return Ok(await Mediator.Send(query));
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> Create(CreateBookCommand command)
    {
        return Ok(await Mediator.Send(command));
    }
    
    [HttpPut]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> Update(UpdateBookCommand command)
    {
        return Ok(await Mediator.Send(command));
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(long id)
    {
        await Mediator.Send(new DeleteBookCommand { Id = id });
        return NoContent();
    }
}