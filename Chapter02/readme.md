# Chapter 02 - Financial department last tweaks: MVP + fixing bugs, source control

We installed our console app on one of the computers of an employee in the financial department, we set it up and we let it running. After a few days we had some bug fixing and some new requests that came in. We saw an enthusiastic behavior on our colleagues by using our solution and that was our first real feedback that we were resolving a customer pain. We anticipated that we will get more feedback and to track what we have done we needed a source control. After a few iterations, we had our financial department happy and we are ready with our first MVP.

## Technical analysis

We decided to have 2 separate projects (a business logic and console) because it is not taking so much time and can be beneficial in the long run. 
Also, because of the modifications , we need to have a source control - or, at least, to can go back to some version.

## Exercise 

Try to refactor the solution from Chapter 1 to extract the business logic( i.e. transforming word files into an excel file) into a separate class.

## Code

```csharp
var wordExtractor = new WordContractExtractor(folderWithWordDocs);
wordExtractor.ExtractToFile(excelResultsFile);
```

Now, we are ready to process any folder very easy, just be instantiating a new class with the directory

### Download code 
Code at [![Chapter02](Chapter02.svg)](https://ignatandrei.github.io/console_to_saas/sources/Chapter02.zip)


## Further reading

Version Control : https://en.wikipedia.org/wiki/Version_control

Set also a repository at http://github.com/ , https://azure.microsoft.com/en-us/services/devops/ or other online source control.

Refactoring: https://www.amazon.com/Refactoring-Improving-Design-Existing-Code/dp/0201485672


