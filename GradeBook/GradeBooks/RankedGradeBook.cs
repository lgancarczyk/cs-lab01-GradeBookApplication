using GradeBook.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace GradeBook.GradeBooks
{
    class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
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

            int twentyPercent = Students.Count/5;
            int betterStudents = 0;
            foreach (var student in Students)
            {
                if (averageGrade<= student.AverageGrade)
                {
                    betterStudents++;
                }
            }
            if (betterStudents<=twentyPercent)
            {
                return 'A';
            }
            else if (betterStudents >twentyPercent && betterStudents<= twentyPercent*2)
            {
                return 'B';
            }
            else if (betterStudents > twentyPercent * 2 && betterStudents <= twentyPercent * 3)
            {
                return 'C';
            }
            else if (betterStudents > twentyPercent * 3 && betterStudents <= twentyPercent * 4)
            {
                return 'D';
            }
            else
            {
                return 'F';
            }



        }
    }
}
