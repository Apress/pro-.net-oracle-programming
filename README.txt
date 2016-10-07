The folder structure for the sample code is as follows:

/Microsoft - contains the Microsoft Data Provider versions of the samples
/Oracle    - contains the Oracle Data Provider for .NET versions of the samples
/Temp      - contains the files that reside in the temp directory used in Chapter 6


Within each folder (excluding the temp folder) are two sub-folders as follows:

/Microsoft/C# - contains the sample code in C#
/Microsoft/VB - contains the sample code in VB.NET

/Oracle/C# - contains the sample code in C#
/Oracle/VB - contains the sample code in VB.NET


Within each language sub-folder (C# or VB) resides the sample code for each chapter.
The sample code for each chapter is in a folder named after the chapter number
as follows:

Chapter01 through Chapter09


Within each chapter folder are the Visual Studio sample code solutions.


NOTE:  Chapter 7 contains 2 web solutions (AnonAccess and PagedResults).
       These solutions were developed using http://localhost/odp/
       and http://localhost/msp/ as the folder locations. You may need to
       either edit the .sln file or create the same directory structure
       under you root web folder in order to open and run these samples.


NOTE:  Under the Chapter01 folder is a folder named "CreateUsers". This folder
       contains a SQL script that can be used to create the users in Oracle rather
       than using the graphical method as described in Chapter 1.