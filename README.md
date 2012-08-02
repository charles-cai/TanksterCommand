## Tankster Command: Leaderboard & Chat Sample

The Leaderboard sample demonstrates how you can combine ASP.NET and Node.js in the same web application. The application consists of the following components.

* An [ASP.NET MVC 4](http://www.asp.net/mvc/mvc4) leaderbaord application using Entity Framework Code First.
* A [Node.js](http://nodejs.org/) server that leverages [Socket.IO](https://socket.io) to handle real-time communication between chat users.
* A [Redis](http://redis.io) store to persist Socket.IO connections and messages, permitting to scale out the chat services.

### Prerequisites

* [Visual Studio 2010 or greater](http://www.microsoft.com/visualstudio/en-us/products)
* [ASP.NET MVC 4](http://www.asp.net/mvc/mvc4)
* [Windows Azure SDK for Node.js 1.6 or greater](http://www.windowsazure.com/en-us/develop/nodejs/)
* [IIS 7.5 Express or greater](http://www.microsoft.com/web/gallery/install.aspx?appid=IISExpress)
* [IISNode for IIS 7.5 Express or greater](http://go.microsoft.com/fwlink/?LinkId=255386)

### Running the Sample Locally

1. Open the **TanksterCommand.sln** solution.
2. Compile the solution. The NuGet packages dependencies will be automatically downloaded and installed.
3. Create a Facebook Application and set the FacebookAppId and FacebookAppSecret in the web.config file. You must also set the Facebook Site Url for you Facebook application to the URL where your site will run locally, for example http://localhost:23595. See [this post](http://blog.ntotten.com/2012/07/23/facebook-apps-and-windows-azure-web-sites-part-1-getting-started/) or [Facebook's article](https://developers.facebook.com/docs/opengraph/tutorial/) for more details on setting up a Facebook app.

		<add key="FacebookAppId" value="..." />
		<add key="FacebookAppSecret" value="..." />
4. Press F5 to run the sample. Log in and try the Chat view.

### Deploying the Application to Windows Azure

1. Create a Windows Azure Web Site with a Database and download the publish profile. See [this tutorial](https://www.windowsazure.com/en-us/develop/net/tutorials/web-site-with-sql-database/) for more details.
2. After you have downloaded the publish profile open the project in Visual Studio. Right-click on the TanksterCommand project and click publish.
3. Import your publish profile and click publish. 
4. Be sure to enable code first migrations in order to setup your database after you deploy.

	![Enable Migrations](https://raw.github.com/WindowsAzure-Samples/TanksterCommand/master/assets/enablemigrations.png?login=ntotten&token=c25deb33f7682c3f747f84b1b7401e96)
5. Click publish and wait for the application to deploy.
6. After the applciation is published it will open in the browser. You can now login and test the chat.
