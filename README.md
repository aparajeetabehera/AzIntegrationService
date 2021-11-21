# Integrating Azure Service Bus using Azure Function

1. [ Integration Scenario ](#aIntScenario)
2. [ Integrate VNET with Azure Service Bus  ](#aVNetServiceBus)
3. [ Integrate VNET with Azure Function App  ](#aVNetFunctionApp)
4. [ Steps to create service bus trigger function ](#aFunctionTrigger)
5. [ Steps to send messages to Queue ](#aSendMessage)


<a name="aIntScenario"></a>
##	Integration Scenario 
 
Let’s assume XYZ is a client and its app acts as a source, asynchronously sending messages to service bus queue. An azure function which is bound to trigger on every message received at the queue, process it and saves the data to the CRM System and acts as target. The message data can be of any kind of information including structured data encoded with the common formats such as JSON, XML, Plain Text.

![image](https://user-images.githubusercontent.com/3272780/142759594-0a4e0d8e-e0cd-49b9-b13a-bb912d7e8a09.png)

<a name="aVNetServiceBus"></a>
##	Integrate VNET with Azure Service Bus

<a name="aVNetFunctionApp"></a>
##	Integrate VNET with Azure Function App

<a name="aFunctionTrigger"></a>
##	Steps to create Service Bus Trigger based Azure function

#### 1. Create your New Azure Function Project 

![image](https://user-images.githubusercontent.com/3272780/140976100-1c692449-83af-4c2f-98fd-20b85eaf1f75.png)
![image](https://user-images.githubusercontent.com/3272780/140976139-4627c375-bcce-4e16-bd9f-a1d7d17e6c76.png)

####	2. Select Service Bus Queue Trigger Function

![image](https://user-images.githubusercontent.com/3272780/140976176-f4177471-32b6-4c30-af9a-b2eb285402e6.png)

####	3. Update your Azure function code  

![image](https://user-images.githubusercontent.com/3272780/140976235-81360242-3c5f-4305-b3dc-78321dbfcbd8.png)

####	4. Update your settings.json 

![image](https://user-images.githubusercontent.com/3272780/140976831-4fe2487d-522e-4b6c-ac8c-9052a84903aa.png)

####	5. Run, Debug code

![image](https://user-images.githubusercontent.com/3272780/140976255-737df29e-0dad-4ca6-a94b-2797676665af.png)


####	6. Use Service Bus Explorer tool 

This tool allows you to connect to Azure Service Bus and administer messaging entities much quickly and easily. 

Download https://aka.ms/servicebusexplorer

Open Service Bus Explorer, Go to File and Connect. Manually enter your azure service bus connectionstring under the box, and start sending messages to your choose queue under the entities.

![image](https://user-images.githubusercontent.com/3272780/140977978-62a95c98-8f0c-4522-88bc-3857b5630761.png)

![image](https://user-images.githubusercontent.com/3272780/140978051-b617ba3b-2684-4f73-8d79-c1ee868a8801.png)

<a name="aSendMessage"></a>
##	Steps to send messages to Queue
