/*
 * Grading ID: M5477
 * Program: 2
 * Due Date: Mar 5 2019
 * Course Section: 01
 * Description: This program determines a users marginal tax rate and the amount due.
 */
 
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace tax_brackets
{
    public partial class TaxBrackets : Form
    {
        public TaxBrackets()
        {
            InitializeComponent();
        }

        private void calculateButton_Click(object sender, EventArgs e)
        {
            const uint TIER1_SINGLE_MAX = 9700, // The highest dollar amount for someone filing as a single in tier 1.
                TIER2_SINGLE_MAX = 39475,       // The highest dollar amount for someone filing as a single in tier 2.
                TIER3_SINGLE_MAX = 84200,       // The highest dollar amount for someone filing as a single in tier 3.
                TIER4_SINGLE_MAX = 160725,      // The highest dollar amount for someone filing as a single in tier 4.
                TIER5_SINGLE_MAX = 204100,      // The highest dollar amount for someone filing as a single in tier 5.
                TIER6_SINGLE_MAX = 510300,      // The highest dollar amount for someone filing as a single in tier 6.

                TIER1_JOINT_MAX = 19400,  // The highest dollar amount for someone filing jointly in tier 1.
                TIER2_JOINT_MAX = 78950,  // The highest dollar amount for someone filing jointly in tier 2.
                TIER3_JOINT_MAX = 168400, // The highest dollar amount for someone filing jointly in tier 3.
                TIER4_JOINT_MAX = 321450, // The highest dollar amount for someone filing jointly in tier 4.
                TIER5_JOINT_MAX = 408200, // The highest dollar amount for someone filing jointly in tier 5.
                TIER6_JOINT_MAX = 612350, // The highest dollar amount for someone filing jointly in tier 6.

                TIER1_HEAD_MAX = 13850,  // The highest dollar amount for someone filing as the head in tier 1.
                TIER2_HEAD_MAX = 52850,  // The highest dollar amount for someone filing as the head in tier 2.
                TIER3_HEAD_MAX = 84200,  // The highest dollar amount for someone filing as the head in tier 3.
                TIER4_HEAD_MAX = 160700, // The highest dollar amount for someone filing as the head in tier 4.
                TIER5_HEAD_MAX = 204100, // The highest dollar amount for someone filing as the head in tier 5.
                TIER6_HEAD_MAX = 510300, // The highest dollar amount for someone filing as the head in tier 6.

                TIER6_SEPARATE_MAX = 306175; // The highest dollar amount for someone filing seperately in tier 6.

            const double TIER1_RATE = .1, // The 2019 tax rate for tier 1.
                TIER2_RATE = .12,         // The 2019 tax rate for tier 2.
                TIER3_RATE = .22,         // The 2019 tax rate for tier 3.
                TIER4_RATE = .24,         // The 2019 tax rate for tier 4.
                TIER5_RATE = .32,         // The 2019 tax rate for tier 5.
                TIER6_RATE = .35,         // The 2019 tax rate for tier 6.
                TIER7_RATE = .37;         // The 2019 tax rate for tier 7.

            double topMarginalBracket = 0, // The highest bracket the user is in
                incomeTaxOwed = 0;         // The money owed to Uncle Sam

            uint reportedIncome, // The income reported by the user
                tierIncome;      // The income available for the next tier

            bool incomeValid; // (Hopefully) our user entered a valid income
            incomeValid = uint.TryParse(income.Text, out reportedIncome);

            if (incomeValid)
            {
                Debug.WriteLine("");
                Debug.WriteLine("==== NEW RUN ====");
                Debug.WriteLine("");

                Debug.WriteLine($"Their reported income is {reportedIncome:C}");
                if (single.Checked)
                {
                    Debug.WriteLine("The user is filing as a single");
                    tierIncome = reportedIncome;

                    if (tierIncome > TIER6_SINGLE_MAX)
                    {
                        Debug.WriteLine("The user has income at tier 7");
                        topMarginalBracket = TIER7_RATE;

                        tierIncome -= TIER6_SINGLE_MAX;
                        Debug.WriteLine($"We will be charging a {topMarginalBracket:P} tax on {tierIncome:C}");
                        incomeTaxOwed += tierIncome * TIER7_RATE;
                        tierIncome = TIER6_SINGLE_MAX;

                        Debug.WriteLine($"As of now they owe {incomeTaxOwed:C}");
                        Debug.WriteLine($"{tierIncome:C} is left remaining to tax");
                        Debug.WriteLine("");
                    }
                    if (tierIncome >= TIER5_SINGLE_MAX)
                    {
                        Debug.WriteLine("The user has income at tier 6");
                        topMarginalBracket = TIER6_RATE;

                        tierIncome -= TIER5_SINGLE_MAX;
                        Debug.WriteLine($"We will be charging a {topMarginalBracket:P} tax on {tierIncome:C}");
                        incomeTaxOwed += tierIncome * TIER6_RATE;
                        tierIncome = TIER5_SINGLE_MAX;

                        Debug.WriteLine($"As of now they owe {incomeTaxOwed:C}");
                        Debug.WriteLine($"{tierIncome:C} is left remaining to tax");
                        Debug.WriteLine("");
                    }
                    if (tierIncome >= TIER4_SINGLE_MAX)
                    {
                        Debug.WriteLine("The user has income at tier 5");
                        topMarginalBracket = TIER5_RATE;

                        tierIncome -= TIER4_SINGLE_MAX;
                        Debug.WriteLine($"We will be charging a {topMarginalBracket:P} tax on {tierIncome:C}");
                        incomeTaxOwed += tierIncome * TIER5_RATE;
                        tierIncome = TIER4_SINGLE_MAX;

                        Debug.WriteLine($"As of now they owe {incomeTaxOwed:C}");
                        Debug.WriteLine($"{tierIncome:C} is left remaining to tax");
                        Debug.WriteLine("");
                    }
                    if (tierIncome >= TIER3_SINGLE_MAX)
                    {
                        Debug.WriteLine("The user has income at tier 4");
                        topMarginalBracket = TIER4_RATE;

                        tierIncome -= TIER3_SINGLE_MAX;
                        Debug.WriteLine($"We will be charging a {topMarginalBracket:P} tax on {tierIncome:C}");
                        incomeTaxOwed += tierIncome * TIER4_RATE;
                        tierIncome = TIER3_SINGLE_MAX;

                        Debug.WriteLine($"As of now they owe {incomeTaxOwed:C}");
                        Debug.WriteLine($"{tierIncome:C} is left remaining to tax");
                        Debug.WriteLine("");
                    }
                    if (tierIncome >= TIER2_SINGLE_MAX)
                    {
                        Debug.WriteLine("The user has income at tier 3");
                        topMarginalBracket = TIER3_RATE;

                        tierIncome -= TIER2_SINGLE_MAX;
                        Debug.WriteLine($"We will be charging a {topMarginalBracket:P} tax on {tierIncome:C}");
                        incomeTaxOwed += tierIncome * TIER3_RATE;
                        tierIncome = TIER2_SINGLE_MAX;

                        Debug.WriteLine($"As of now they owe {incomeTaxOwed:C}");
                        Debug.WriteLine($"{tierIncome:C} is left remaining to tax");
                        Debug.WriteLine("");
                    }
                    if (tierIncome >= TIER1_SINGLE_MAX)
                    {
                        Debug.WriteLine("The user has income at tier 2");
                        topMarginalBracket = TIER2_RATE;

                        tierIncome -= TIER1_SINGLE_MAX;
                        Debug.WriteLine($"We will be charging a {topMarginalBracket:P} tax on {tierIncome:C}");
                        incomeTaxOwed += tierIncome * TIER2_RATE;
                        tierIncome = TIER1_SINGLE_MAX;

                        Debug.WriteLine($"As of now they owe {incomeTaxOwed:C}");
                        Debug.WriteLine($"{tierIncome:C} is left remaining to tax");
                        Debug.WriteLine("");
                    }

                    Debug.WriteLine("The user has income at tier 1");
                    topMarginalBracket = TIER1_RATE;

                    Debug.WriteLine($"We will be charging a {topMarginalBracket:P} tax on {tierIncome:C}");
                    incomeTaxOwed += tierIncome * TIER1_RATE;
                    tierIncome = 0;

                    Debug.WriteLine($"{incomeTaxOwed:C} is the total tax");
                }
                else if (marriedJoint.Checked)
                {
                    Debug.WriteLine("The user is filing jointly");
                }
                else if (headOfHousehold.Checked)
                {
                    Debug.WriteLine("The user is filing as the head of the household");
                }
                else if (marriedSeparate.Checked)
                {
                    Debug.WriteLine("The user is filing married but separately");
                }
                else
                {
                    // Something is broken if this ever happens, but I don't want to make the assumption one is checked
                    Debug.WriteLine("SOMETHING BROKE CALL 911");
                }

                taxOwed.Text = incomeTaxOwed.ToString("C");
                taxRate.Text = topMarginalBracket.ToString("P");

                Debug.WriteLine("");
                Debug.WriteLine("=================");
            }
            else
            {
                MessageBox.Show("There was an error processing your taxes. Please ensure your income is reported in whole dollars and try again.",
                    "Form Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
