using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Diagnostics;

namespace Passwortknacker_UI
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // variables
        public string password;
        string crackedPassword = "asd";
        long crackAttempts = 0;
        int amountOfCracksPerSec = 0;
        string passwordBoxText;

        // variables for each character in password
        #region variables
        int one = 0;
        int two = 0;
        int three = 0;
        int four = 0;
        int five = 0;
        int six = 0;
        int seven = 0;
        int eight = 0;
        int nine = 0;
        int ten = 0;
        int eleven = 0;
        int twelve = 0;
        int thirteen = 0;
        int fourteen = 0;
        int fiveteen = 0;
        int sixteen = 0;
        int seventeen = 0;
        int eighteen = 0;
        int nineteen = 0;
        int twenty = 0;
        #endregion

        // array with all characters to check in password
        string[] arrayOfSymbols = new string[]
        { "", "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z",
                "A","B","C","D","E","F","G","H","I","J","K","L","M","N","O","P","Q","R","S","T","U","V","W","X","Y","Z",
                "1","2","3","4","5","6","7","8","9","0",
                "!","\"","§","$","%","&","/","(",")","[",
                "]","=","{","}","\\","ß","?","´","`","+",
                "*","#","'","-","_",".",":",",",";","@",
                "<",">", "ä", "ü", "ö", "|"
        }; //99 total

        public MainWindow()
        {
            InitializeComponent();
        }

        // cracking password logic & displaying result in textboxes
        private void crackingLogic()
        {// stopwatch in order to track time
            var stopwatch = Stopwatch.StartNew();

            // function
            while (!crackedPassword.Equals(passwordBoxText))
            {
                // starting timer
                stopwatch.Start();

                one++;
                #region if Statements
                if (one == arrayOfSymbols.Length)
                {
                    two++;
                    one = 0;
                }
                if (two == arrayOfSymbols.Length)
                {
                    three++;
                    two = 0;
                }
                if (three == arrayOfSymbols.Length)
                {
                    four++;
                    three = 0;
                }
                if (four == arrayOfSymbols.Length)
                {
                    five++;
                    four = 0;
                }
                if (five == arrayOfSymbols.Length)
                {
                    six++;
                    five = 0;
                }
                if (six == arrayOfSymbols.Length)
                {
                    seven++;
                    six = 0;
                }
                if (seven == arrayOfSymbols.Length)
                {
                    eight++;
                    seven = 0;
                }
                if (eight == arrayOfSymbols.Length)
                {
                    nine++;
                    eight = 0;
                }
                if (nine == arrayOfSymbols.Length)
                {
                    ten++;
                    nine = 0;
                }
                if (ten == arrayOfSymbols.Length)
                {
                    eleven++;
                    ten = 0;
                }
                if (eleven == arrayOfSymbols.Length)
                {
                    twelve++;
                    eleven = 0;
                }
                if (twelve == arrayOfSymbols.Length)
                {
                    thirteen++;
                    twelve = 0;
                }
                if (thirteen == arrayOfSymbols.Length)
                {
                    fourteen++;
                    thirteen = 0;
                }
                if (fourteen == arrayOfSymbols.Length)
                {
                    fiveteen++;
                    fourteen = 0;
                }
                if (fiveteen == arrayOfSymbols.Length)
                {
                    sixteen++;
                    fiveteen = 0;
                }
                if (sixteen == arrayOfSymbols.Length)
                {
                    seventeen++;
                    sixteen = 0;
                }
                if (seventeen == arrayOfSymbols.Length)
                {
                    eighteen++;
                    seventeen = 0;
                }
                if (eighteen == arrayOfSymbols.Length)
                {
                    nineteen++;
                    eighteen = 0;
                }
                if (nineteen == arrayOfSymbols.Length)
                {
                    twenty++;
                    nineteen = 0;
                }
                if (twenty == arrayOfSymbols.Length)
                {
                    twenty = 0;
                }
                #endregion

                crackAttempts++;

                // adding password
                crackedPassword = arrayOfSymbols[one] + arrayOfSymbols[two] + arrayOfSymbols[three] + arrayOfSymbols[four] + arrayOfSymbols[five] + arrayOfSymbols[six] +
                    arrayOfSymbols[seven] + arrayOfSymbols[eight] + arrayOfSymbols[nine] + arrayOfSymbols[ten] + arrayOfSymbols[eleven] + arrayOfSymbols[twelve] +
                    arrayOfSymbols[thirteen] + arrayOfSymbols[fourteen] + arrayOfSymbols[fiveteen] + arrayOfSymbols[sixteen] + arrayOfSymbols[seventeen] + arrayOfSymbols[eighteen] +
                    arrayOfSymbols[nineteen] + arrayOfSymbols[twenty];

                // Console.Write(crackedPassword+ " " ); // printing password function if needed - be carefull, slows progress down immensely

            }

            // stopping timer
            stopwatch.Stop();

            // converting stopped time into seconds and minutes
            double miliseconds = stopwatch.ElapsedMilliseconds;
            var seconds = miliseconds / 1000;
            double minutes = seconds / 60;

            // calculating cracks per sec
            amountOfCracksPerSec = 0;
            try
            {
                amountOfCracksPerSec = Convert.ToInt32(crackAttempts / seconds);
            }
            catch
            {
                // unneccessary to print anything to the user
            }


            // password was textbox show
            passwordWasTextbox.Text = crackedPassword;
            // total cracks textbox show
            totalCracksTextbox.Text = Convert.ToString(crackAttempts);
            // cracks per second textbox show
            attemptedCracksPerSecTextbox.Text = Convert.ToString(amountOfCracksPerSec);
            // seconds to crack textbox show
            timeToCrackTextbox.Text = Convert.ToString(seconds);
        }

        //taking input from password text, execute crackinglogic
        public void SubmitPassword_Click(object sender, RoutedEventArgs e)
        {
            passwordBoxText = passwordBox.Password.ToString();
            crackingLogic();
        }

        // submitting password content when enterkey is pressed
        private void PasswordBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                SubmitPassword_Click(sender, e);
                e.Handled = true;
            }
        }
    }
}
