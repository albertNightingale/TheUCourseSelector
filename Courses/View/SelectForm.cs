using Courses.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
/// - View code
/// - event handlers
/// </summary>
namespace Courses
{
    public partial class SelectCourses : Form
    {
        private readonly string FALL = "Fall";
        private readonly string SUMMER = "Summer";
        private readonly string SPRING = "Spring";

        private Controller.Controller controller;
        public SelectCourses()
        {
            InitializeComponent();

            this.semesterDropdown.Items.Add(FALL);
            this.semesterDropdown.Items.Add(SPRING);
            this.semesterDropdown.Items.Add(SUMMER);
            // dummy value, preset here 
            this.semesterDropdown.Text = SPRING;
            this.yearTextbox.Text = "2020";
            this.courseTextbox.Text = "CS 3500";
        }

        private void PreClickEvent(bool list)
        {
            this.runButton.Enabled = false;
            this.saveButton.Enabled = false;
            this.searchButton.Enabled = false;

            if (list)
            {
                resultTable.Rows.Clear();
            }
            else
            {
                descriptionTextbox.Text = "";
            }

        }

        private void PostClickEvent(bool list)
        {
            this.runButton.Enabled = true;
            this.saveButton.Enabled = true;
            this.searchButton.Enabled = true;
            controller.NullifyDriver();

            // anything to do after the event that is based on list or search event
            if (list)
            {

            }
            else
            {

            }
        }

        /// <summary>
        /// Event when selenium run button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void runButton_MouseClick(object sender, MouseEventArgs e)
        {
            PreClickEvent(true);
            controller = new Controller.Controller();
            
            /////  data validation
            string year = this.yearTextbox.Text.Trim();

            if (year == null || year.Length != 4)
            {
                MessageBox.Show("Year invalid: " + year);
                return;
            }

            string semester = this.semesterDropdown.Text.Trim();
            if (semester == null || !("Fall"+"Summer"+"Spring").Contains(semester))
            {
                MessageBox.Show("Semester invalid: " + semester);
                return;
            }

            int limit = -1;
            if (!int.TryParse(this.limitTextbox.Text, out limit))
            {
                MessageBox.Show("Invalid data passed in: " + this.limitTextbox.Text);
                return;
            }

            ///// Retrieving data 
            Dictionary<string, Course> outputData = controller.retrieveListOfCourses(year, semester, limit);
            // using the dictionary and render data to the table

            this.AutoScroll = true;


            foreach (string courseNum in outputData.Keys)
            {
                Course course = outputData[courseNum];
                this.resultTable.Rows.Add(course.PartialDisplay());
            }

            PostClickEvent(true);
        }

        /// <summary>
        /// When event save to file button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveButton_MouseClick(object sender, MouseEventArgs e)
        {
            PreClickEvent(true);

            MessageBox.Show("Your file will be saved to your Desktop folder, here is the filename: " + "data.csv");
            this.controller.saveToCSV("data.csv");
            MessageBox.Show("Saving complete");

            PostClickEvent(true);
        }

        private void searchButton_MouseClick(object sender, MouseEventArgs e)
        {
            PreClickEvent(false);
            string courseNumber = this.courseTextbox.Text;

            if (this.controller == null)
                controller = new Controller.Controller();

            /////  data validation
            string year = this.yearTextbox.Text.Trim();

            if (year == null || year.Length != 4)
            {
                MessageBox.Show("Year invalid: " + year);
                return;
            }

            string semester = this.semesterDropdown.Text.Trim();
            if (semester == null || !("Fall" + "Summer" + "Spring").Contains(semester))
            {
                MessageBox.Show("Semester invalid: " + semester);
                return;
            }

            int limit = -1;
            if (!int.TryParse(this.limitTextbox.Text, out limit))
            {
                MessageBox.Show("Invalid data passed in: " + this.limitTextbox.Text);
                return;
            }

            if (courseNumber == null || courseNumber.Length == 0)
            {
                MessageBox.Show("courseNumber invalid: " + courseNumber);
                return;
            }
            else
            {
                if (!courseNumber.Contains(" "))
                {
                    MessageBox.Show("courseNumber invalid, please add space after department: " + courseNumber);
                    return;
                }
            }

            string courseDescription = controller.GetCourseDescription(semester, year, courseNumber);

            descriptionTextbox.Text = courseDescription;

            PostClickEvent(false);
        }
    }
}
