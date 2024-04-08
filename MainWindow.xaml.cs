using System;
using System.Windows;
using System.Windows.Controls;

namespace Calculator
{
    public partial class MainWindow : Window
    {
        public string first = "";
        public string second = "";
        public string operation = "";
        public double firstNumber = 0;
        public double secondNumber = 0;

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void Number_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            if (operation == "")
            {
                first += button.Content.ToString();
                ResultLabel.Content = first;

            }
            else
            {
                second += button.Content.ToString();
                ResultLabel.Content = second;
            }
        }

        private void Operation_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            if (first != "" && second == "")
            {
                operation = button.Content.ToString();
                ResultLabel.Content = operation;
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (second != "")
            {
                second = second.Remove(second.Length - 1);
                ResultLabel.Content = second;
            }
            else if (operation != "")
            {
                operation = "";
                ResultLabel.Content = first;
            }
            else if (first != "")
            {
                first = first.Remove(first.Length - 1);
                ResultLabel.Content = first;
            }
        }

        private void Equal_Click(object sender, RoutedEventArgs e)
        {
            if (first != "" && second != "")
            {
                double firstNumber = double.Parse(first);
                double secondNumber = double.Parse(second);
                double result = 0;

                switch (operation)
                {
                    case "+":
                        result = firstNumber + secondNumber;
                        ResultLabel.Content = result;

                        break;
                    case "-":
                        result = firstNumber - secondNumber;
                        ResultLabel.Content = result;
                        break;
                    case "*":
                        result = firstNumber * secondNumber;
                        ResultLabel.Content = result;
                        break;
                    case "/":
                        if (secondNumber != 0)
                        {
                            result = firstNumber / secondNumber;
                            ResultLabel.Content = result;
                        }
                        else
                            ResultLabel.Content = "ERROR: Division by zero";
                        break;
                }
                ResultLabel.Content = result;
                first = result.ToString();
                second = "";
                operation = "";

            }
        }

        private void ca_Click(object sender, RoutedEventArgs e)
        {
            first = "";
            second = "";
            ResultLabel.Content = " ";
        }

      
    }
}
