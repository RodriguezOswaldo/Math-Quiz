using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MathQuiz
{
    public partial class Form1 : Form
    {
        //Create a random object called randomizer
        //to generate random numbers
        Random randomizer = new Random();

        //These integer variables will store the numbers
        //for the addition problem.
        int addend1;
        int addend2;

        // These integer variables store the numbers 
        // for the subtraction problem. 
        int minuend;
        int subtrahend;

        // These integer variables store the numbers 
        // for the multiplication problem. 
        int multiplicand;
        int multiplier;

        // These integer variables store the numbers 
        // for the division problem. 
        int dividend;
        int divisor;


        //keeping track of the time
        int timeLeft;
        /// <summary>
        /// Start the quiz by filling in all of the problems 
        /// and starting the timer
        /// </summary>
        /// 
        public void StartTheQuiz()
        {
            //generate two random numbers to add
            addend1 = randomizer.Next(51);
            addend2 = randomizer.Next(51);

            //Convert the random numbers into a strings to be displayed
            plusLeftLabel.Text = addend1.ToString();
            plusRightLabel.Text = addend2.ToString();

            // 'sum' is the name of the NumericUpDown control.
            // This step makes sure its value is zero before
            // adding any values to it.
            sum.Value = 0;


            // Fill in the subtraction problem.
            //It has the same information for the addition, but for the substraction 
            //and in just one block
            minuend = randomizer.Next(1, 101);
            subtrahend = randomizer.Next(1, minuend);
            minusLeftLabel.Text = minuend.ToString();
            minusRightLabel.Text = subtrahend.ToString();
            difference.Value = 0;

            // Fill in the multiplication problem.
            multiplicand = randomizer.Next(2, 11);
            multiplier = randomizer.Next(2, 11);
            timesLeftLabel.Text = multiplicand.ToString();
            timesRightLabel.Text = multiplier.ToString();
            product.Value = 0;

            //Fill in the division problem.
            divisor = randomizer.Next(2, 11);
            int temporaryQuotient = randomizer.Next(2, 11);
            dividend = divisor * temporaryQuotient;
            dividedLeftLabel.Text = dividend.ToString();
            dividedRightLabel.Text = divisor.ToString();
            quotient.Value = 0;

            //Start the timer
            timeLeft = 30;
            timeLabel.Text = "30 Seconds";
            timer1.Start();
        }

        private bool CheckTheAnswer()
        {
            /// <summary>
            /// Check the answers to see if the user got everything right.
            /// </summary>
            /// <returns>True if the answer's correct, false otherwise.</returns>
            if ((addend1 + addend2 == sum.Value)
                && (minuend - subtrahend == difference.Value)
                && (multiplicand * multiplier == product.Value)
                && (dividend / divisor == quotient.Value))
                return true;
            else
                return false;
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void TimeLabel_Click(object sender, EventArgs e)
        {

        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            StartTheQuiz();
            startButton.Enabled = false;

            dateLabel.Text = DateTime.Now.ToShortDateString();
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            //Checking the answer
            if (CheckTheAnswer())
            {
                timer1.Stop();
                MessageBox.Show("You got all the answers right!", "congratulations!");
                startButton.Enabled = true;
            }
            else if (timeLeft > 0)
            {
                //If answer return false keep counting down. Decrease the time left
                timeLeft--;
                timeLabel.Text = timeLeft + " seconds";
            }
            else
            {
                // If the user ran out of time, stop the timer, show 
                // a MessageBox, and fill in the answers.
                timer1.Stop();
                timeLabel.Text = "Time's up!";
                MessageBox.Show("You didn't finish in time.", "Sorry!");
                sum.Value = addend1 + addend2;
                difference.Value = minuend - subtrahend;
                product.Value = multiplicand * multiplier;
                quotient.Value = dividend / divisor;
                startButton.Enabled = true;
            }

        }

        private void answer_Enter(object sender, EventArgs e)
        {
            //Select the whole answer in the NumericUpDown control.
            NumericUpDown answerBox = sender as NumericUpDown;

            if (answerBox != null)
            {
                int lenghtOfAnswer = answerBox.Value.ToString().Length;
                answerBox.Select(0, lenghtOfAnswer);
            }
        }

        private void DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void DateLabel_Click(object sender, EventArgs e)
        {
            

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}