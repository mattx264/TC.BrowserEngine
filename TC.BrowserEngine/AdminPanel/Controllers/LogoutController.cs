using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TC.BrowserEngine.AdminPanel.DataAccess;

namespace TC.BrowserEngine.AdminPanel.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LogoutController : ControllerBase
    {
        private BrowserEngineManager _browserEngineManager;
        private LocalUserRepository _localUserRepository;

        public LogoutController(BrowserEngineManager browserEngineManager)
        {
            _browserEngineManager = browserEngineManager;
            _localUserRepository = new LocalUserRepository();
        }
        [HttpPost]
        public ActionResult Post()
        {
            _localUserRepository.LogoutCurrentUser();
            _browserEngineManager.StopInstances();
            return Ok();
        }
    }
}
