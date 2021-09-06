using System;
using System.Collections.Generic;
using System.Text;

namespace Courses.Model
{
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
    /// - Model
    /// </summary>
    class Course
    {
        public string Dept { get; set; }
        public string Number { get; set; }
        public int Credit { get; set; }
        public string Title { get; set; }
        public int Enrollment { get; set; }
        public string Semester { get; set; }
        public string Year { get; set; }
        public string Description { get; set; }

        public Course(string dept, string number, int credit, string title, int enrollment, string semester, string year, string description)
        {
            this.Dept = dept;
            this.Number = number;
            this.Credit = credit;
            this.Title = title;
            this.Enrollment = enrollment;
            this.Semester = semester;
            this.Year = year;
            this.Description = description;
        }

        /// <summary>
        /// For data storage into the database and a full display
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.Dept + "," + this.Number + "," + 
                this.Credit + "," + this.Title + "," + this.Enrollment + "," + 
                this.Semester + "," + this.Year + "," + 
                this.Description;
        }

        /// <summary>
        /// For return to the file
        /// </summary>
        /// <returns></returns>
        public string[] PartialDisplay()
        {
            string[] arr = new string[5];
            arr[0] = this.Number;
            arr[1] = this.Title;
            arr[2] = this.Credit.ToString();
            arr[3] = this.Enrollment.ToString();

            if (this.Description.Length > 60)
                arr[4] = this.Description.Substring(0, 61) + "...";
            else
                arr[4] = this.Description;

            return arr;
        }
    }
}
