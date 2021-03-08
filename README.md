# Contoso Bicycle
[![Build Status](https://dev.azure.com/contoso6719/ContosoBicycle/_apis/build/status/RandyPatterson.ContosoBicycle?branchName=main)](https://dev.azure.com/contoso6719/ContosoBicycle/_build/latest?definitionId=1&branchName=main)

![Logo](./images/bike.jpg)

## Description 
Sample Application showing the integration of **GitHub** and **Azure DevOps**.  
The Sample application is an ASP.NET MVC application hosted in IIS. 

1. Uses docker-compose for local development and deploys to Azure Kubernetes Service
1. Uses a PowerShell script to update or insert env variables into web.config for a no code change migration to Kubernetes
1. Uses a Publish Profile named *docker* in the CI pipeline to to publish application to a directory that the **dockerfile** expects

