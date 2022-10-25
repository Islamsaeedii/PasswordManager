using Application.Details;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class InformationController : BaseApiController
    {
        private readonly ILogger<InformationController> _logger;
        public InformationController(ILogger<InformationController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> CreateInfo(Information information)
        {
            _logger.LogInformation("Create Information");
            return HandleResult(await Mediator.Send(new Create.Command { Information = information }));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            _logger.LogInformation("Edit Information");

            return HandleResult(await Mediator.Send(new Delete.Command { Id = id }));
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(string id, EditDto info)
        {
            _logger.LogInformation("Delete Information");


            info.Id = id;
            return HandleResult(await Mediator.Send(new Edit.Command { Info = info }));
        }
    }
}