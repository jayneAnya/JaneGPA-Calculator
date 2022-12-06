using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JaneCalc.Core
{
    public class GPACalc
    {
        public int totalCourseUnit = 0;
        public int totalCourseUnitPassed = 0;
        public double totalWeigthPoint = 0;
        public int weightPoint;

        public string[] Calc(string courseCode, int courseUnit, double score)
        {
            string[] row = new string[6];
            row[0] = courseCode;
            row[1] = courseUnit.ToString();
            row[2] = Grade(score);
            row[3] = GradeUnit(score, courseUnit).ToString();
            row[4] = weightPoint.ToString();
            row[5] = Remarks(score);
            return row;
        }

        private string Grade(double score)
        {
            if (score >= 70 && score <= 100) return "A";
            if (score >= 60 && score <= 69) return "B";
            if (score >= 50 && score <= 59) return "C";
            if (score >= 45 && score <= 49) return "D";
            if (score >= 0 && score <= 39) return "E";
            return "F";
        }
        public int GradeUnit(double score, int courseUnit)
        {
            int gradeUnit = score >= 70 && score <= 100 ? 5 :
                            score >= 60 && score <= 69 ? 4 :
                            score >= 50 && score <= 59 ? 3 :
                            score >= 45 && score <= 49 ? 2 :
                            score >= 0 && score <= 39 ? 1 :
                            0;
            weightPoint = gradeUnit * courseUnit;
            totalCourseUnit += courseUnit;
            if (gradeUnit > 0) totalCourseUnitPassed += gradeUnit;
            totalWeigthPoint += weightPoint;
            return gradeUnit;
        }
        private string Remarks(double score)
        {
            if (score >= 70 && score <= 100) return "Excellent";
            if (score >= 60 && score <= 69) return "Very Good";
            if (score >= 50 && score <= 59) return "Good";
            if (score >= 45 && score <= 49) return "Fair";
            if (score >= 0 && score <= 39) return "Pass";
            return "Fail";
        }
    }

}
