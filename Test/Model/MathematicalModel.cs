using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Test.CalculatorServiceReference;

namespace Test.Model
{
    class MathematicalModel
    {
        private readonly ICollection<Equation> _history;

        public MathematicalModel(ICollection<Equation> history)
        {
            _history = history;
        }

        public void GetResult (Equation equation, Action onUpdate)
        {
            CalculatorSoapClient client = new CalculatorSoapClient();
            switch (equation.Operation)
            {
                case "+":
                    equation.Result = client.Add(equation.Number1, equation.Number2);
                    break;
                case "-":
                    equation.Result = client.Subtract(equation.Number1, equation.Number2);
                    break;
                case "*":
                    equation.Result = client.Multiply(equation.Number1, equation.Number2);
                    break;
                case " ":
                    return;
                default:
                    return;
            }

            _history.Add(equation);

            onUpdate();
        }

        public void CreateXML()
        {
            XDocument xdoc = new XDocument(
                new XDeclaration("1.0", "utf-8", "yes"),
                new XElement("History",
                    from eq in _history
                    select
                        new XElement("Equation",
                            new XElement("FirstName", eq.Number1),
                            new XElement("LastName", eq.Number2),
                            new XElement("Operation", eq.Operation),
                            new XElement("Result", eq.Result))));

            xdoc.Save(Environment.GetFolderPath(Environment.SpecialFolder.Desktop));
        }
    }
}
