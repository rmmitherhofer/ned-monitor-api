using Api.Service.Controllers;
using Common.Notifications.Interfaces;
using Microsoft.AspNetCore.Mvc;
using NedMonitor.Application.Commands;
using NedMonitor.Application.Core;
using NedMonitor.Application.Requests;
using Swashbuckle.AspNetCore.Annotations;

namespace NedMonitor.Api.Controllers;

[ApiVersion("1.0", Deprecated = false)]
[Route("api/v{version:ApiVersion}/logs")]
public class LogsController : MainController
{
    private readonly ILogger<LogsController> _logger; 
    
    private readonly IMediatorHandler _mediatorHandler;

    public LogsController(INotificationHandler notification, ILogger<LogsController> logger, IMediatorHandler mediatorHandler) : base(notification)
    {
        _logger = logger;
        _mediatorHandler = mediatorHandler;
    }

    [SwaggerOperation(Tags = new[] { "Resume Summary" })]
    [HttpPost("context")]
    public async Task<IActionResult> Post([FromBody] LogContextRequest request)
    {
        if (request is null)
        {
            Notify("");
            return CustomResponse();
        }

        var result = await _mediatorHandler.Send(new AddLogCommand(request));

        return CustomResponse(result);
    }
}
