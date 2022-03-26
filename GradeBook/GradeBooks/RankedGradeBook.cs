using GradeBook.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GradeBook.GradeBooks
{
    class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name, bool isWeighted) : base(name, isWeighted)
        {
            Type = GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            //return base.GetLetterGrade(averageGrade);
            if (Students.Count <5)
            {
                throw new InvalidOperationException("Can`t be less than 5 students!");
            }
            var twentyPercent = (int)Math.Ceiling(Students.Count * 0.2);

            var grades = Students.OrderByDescending(e => e.AverageGrade).Select(e => e.AverageGrade).ToList();

            if (averageGrade >= grades[twentyPercent - 1])
                return 'A';
            if (averageGrade >= grades[(twentyPercent * 2) - 1])
                return 'B';
            if (averageGrade >= grades[(twentyPercent * 3) - 1])
                return 'C';
            if (averageGrade >= grades[(twentyPercent * 4) - 1])
                return 'D';
            return 'F';
        }

        public override void CalculateStatistics()
        {
            
            if (Students.Count<5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students.");
            }
            else
            {
                base.CalculateStatistics();
            }
        }
        public override void CalculateStudentStatistics(string name)
        {
            if (Students.Count<5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students.");
            }
            else
            {
                base.CalculateStudentStatistics(name);
            }
            
        }
    }
}
