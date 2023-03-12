# C# .net6 w/ Unity client w/ Custom Utils
 project is an experimental
## Intro

C# 서버엔진과 유니티 클라이언트를 이용한 MMORPG 개발을 진행중인 프로젝트입니다.
.Net6와 5부터 나온 IO.Pipeline(Unity는 사용 불가)를 사용한 패킷버퍼를 기반으로 소켓 통신을 할 수 있도록 개발되었습니다.


### Common used
 - [Custom .Net6 TcpCore](https://github.com/yoonbigbear/CSharp-TCP-Core)
 - [Google Flatbuffer](https://google.github.io/flatbuffers/)
 - [Custom TableConverter](https://github.com/yoonbigbear/TableConverter)
 - [Custom C# Libraries](https://github.com/yoonbigbear/MMOLib)
## Unity Client
![image](https://user-images.githubusercontent.com/101116747/224535900-3d705901-0f62-4f2a-9afd-011e0268e5b7.png)
Server-Unity client location and conflict synchronization purpose.

Only character movement and synchronization are possible. You can also display the collision range.

주 목적은 이동 동기화 및 충돌 박스 체크등 유니티-C# 서버 동기화 R&D 용도로 개발중인 클라이언트입니다.

## Server
![image](https://user-images.githubusercontent.com/101116747/224535958-2142770f-9a12-4e24-bda9-4de117bf4ce2.png)
A C# Tcpmmo server built on a server core using .net6 tcp and system.io.pipeline. The database uses MySql and goes through the login phase through the Http terminal.

Game data is created using an Excel table and is automatically generated as a csv file and C# source code for use by Unity clients and servers using a converter.

Create a character unique ID using the custom ID generator and use it as a key in the database, and the database uses MySql.

Additional features are use Rabbit MQ and Redis db.

C# MMO 서버엔진으로 상용화 가능한 단계까지 사용 가능한 엔진을 개발하고 있습니다.
클라이언트-서버간이 패킷핸들링과, 간단한 동기화가 가능합니다. Http를 이용해 계정 로그인 단계를 진행하며 게임 내부는 TCP를 통해 통신합니다.
Database로는 MySql을 사용하고있습니다.

그 외 RabbitMq와 Redis db 사용이 가능하지만 아직 사용중인 컨텐츠는 없습니다.

## ~~GraphicsClient~~
~~A tool originally built with Winform for command and monitoring purposes on the server.~~

~~서버 명령어 및 패킷테스트 용도의 윈폼 툴~~
