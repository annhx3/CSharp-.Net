using System;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;

namespace AlyssaNielsenWPFCalculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    public partial class MainWindow : Window
    {
        static Display DisplayResult;
        static Display DisplayAll;
        static DisplayEquation Equation;
        public MainWindow()
        {
            InitializeComponent();

            CreateResultBox();
            CreateDisplay();

            Equation = new DisplayEquation();
            CalcGrid.Children.Add(DisplayAll);
            ReadKey('0');
            ClearDisplay = true;

        }

        private Display CreateResultBox()
        {
            DisplayResult = new Display();
            Grid.SetRow(DisplayResult, 0);
            Grid.SetColumn(DisplayResult, 4);
            Grid.SetColumnSpan(DisplayResult, 5);
            DisplayResult.Height = 30;
            DisplayResult.Margin = new Thickness(4);
            CalcGrid.Children.Add(DisplayResult);
            return DisplayResult;
        }

        private Display CreateDisplay()
        {
            DisplayAll = new Display();
            Grid.SetRow(DisplayAll, 1);
            Grid.SetColumn(DisplayAll, 0);
            Grid.SetColumnSpan(DisplayAll, 4);
            Grid.SetRowSpan(DisplayAll, 5);
            DisplayAll.IsReadOnly = true;
            DisplayAll.Margin = new Thickness(4);
            DisplayAll.VerticalScrollBarVisibility = ScrollBarVisibility.Visible;
            DisplayAll.Margin = new Thickness(3.0, 3.0, 3.0, 3.0);
            DisplayAll.HorizontalScrollBarVisibility = ScrollBarVisibility.Auto;
            return DisplayAll;
        }

        private enum MathOperations
        {
            None,
            Divide,
            Multiply,
            Subtract,
            Add,
            Percent,
            SquareRoot,
            PlusMinus
        }

        private MathOperations _prevOp;
        private string _display;
        private string _prevValue;
        private string _memoryValue;
        private bool _clearDisplay;

        private bool ClearDisplay
        {
            get
            {
                return _clearDisplay;

            }
            set
            {
                _clearDisplay = value;
            }
        }

        private float MemoryValue
        {
            get
            {
                if (_memoryValue == string.Empty)
                    return 0.0F;
                else
                    return float.Parse(_memoryValue, CultureInfo.InvariantCulture.NumberFormat);
            }
            set
            {
                _memoryValue = value.ToString();
            }
        }

        private string PrevValue
        {
            get
            {
                if (_prevValue == string.Empty)
                    return "0";
                return _prevValue;

            }
            set
            {
                _prevValue = value;
            }
        }

        private string Display
        {
            get
            {
                return _display;
            }
            set
            {
                _display = value;
            }
        }

        private void Num_Click(object sender, RoutedEventArgs e)
        {

            string input = ((Button)sender).Content.ToString();
            char[] ids = input.ToCharArray();
            ReadKey(ids[0]);

        }
        private void Op_Click(object sender, RoutedEventArgs e)
        {
            ProcessOperation(((Button)sender).Name.ToString());
        }

        private void OnWindowKeyDown(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            try
            {
                string input = e.Text;
                char key = (input.ToCharArray())[0];
                e.Handled = true;

                if ((key >= '0' && key <= '9') || key == '.' || key == '\b') 
                {
                    ReadKey(key);
                    return;
                }
                switch (key)
                {
                    case '+':
                        ProcessOperation("Add");
                        break;
                    case '-':
                        ProcessOperation("Subtract");
                        break;
                    case '*':
                        ProcessOperation("Multiply");
                        break;
                    case '/':
                        ProcessOperation("Divide");
                        break;
                    case '%':
                        ProcessOperation("Percent");
                        break;
                    case '=':
                        ProcessOperation("Equals");
                        break;
                }
            }
            catch (FormatException exception)
            {
                Equation.AddResult("Error");
            }

        }

        private void ProcessOperation(string s)
        {
            try
            {
                float f = 0.0F;
                switch (s)
                {
                    case "Divide":

                        if (ClearDisplay)
                        {
                            _prevOp = MathOperations.Divide;
                            break;
                        }
                        CalculateResult();
                        _prevOp = MathOperations.Divide;
                        PrevValue = Display;
                        ClearDisplay = true;
                        break;
                    case "Multiply":
                        if (ClearDisplay)
                        {
                            _prevOp = MathOperations.Multiply;
                            break;
                        }
                        CalculateResult();
                        _prevOp = MathOperations.Multiply;
                        PrevValue = Display;
                        ClearDisplay = true;
                        break;
                    case "Subtract":
                        if (ClearDisplay)
                        {
                            _prevOp = MathOperations.Subtract;
                            break;
                        }
                        CalculateResult();
                        _prevOp = MathOperations.Subtract;
                        PrevValue = Display;
                        ClearDisplay = true;
                        break;
                    case "Add":
                        if (ClearDisplay)
                        {
                            _prevOp = MathOperations.Add;
                            break;
                        }
                        CalculateResult();
                        _prevOp = MathOperations.Add;
                        PrevValue = Display;
                        ClearDisplay = true;
                        break;
                    case "Equals":
                        if (ClearDisplay)
                            break;
                        CalculateResult();
                        ClearDisplay = true;
                        _prevOp = MathOperations.None;
                        PrevValue = Display;
                        break;
                    case "SquareRoot":
                        _prevOp = MathOperations.SquareRoot;
                        PrevValue = Display;
                        CalculateResult();
                        PrevValue = Display;
                        ClearDisplay = true;
                        _prevOp = MathOperations.None;
                        break;
                    case "Percent":
                        if (ClearDisplay)
                        {
                            _prevOp = MathOperations.Percent;
                            break;
                        }
                        CalculateResult();
                        _prevOp = MathOperations.Percent;
                        PrevValue = Display;
                        ClearDisplay = true;
                        break;
                    case "PlusMinus":
                        _prevOp = MathOperations.PlusMinus;
                        PrevValue = Display;
                        CalculateResult();
                        PrevValue = Display;
                        ClearDisplay = true;
                        _prevOp = MathOperations.None;
                        break;
                    case "ClearAll":
                        _prevOp = MathOperations.None;
                        Display = PrevValue = string.Empty;
                        Equation.Clear();
                        UpdateDisplay();
                        break;
                    case "ClearEntry":
                        _prevOp = MathOperations.None;
                        Display = PrevValue;
                        UpdateDisplay();
                        break;
                    case "MemoryClear":
                        MemoryValue = 0.0F;
                        DisplayMemory();
                        break;
                    case "MemorySave":
                        MemoryValue = float.Parse(Display, CultureInfo.InvariantCulture.NumberFormat);
                        DisplayMemory();
                        ClearDisplay = true;
                        break;
                    case "MemoryRecall":
                        Display = MemoryValue.ToString();
                        UpdateDisplay();
                        ClearDisplay = false;
                        break;
                    case "MemoryAdd":
                        f = MemoryValue + float.Parse(Display, CultureInfo.InvariantCulture.NumberFormat);
                        MemoryValue = f;
                        DisplayMemory();
                        ClearDisplay = true;
                        break;
                }
            }
            catch (Exception exception)
            {
                Equation.AddResult("Error");
            }
        }

        private void CalculateResult()
        {
            float f;
            if (_prevOp == MathOperations.None)
                return;

            f = Calculate(_prevOp);
            Display = f.ToString();

            UpdateDisplay();
        }
        private float Calculate(MathOperations LastOper)
        {
            float f = 0.0F;

            try
            {
                switch (LastOper)
                {
                    case MathOperations.Divide:
                        Equation.AddArguments(PrevValue + " / " + Display);
                        f = (float.Parse(PrevValue, CultureInfo.InvariantCulture.NumberFormat) / float.Parse(Display, CultureInfo.InvariantCulture.NumberFormat));
                        CheckResult(f);
                        Equation.AddResult(f.ToString());
                        break;
                    case MathOperations.Add:
                        Equation.AddArguments(PrevValue + " + " + Display);
                        f = (float.Parse(PrevValue, CultureInfo.InvariantCulture.NumberFormat) + float.Parse(Display, CultureInfo.InvariantCulture.NumberFormat));
                        CheckResult(f);
                        Equation.AddResult(f.ToString());
                        break;
                    case MathOperations.Multiply:
                        Equation.AddArguments(PrevValue + " * " + Display);
                        f = (float.Parse(PrevValue, CultureInfo.InvariantCulture.NumberFormat) * float.Parse(Display, CultureInfo.InvariantCulture.NumberFormat));
                        CheckResult(f);
                        Equation.AddResult(f.ToString());
                        break;
                    case MathOperations.Percent:
                        //Note: this is different (but make more sense) then Windows calculator
                        Equation.AddArguments(PrevValue + " % " + Display);
                        f = f = (float.Parse(PrevValue, CultureInfo.InvariantCulture.NumberFormat) * float.Parse(Display, CultureInfo.InvariantCulture.NumberFormat)) / 100.0F;
                        CheckResult(f);
                        Equation.AddResult(f.ToString());
                        break;
                    case MathOperations.Subtract:
                        Equation.AddArguments(PrevValue + " - " + Display);
                        f = (float.Parse(PrevValue, CultureInfo.InvariantCulture.NumberFormat) - float.Parse(Display, CultureInfo.InvariantCulture.NumberFormat));
                        CheckResult(f);
                        Equation.AddResult(f.ToString());
                        break;
                    case MathOperations.SquareRoot:
                        Equation.AddArguments("SquareRoot( " + PrevValue + " )");
                        f = (float)Math.Sqrt(float.Parse(PrevValue, CultureInfo.InvariantCulture.NumberFormat));
                        CheckResult(f);
                        Equation.AddResult(f.ToString());
                        break;
                    case MathOperations.PlusMinus:
                        f = float.Parse(PrevValue, CultureInfo.InvariantCulture.NumberFormat) * (-1.0F);
                        break;
                }
            }
            catch (Exception exception)
            {
                f = 0;
                Window parent = (Window)CalculatorPanel.Parent;
                Equation.AddResult("Error");
                MessageBox.Show(parent, "The operation cannot be performed", parent.Title);
            }

            return f;
        }

        private void CheckResult(float f)
        {
            if (float.IsNegativeInfinity(f) || float.IsPositiveInfinity(f) || float.IsNaN(f))
                throw new Exception("Illegal value");
        }
        private void ReadKey(char c)
        {
            if (ClearDisplay)
            {
                Display = string.Empty;
                ClearDisplay = false;
            }
            AddToDisplay(c);
        }
        private void AddToDisplay(char c)
        {
            if (c == '.')
            {
                if (Display.IndexOf('.', 0) >= 0)  //already exists
                    return;
                Display = Display + c;
            }
            else
            {
                if (c >= '0' && c <= '9')
                {
                    Display = Display + c;
                }
                else
                if (c == '\b')  //backspace ?
                {
                    if (Display.Length <= 1)
                        Display = String.Empty;
                    else
                    {
                        int i = Display.Length;
                        Display = Display.Remove(i - 1, 1);  //remove last char 
                    }
                }

            }

            UpdateDisplay();
        }
        private void UpdateDisplay()
        {
            if (Display == String.Empty)
                DisplayResult.Text = "0";
            else
                DisplayResult.Text = Display;
        }

        private void DisplayMemory()
        {
            if (_memoryValue != String.Empty)
                MemoryBox.Text = "MemoryValue: " + _memoryValue;
            else
                MemoryBox.Text = "MemoryValue: [empty]";
        }


        private class DisplayEquation
        {
            string args;

            public DisplayEquation()
            {
            }
            public void AddArguments(string a)
            {
                args = a;
            }
            public void AddResult(string r)
            {
                DisplayAll.Text += args + " = " + r + "\n";
            }
            public void Clear()
            {
                DisplayAll.Text = string.Empty;
                args = string.Empty;
            }
        }


    }

}

