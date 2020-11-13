# ESAPICommander
Windows Console application for data mining with the help of VARIAN ESAPI. 

## ESAPICommander version 1.0
### Supported commands:
  - dump 
  - pointsstructure
  - dvh
  
### Examples
1/ Print out the "Course" tree of a patient

  +ESAPICommander.exe dumo -z 1234567id

2/ Get the list of dose grid points, that are inside/included by a structure

  +ESAPICommander.exe dumo -z 1234567id -c courseId -p planId -s GTV, PTV -o export.csv

