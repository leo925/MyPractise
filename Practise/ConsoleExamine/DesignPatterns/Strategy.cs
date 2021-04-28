using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleExamine
{
    class Strategy
    {
    }

    public abstract class StudentScoreStrategy
    {
        protected StudentScoreStrategy()
        {
        }
        public decimal TestPaperScore
        {
            get; set;
        }
        public abstract decimal GetScore();
    }

    public class PrimaryStudentScore : StudentScoreStrategy
    {
        public PrimaryStudentScore(decimal testPaperScore)
        {
            this.TestPaperScore = testPaperScore;
        }
        public override decimal GetScore()
        {
            return this.TestPaperScore;
        }
    }

    public class CollegeStudentScore : StudentScoreStrategy
    {
        public decimal AttendanceScore
        {
            get; set;
        }
        public CollegeStudentScore(decimal testPaperScore, decimal attendanceScore)
        {
            this.TestPaperScore = testPaperScore;
            AttendanceScore = attendanceScore;
        }
        public override decimal GetScore()
        {
            return this.TestPaperScore / 2 + AttendanceScore;
        }
    }
}
