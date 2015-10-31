using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalculatorOne
{
    public partial class Form1 : Form
    {
        public float HeldNumber; //The number we are currently inputting/ans
        public float lastHeldNumber; //The last number we inputted
        public bool HeldNumberInDecimal = false; //Have we pressed the decimal button yet on the current held number
        public byte CurOp; //The current opperation we're going to perform  (1 is add, 2 is sub, 3 is mult, 4 is div, 5 will be mod)
        public bool JustEquated = false; //Has the user's last action been an equation
        public List<int> BaseConversionInputInts = new List<int>(); //The value of every digit in the base conversion input
        public bool invalidBaseInput = false; //Is the base conversion input not valid

        public Form1()
        {
            InitializeComponent();
        }

        //Event for if Help/About is clicked
        private void menuItem4_Click(object sender, EventArgs e)
        {
            //Creates a local About Box Form
            AboutBox1 AboutBox = new AboutBox1();
            //Makes the About Box Appear
            AboutBox.Show();
        }

        //Event for form being loaded
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        //Event for Help/Help being clicked
        private void menuItem6_Click(object sender, EventArgs e)
        {
            //Creates a local Help Form
            HelpForm HelpForm = new HelpForm();
            //Makes the Help Form Appear
            HelpForm.Show();
        }

        //A region containing events for input buttons being clicked
        #region buttonInput

        private void button1_Click(object sender, EventArgs e)
        {
            ChangeHeldNumber(1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ChangeHeldNumber(2);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ChangeHeldNumber(3);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ChangeHeldNumber(4);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ChangeHeldNumber(5);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ChangeHeldNumber(6);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            ChangeHeldNumber(7);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            ChangeHeldNumber(8);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            ChangeHeldNumber(9);
        }

        private void button0_Click(object sender, EventArgs e)
        {
            ChangeHeldNumber(0);
        }

        private void buttonDecimal_Click(object sender, EventArgs e)
        {
            HeldNumberInDecimal = true;
        }

        private void buttonPlus_Click(object sender, EventArgs e)
        {
            PerformOperation(1);
        }

        private void buttonMinus_Click(object sender, EventArgs e)
        {
            PerformOperation(2);
        }

        private void buttonMult_Click(object sender, EventArgs e)
        {
            PerformOperation(3);
        }

        private void buttonDiv_Click(object sender, EventArgs e)
        {
            PerformOperation(4);
        }

        private void buttonMod_Click(object sender, EventArgs e)
        {
            PerformOperation(5);
        }

        private void buttonEquals_Click(object sender, EventArgs e)
        {
            Equate();
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            ClearDisplay();
        }

        #endregion

        //A function for changing the currently displayed number -- TBI after-decimal changes
        private void ChangeHeldNumber(int number)
        {
            if (JustEquated == true)
            {
                lastHeldNumber = HeldNumber;
                HeldNumber = 0;
                HeldNumberInDecimal = false;
            }
            if (HeldNumberInDecimal == false)
            {
                HeldNumber *= 10f;
                HeldNumber += number;
            }

            RefreshDisplay();
            JustEquated = false;
        }

        //A function for preparing and operation for execution
        private void PerformOperation(byte OperationNum)
        {
            lastHeldNumber = HeldNumber;
            HeldNumber = 0;
            HeldNumberInDecimal = false;
            CurOp = OperationNum;
            RefreshDisplay();
            JustEquated = false;
        }

        //Clears the display (When the clear button is pressed)
        private void ClearDisplay()
        {
            lastHeldNumber = HeldNumber;
            HeldNumber = 0;
            HeldNumberInDecimal = false;
            JustEquated = false;
            RefreshDisplay();
        }

        //Takes the two held numbers and performs chosen operation on them
        private void Equate()
        {
            float tempHold;
            switch (CurOp)
            {
                case 1:
                    tempHold = HeldNumber;
                    HeldNumber = lastHeldNumber + HeldNumber;
                    lastHeldNumber = tempHold;
                    RefreshDisplay();
                    break;
                case 2:
                    tempHold = HeldNumber;
                    HeldNumber = lastHeldNumber - HeldNumber;
                    lastHeldNumber = tempHold;
                    RefreshDisplay();
                    break;
                case 3:
                    tempHold = HeldNumber;
                    HeldNumber = lastHeldNumber * HeldNumber;
                    lastHeldNumber = tempHold;
                    RefreshDisplay();
                    break;
                case 4:
                    tempHold = HeldNumber;
                    HeldNumber = lastHeldNumber / HeldNumber;
                    lastHeldNumber = tempHold;
                    RefreshDisplay();
                    break;
                case 5:
                    tempHold = HeldNumber;
                    HeldNumber = lastHeldNumber % HeldNumber;
                    lastHeldNumber = tempHold;
                    RefreshDisplay();
                    break;
            }
            JustEquated = true;
        }

        //Refreshes user's display
        private void RefreshDisplay()
        {
            displayTextBox.Text = HeldNumber.ToString();
        }

        //Grabs the digits from the Base Conversion Input and stores them in an array
        private void GetBaseInputDigits()
        {
            string input = BaseConvertInput.Text;
            char[] b = new char[input.Length];
            
            using (StringReader sr = new StringReader(input))
            {
                // Read 13 characters from the string into the array.
                sr.Read(b, 0, input.Length);
            }

            for (int i = 0; i < input.Length; i++)
            {
#region BigSwitch
                switch (b[i])
                {
                    case '0':
                        BaseConversionInputInts.Add(0);
                    break;
                    case '1':
                        BaseConversionInputInts.Add(1);
                    break;
                    case '2':
                        BaseConversionInputInts.Add(2);
                    break;
                    case '3':
                        BaseConversionInputInts.Add(3);
                    break;
                    case '4':
                        BaseConversionInputInts.Add(4);
                    break;
                    case '5':
                        BaseConversionInputInts.Add(5);
                    break;
                    case '6':
                        BaseConversionInputInts.Add(6);
                    break;
                    case '7':
                        BaseConversionInputInts.Add(7);
                    break;
                    case '8':
                        BaseConversionInputInts.Add(8);
                    break;
                    case '9':
                        BaseConversionInputInts.Add(9);
                    break;
                    case 'A':
                        BaseConversionInputInts.Add(10);
                    break;
                    case 'B':
                        BaseConversionInputInts.Add(11);
                    break;
                    case 'C':
                        BaseConversionInputInts.Add(12);
                    break;
                    case 'D':
                        BaseConversionInputInts.Add(13);
                    break;
                    case 'E':
                        BaseConversionInputInts.Add(14);
                    break;
                    case 'F':
                        BaseConversionInputInts.Add(15);
                    break;
                    case 'G':
                        BaseConversionInputInts.Add(16);
                    break;
                    case 'H':
                        BaseConversionInputInts.Add(17);
                    break;
                    case 'I':
                        BaseConversionInputInts.Add(18);
                    break;
                    case 'J':
                        BaseConversionInputInts.Add(19);
                    break;
                    case 'K':
                        BaseConversionInputInts.Add(20);
                    break;
                    case 'L':
                        BaseConversionInputInts.Add(21);
                    break;
                    case 'M':
                        BaseConversionInputInts.Add(22);
                    break;
                    case 'N':
                        BaseConversionInputInts.Add(23);
                    break;
                    case 'O':
                        BaseConversionInputInts.Add(24);
                    break;
                    case 'P':
                        BaseConversionInputInts.Add(25);
                    break;
                    case 'Q':
                        BaseConversionInputInts.Add(26);
                    break;
                    case 'R':
                        BaseConversionInputInts.Add(27);
                    break;
                    case 'S':
                        BaseConversionInputInts.Add(28);
                    break;
                    case 'T':
                        BaseConversionInputInts.Add(29);
                    break;
                    case 'U':
                        BaseConversionInputInts.Add(30);
                    break;
                    case 'V':
                        BaseConversionInputInts.Add(31);
                    break;
                    case 'W':
                        BaseConversionInputInts.Add(32);
                    break;
                    case 'X':
                        BaseConversionInputInts.Add(33);
                    break;
                    case 'Y':
                        BaseConversionInputInts.Add(34);
                    break;
                    case 'Z':
                        BaseConversionInputInts.Add(35);
                    break;
                }
#endregion
            }
            
        }

        private void BaseConvertInput_TextChanged(object sender, EventArgs e)
        {
            GetBaseInputDigits();
        }

    }
}
