﻿using ImageStorage.BLL.Models.CreateModels;
using ImageStorage.BLL.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace webapi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RegistrationController : ControllerBase
    {
        private readonly IAccountService _accountService;
        public RegistrationController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateAccountModel model)
        {
            if (ModelState.IsValid)
            {
                string jwt = await _accountService.CreateAccountAsync(model);
                return new JsonResult(jwt);
            }

            return BadRequest(ModelState);
        }
    }
}
