using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Data.Interfaces;
using Data.Models;

namespace Service.Controllers
{
    [Produces("application/json")]
    [Route("[controller]")]
    public class ValidateController : Controller
    {
        private IValidator _validator;
        public ValidateController(IValidator validator) => _validator = validator;

        /// <summary>
        /// Validates the addition of a new player to an existing team
        /// </summary> 
        /// <remarks>
        /// Sample request:
        ///
        /// </remarks>
        /// <param name="purchaserequest"></param>
        /// <returns>A validation response (true/false, and list of errors if false)</returns>
        /// <response code="201">Returns the validation response </response>
        /// <response code="400">If the request or playerToPurchase is null</response>    
        [HttpPost("/purchase")]
        [ProducesResponseType(typeof(ValidationResult), 201)]
        [ProducesResponseType(400)]
        public IActionResult Purchase([FromBody]PurchaseRequest purchaserequest)
        {
            if(purchaserequest==null||purchaserequest.PlayerToPurchase==null) return BadRequest();
            
            return new JsonResult(_validator.ValidatePlayerPurchase(purchaserequest.CurrentTeam,purchaserequest.PlayerToPurchase));
        }

        /// <summary>
        /// Validates the replacement of an existing player with a new player
        /// </summary> 
        [HttpPost("/transfer")]
        [ProducesResponseType(typeof(ValidationResult), 201)]
        [ProducesResponseType(400)]
        public IActionResult Transfer([FromBody]TransferRequest request)
        {
            return new JsonResult(_validator.ValidateTransfer(request.CurrentTeam,request.PlayerIn,request.PlayerOut));
        }

        /// <summary>
        /// Validates an entire team
        /// </summary> 
        [HttpPost("/team")]
        [ProducesResponseType(typeof(ValidationResult), 201)]
        [ProducesResponseType(400)]
        public IActionResult Team([FromBody]Team team)
        {
            return new JsonResult(_validator.Validate(team));
        }
    }
}
