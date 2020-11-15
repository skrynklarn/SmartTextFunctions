# SmartTextFunctions

Small application that lives in the task bar with functions to process text that are in your clipboard. Copy data string into your clipboard and the right click on the icon in the task bar and select your function that will process the string in the clipboard and then insert the output back into your clipboard. Then you can use it by paste clipboard data in where you want it.

## Functions

Here is documentation for each function and how it works with input and output example.

### Jira table (with header)
Functions for displaying data in table format in Atlassians application Jira.
Adds | in start and end of each line and then a | in each tab. If there is a empty value between two tabs a space will also be inserted to indicate a empty cell in the table.
This also adds double pipes || on the first row to indicate header row.

```
Input:
Id    Text  Date
1     ABC   2020-12-24
2     DEF   2020-12-24
3           2020-12-24

Output:
||Id||Text||Date||
|1|ABC|2020-12-24|
|2|DEF|2020-12-24|
|3| |2020-12-24|
```

### Jira table (without header)
Same as Jira table (with header) but don't have double pipes || on the first row.
```
Input:
1     ABC   2020-12-24
2     DEF   2020-12-24
3           2020-12-24

Output:
|1|ABC|2020-12-24|
|2|DEF|2020-12-24|
|3| |2020-12-24|
```

### CVS int
Splits a string on every line break and tab and joins it back togeather with a , between each part.

```
Input:
1   2   3
4   5   6

Output:
1,2,3,4,5,6
```

### CVS string
Splits a string on every line break and tab and joins it back togeather with a , between and adds a ' before and after each part.

```
Input:
a   b   c
d   e   f

Output:
'a','b','c','d','e','f'
```

### Semicolon-seperated int
Splits a string on every line break and tab and joins it back togeather with a ; between each part.

```
Input:
1   2   3
4   5   6

Output:
1;2;3;4;5;6
```

### SQL insert dataset
Creates the "value" string for a SQL insert dataset.

Splits the string on each row and then each tab.
On each tab it will be joined with a , between and if the value between each tab is a not a integer it will be wrapped inside ''.
Each row will then be wrapped inside a () with a , in the end of the line. Last line will have a ; instead of a ,.

```
Input:
2020-12-24   1   ABC
2020-12-24   2   DEF
2020-12-24   3   GHI

Output:
('2020-12-24',1,'ABC'),
('2020-12-24',2,'DEF'),
('2020-12-24',3,'GHI');
```

### String information
Displays some information about the string in the clipboard. Total lenght and also amout of lines, tabs, spaces.
