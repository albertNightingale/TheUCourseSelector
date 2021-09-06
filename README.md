## **Author** ​: Albert Liu
## **Partner** ​: None
## **Date** ​: 11/12/
## **Course** ​: CS 4540, University of Utah, School of Computing
## **Copyright** ​: CS 4540 and Albert Liu - This work may not be copied for use in Academic Coursework.
## **Deployed URL** ​:
## **Github Page** ​: https://github.com/uofu-cs4540-fall2020/ps7---selenium-scraper-albertNightingale

# Comments to Evaluators:

```
● The project is built into Model View Control Structure:
    ○ Model:
        ■ Course: create objects and helper methods for course
    ○ View
        ■ 2 buttons: Start selenium and save to file
        ■ 3 fields: year(​ 2020 ​), semester(Fall, Summer, ​ Spring ​), limit (default 50)
            ● Combo Box
            ● Textbox
        ■ A data table
            ● DataGridView
            ● Columns:
                ○ Course Number
                ○ Course Title
                ○ Credit
                ○ Enrollment
                ○ Description: first 35 characters
    ○ Controller:
        ■ Handler for actions:
            ● Starting selenium and grab all the data and generate a data structure of courses
        ■ Save data to a csv
```
# Assignment Specific Write-up:

### 1. Peer review (one line): 
Luke, u0894525

### 2. Time Out Value - what value did you choose, why did you choose it, and what effects did various values have on your program?
10 seconds is what I chose. It is the safest in the start the program might need some time to load the html. I have no issue with time out from the beginning.

### 3. Thoughts on Selenium/What was easy/What was hard. Write two paragraphs. One about what your thoughts are on Selenium and how easy it was to use. In the second paragraph, explain how easy/hard you think it would be to apply Selenium as a testing tool for your URC project.
Selenium is a library that is useful but poorly built. There is limited documentation online to help the developers to use this tool and it is really a lot of hard work on testing out to ensure you are grabbing the intended html. Overall, Selenium demonstrates that web scraping is very fragile.

Selenium usage and the idea of web scraping is a waste of time for frontend testing. Writing a selenium test for a typical component requires more tests to ensure your selenium test works than the test itself. However, the use of web scraping and selenium can be used to retrieve data from websites or web apps without using their APIs. For example, you could use web scraping to retrieve your daily stock transactions on your Fidelity Account (does not have an API that does that). Even though web scraping is very fragile due to the frontend instability, it is useful because it can achieve more than API.

# Peers Helped:

Luke - peer review partner

# Peers Consulted:

Luke - peer review partner

# Acknowledgements:

Lecture 17.

# References:

DataGridView:

https://docs.microsoft.com/en-us/dotnet/desktop/winforms/controls/how-to-add-tables-and-columns-to-the-windows-forms-datagrid-control?view=netframeworkdesktop-4.

Selenium Documentation:

https://www.selenium.dev/selenium/docs/api/dotnet/


Stale Element Reference Exception

https://stackoverflow.com/questions/12967541/how-to-avoid-staleelementreferenceexception-in-selenium
https://www.softwaretestingmaterial.com/stale-element-reference-exception-selenium-webdriver/

Writing to a file

https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/file-system/how-to-write-to-a-text-file

