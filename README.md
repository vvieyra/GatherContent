GatherContent C# Api
=============

Due to the very dynamic nature of GatherContent, the best way I found to accommodate all the varying options was to not create strongly typed classes but leave everything as a JSON Object. I'm not saying this is the best way to complete the task, but it is the most versatile.

Connecting to the API
---------------------
GatherContent requires the use of an API Key along with your account name. Using these two pieces of information as parameters into the GatherApi class will handle the authentication and return any error that may occur. If no errors are found GatherContent is successfully authenticated and the GcAssetAccess class can then be used to access all the information in Gather Content.

Retrieving the DLL
------------------
Located inside GCApi/bin/GCApi.dll

It is currently built for ASP.Net 4.5.

Last but not least, please feel free to play around with this wrapper. I've built it to be as friendly as possible, but I'm by no means perfect. Take a copy, modify it to best fit your needs, and most importantly, have fun.
