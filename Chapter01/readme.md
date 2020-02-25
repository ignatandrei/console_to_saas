# Chapter 01- The boss that is hurrying up: proof of concept + source code


True story: one day my boss came and he asked me to have a discussion about how can we help our colleagues from the financial department since they are thinking about automation process. We found a spare place and scheduled a meeting where we find out that 3 employees were manually extracting the client information (name, identity information, address) and contract agreement details (fee, payment schedule) to an Excel file and saving the document in a protected area. 
## Technical analysis
After putting some brainstorming and analyzing the constraint we ended up developing a solution that reads from a folder share and continue the process without any human intervention. This would allow to have all our employees to continue their work simultaneously with less effort than before. The prototype solution that we developed was a console app written in C# where we were able to fulfill our requirements in a minimum amount of time.

## Exercise 
Make a Console solution that reads all word documents from a folder , parses and outputs the contents to Excel.. Create and make it work, the easy way. You can find sample data in the folder data in the github project .

## Impact to the solution
We decided to go with a third-party tool (NPOI) instead of us making a library that parses word documents.

## Code
```csharp
string folderWithWordDocs = Console.ReadLine();
            
//omitted code for clarity
foreach (string file in Directory.GetFiles(folderWithWordDocs, "*.docx"))
{        
    //omitted code for clarity
    var contractorDetails = ExactContractorDetails(document.Tables[0]);
    allContractors.Add(contractorDetails);
}
```
As you can see, we were facing resolving the solution for the particular client for the specific situation without having an overview of the overall process or any thoughts to going this idea further. The whole process is a sequence of operations without any control flow involved.

### Download code 
Code at [Chapter01](https://ignatandrei.github.io/console_to_saas/sources/Chapter01.zip)

## Technical box

Read about Gui.cs - https://github.com/migueldeicaza/gui.cs

Read about the difference between IEnumerable and array (e.g. EnumerateFiles and GetFiles). Read https://www.codeproject.com/Articles/832189/List-vs-IEnumerable-vs-IQueryable-vs-ICollection-v

Read about Async Enumerable in .NET 3.0 : https://docs.microsoft.com/en-us/archive/msdn-magazine/2019/november/csharp-iterating-with-async-enumerables-in-csharp-8


