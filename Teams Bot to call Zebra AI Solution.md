`                         `**Teams Bot to call Zebra AI Solution**

`                                                                                     `**---Amy Peng**

**1.Prerequisite:**
Ensure that you install the following tools and set up your development environment:

||
| :- |

|** |**Install**|**For using...**|
| :- | :- | :- |
| |[Microsoft 365 developer account](https://learn.microsoft.com/en-us/microsoftteams/platform/concepts/build-and-test/prepare-your-o365-tenant)|Access to Teams account with the appropriate permissions to install an app.|
| |[Visual Studio 2022](https://visualstudio.microsoft.com/)|You can install the enterprise version in Visual Studio 2022, and install the ASP.NET <br>and web development workloads. Use the latest version.|
| |[.NET Core SDK](https://dotnet.microsoft.com/en-us/download)|<p>Customized bindings for local debugging and Azure Functions app deployments. </p><p>If you haven't installed the latest version, install the portable version.</p>|
| |[Microsoft Teams](https://www.microsoft.com/microsoft-teams/download-app)|Microsoft Teams to collaborate with everyone you work with through apps for chat, <br>meetings, and call all in one place|
| |Dev tunnel|<p>A tunnel connects your development system to Teams. Dev tunnel is available in <br>Visual Studio 2022 version 17.7.0 or later.<br>or<br>You can also use [ngrok](https://ngrok.com/download) as a tunnel to connect your development system to Teams. </p><p></p>|

||
| :- |

**2.Register Microsoft Entra app**

1) **Go to [Azure portal](https://ms.portal.azure.com/).**
1) **Select App registrations.**

![Screenshot shows the Azure services to select App registrations.](Aspose.Words.19d4e15f-f853-43bc-984f-1e0af15bf6e2.001.png)

1) **Select + New registration.**

![Screenshot shows the New registration page on Microsoft Entra admin center.](Aspose.Words.19d4e15f-f853-43bc-984f-1e0af15bf6e2.002.png)

1) **Enter the name of your app.**
1) **Select Accounts in any organizational directory (Any Microsoft Entra ID tenant - Multitenant).**
1) **Select Register.**

![Screenshot shows the option to register the bot in Microsoft Entra admin center.](Aspose.Words.19d4e15f-f853-43bc-984f-1e0af15bf6e2.003.png)

**Your app is registered in Microsoft Entra ID. The app overview page appears.**

![Screenshot shows the app registration overview page.](Aspose.Words.19d4e15f-f853-43bc-984f-1e0af15bf6e2.004.png)

1) **Bind Service Management ID (If you want to use to get the application based permission)**

   ![](Aspose.Words.19d4e15f-f853-43bc-984f-1e0af15bf6e2.005.png)

1) **Get Zebra AI Application Permission (If you want to use to get the application based permission)**

![](Aspose.Words.19d4e15f-f853-43bc-984f-1e0af15bf6e2.006.png)

`     `**Note: You can skip the step 7 and step 8, if you only want to get the user based permission, which means that you can not share your teams bot to others if they are not the owner for your zebra AI experiments. But if you have done the step 7 and step 8 which means that everyone who is using your teams bot can use your zebra AI experiments.** 

**9) Go to [this Zebra AI form](https://forms.office.com/pages/responsepage.aspx?id=v4j5cvGGr0GRqy180BHbR3IuNv7lfiNCnaFIzX4ZZoFUQ0NGMUxFT1owVzM0MEtaWlVPWVRGOEs2Ni4u&route=shorturl) to apply for zebra API permission by entering your client ID and experiment id.**

**3. Setup your Local Debuging Environment**

1) **Open**  [**https://github.com/AmyPengMS/MSTeamsBot](https://github.com/AmyPengMS/MSTeamsBot) **to my github app**
1) **Select Code.**
1) **From the dropdown menu, select Open with GitHub Desktop or Download Zip.**
1) **Open the application using Visual Studio**
1) **In the debug dropdown list, select Dev Tunnels (no active tunnel) > Create a Tunnel....**

   ![Screenshot shows the dropdown to select the dev tunnels.](Aspose.Words.19d4e15f-f853-43bc-984f-1e0af15bf6e2.007.png)

1) **Update the following details in the pop-up window:**

   ![Screenshot shows the details to update for creation of tunnel.](Aspose.Words.19d4e15f-f853-43bc-984f-1e0af15bf6e2.008.png)

1) **A pop-up window appears showing that dev tunnel is successfully created.**

   ![Screenshot shows the pop-up message that the tunnel is created.](Aspose.Words.19d4e15f-f853-43bc-984f-1e0af15bf6e2.009.png)

1) **You can find the tunnel you've created in the debug dropdown list as follows:**

![Screenshot shows the tunnel is active and selected.](Aspose.Words.19d4e15f-f853-43bc-984f-1e0af15bf6e2.010.png)

1) **Select F5 to run the application in the debug mode.**
1) **If a Security Warning dialog appears, select Yes.**

![Screenshot shows the dialog box to accept the security warning.](Aspose.Words.19d4e15f-f853-43bc-984f-1e0af15bf6e2.011.png)

1) **A pop-up window appears.**
1) **Select Continue.**

![Screenshot shows the url for the tunnel.](Aspose.Words.19d4e15f-f853-43bc-984f-1e0af15bf6e2.012.png)

1) **The dev tunnel home page opens in a new browser window and the dev tunnel is now active.**

   ![Screenshot shows the dev tunnel welcome page in browser.](Aspose.Words.19d4e15f-f853-43bc-984f-1e0af15bf6e2.013.png)

1) **Go to Visual Studio, select View > Output.**
1) **From the Output console dropdown menu, select Dev Tunnels.**
1) **The Output console shows the dev tunnel URL.**

   ![Screenshot shows the url in the Visual Studio output console.] **17) Please remember this URL**

**4. Create Azure Bot**

1) **Go to Home.**
1) **Select + Create a resource.**
1) **In the search box, enter Azure Bot.**
1) **Select Enter.**
1) **Select Azure Bot.**
1) **Select Create.**

![Screenshot shows the creation of Azure bot.](Aspose.Words.19d4e15f-f853-43bc-984f-1e0af15bf6e2.015.png)

1) **Enter the bot name in Bot handle.**
1) **Select your Subscription from the dropdown list.**
1) **Select your Resource group from the dropdown list.**

![Screenshot shows the option resource group and subscription in the Azure portal.](Aspose.Words.19d4e15f-f853-43bc-984f-1e0af15bf6e2.016.png)

**If you don't have an existing resource group, you can create a new resource group. To create a new resource group, follow these steps:**

1. **Select Create new.**
1. **Enter the resource name and select OK.**
1. **Select a location from New resource group location dropdown list.**

   ![Screenshot shows the new resource group option in Azure portal.](Aspose.Words.19d4e15f-f853-43bc-984f-1e0af15bf6e2.017.png)

1) **Under Pricing, select Change plan.**

![Screenshot shows the pricing option in Azure portal.](Aspose.Words.19d4e15f-f853-43bc-984f-1e0af15bf6e2.018.png)

1) **Select FO Free > Select.**

![Screenshot shows the option to select free.](Aspose.Words.19d4e15f-f853-43bc-984f-1e0af15bf6e2.019.png)

1) **Under Microsoft App ID, select Type of App as Multi Tenant.**
1) **In the Creation type, select Use existing app registration.**
1) **Enter the App ID.**
1) **Select Review + create.**

![Screenshot shows the creation of new bot.](Aspose.Words.19d4e15f-f853-43bc-984f-1e0af15bf6e2.020.png)

1) **After the validation passes, select Create.**

**The bot takes a few minutes to provision.**

1) **Select Go to resource.**

![Screenshot shows the Go to resource option in the Azure portal.](Aspose.Words.19d4e15f-f853-43bc-984f-1e0af15bf6e2.021.png)

**You've successfully created your Azure bot.**

![Screenshot shows the output of a bot.](Aspose.Words.19d4e15f-f853-43bc-984f-1e0af15bf6e2.022.png)

**Add a Teams channel**

1. **In the left pane, select Channels.**
1. **Under Available Channels, select Microsoft Teams.**

![Screenshot shows the selection of Teams in channels.](Aspose.Words.19d4e15f-f853-43bc-984f-1e0af15bf6e2.023.png)

1. **Select the checkbox to accept the Terms of Service.**
1. **Select Agree.**

![Screenshot shows the acceptance of terms of service.](Aspose.Words.19d4e15f-f853-43bc-984f-1e0af15bf6e2.024.png)

1. **Select Apply.**

![Screenshot shows the Microsoft Teams as messaging to apply.](Aspose.Words.19d4e15f-f853-43bc-984f-1e0af15bf6e2.025.png)

**To add a messaging endpoint**

1) **Use the dev tunnel URL in the Output console as the messaging endpoint.**

   ![Screenshot shows the url in the Visual studio output console.][Screenshot shows the url in the Visual Studio output console.]

1) **In the left pane, under Settings, select Configuration.**
1) **Update the Messaging endpoint in the format https://your-devtunnel-domain/api/messages.**

   ![Screenshot shows the messaging endpoint adding api.](Aspose.Words.19d4e15f-f853-43bc-984f-1e0af15bf6e2.026.png)

1) **Select Apply.**
1) **You've successfully set up a bot in Azure Bot service.**

**5. Update your experiment id**

1) **Go to the MessageReactionBot.cs file to find the OnMessageActivityAsync method, then change the experiment id to your own and you can also add multiple experiment ids to get zebra AI data based on your requirements**

   **Note: This application is adding the authentication method for application based permission, if you want to have the user-based permission, please change this GetAPPEntraIdToken() method by referring this method: GetInteractiveUserEntraIdToken() on [Zebra AI official sample](https://microsoftapc.sharepoint.com/:u:/t/ZebraAI/EXoe5ZAy3_dOmVo1IW6qpTUBN3R7fhZiTZ5eKZTY0Ov7Rg?e=bhLvN5).**


**6.Set up bot service connection**

**To update appsettings**

1. **Open the appsettings.json file in Visual Studio and update the configuration for the bot.**

   1. **Set "MicrosoftAppType"to Multitenant.**
   1. **Set "MicrosoftAppId" to your bot's Microsoft App ID.**
   1. **Set "MicrosoftAppPassword" to your bot's client secrets Value.**
   1. **Set your "MicrosoftAppTenantId" to your tenant ID.**

![Screenshot shows the Appsettings Json.](Aspose.Words.19d4e15f-f853-43bc-984f-1e0af15bf6e2.027.png)

1. **Select Save.**

**To update manifest**

1. **In the File Explorer, go to Microsoft-Teams-Samples > samples > bot-conversation > csharp > TeamsApp > appPackage.**

![Screenshot shows the Manifest.](Aspose.Words.19d4e15f-f853-43bc-984f-1e0af15bf6e2.028.png)

1. **Open the manifest.json file in Visual Studio and make the following changes:**

   1. **Replace "id"and "botId" to your bot's Microsoft App ID.**
   1. **Replace validDomains to "validDomains": [
      `     `"\*.asse.devtunnels.ms",]**
1. **Zip the contents of the** appPackage **folder to create manifest.zip.**

` `**Note**

**The manifest.zip must not contain any other folders in it. It must have manifest json source file, color icon, and outline icon inside the zip folder. Run your solution in Visual Studio and upload your manifest in your demo tenant for organization or your Teams account.**

**7.Install Teams APP**

**To upload the app to Teams**

1. **In the Teams client, select the Apps icon.**
1. **Select Manage your apps.**
1. **Select Upload an app.**
1. **Look for the option to Upload a custom app. If the option is visible, custom app upload is enabled.**

![Screenshot shows the option to upload a custom app.](Aspose.Words.19d4e15f-f853-43bc-984f-1e0af15bf6e2.029.png)

` `**Note**

**Contact your Teams administrator, if you don't find the option to upload a custom app.**

1. **Select Open to upload the .zip file that you created in the appPackage folder.**

![Screenshot shows the Manifest upload in Teams.](Aspose.Words.19d4e15f-f853-43bc-984f-1e0af15bf6e2.030.png)

1. **Select Add.**

![Screenshot shows the app added into Teams.](Aspose.Words.19d4e15f-f853-43bc-984f-1e0af15bf6e2.031.png)

**You can interact with the bot.**

**8.Deploy Application to Azure**

**1) Right-Click your solution and click Pulish step by step to publish to Azure App Service**

![A screenshot of a computer

Description automatically generated](Aspose.Words.19d4e15f-f853-43bc-984f-1e0af15bf6e2.032.png)

**2)Please remember to change your bot messging endpoint to your azurewebsite uri**

![](Aspose.Words.19d4e15f-f853-43bc-984f-1e0af15bf6e2.033.png)

**3)Please remember to change validDomains in your manifest to your azurewebsite uri
![A screen shot of a computer

Description automatically generated](Aspose.Words.19d4e15f-f853-43bc-984f-1e0af15bf6e2.034.png)**

**4)Zip your manifest again**

**5) Follow the step 8 to install teams app again**

**6)Now you can share your manifest to others to use your bots.**







[Screenshot shows the url in the Visual Studio output console.]: Aspose.Words.19d4e15f-f853-43bc-984f-1e0af15bf6e2.014.png
