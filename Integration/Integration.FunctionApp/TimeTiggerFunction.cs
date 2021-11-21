namespace myFunctionAppDemo
{
    using Microsoft.Azure.WebJobs;
    using Microsoft.Extensions.Logging;
    using System;
    using System.IO;
    using System.Net;

    public static class TimeTiggerFunction
    {
        [FunctionName("TimeTiggerFunction")]
        public static void Run([TimerTrigger("%TimeInterval%")] TimerInfo myTimer, ILogger log)
        {
            log.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");
        }
    }
}
