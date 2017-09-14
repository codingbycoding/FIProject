# FIProject

## 1. Overview 
The project was a part of my master's thesis, it is a small demo [Unity](https://unity3d.com/) project with a server side which consists of **Game Server** and **Online Server**.
**Online Server** is based on [Ice](https://zeroc.com/products/ice) framework.
The project focuses on the process to build a network-based unity game using a flexible server side.

Both the client and server are cross platform, for client side because of Unity's cross platform ability, 
and for server side's Online Server because Ice framework cross platform ability.

The Unity scenes in this project are very simple which are only for distinguish with each other and to fulfill the basic avatar operations.


## 2. Client(Game Client)
The Client or **Game Client** is a Unity project and all the Unity Assets are imported from Unity Standard Assets or [Unity Asset Store](https://www.assetstore.unity3d.com/) free assets.
The Client communicates with Game Server using Unity Unet, and communicates with Online Server using Ice.

the Unity Object **GameClient** is the entry of Game Server's logic.
To build the Game Client use the **GameClient** scene as the first scene in Unity build setting.

## 3. Servers(Game Server & Online Server)
The Servers consist of **Game Server** and **Online Server**.
The Game Server shares the same assets with Game Client.

The Online Server is a seperate java project which uses Ice Framework.

### 3.1 Game Server
The Game Server shares the resource with Game Client, but the Unity Object GameServer is the entry of Game Server's logic.
To build the Game Server use the GameServer scene as the first scene in Unity build setting.

### 3.2 Online Server
The **Online Server** resides in **OnlineServies** folder, using [Gradle](https://gradle.org/) as the build tool.


## 4. Tools
All the script files which are used to launch the Servers(Game Server & Online Server) reside in Tools folder.
The project has been tested both in Windows 10 and macOS Sierra.



