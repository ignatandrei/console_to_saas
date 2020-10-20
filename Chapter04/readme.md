

# Chapter 4
## Transform to product
**Making a Graphical User Interface**

-----
At our Digital Transformation Center Department, we have recurring meetings with clients that are part of our continuous iterative process to identify things that need to be improved. In one of the meetups that we hosted on our desk, we invited the financial department to leave feedback on the process that we helped. We talked about how the process evolved and how, by adopting Digital Solutions, we decreased the manual work. 

The presentation ended up with some Q&A and with several clients who were interested to have the application installed. At that point, we realized that this is a missing point in the current market and we planned to develop a product around it. At this point, we had a validated idea by a consistent number of users and we decided to evolve based on the client's needs.

Selling the application to multiple clients means to have configurable the word extracting and location of the documents. We ended up creating a GUI to allow the user alone to configure the application with the automation parameters. This was a valuable feature for our users since most of them may be non-technical. 
Transfer the ownership of the paths from the config file to a more appropriate user interface.

## Problem 
Modify the existing solution to support both Console and GUI.

## Technical analysis

For both applications, we have the same functionality: reading files from the hard disk and reading settings. We do not want to copy-paste code and become unmaintainable, so we want to share source code from the console application to the GUI application.

Because the user works now with network folders, that cannot be always available, we need to perform some modifications to alert the user about the problems. In our case we have the user interface for:
- showing the progress of the operations 
- adding logging for knowing what happens if an error occurs
- adding exception handling to not crash the application
- handling edge cases of the user saving configuration (assert that the user has not entered any folder, list what documents have been successfully processed, etc)

From a solution with a single project, we get now a solution with 3 projects:
- Business Layer (BL) - the logic for the application - in our case, processing documents from a folder
- Console (referencing BL) 
- Desktop (referencing BL)

The BL contains the code that was previously in the console application (loading settings, doing extraction) + some new code (logging, others).

## Code 
The business logic is now simpler:
```csharp
public void ExtractToFile(string excelFileOutput)
{       
    string[] files = Directory.GetFiles(_documentLocation, "*.docx");
    _logger.Info($"processing {files.Length} word documents");
//code omitted for brevity
```

The Console code now is very simple, just calling code from BL:
```csharp
var settings = Settings.From("app.json");
var extractor = new WordContractExtractor(settings.DocumentsLocation);
extractor.Start();
```

The Desktop is calling the same BL, with some increased feedback for the user:
```csharp
try
{
    string folderWithWordDocs = folderPath.Text;
    if (string.IsNullOrWhiteSpace(folderWithWordDocs))
    {
        MessageBox.Show("please choose a folder");
        return;
    }
    string excelResultsFile = "Contractors.xlsx";
    var wordExtractor = new WordContractExtractor(folderWithWordDocs);
    wordExtractor.ExtractToFile(excelResultsFile);
}
catch(Exception ex)
{
    _logger.Error(ex,$"exception in  {nameof(StartButton_Click)}");
    MessageBox.Show("an error occured. See the log file for details");
}
```

**Download code**
Code at [![Chapter04](https://ignatandrei.github.io/console_to_saas/Chapter04.svg)](https://ignatandrei.github.io/console_to_saas/sources/Chapter04.zip)


## Further reading

.NET Core 3.0 Windows application (WPF, WinForms): https://docs.microsoft.com/en-us/dotnet/core/whats-new/dotnet-core-3-0

MultiTier architecture: https://en.wikipedia.org/wiki/Multitier_architecture
