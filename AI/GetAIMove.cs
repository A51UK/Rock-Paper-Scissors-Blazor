using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using SharedObjects;

namespace AI
{
    public static class GetAIMove
    {
        [FunctionName("GetAIMove")]
        public static IActionResult Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = null)] HttpRequest req,
            ILogger log)
        {
            SharedFunctions sharedFunctions = new SharedFunctions();

            Random random = new Random();

            int randomMove = random.Next(0, 3);

            var move = sharedFunctions.GetMove(randomMove);

            return new OkObjectResult(move);
        }
    }
}
