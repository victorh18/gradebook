namespace GradeBook
{
    public class Statistics
    {
        public Statistics()
        {
            Max = double.MinValue;
            Min = double.MaxValue;
            Count = 0;
            
        }
        public double Average
        {
            get
            {
                return Count == 0 ? 0 : Sum / Count;
            }
        }
        public double Max;
        public double Min;
        public char Letter
        {
            get
            {
                switch (Average)
                {
                    case var d when d >= 90:
                        return 'A';
                    case var d when d >= 80:
                        return 'B';
                    case var d when d >= 70:
                        return 'C';
                    case var d when d >= 60:
                        return 'D';
                    default:
                        return 'F';
                };
            }
        }
        public double Sum;
        public int Count;

        public void Add(double grade)
        {
            Sum += grade;
            Count++;
            Max = Math.Max(grade, Max);
            Min = Math.Min(grade, Min);
        }
    }
}