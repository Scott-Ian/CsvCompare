# CsvCompare


## Execution Commands

**dotnet run** -> Executes the program



## Requirements:
Input: two csv's of Video File Data (see VideoFileData model).

First list (list A), is the longer. List b is the shorter. 

If List 'B' contains an entry with the same 'Name' as in List A, output the entry but with the timecodes from the entry in List B.
Note that, TimeCode In/Out values should stay the same, and it should only replace "Start" and "End" timecodes.

Otherwise, use the same values that are in List A.

List 'B' will only have items that exist within list 'A'.

List 'A' and List'B' video file names will have some minor difference:
List A name entries will end in ".mov"
List b names will end in ".r3d"

Output should have List B Names.
I can assume all List 'B' names will end in ".r3d". 
    (Not completely true, but the few strange ones can be manually changed he says).
I will split it along the periods to seperate. 