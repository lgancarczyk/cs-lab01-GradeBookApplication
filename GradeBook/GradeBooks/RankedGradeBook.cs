using GradeBook.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name, bool isWeighted) : base(name, isWeighted)
        {
            Type = GradeBookType.Ranked;
        }
        
        public override char GetLetterGrade(double averageGrade)
        {
            //return base.GetLetterGrade(averageGrade) ;  ten średniczek wysypuje program jak jest bez spacji xddddd godzinka w plecy 

            if (Students.Count < 5)
            {
                throw new InvalidOperationException();
            }
            int noOfStudents = Students.Count;
            int betterStudents = 0;

            foreach (var student in Students)
            {
                if (student.AverageGrade > averageGrade)
                {
                    betterStudents++;
                }
            }

            if (betterStudents < (noOfStudents * 0.2))
            {
                return 'A';
            }
            else if (betterStudents < (noOfStudents * 0.4))
            {
                return 'B';
            }         
            else if (betterStudents < (noOfStudents * 0.6))
            {
                return 'C';
            }           
            else if (betterStudents < (noOfStudents * 0.8))
            {
                return 'D';
            }
            else 
            {
                return 'F';
            }
                
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
