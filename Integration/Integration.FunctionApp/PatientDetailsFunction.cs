namespace myFunctionAppDemo
{
    using System;
    using System.Linq;
    using System.Text.Json;

    using Integration.FunctionApp.Models;
    using Microsoft.Azure.WebJobs;
    using Microsoft.Extensions.Logging;
    using Newtonsoft.Json.Linq;

    public class PatientDetailsFunction
    {
        [FunctionName("PatientDetailsFunction")]
        public static void Run([ServiceBusTrigger("%QueueName%", Connection = "ServiceBusConnectionString")] string message, ILogger log)
        {
            log.LogInformation("PatientDetails Function started.", log);

            try
            {
                // validate message
                if (JToken.Parse(message).Count() == 0)
                {
                    log.LogInformation("Message is empty.");
                    return;
                }

                ProcessMessage(message);
            }
            catch (Exception ex)
            {
                log.LogInformation("Error occurred: " + ex.Message);
            }
        }

        /// <summary>
        /// process message
        /// </summary>
        /// <param name="message">Patient information.</param>
        private static void ProcessMessage(string message)
        {
            // Deserialize queue message
            var data = JsonSerializer.Deserialize<Patient>(message, new JsonSerializerOptions { AllowTrailingCommas = true });

            // apply business rules, process the information and save to the target system.
        }
    }
}
