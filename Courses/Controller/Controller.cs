using Courses.Model;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

/// <summary>
/// Author: Albert Liu
/// Partner: none
/// Date: 11/13/2020
/// CS4540, University of Utah, School of Computing
/// Copyright: CS4540 and Albert Liu - this work may not be copied for use in academic coursework. 
/// 
/// I, Albert Liu, certify that I wrote this code from scratch and did 
/// not copy it in part or whole from another source.  Any references 
/// in the completion of the assignment are cited in my README file and  
/// the appropriate method header.
/// 
/// File contents: 
/// - the controller of the courseScraping project
///     - controls the logic for the project
///     - holding a list of courses and enrollment informations pulled from retrieveListOfCourses
/// - Actions available: 
///     - Retrieve a list of courses
///     - Save to the file
/// </summary>
namespace Courses.Controller
{
    class Controller
    {
        private List<Course> courses;
        private Dictionary<string, int> enrollmentInformations;
        private Dictionary<string, string> descriptionDictionary;

        private string scheduleURL = "";
        private ChromeDriver _driver;

        private readonly string pathToclassdetails = "//div[@id=\"class-details\"]";
        private readonly string pathToSeatsAvailability = "//div[@class=\"row mt-3\"]//div[@class=\"col text-center\"]";

        /*
         * Readonly properties 
         */
        private static readonly string YEARSEMESTER_TEMP = "YEAR_SEMESTER_TEMPLATE";
        private static readonly string DEPARTMENT_TEMP = "DEPARTMENT_TEMPLATE";
        private readonly string SCHEDULE_URL_TEMPLATE =
            "https://student.apps.utah.edu/uofu/stu/ClassSchedules/main/" + YEARSEMESTER_TEMP + 
            "/class_list.html?subject=" + DEPARTMENT_TEMP;

        public Controller()
        {        }

        public void StartDriver()
        {

        }

        public void NullifyDriver()
        {
            _driver = null;
        }

        private bool buildURL(string year, string semester, string department = "CS")
        {
            string yearSemester = "1" + year.Substring(2);
            switch (semester)
            {
                case "Fall":
                    yearSemester += "8";
                    break;
                case "Spring":
                    yearSemester += "4";
                    break;
                case "Summer":
                    yearSemester += "6";
                    break;
                default:
                    Console.WriteLine("This is not a valid semester: " + semester);
                    return false;
            }
            scheduleURL = SCHEDULE_URL_TEMPLATE.Replace(YEARSEMESTER_TEMP, yearSemester).Replace(DEPARTMENT_TEMP, department);
            return scheduleURL != null;
        }

        /// <summary>
        /// Construct a course list and returns a course dictionary
        /// 
        /// Retrieve course data from the URL
        /// </summary>
        /// <param name="year"></param>
        /// <param name="semester"></param>
        /// <param name="limit"></param>
        /// <param name="department"></param>
        /// <returns>
        ///     Return a dictionary with the key being the "Department Space Course Number - section number" 
        ///     and 
        ///     value being Course Object
        /// </returns>
        public Dictionary<string, Course> retrieveListOfCourses(string year, string semester, int limit, string department = "CS")
        {
            if (!buildURL(year, semester))
            {
                Console.WriteLine("Trouble with url set up");
                return null;
            }

            if (_driver == null)
            {
                _driver = new ChromeDriver();
            }

            Dictionary<string, Course> courseDict = new Dictionary<string, Course>();
            courses = new List<Course>();
            descriptionDictionary = new Dictionary<string, string>();

            _driver.Navigate().GoToUrl(scheduleURL);
            Thread.Sleep(3000); // timeout

            // a div holding a anchor tag is the seatAvailability
            // grab them and store in a data structure
            IWebElement seatAvailabilityLink = _driver.FindElementByTagName("body").FindElement(By.XPath(pathToSeatsAvailability));
            enrollmentInformations = ClickToEnrollmentInfo(seatAvailabilityLink);
            _driver.Navigate().GoToUrl(scheduleURL);                 

            List<IWebElement> courseDetails = new List<IWebElement>(_driver.FindElementByTagName("body").FindElement(By.XPath(pathToclassdetails)).FindElements(By.CssSelector(".class-info.card.mt-3")));
            // System.Diagnostics.Debug.WriteLine("Total amount of elements: " + courseDetails.Count);

            int stopPoint = limit;
            int totalCount = courseDetails.Count;
            if (totalCount < stopPoint)
                stopPoint = courseDetails.Count;

            for (int i = 0; i < stopPoint; i++)
            {
                // course name
                string courseName = "";
                // the course number + department exist in the first a of head, and the sub number exist in first and only span of head,
                string courseNumber = "";
                int enrollment = -1;
                string description = "";
                int credit = -1;

                // find the button and click it to grab the information first, then renavigate back to the homepage
                IWebElement courseDetailButton = GetDetailButton(i);
                ClickForMoreInfo(courseDetailButton, out description, out credit);
                _driver.Navigate().GoToUrl(scheduleURL);

                // head to get information about a  course
                IWebElement head = GetHead(i);

                // course number
                courseNumber = head.FindElement(By.TagName("a")).Text;
                string section = head.FindElement(By.TagName("span")).Text;

                // normalize it to make sure course is filtered out
                if (!IsCourseOkay(department, courseName, section, courseNumber))
                {
                    if (stopPoint < totalCount)
                        stopPoint++;

                    // reset values
                    courseName = "";
                    courseNumber = "";
                    enrollment = -1;
                    description = "";
                    credit = -1;
                    continue;
                }

                // course name
                if (head.FindElements(By.TagName("a")).Count < 2)
                    courseName = head.FindElements(By.TagName("span"))[1].Text;
                else if (head.FindElements(By.TagName("span")).Count < 2)
                    courseName = head.FindElements(By.TagName("a"))[1].Text;
                else
                    System.Diagnostics.Debug.WriteLine("failed to load: \n" + head.GetAttribute("innerHTML"));

                // enrollment 
                enrollment = enrollmentInformations[courseNumber];

                Course course = new Course(department, courseNumber, credit, courseName, enrollment, semester, year, description);

                System.Diagnostics.Debug.WriteLine(course);

                courses.Add(course); // adding to internal data struct

                if (!courseDict.ContainsKey(courseNumber))
                {
                    courseDict.Add(courseNumber, course); // adding to the external data structure
                }

                if (!descriptionDictionary.ContainsKey(courseNumber))
                {
                    descriptionDictionary.Add(courseNumber, description);
                }
            }

            return courseDict;
        }

        /// <summary>
        /// Normalize the course
        /// </summary>
        /// <returns></returns>
        private bool IsCourseOkay(string dept, string courseName, string section, string number)
        {
            if (courseName.Contains("Seminar") || courseName.Contains("Special Topics"))
                return false;
            if (section != "001")
                return false;

            string normalizedNumber = number.Replace(dept + " ", "");
            if (int.Parse(normalizedNumber) >= 7000 || int.Parse(normalizedNumber) <= 1000)
                return false;

            return true;
        }

        /// <summary>
        /// Click into enrollment information and grab all the data
        /// </summary>
        /// <param name="clickableElement"></param>
        /// <returns>course number map to enrollment</returns>
        private Dictionary<string, int> ClickToEnrollmentInfo(IWebElement clickableElement)
        {
            Dictionary<string, int> enrollmentDictionary = new Dictionary<string, int>();

            clickableElement.Click();
            System.Diagnostics.Debug.WriteLine(_driver.Url);

            IWebElement table = _driver.FindElementByTagName("table").FindElement(By.TagName("tbody"));

            ReadOnlyCollection<IWebElement> readonlyRows =
                table.FindElements(By.TagName("tr"));
            System.Diagnostics.Debug.WriteLine("Total amount of rows of enrollment information: " + readonlyRows.Count);

            List<IWebElement> enrollmentRows = new List<IWebElement>(readonlyRows);

            foreach (var row in enrollmentRows)
            {
                ReadOnlyCollection<IWebElement> readonlyEntriesOfARow = row.FindElements(By.TagName("td"));
                string dept = readonlyEntriesOfARow[1].FindElement(By.TagName("a")).GetAttribute("innerHTML");
                string catelogNum = readonlyEntriesOfARow[2].FindElement(By.TagName("a")).GetAttribute("innerHTML");
                // string section = readonlyEntriesOfARow[3].GetAttribute("innerHTML");
                int currEnrolled = int.Parse(readonlyEntriesOfARow[7].GetAttribute("innerHTML"));

                string courseNum = dept + " " + catelogNum; // + " - " + section;
                // System.Diagnostics.Debug.WriteLine("course " + courseNum + " enrollment: " + currEnrolled);

                if (!enrollmentDictionary.ContainsKey(courseNum))
                {
                    enrollmentDictionary.Add(courseNum, currEnrolled);
                }
            }

            return enrollmentDictionary;
        }

        private IWebElement GetDetailButton(int i)
        {
            return _driver
                    .FindElementByTagName("body")
                    .FindElement(By.XPath(pathToclassdetails))
                    .FindElements(By.CssSelector(".class-info.card.mt-3"))[i]
                    .FindElement(By.CssSelector(".card-body.row.d-none.d-md-block"))
                    .FindElements(By.CssSelector(".col-12.p-0"))[0]
                    .FindElement(By.TagName("div"))
                    .FindElement(By.LinkText("Class Details"));
        }
        private IWebElement GetHead(int i)
        {
            return _driver
                    .FindElementByTagName("body")
                    .FindElement(By.XPath(pathToclassdetails))
                    .FindElements(By.CssSelector(".class-info.card.mt-3"))[i]
                    .FindElement(By.CssSelector(".card-body.row.d-none.d-md-block"))
                    .FindElements(By.CssSelector(".col-12.p-0"))[0]
                    .FindElement(By.TagName("h3"));
        }

        private Dictionary<string, string> GetDescriptionDictionary(string year, string semester)
        {
            if (descriptionDictionary == null)
            {
                if (!buildURL(year, semester))
                {
                    Console.WriteLine("Trouble with url set up");
                    return null;
                }

                if (_driver == null)
                {
                    _driver = new ChromeDriver();
                }

                _driver.Navigate().GoToUrl(scheduleURL);
                Thread.Sleep(3000);

                int courseCount = _driver.FindElementByTagName("body").FindElement(By.XPath(pathToclassdetails)).FindElements(By.CssSelector(".class-info.card.mt-3")).Count;

                descriptionDictionary = new Dictionary<string, string>();

                for (int i = 0; i < courseCount; i++)
                {
                    IWebElement head = GetHead(i);

                    // course number
                    string courseNumber = head.FindElement(By.TagName("a")).Text;
                    string section = head.FindElement(By.TagName("span")).Text;

                    IWebElement courseDetailButton = GetDetailButton(i);

                    string description = "";
                    int credit = -1;
                    ClickForMoreInfo(courseDetailButton, out description, out credit);
                    System.Diagnostics.Debug.WriteLine(courseNumber + ": " + description);

                    _driver.Navigate().GoToUrl(scheduleURL);

                    if (!descriptionDictionary.ContainsKey(courseNumber))
                    {
                        descriptionDictionary.Add(courseNumber, description);
                    }
                }
            }
            return descriptionDictionary;
        }

        /// <summary>
        /// Click the details and retrieve more information
        /// </summary>
        /// <param name="clickableElement"></param>
        /// <returns></returns>
        private void ClickForMoreInfo(IWebElement clickableElement, out string description, out int credit)
        {
            string XPathToContent = "//div[@class=\"container-fluid mb-auto mt-0 mx-0 p-0\"]" +
                                    "//section[@class=\"container-fluid px-2 px-sm-4 px-md-5 flex-grow-1\"]" +
                                    "//main[@class=\"uu-main class-details\"]" +
                                    "//div[@class=\"uu-container\"]";

            clickableElement.Click();

            IWebElement result = _driver.FindElementByTagName("body").FindElement(By.XPath(XPathToContent));

            double credit1 = -1.0;
            bool succeed = double.TryParse(result
                    .FindElement(By.ClassName("row"))
                    .FindElement(By.ClassName("col"))
                    .FindElement(By.CssSelector(".card.mt-3"))
                    .FindElement(By.ClassName("card-body"))
                    .FindElement(By.TagName("span"))
                    .Text, out credit1);

            if (!succeed)
                credit = 0;
            else
                credit = (int)credit1;

            ReadOnlyCollection <IWebElement> listOfDescriptions = result.FindElements(
                By.XPath(
                    "//div[@class=\"row\"]" +
                    "//div[@class=\"col\"]" +
                    "//div[@class=\"card  mt-3\"]" +
                    "//div[@class=\"card-body\"]"
                    )
                );

            if (listOfDescriptions.Count >= 2) description = listOfDescriptions[listOfDescriptions.Count-1].FindElement(By.ClassName("col")).Text;
            else  description = listOfDescriptions[0].FindElement(By.ClassName("col")).Text;
        }

        
        /// <summary>
        /// Save data to CSV
        /// </summary>
        /// <param name="csvPath"></param>
        public void saveToCSV(string csvPath)
        {
            string headerCol = "Course Dept,Course Number,Course Credits,Course Title,Course Enrollment,Course Semester,Course Year,Course Description";

            string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string fullPath = Path.Combine(folderPath, csvPath);
            System.Diagnostics.Debug.WriteLine("print out the path: " + fullPath);

            using (StreamWriter writer = new StreamWriter(fullPath))
            {
                writer.WriteLine(headerCol);
                foreach (Course course in courses)
                {
                    writer.WriteLine(course);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public string GetCourseDescription(string semester, string yr, string courseNumber, int limit = 9999)
        {
            Dictionary<string, string> dictionary = GetDescriptionDictionary(yr, semester);
            if (dictionary.ContainsKey(courseNumber))
                return dictionary[courseNumber];
            return null;
        }


    }
}
