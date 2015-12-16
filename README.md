# BusinessLight
[![Build status](https://ci.appveyor.com/api/projects/status/trqsqqr8mwag8opt?svg=true)](https://ci.appveyor.com/project/martinobordin/businesslight)

![BusinessLight](http://www.martinobordin.it/businesslight.png) Light framework for speed up writing .NET Line of Business (LOB) applications

## What is
- Entities, Value objects and common types for model your data
- Repository, Unit of Work and Query object abstraction (implementation with EntityFramework and InMemory)
- Mapping abstraction (implementation with Automapper)
- Validation abstraction (implemention with FluentValidation)
- ServiceLayer footprint

## What is not
It's not a silver bullet framework (otherwise I'll be billionaire). It's a footprint for developing applications and has abstractions that allows to plug-in your busienss logics.

## Installation
Install using Nuget or compile binary from https://github.com/martinobordin/BusinessLight.

https://www.nuget.org/packages?q=businesslight

## Samples
The solution contains a sample PhoneBook application with 3 UI:
- MVC
- Angular (coming soon)
- Console

## Demo
Checkout the MVC sample here: http://phonebooksample.azurewebsites.net

## Disclaimer

The software is provided "AS IS". I didn't full test it (Chart.Js has tons of options) and you'd need to properly escape strings containing JavaScript and be sure to pass correct parameters (valid colors values, etc) .

To contribute and improve the code just contact me!
