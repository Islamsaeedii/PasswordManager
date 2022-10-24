using Application.Details;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class InformationController : BaseApiController
    {
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> CreateInfo(Information information)
        {
            return HandleResult(await Mediator.Send(new Create.Command { Information = information }));
        }
        [AllowAnonymous]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            return HandleResult(await Mediator.Send(new Delete.Command { Id = id }));
        }
        [AllowAnonymous]
        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(string id, EditDto info)
        {
            info.Id = id;
            return HandleResult(await Mediator.Send(new Edit.Command { Info = info }));
        }
    }
}