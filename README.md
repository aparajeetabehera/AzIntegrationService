# Integrating Azure Service Bus using Azure Function

1. [ Integration Scenario ](#aIntScenario)
2. [ Create Azure Service Bus using azure portal  ](#aServiceBus)
3. [ Create Azure Service Bus Queue using azure portal](#aServiceBusQueue)
4. [ Create Azure Function App using azure portal  ](#aFunctionApp)
5. [ Implement Service Bus Trigger Azure Function ](#aFunctionTrigger)
6. [ Send messages to Queue ](#aSendMessage)


<a name="aIntScenario"></a>
##	1. Integration Scenario 
 
Let’s assume XYZ is a client and its app acts as a source, asynchronously sending messages to service bus queue. An azure function which is bound to trigger on every message received at the queue, process it and saves the data to the CRM System and acts as target. The message data can be of any kind of information including structured data encoded with the common formats such as JSON, XML, Plain Text.

![image](https://user-images.githubusercontent.com/3272780/142763934-92a679d9-3b91-4828-8d53-d925f658d742.png)


<a name="aServiceBus"></a>
##	2. Create Azure Service Bus using azure portal

1. [Sign-In](http://portal.azure/) to your Azure Portal.
2. Type and select 'Service Bus' in the search bar. Click '+ Create' under the 'Service Bus' section.
3. Enter the basics configuration details and click "Review + create" button.
</br>

![image](https://user-images.githubusercontent.com/3272780/142761298-3a71057e-0023-4d4d-bf3c-4d09a04d3cc3.png)


<a name="aServiceBusQueue"></a>
##	3. Create Azure Service Bus Queue using azure portal

1. Navigate to your Service Bus. 
2. Click 'Queues' under the Entities left menu. Click '+ Queue' under the 'Queues' section.
3. Enter the basics configuration details under the 'Create Queue' left panel. And click 'create' button.
</br>

![image](https://user-images.githubusercontent.com/3272780/142761304-1eccaaf9-9ba0-4f8e-8d5e-4210825ff6a6.png)

<a name="aFunctionApp"></a>
##	4. Create Azure Function App using azure portal

1. Type and select 'Function App' in the search bar. Click '+ Create' under the 'Function App' section.
2. Enter the basics configuration details under the 'Create Function App' section. Ann click 'Next: Hosting' button.
</br>

![image](https://user-images.githubusercontent.com/3272780/142761308-573b5138-7df3-4dca-95bc-a0dee0a76a6a.png)

3. Under 'Hosting' tab, provide the storage account, operating system and plan details. 
4. Click 'Next: Networking' button.
<br/>

![image](https://user-images.githubusercontent.com/3272780/142761312-d515340d-62fc-4c44-a2d4-24ba20d0f450.png)

5. Ignore 'Networking' tab, if 'consumption' plan is selected. Otherwise, choose 'Premium' or 'App service' plan for integrating with virtual networking.
6. Click 'Next: Mointoring' button.
<br/>

![image](https://user-images.githubusercontent.com/3272780/142761327-e06522cb-1de4-4fd2-b572-1e43c768d27f.png)

7. Ignore 'Application Insights' tab, if not required. Otherwise, enable application insights and provide the details.
8. Click 'Next' and click 'Review + Create' button.
<br/>

![image](https://user-images.githubusercontent.com/3272780/142761342-bfddb1ff-9d29-4426-aa13-c4bce4c16cb1.png)

<a name="aFunctionTrigger"></a>
##	5. Implement Service Bus Trigger Azure Function

1. Create your New Azure Function Project

![image](https://user-images.githubusercontent.com/3272780/140976100-1c692449-83af-4c2f-98fd-20b85eaf1f75.png)
![image](https://user-images.githubusercontent.com/3272780/140976139-4627c375-bcce-4e16-bd9f-a1d7d17e6c76.png)

2. Select Service Bus Queue Trigger Function

![image](https://user-images.githubusercontent.com/3272780/140976176-f4177471-32b6-4c30-af9a-b2eb285402e6.png)

3. Update your Azure function code  

       [FunctionName("PatientDetailsFunction")]
        public static void Run([ServiceBusTrigger("%QueueName%", Connection = "ServiceBusConnectionString")] string message, ILogger log)
        {
            log.LogInformation("PatientDetails Function started.", log);

            try
            {  
                // process the message
                ProcessMessage(message);
            }
            catch (Exception ex)
            {
                log.LogInformation("Error occurred: " + ex.Message);
            }
        }

4. Update your settings.json 
 
       {
       "IsEncrypted": false,
       "Values": {
       "FUNCTIONS_WORKER_RUNTIME": "dotnet",
       "ServiceBusConnectionString": "<Enter the azure Service Bus endpoint>",
       "QueueName": "<Enter your Queue Name>",
       "TimeInterval": <CRON EXPRESSION>,
       "AzureWebJobsStorage": "<Enter the azure storage account endpoint>"
       }
       }      
     

5. Run, Debug code

<a name="aSendMessage"></a>
##	6. Send messages to Queue

1. [Azure Service Bus client library for .NET](https://github.com/Azure/azure-sdk-for-net/blob/Azure.Messaging.ServiceBus_7.5.0/sdk/servicebus/Azure.Messaging.ServiceBus/README.md#send-and-receive-a-message)
2. Alternative option for sending message, Service Bus Explorer tool. This tool allow you to connect with Azure Service Bus and administer messaging entities much quickly and easily. [Download](https://aka.ms/servicebusexplorer)

Open Service Bus Explorer, Go to File and Connect. Manually enter your azure service bus connectionstring under the box, and start sending messages to your choose queue under the entities.

![image](https://user-images.githubusercontent.com/3272780/140977978-62a95c98-8f0c-4522-88bc-3857b5630761.png)

![image](https://user-images.githubusercontent.com/3272780/140978051-b617ba3b-2684-4f73-8d79-c1ee868a8801.png)

### HAPPY INTEGRATION!!!
