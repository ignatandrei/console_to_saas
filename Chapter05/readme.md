

# Chapter 5
## The first real client
**Componentization / Testing / Refactoring**

-----
A client who was interested mentioned that they were using zip files for backup the documents for company service. They were interested in having our product, but we didn’t support zip files. We shared our vision to create a highly customizable product, so implementing reading files from zipping would be an additional feature. He agreed to pay for it and we started the product development.

## Problem
Starting from the solution, add support for reading either from a folder, either from a zip file.

## Technical analysis
Changing the business core requires refactoring, which usually involves regression testing. Before every refactoring is started, we need to define the supported test scenarios from the business perspective. This is a list that usually includes inputs, appropriate action, and the expected output. The easiest way to achieve this is to add unit tests which do the checking automatically. 

Altering pretty much the entire core adds some regression risks. To compensate for that, we will add tests (unit and/or integration and/or component and/or system) which verifies the already old behavior and the new one. The tests will make sure that our core (reading and parsing) outputs the expected output using various file systems. We will add a new project for unit/component test and we will reference the business core project and inject different components (in our case, file system).
This core modification will also impact other projects, including GUI and console applications.
In our case, we want to make sure that the contract parsing success if we use both file systems.

We already identified the operations that need to be abstract, so let’s write the interfaces that allow this:
1. An interface for the file system which supports listing files (IFileSystem)
2. An interface with the actual file. This needs to have a Name and to read the content from either a zip file, either a folder into the system (IFile).
   
Our core program needs to:

1. find Word documents
2. extract information from it

These two operations are part of the actual business flow. We need to abstract the finding operation and reading from a file operation and allow different implementations.

## Code
One implementation is from the actual file system (an existing directory) and the other one from the zip archive, hence:
1. DirectoryFileSystem
2. ZipFileSystem
 
A zip file can have inside folders and files, similar to a directory. Hence, we can do the same operations just like in the actual file system (listing files and reading a file from it). 
```csharp
var settings = Settings.From("app.json");
var fileSystem = settings.FileSystemProvider.CurrentFileSystem();
var extractor = new WordContractExtractor(fileSystem);
extractor.Start();
```

**Download code**

Code at [![Chapter05](https://ignatandrei.github.io/console_to_saas/Chapter05.svg)](https://ignatandrei.github.io/console_to_saas/sources/Chapter05.zip)

## Homework
There are a few issues that you could encounter to transform this code example in production. The **WordContractExtractor** depends on the IFileSystem. The latter one is the state (it keeps the source files). While it is ok to have a state which is read-only (multiple requests will not alter the state), you could have concurrency problems if the files are written there. In this case, the IFileSystem has only methods for reading. Your homework is to modify the WordContractExtractor to be consistent and use the IFileSystem for writing. 

Your task is to:
- add a function for writing in the IFileSystem that receives a Stream and it writes the content to the file system.
- add a property CanWrite to the IFileSystem and ensure writing is possible
- implement in the classes that IFileSystems inherits from the functionality

## Further reading

1. Choosing Between an Interface and an Abstract Class - https://medium.com/better-programming/choosing-between-interface-and-abstract-class-7a078551b914
2. How to manage external connections using IDisposable - https://docs.microsoft.com/en-us/dotnet/api/system.idisposable
3. Read about file system abstraction (exists already:  https://github.com/System-IO-Abstractions/System.IO.Abstractions
4. How to unit test  http://dontcodetired.com/blog/post/Unit-Testing-C-File-Access-Code-with-SystemIOAbstractions) 

