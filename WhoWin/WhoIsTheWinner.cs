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
using SharedObjects.Enum;
using SharedObjects.Modal;

namespace WhoWin
{
    public static class WhoIsTheWinner
    {
        [FunctionName("GetTheWinner")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] HttpRequest req,
            ILogger log)
        {

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            Payers data = (Payers)JsonConvert.DeserializeObject(requestBody, typeof(Payers));

            var win = WhoWin(data);

            return new OkObjectResult(win);
        }


        private static Win WhoWin(Payers player) => player switch
        {
            { Human.move: Move.Paper, Bot.move: Move.Rock } => Win.Player,
            { Human.move: Move.Scissors, Bot.move: Move.Paper } => Win.Player,
            { Human.move: Move.Rock, Bot.move: Move.Scissors } => Win.Player,
            { Human.move: Move.Paper, Bot.move: Move.Scissors } => Win.Computer,
            { Human.move: Move.Scissors, Bot.move: Move.Rock } => Win.Computer,
            { Human.move: Move.Rock, Bot.move: Move.Paper } => Win.Computer,
            { Human.move: Move.Paper, Bot.move: Move.Paper } => Win.Draw,
            { Human.move: Move.Rock, Bot.move: Move.Rock } => Win.Draw,
            { Human.move: Move.Scissors, Bot.move: Move.Scissors } => Win.Draw,
            _ => throw new NotImplementedException()
        };
    }
}
