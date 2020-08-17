# Chapter 07 - Passing to SAAS

Dealing with multiple clients adds complexity that must be handled, and there are several challenges:
- Keep track of the configuration/version of the app of each client 
- Deliver different patches for the different clients 
Besides this, we want to have a central part where we want to see how clients are using the app, so some analytics were needed.
Customer issues with the system where it is installed the application (like OS incompatibility, antivirus, dll problems, or others) must be solved.

These challenges we could tackle easier if we could have a central point. Moreover, transforming this project into a SAAS could allow the activation of a subscription model for each individual client.


## Problem
Create a website that allows us to import a zip file with multiple documents and output the resulting Excel.

## Technical analysis
Create a new web project and use the existing functionality in the ``ContractExtractor`` project. The application must be converted to a web application (eventually, a mobile application should be ready also).
The web application should allow manage multiple client and be [multi-tenant](https://en.wikipedia.org/wiki/Multitenancy) enabled.

Authentication mechanism should allow to have one or more ways to identify users (either username + password, either via a third provider, like Google / Facebook, either via an integrated provider, like Azure Active Directory / Okta).

The zip files can be uploaded and processed on the web. But, for the local files, the architecture should be somehow different: You may think about an agent that works on local, monitors the local file system and uploads data to the web to be processed. This will allow to have access to local resources and process on the web.


## Code
The most code will belong to the HTML and the backend infrastructure. 
```html


<div class="text-center">
    <h1 class="display-4">Welcome to extractor !</h1>
    Please upload your zip file with documents
    <form asp-controller="Home" asp-action="UploadFile" method="post"
          enctype="multipart/form-data">


        <input type="file" name="file" id="fileToSubmit" />

        <input type="submit" value="Generate Summary" />

    </form>
</div>

```
The business layer code , if well written, will be mostly the same
```csharp
var fullPathFile = Path.Combine(_environment.WebRootPath,Path.GetFileName(file.FileName));
if (System.IO.File.Exists(fullPathFile))
    System.IO.File.Delete(fullPathFile);

using (var stream = new FileStream(fullPathFile, FileMode.Create))
{
    await file.CopyToAsync(stream);
}
var fileSystem = new ZipFileSystem(fullPathFile);
var extractor = new WordContractExtractor(fileSystem);
extractor.Start();
```
Now, all we need to do is to use the class and pass the needed parameters. In this case, the file path is the only dependent requirement. This path can come from a config file or from a user pick action. The only check we could add is to make sure it is writeable. We can add this check before executing the program or we can just handle separately the exception and display to the user a message. We will see that later in the next chapters.

**Download code**
Code at [![Chapter02](https://ignatandrei.github.io/console_to_saas/Chapter07.svg)](https://ignatandrei.github.io/console_to_saas/sources/Chapter07.zip)


### Possible architecture

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
				
</small>


### Decoupling GUI from backend - allow Mobile , Local, Web to work with same ( http ) endpoints
### Microservices
### Revisit the application to see long duration processes
### Think about databases / websites - multi tenant vs single tenant
### Multiple types of contracts
### Working related to other apps - extension endpoints reporting when finishes to extract data 
### Automated CI / CD  ( blue-green deployment, canary deployment, feature toggle ,KeystoneInterface , ...)



## Technical Box

1.	Identity Server 
1.  2FA
1. Authentication / Authorization in .NET Core