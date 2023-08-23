// using Microsoft.AspNetCore.Mvc;
// using Olimpo.Controllers;
// using Olimpo.Models;

// namespace Olimpo.Views
// {
//     [ApiController]
//     [Route("api/login")]
//     public class LoginHandler : ControllerBase
//     {   
//         private CadastroController cadastroController = new CadastroController();

//         [HttpGet("{tokenId}", Name = "ValidadeParticipanteByToken")]
//         public ActionResult<LoginResponse> ValidadeParticipanteByToken(string tokenId)
//         {
//             var response = cadastroController.ValidadeParticipanteByToken(tokenId); 
//             if(response == null)
//             {
//                 return NotFound();
//             }

//             return response;
//         }
//     }
// }
