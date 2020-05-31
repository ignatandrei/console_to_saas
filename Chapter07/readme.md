# Chapter 07 - Passing to SAAS

The business figures out that the application can be easy done as a Software as a Service instead of working on local.
From a business perspective, this means recurring paying customers instead of selling one shot the application . As an example, see Office XP that you buy versus Office 365 on cloud.

## Technical approach - what must be build


### Web Application

The application must be converted to a web application ( eventually, a mobile application should be ready also)

### Users / Roles / configuration

The application should have one or more ways to identify users ( either username + password, either via a third provider, like Google / Facebook  , either via an integrated provider , like Azure Active Directory /  Okta)

### Revisit application to see what works on local and should be handled differently on web

There are will be always some parts of the application that will work on local. 
In our example , the application is monitoring either : 
1.  Network files
2.  Zip files

The zip files can be uploaded and processed ion the web. But, for the local files, the architecture should be somehow different : You may think about an agent that works on local , monitors the local file system and uploads data to the web to be processed. 

[![](https://mermaid.ink/img/eyJjb2RlIjoic3RhdGVEaWFncmFtIFxuICAgIFxuICAgXG4gICAgTG9jYWxQQyAtLT4gV2ViRnVuY3Rpb24gOiBzZW5kcyBkYXRhIGZyb20gbG9jYWwgUENcbiAgICBXZWJGdW5jdGlvbiAtLT5XZWJBcHAgOiBub3RpZmllcyBkYXRhIHJlYWR5IC8gcHJvY2Vzc2luZ1xuICAgIFVzZXItLT4gV2ViQXBwIDogc2VlIHJlc3VsdHNcbiAgICBzdGF0ZSBMb2NhbFBDICB7XG4gICAgICAgIEhhcmREcml2ZSAtLT4gTG9jYWxBcHAgICAgICAgICBcblxuICAgIH1cbiAgICBzdGF0ZSBXZWJGdW5jdGlvbiB7XG4gICAgICAgIFJlY2VpdmVEYXRhIC0tPiBQcm9jZXNzRGF0YSAgICAgICAgXG4gICAgICAgIFByb2Nlc3NEYXRhIC0tPiBTdG9yZXNSZXN1bHRcbiAgICB9XG4gICAgc3RhdGUgV2ViQXBwe1xuICAgICAgU3RvcmVzUmVzdWx0LS0-IERpc3BsYXlEYXRhXG4gICAgfVxuXG5cdFxuXHRcdFx0XHRcdCIsIm1lcm1haWQiOnsidGhlbWUiOiJkZWZhdWx0In0sInVwZGF0ZUVkaXRvciI6ZmFsc2V9)](https://mermaid-js.github.io/mermaid-live-editor/#/edit/eyJjb2RlIjoic3RhdGVEaWFncmFtIFxuICAgIFxuICAgXG4gICAgTG9jYWxQQyAtLT4gV2ViRnVuY3Rpb24gOiBzZW5kcyBkYXRhIGZyb20gbG9jYWwgUENcbiAgICBXZWJGdW5jdGlvbiAtLT5XZWJBcHAgOiBub3RpZmllcyBkYXRhIHJlYWR5IC8gcHJvY2Vzc2luZ1xuICAgIFVzZXItLT4gV2ViQXBwIDogc2VlIHJlc3VsdHNcbiAgICBzdGF0ZSBMb2NhbFBDICB7XG4gICAgICAgIEhhcmREcml2ZSAtLT4gTG9jYWxBcHAgICAgICAgICBcblxuICAgIH1cbiAgICBzdGF0ZSBXZWJGdW5jdGlvbiB7XG4gICAgICAgIFJlY2VpdmVEYXRhIC0tPiBQcm9jZXNzRGF0YSAgICAgICAgXG4gICAgICAgIFByb2Nlc3NEYXRhIC0tPiBTdG9yZXNSZXN1bHRcbiAgICB9XG4gICAgc3RhdGUgV2ViQXBwe1xuICAgICAgU3RvcmVzUmVzdWx0LS0-IERpc3BsYXlEYXRhXG4gICAgfVxuXG5cdFxuXHRcdFx0XHRcdCIsIm1lcm1haWQiOnsidGhlbWUiOiJkZWZhdWx0In0sInVwZGF0ZUVkaXRvciI6ZmFsc2V9)

(<small>Generated with mermaid.js , https://mermaid-js.github.io/mermaid-live-editor/#

stateDiagram 
    LocalPC --> WebFunction : sends data from local PC
    WebFunction -->WebApp : notifies data ready / processing
    User--> WebApp : see results
    state LocalPC  {
        HardDrive --> LocalApp         

    }
    state WebFunction {
        ReceiveData --> ProcessData        
        ProcessData --> StoresResult
    }
    state WebApp{
      StoresResult--> DisplayData
    }
					
</small> )
### Revisit the application to see long duration processes

### Think about databases / websites - multi tenant vs single tenant

## Technical Box

1.	Identity Server 
1.  2FA
1. Authentication / Authorization in .NET Core