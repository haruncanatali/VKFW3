using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace VKFW3.Api.Controllers;

// Api Şablonları
[ApiController]
[Route("api/[controller]")]
public abstract class BaseController : ControllerBase
{
    // Mediator DI İşlemleri
    
    private IMediator _mediator;

    protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
}