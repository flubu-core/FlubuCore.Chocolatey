# FlubuCore.Chocolatey

[![NuGet](https://img.shields.io/nuget/v/FlubuCore.CakePlugin.svg)](https://www.nuget.org/packages/FlubuCore.Chocolatey/)
[![Gitter](https://img.shields.io/gitter/room/FlubuCore/Lobby.svg)](https://gitter.im/FlubuCore/Lobby?utm_source=badge&utm_medium=badge&utm_campaign=pr-badge&utm_content=badge)
[![License](https://img.shields.io/github/license/flubu-core/flubuCore.CakePlugin.svg)](https://github.com/flubu-core/FlubuCore.Chocolatey/blob/master/LICENSE)

FlubuCore.Chocolatey is a [FlubuCore](https://github.com/flubu-core/flubu.core) plugin adds chocolatey specific tasks. 

Chocolatey is a software management solution unlike anything else you've ever experienced on Windows. It focuses on simplicity, security, and scalability. You write a software deployment in PowerShell once for any software (not just installers), then you can deploy it everywhere you have Windows with any solution that can manage systems (configuration management, endpoint management, etc) and track and manage updates of that software over time. Manage software on-premise, in the "Cloud", or in Docker containers with Chocolatey.

Plugin adds chocolatey tasks to FlubuCore ``` ITaskContext ``` interface:  ``` context.Tasks().Chocolatey(). ```

Plugin adds tasks for Following npm CLI commands:
* Install
* Upgrade
* Uninstall
* New
* Pack
* Publish

Find more about [Chocolatey](https://chocolatey.org/docs) 
