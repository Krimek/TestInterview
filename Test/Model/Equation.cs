namespace Test.Model
{
    public class Equation
    {
        public int Number1 { get; set; }

        public int Number2 { get; set; }

        public string Operation { get; set; }

        public int Result { get; set; }

        public Equation(string number1, string number2, string operation)
        {
            Operation = operation;
            Number1 = int.Parse(number1);
            Number2 = int.Parse(number2);
        }
    }
}
