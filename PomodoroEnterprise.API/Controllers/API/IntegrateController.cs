using PomodoroEnterprise.API.EF;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TrelloNet;

namespace PomodoroEnterprise.API.Controllers.API
{
    [Authorize]
    [RoutePrefix("api/integrate")]
    public class IntegrateController : ApiController
    {
        [Route("trelloAuth")]
        [HttpGet]
        public IHttpActionResult Get()
        {
            ITrello trello = new Trello(ConfigurationManager.AppSettings["TrelloAppID"]);
            var uri = trello.GetAuthorizationUrl("SampleApp", Scope.ReadWriteAccount);
            string url = uri.ToString() + "&return_url=http://localhost:7743/Trello/Register?token=";
            return Redirect(url);
        }

        private DataContext db = new DataContext();
        
        [HttpGet]
        [Route("trello")]
        public IHttpActionResult Trello(string username,string password)
        {
            ITrello trello = new Trello(ConfigurationManager.AppSettings["TrelloAppID"]);
            var me = trello.Members.Me();

            var myBoard = trello.Boards.ForMe(BoardFilter.All);
            
            return Ok();
        }
    }
}
