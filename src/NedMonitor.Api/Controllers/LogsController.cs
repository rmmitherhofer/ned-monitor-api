using Microsoft.AspNetCore.Mvc;
using NedMonitor.Application.Commands;
using NedMonitor.Application.Core;
using NedMonitor.Application.Queries;
using NedMonitor.Application.Requests;
using NedMonitor.Domain.Interfaces;
using Swashbuckle.AspNetCore.Annotations;
using Zypher.Api.Foundation.Controllers;
using Zypher.Json;
using Zypher.Notifications.Interfaces;

namespace NedMonitor.Api.Controllers;

[ApiVersion("1.0", Deprecated = false)]
[Route("api/v{version:ApiVersion}/logs")]
public class LogsController : MainController
{
    private readonly ILogger<LogsController> _logger; 
    private readonly IMediatorHandler _mediatorHandler;
    private readonly ILogQuery _logQuery;

    public LogsController(INotificationHandler notification, ILogger<LogsController> logger, IMediatorHandler mediatorHandler, ILogQuery logQuery) : base(notification)
    {
        _logger = logger;
        _mediatorHandler = mediatorHandler;
        _logQuery = logQuery;
    }

    [SwaggerOperation(Tags = new[] { "Resume Summary" })]
    [HttpPost("context")]
    public async Task<IActionResult> Post([FromBody] LogContextInfo request)
    {
        if (request is null)
        {
            Notify("");
            return CustomResponse();
        }

        Console.WriteLine(JsonExtensions.Serialize(request));

        var result = await _mediatorHandler.Send(new AddLogCommand(request));

        return CustomResponse(result);
    }

    [HttpGet]
    public async Task<IActionResult> Get([FromQuery]LogFilterRequest request)
    {
        return CustomResponse(await _logQuery.Get(request));
    }
}
