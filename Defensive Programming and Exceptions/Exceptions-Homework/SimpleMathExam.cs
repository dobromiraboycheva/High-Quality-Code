using System;

public class SimpleMathExam : Exam
{
    private const int ProblemSoveMinValue = 0;
    private const int ProblemSoveMaxValue = 10;
    private const int BadGradeMaxProblems = 2;
    private const int AverageGradeMaxProblems = 5;
    private const int GoodGradeMaxProblems = 8;

    private int problemsSolved;

    public SimpleMathExam(int problemsSolved)
    {
        this.ProblemsSolved = problemsSolved;
    }

    public int ProblemsSolved
    {
        get
        {
            if (this.problemsSolved < ProblemSoveMinValue)
            {
                return ProblemSoveMinValue;
            }
            else if (this.problemsSolved > ProblemSoveMaxValue)
            {
                return ProblemSoveMaxValue;
            }
            else
            {
                return this.problemsSolved;
            }
        }

        private set
        {
            this.problemsSolved = value;
        }
    }

    public override ExamResult Check()
    {
        if (this.ProblemsSolved <= BadGradeMaxProblems)
        {
            return new ExamResult(2, 2, 6, "Bad result: nothing done.");
        }
        else if (this.ProblemsSolved <= AverageGradeMaxProblems)
        {
            return new ExamResult(4, 2, 6, "Average result: nothing done.");
        }
        else if (this.ProblemsSolved <= GoodGradeMaxProblems)
        {
            return new ExamResult(6, 2, 6, "Average result: nothing done.");
        }

        return new ExamResult(0, 0, 0, "Invalid number of problems solved!");
    }
}
