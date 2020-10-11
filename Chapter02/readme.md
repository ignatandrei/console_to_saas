# Chapter 2
## Adapt to the financial department last tweaks

----
We installed our console app on one of the computers of an employee in the financial department, we set it up and we let it run. After a few days, we had some bug fixing and some new requests that came in. We saw an enthusiastic behavior on our colleagues by using our solution and that was our first real feedback that we were resolving a customer pain. We anticipated that we will get more feedback and to track what we have done we needed a source control. After a few iterations, we had our financial department happy and we are ready with our first MVP.

## Problem 
Try to refactor the solution from Chapter 1 to extract the business logic (i.e. transforming Word files into an Excel file) into a separate file.

## Technical analysis
As a starting point, we decided to have 2 separate projects:
- a business logic
- the host (in our case the console app)

We decide to have this approach because it keeps a well balanced effort between value and time, and allows the flexibility to ensure [separation of concerns](https://en.wikipedia.org/wiki/Separation_of_concerns).
We went with creating the **WordContractExtractor** where we handle all the Word related file formats. Here we moved the usage of the NPOI library and we make sure that the expected format is according to our requirements.
Hence, our solution looks now like:
- all the file conversion resides in a single place
- the main program file is more simple

This is a simple and long term solution because it is not a time-waster and offers us the possibility to adapt later to possible changes. Moreover using this technique early in the process, helps to isolate the problem better. You have less code to look in one place, and the problems are isolated. 

To help the versioning we added a source control. We have chosen GIT since it is simple and allows us to work without an internet connection.


## Code
```csharp
var wordExtractor = new WordContractExtractor(folderWithWordDocs);
wordExtractor.ExtractToFile(excelResultsFile);
```
Now, all we need to do is to use the class and pass the needed parameters. In this case, the file path is the only dependent requirement. This path can come from a config file or from a user pick action. The only check we could add is to make sure it is writeable. We can add this check before executing the program or we can just handle separately the exception and display to the user a message. We will see that later in the next chapters.

**Download code**
Code at [![Chapter02](https://ignatandrei.github.io/console_to_saas/Chapter02.svg)](https://ignatandrei.github.io/console_to_saas/sources/Chapter02.zip)


## Further reading

What is version control: https://en.wikipedia.org/wiki/Version_control

Create a free version control repository at http://github.com/, https://azure.microsoft.com/en-us/services/devops/, or other online source control.

Read more about how you improve the design of existing code by refactoring: https://www.amazon.com/Refactoring-Improving-Design-Existing-Code/dp/0201485672


