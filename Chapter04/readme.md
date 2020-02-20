# Transform to product: making a GUI 

At our Digital Transformation Center Department we have recurring meetings with clients that are part of our continuous iterative process to identify things that needs to be improved. In one of the meetups that we hosted on our desk, we invited the financial department to leave feedback on the process that we helped. We talked about how the process evolved and how by adopting Digital Solutions decreased manual work. 
The presentation ended up with some Q&A and several clients they were interested to have the application installed. At that point we realised that this is real a missing point in the current market and we planned to develop a product around this. At this point we had a validated idea by the market and we decided to evolve based on the client needs.
Selling the application to multiple clients means to have configurable the word extracting and location of the documents. We ended up creating a GUI to allow the user to configure himself the automation parameters. This was a valuable feature for our users since most of them could be non technical. 
Transfer the ownership of the paths from the config file to more appropriate user interface

## Technical analysis

Sharing code source from console application to the GUI application in order to not duplicate code
Transfer the ownership of the hardcoded paths to an external location. In our case we have the user interface for this
Define a user interface (maybe with the progress of the operations ?)
Adding logging for knowing what happens if an error occurs
Adding exception handling to not crash the application
Maybe add some specific code per project ( in our case, assert that user have not entered any folder /  maybe list what documents have been successfully processed and what not)

## Exercise 
Modify the existing solution to support both Console and GUI.

## Impact to the solution
From a solution with a single project, we have now a solution with 3 projects
Business Layer (BL) -  logic for the application  - in our case, processing documents from a folder
Console ( referencing BL) 
Desktop ( referencing  BL)



The BL has the code that was previous in the console application( loading settings, doing extraction) + some new code ( logging, others)

## Code 
The business logic is now  more simple:
```csharp
public void Start()
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

The Desktop is calling the same BL , with some increased feedback for the user:
```csharp
try
{
    string folder = folderPath.Text;
    if(string.IsNullOrWhiteSpace(folder))
    {
        MessageBox.Show("please choose a folder");
        return;

    }
    var extractor = new WordContractExtractor(folder);
    extractor.Start();
}
catch(Exception ex)
{
    _logger.Error(ex,$"exception in  {nameof(StartButton_Click)}");
    MessageBox.Show("an error occured. See the log file for details");
}
```

## Further reading

.NET Core 3.0 Windows application ( WPF, WinForms): https://docs.microsoft.com/en-us/dotnet/core/whats-new/dotnet-core-3-0

MultiTier architecture :
https://en.wikipedia.org/wiki/Multitier_architecture
