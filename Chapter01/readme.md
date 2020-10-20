

# Chapter 1
## The boss that is hurrying up
-----

True story: one day my boss came and he asked me to discuss how can we help our colleagues from the financial department since they are thinking about the automation process. We found a spare place and scheduled a meeting where we find out that 3 employees were manually extracting the client information (name, identity information, address) and contract agreement details (fee, payment schedule) to an Excel file and saving the document in a protected area. 

## Exercise 
Make an application that reads all word documents from a folder, parses, and outputs the contents to Excel. Create and make it work, the easy way. You can find sample data in the folder data in the GitHub project.

## Technical analysis
After putting some brainstorming and analyzing the constraint we ended up developing a solution that reads from a folder share and continues the process without any human intervention. This would allow us to have all our employees to continue their work simultaneously with less effort than before. The final setup was:
- prototype solution in a console app
- use [NPOI](https://github.com/dotnetcore/NPOI) library for handling Word document reading. The decision is simply based on preference. However [ClosedXML](https://github.com/ClosedXML/ClosedXML) is another valid option too. Our main focus was to remove any dependency of Microsoft Office, so our program to not require to have it installed while running. Limiting the dependencies is generally a good approach because it makes the testing easier.

We wrapped everything in the same project, just to make sure it works and to keep our focus on delivering. Everything we put in the main file of the console app, and we have chosen C# because we were the most comfortable and were able to fulfill our requirements in a minimum amount of time.

## Code
```csharp
string folderWithWordDocs = Console.ReadLine();
            
//omitted code for clarity
foreach (string file in Directory.GetFiles(folderWithWordDocs, "*.docx"))
{        
    //omitted code for clarity
    XWPFDocument document = new XWPFDocument(File.OpenRead(file));
    var contractorDetails = ExactContractorDetails(document.Tables[0]);
    allContractors.Add(contractorDetails);
}
```
We were facing resolving the solution just with a list of sequences of operations without any control flow involved. Great!


**Download code**
Code at [![Chapter01](https://ignatandrei.github.io/console_to_saas/Chapter01.svg)](https://ignatandrei.github.io/console_to_saas/sources/Chapter01.zip) 



## Further reading

How to create a menu for the console app - https://github.com/migueldeicaza/gui.cs

When reading files on the hard disk, you should understand if you want to enumerate all files or just those that match a path. Read about the difference between IEnumerable and array (e.g. Directory.EnumerateFiles vs Directory.GetFiles) - https://www.codeproject.com/Articles/832189/List-vs-IEnumerable-vs-IQueryable-vs-ICollection-v






