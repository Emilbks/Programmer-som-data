When we need the .bat files. 
Move then into the correct folders and edit the path to go back up to the root folder.

`fslex.bat` -> `Lecture_03/Expr/fslex.bat`
```bat
dotnet ".\fsharp\FsLexYacc.11.3.0\build\fslex\net6.0\fslex.dll" %*
```
->
```bat
dotnet ".\..\..\fsharp\FsLexYacc.11.3.0\build\fslex\net6.0\fslex.dll" %*
```

They can only be run easily in CMD.

