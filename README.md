# C# .net6 w/ Unity client w/ Custom Utils
 project is an experimental
## Intro
 

### Common used
 - [Custom .Net6 TcpCore](https://github.com/yoonbigbear/CSharp-TCP-Core)
 - [Google Flatbuffer](https://google.github.io/flatbuffers/)
 - [Custom TableConverter](https://github.com/yoonbigbear/TableConverter)
 - [Custom C# Libraries](https://github.com/yoonbigbear/MMOLib)
## Unity Client
![image](https://user-images.githubusercontent.com/101116747/224535900-3d705901-0f62-4f2a-9afd-011e0268e5b7.png)
Server-Unity client location and conflict synchronization purpose.

Only character movement and synchronization are possible. You can also display the collision range.

## Server
![image](https://user-images.githubusercontent.com/101116747/224535958-2142770f-9a12-4e24-bda9-4de117bf4ce2.png)
A C# Tcpmmo server built on a server core using .net6 tcp and system.io.pipeline. The database uses MySql and goes through the login phase through the Http terminal.

Game data is created using an Excel table and is automatically generated as a csv file and C# source code for use by Unity clients and servers using a converter.

Create a character unique ID using the custom ID generator and use it as a key in the database, and the database uses MySql.

Additional features are use Rabbit MQ and Redis db.

## ~~GraphicsClient~~
~~A tool originally built with Winform for command and monitoring purposes on the server.~~


