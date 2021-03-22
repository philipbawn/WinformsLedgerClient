# WinformsLedgerClient
This is a project for experimenting with the GoDbLedger grpc api

This works with and requires that you are running GoDbLedger.
I am currently developing against v0.5.1 https://github.com/darcys22/godbledger/commit/d5b6153b4c01dd2aa1fd8d0d71e5e55033b889a5

## Features
The only feature is searching transactions. You are presented a start and end date pickers and can choose any valid starting and ending DateTime.
Once you've chosen a start and end date you can click a button to retrieve all transactions.

Right now I only have support for the USD currency.

## Running and developing
Download the .NET 5 SDK from https://dotnet.microsoft.com/download/dotnet
Change directory into the LedgerFormsApp project folder and type dotnet run to run the project.

## Debugging
I recommend using Visual Studio Community  (https://visualstudio.microsoft.com/) for developing .NET applications.