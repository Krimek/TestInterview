using System;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;
using System.Windows.Input;
using Test.Model;
using Test.ViewModel.MVVM;

namespace Test.ViewModel
{
    internal sealed class MathematicalViewModel : Presenter
    {
        private static readonly Regex _regex = new Regex("[^0-9.-]+");
        private readonly MathematicalModel _model;
        private string _number1 = String.Empty;
        private string _number2 = String.Empty;
        private string _operation = String.Empty;

        public MathematicalViewModel(MathematicalModel model, ObservableCollection<Equation> history)
        {
            (_model, History) = (model, history);
        }

        public string Number1
        {
            get => _number1;
            set
            {
                if (_regex.IsMatch(value))
                {
                    Update(ref _number1, value);
                }
            } 
        }

        public string Number2
        {
            get => _number2;
            set => Update(ref _number2, value);
        }
        public string Operation
        {
            get => _number2;
            set
            {
                if (_regex.IsMatch(value))
                {
                    Update(ref _operation, value);
                }
            }
        }

        public ObservableCollection<Equation> History { get; }  

        public ICommand GetResult => new Command(_ => _model.GetResult(new Equation(Number1, Number2, Operation), OnUpdateAddHistory));

        public ICommand CreateXML => new Command(_ => _model.CreateXML());

        private void OnUpdateAddHistory()
        {
            Number1 = string.Empty;
            Number2 = String.Empty;
            Operation = String.Empty;
        }
    }
}
