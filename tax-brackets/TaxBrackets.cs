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
            const uint TIER1_SINGLE_MAX = 9700, // The highest dollar amount for someone filing separately in tier 1.
                TIER2_SINGLE_MAX = 39475,       // The highest dollar amount for someone filing separately in tier 2.
                TIER3_SINGLE_MAX = 84200,       // The highest dollar amount for someone filing separately in tier 3.
                TIER4_SINGLE_MAX = 160725,      // The highest dollar amount for someone filing separately in tier 4.
                TIER5_SINGLE_MAX = 204100,      // The highest dollar amount for someone filing separately in tier 5.
                TIER6_SINGLE_MAX = 510300,      // The highest dollar amount for someone filing separately in tier 6.

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

                TIER1_SEPARATE_MAX = 9700,     // The highest dollar amount for someone filing separately in tier 1.
                TIER2_SEPARATE_MAX = 39475,    // The highest dollar amount for someone filing separately in tier 2.
                TIER3_SEPARATE_MAX = 84200,    // The highest dollar amount for someone filing separately in tier 3.
                TIER4_SEPARATE_MAX = 160725,   // The highest dollar amount for someone filing separately in tier 4.
                TIER5_SEPARATE_MAX = 204100,   // The highest dollar amount for someone filing separately in tier 5.
                TIER6_SEPARATE_MAX = 306175;   // The highest dollar amount for someone filing seperately in tier 6.

            const double TIER1_RATE = .1, // The 2019 tax rate for tier 1.
                TIER2_RATE = .12,         // The 2019 tax rate for tier 2.
                TIER3_RATE = .22,         // The 2019 tax rate for tier 3.
                TIER4_RATE = .24,         // The 2019 tax rate for tier 4.
                TIER5_RATE = .32,         // The 2019 tax rate for tier 5.
                TIER6_RATE = .35,         // The 2019 tax rate for tier 6.
                TIER7_RATE = .37;         // The 2019 tax rate for tier 7.

            double bracketRate = 0, // The highest bracket percentage rate
                incomeTaxOwed = 0;  // The money owed to Uncle Sam

            uint reportedIncome,        // The income reported by the user
                topMarginalBracket = 0, // The highest bracket the user is in
                tierIncome;             // The income available for the next tier

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
                    Debug.WriteLine("The user is filing separately");
                    tierIncome = reportedIncome;

                    if (tierIncome > TIER6_SINGLE_MAX)
                    {
                        Debug.WriteLine("The user has income at tier 7");
                        topMarginalBracket++;

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
                        topMarginalBracket++;

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
                        topMarginalBracket++;

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
                        topMarginalBracket++;

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
                        topMarginalBracket++;

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
                        topMarginalBracket++;

                        tierIncome -= TIER1_SINGLE_MAX;
                        Debug.WriteLine($"We will be charging a {topMarginalBracket:P} tax on {tierIncome:C}");
                        incomeTaxOwed += tierIncome * TIER2_RATE;
                        tierIncome = TIER1_SINGLE_MAX;

                        Debug.WriteLine($"As of now they owe {incomeTaxOwed:C}");
                        Debug.WriteLine($"{tierIncome:C} is left remaining to tax");
                        Debug.WriteLine("");
                    }

                    Debug.WriteLine("The user has income at tier 1");
                    topMarginalBracket++;

                    Debug.WriteLine($"We will be charging a {topMarginalBracket:P} tax on {tierIncome:C}");
                    incomeTaxOwed += tierIncome * TIER1_RATE;
                    tierIncome = 0;

                    Debug.WriteLine($"{incomeTaxOwed:C} is the total tax");
                }
                else if (marriedJoint.Checked)
                {
                    Debug.WriteLine("The user is filing jointly");
                    tierIncome = reportedIncome;

                    if (tierIncome > TIER6_JOINT_MAX)
                    {
                        Debug.WriteLine("The user has income at tier 7");
                        topMarginalBracket++;

                        tierIncome -= TIER6_JOINT_MAX;
                        Debug.WriteLine($"We will be charging a {topMarginalBracket:P} tax on {tierIncome:C}");
                        incomeTaxOwed += tierIncome * TIER7_RATE;
                        tierIncome = TIER6_JOINT_MAX;

                        Debug.WriteLine($"As of now they owe {incomeTaxOwed:C}");
                        Debug.WriteLine($"{tierIncome:C} is left remaining to tax");
                        Debug.WriteLine("");
                    }
                    if (tierIncome >= TIER5_JOINT_MAX)
                    {
                        Debug.WriteLine("The user has income at tier 6");
                        topMarginalBracket++;

                        tierIncome -= TIER5_JOINT_MAX;
                        Debug.WriteLine($"We will be charging a {topMarginalBracket:P} tax on {tierIncome:C}");
                        incomeTaxOwed += tierIncome * TIER6_RATE;
                        tierIncome = TIER5_JOINT_MAX;

                        Debug.WriteLine($"As of now they owe {incomeTaxOwed:C}");
                        Debug.WriteLine($"{tierIncome:C} is left remaining to tax");
                        Debug.WriteLine("");
                    }
                    if (tierIncome >= TIER4_JOINT_MAX)
                    {
                        Debug.WriteLine("The user has income at tier 5");
                        topMarginalBracket++;

                        tierIncome -= TIER4_JOINT_MAX;
                        Debug.WriteLine($"We will be charging a {topMarginalBracket:P} tax on {tierIncome:C}");
                        incomeTaxOwed += tierIncome * TIER5_RATE;
                        tierIncome = TIER4_JOINT_MAX;

                        Debug.WriteLine($"As of now they owe {incomeTaxOwed:C}");
                        Debug.WriteLine($"{tierIncome:C} is left remaining to tax");
                        Debug.WriteLine("");
                    }
                    if (tierIncome >= TIER3_JOINT_MAX)
                    {
                        Debug.WriteLine("The user has income at tier 4");
                        topMarginalBracket++;

                        tierIncome -= TIER3_JOINT_MAX;
                        Debug.WriteLine($"We will be charging a {topMarginalBracket:P} tax on {tierIncome:C}");
                        incomeTaxOwed += tierIncome * TIER4_RATE;
                        tierIncome = TIER3_JOINT_MAX;

                        Debug.WriteLine($"As of now they owe {incomeTaxOwed:C}");
                        Debug.WriteLine($"{tierIncome:C} is left remaining to tax");
                        Debug.WriteLine("");
                    }
                    if (tierIncome >= TIER2_JOINT_MAX)
                    {
                        Debug.WriteLine("The user has income at tier 3");
                        topMarginalBracket++;

                        tierIncome -= TIER2_JOINT_MAX;
                        Debug.WriteLine($"We will be charging a {topMarginalBracket:P} tax on {tierIncome:C}");
                        incomeTaxOwed += tierIncome * TIER3_RATE;
                        tierIncome = TIER2_JOINT_MAX;

                        Debug.WriteLine($"As of now they owe {incomeTaxOwed:C}");
                        Debug.WriteLine($"{tierIncome:C} is left remaining to tax");
                        Debug.WriteLine("");
                    }
                    if (tierIncome >= TIER1_JOINT_MAX)
                    {
                        Debug.WriteLine("The user has income at tier 2");
                        topMarginalBracket++;

                        tierIncome -= TIER1_JOINT_MAX;
                        Debug.WriteLine($"We will be charging a {topMarginalBracket:P} tax on {tierIncome:C}");
                        incomeTaxOwed += tierIncome * TIER2_RATE;
                        tierIncome = TIER1_JOINT_MAX;

                        Debug.WriteLine($"As of now they owe {incomeTaxOwed:C}");
                        Debug.WriteLine($"{tierIncome:C} is left remaining to tax");
                        Debug.WriteLine("");
                    }

                    Debug.WriteLine("The user has income at tier 1");
                    topMarginalBracket++;

                    Debug.WriteLine($"We will be charging a {topMarginalBracket:P} tax on {tierIncome:C}");
                    incomeTaxOwed += tierIncome * TIER1_RATE;
                    tierIncome = 0;

                    Debug.WriteLine($"{incomeTaxOwed:C} is the total tax");
                    }
                else if (headOfHousehold.Checked)
                {
                    Debug.WriteLine("The user is filing as the head of the household");
                    tierIncome = reportedIncome;

                    if (tierIncome > TIER6_HEAD_MAX)
                    {
                        Debug.WriteLine("The user has income at tier 7");
                        topMarginalBracket++;

                        tierIncome -= TIER6_HEAD_MAX;
                        Debug.WriteLine($"We will be charging a {topMarginalBracket:P} tax on {tierIncome:C}");
                        incomeTaxOwed += tierIncome * TIER7_RATE;
                        tierIncome = TIER6_HEAD_MAX;

                        Debug.WriteLine($"As of now they owe {incomeTaxOwed:C}");
                        Debug.WriteLine($"{tierIncome:C} is left remaining to tax");
                        Debug.WriteLine("");
                    }
                    if (tierIncome >= TIER5_HEAD_MAX)
                    {
                        Debug.WriteLine("The user has income at tier 6");
                        topMarginalBracket++;

                        tierIncome -= TIER5_HEAD_MAX;
                        Debug.WriteLine($"We will be charging a {topMarginalBracket:P} tax on {tierIncome:C}");
                        incomeTaxOwed += tierIncome * TIER6_RATE;
                        tierIncome = TIER5_HEAD_MAX;

                        Debug.WriteLine($"As of now they owe {incomeTaxOwed:C}");
                        Debug.WriteLine($"{tierIncome:C} is left remaining to tax");
                        Debug.WriteLine("");
                    }
                    if (tierIncome >= TIER4_HEAD_MAX)
                    {
                        Debug.WriteLine("The user has income at tier 5");
                        topMarginalBracket++;

                        tierIncome -= TIER4_HEAD_MAX;
                        Debug.WriteLine($"We will be charging a {topMarginalBracket:P} tax on {tierIncome:C}");
                        incomeTaxOwed += tierIncome * TIER5_RATE;
                        tierIncome = TIER4_HEAD_MAX;

                        Debug.WriteLine($"As of now they owe {incomeTaxOwed:C}");
                        Debug.WriteLine($"{tierIncome:C} is left remaining to tax");
                        Debug.WriteLine("");
                    }
                    if (tierIncome >= TIER3_HEAD_MAX)
                    {
                        Debug.WriteLine("The user has income at tier 4");
                        topMarginalBracket++;

                        tierIncome -= TIER3_HEAD_MAX;
                        Debug.WriteLine($"We will be charging a {topMarginalBracket:P} tax on {tierIncome:C}");
                        incomeTaxOwed += tierIncome * TIER4_RATE;
                        tierIncome = TIER3_HEAD_MAX;

                        Debug.WriteLine($"As of now they owe {incomeTaxOwed:C}");
                        Debug.WriteLine($"{tierIncome:C} is left remaining to tax");
                        Debug.WriteLine("");
                    }
                    if (tierIncome >= TIER2_HEAD_MAX)
                    {
                        Debug.WriteLine("The user has income at tier 3");
                        topMarginalBracket++;

                        tierIncome -= TIER2_HEAD_MAX;
                        Debug.WriteLine($"We will be charging a {topMarginalBracket:P} tax on {tierIncome:C}");
                        incomeTaxOwed += tierIncome * TIER3_RATE;
                        tierIncome = TIER2_HEAD_MAX;

                        Debug.WriteLine($"As of now they owe {incomeTaxOwed:C}");
                        Debug.WriteLine($"{tierIncome:C} is left remaining to tax");
                        Debug.WriteLine("");
                    }
                    if (tierIncome >= TIER1_HEAD_MAX)
                    {
                        Debug.WriteLine("The user has income at tier 2");
                        topMarginalBracket++;

                        tierIncome -= TIER1_HEAD_MAX;
                        Debug.WriteLine($"We will be charging a {topMarginalBracket:P} tax on {tierIncome:C}");
                        incomeTaxOwed += tierIncome * TIER2_RATE;
                        tierIncome = TIER1_HEAD_MAX;

                        Debug.WriteLine($"As of now they owe {incomeTaxOwed:C}");
                        Debug.WriteLine($"{tierIncome:C} is left remaining to tax");
                        Debug.WriteLine("");
                    }

                    Debug.WriteLine("The user has income at tier 1");
                    topMarginalBracket++;

                    Debug.WriteLine($"We will be charging a {topMarginalBracket:P} tax on {tierIncome:C}");
                    incomeTaxOwed += tierIncome * TIER1_RATE;
                    tierIncome = 0;

                    Debug.WriteLine($"{incomeTaxOwed:C} is the total tax");
                }
                else if (marriedSeparate.Checked)
                {
                    Debug.WriteLine("The user is filing married but separately");

                    tierIncome = reportedIncome;

                    if (tierIncome > TIER6_SEPARATE_MAX)
                    {
                        Debug.WriteLine("The user has income at tier 7");
                        topMarginalBracket++;

                        tierIncome -= TIER6_SEPARATE_MAX;
                        Debug.WriteLine($"We will be charging a {topMarginalBracket:P} tax on {tierIncome:C}");
                        incomeTaxOwed += tierIncome * TIER7_RATE;
                        tierIncome = TIER6_SEPARATE_MAX;

                        Debug.WriteLine($"As of now they owe {incomeTaxOwed:C}");
                        Debug.WriteLine($"{tierIncome:C} is left remaining to tax");
                        Debug.WriteLine("");
                    }
                    if (tierIncome >= TIER5_SEPARATE_MAX)
                    {
                        Debug.WriteLine("The user has income at tier 6");
                        topMarginalBracket++;

                        tierIncome -= TIER5_SEPARATE_MAX;
                        Debug.WriteLine($"We will be charging a {topMarginalBracket:P} tax on {tierIncome:C}");
                        incomeTaxOwed += tierIncome * TIER6_RATE;
                        tierIncome = TIER5_SEPARATE_MAX;

                        Debug.WriteLine($"As of now they owe {incomeTaxOwed:C}");
                        Debug.WriteLine($"{tierIncome:C} is left remaining to tax");
                        Debug.WriteLine("");
                    }
                    if (tierIncome >= TIER4_SEPARATE_MAX)
                    {
                        Debug.WriteLine("The user has income at tier 5");
                        topMarginalBracket++;

                        tierIncome -= TIER4_SEPARATE_MAX;
                        Debug.WriteLine($"We will be charging a {topMarginalBracket:P} tax on {tierIncome:C}");
                        incomeTaxOwed += tierIncome * TIER5_RATE;
                        tierIncome = TIER4_SEPARATE_MAX;

                        Debug.WriteLine($"As of now they owe {incomeTaxOwed:C}");
                        Debug.WriteLine($"{tierIncome:C} is left remaining to tax");
                        Debug.WriteLine("");
                    }
                    if (tierIncome >= TIER3_SEPARATE_MAX)
                    {
                        Debug.WriteLine("The user has income at tier 4");
                        topMarginalBracket++;

                        tierIncome -= TIER3_SEPARATE_MAX;
                        Debug.WriteLine($"We will be charging a {topMarginalBracket:P} tax on {tierIncome:C}");
                        incomeTaxOwed += tierIncome * TIER4_RATE;
                        tierIncome = TIER3_SEPARATE_MAX;

                        Debug.WriteLine($"As of now they owe {incomeTaxOwed:C}");
                        Debug.WriteLine($"{tierIncome:C} is left remaining to tax");
                        Debug.WriteLine("");
                    }
                    if (tierIncome >= TIER2_SEPARATE_MAX)
                    {
                        Debug.WriteLine("The user has income at tier 3");
                        topMarginalBracket++;

                        tierIncome -= TIER2_SEPARATE_MAX;
                        Debug.WriteLine($"We will be charging a {topMarginalBracket:P} tax on {tierIncome:C}");
                        incomeTaxOwed += tierIncome * TIER3_RATE;
                        tierIncome = TIER2_SEPARATE_MAX;

                        Debug.WriteLine($"As of now they owe {incomeTaxOwed:C}");
                        Debug.WriteLine($"{tierIncome:C} is left remaining to tax");
                        Debug.WriteLine("");
                    }
                    if (tierIncome >= TIER1_SEPARATE_MAX)
                    {
                        Debug.WriteLine("The user has income at tier 2");
                        topMarginalBracket++;

                        tierIncome -= TIER1_SEPARATE_MAX;
                        Debug.WriteLine($"We will be charging a {topMarginalBracket:P} tax on {tierIncome:C}");
                        incomeTaxOwed += tierIncome * TIER2_RATE;
                        tierIncome = TIER1_SEPARATE_MAX;

                        Debug.WriteLine($"As of now they owe {incomeTaxOwed:C}");
                        Debug.WriteLine($"{tierIncome:C} is left remaining to tax");
                        Debug.WriteLine("");
                    }

                    Debug.WriteLine("The user has income at tier 1");
                    topMarginalBracket++;

                    Debug.WriteLine($"We will be charging a {topMarginalBracket:P} tax on {tierIncome:C}");
                    incomeTaxOwed += tierIncome * TIER1_RATE;
                    tierIncome = 0;

                    Debug.WriteLine($"{incomeTaxOwed:C} is the total tax");
                }

                Debug.WriteLine($"Our tax level is {topMarginalBracket}");
                if (topMarginalBracket == 7)
                    bracketRate = TIER7_RATE;
                else if (topMarginalBracket == 6)
                    bracketRate = TIER6_RATE;
                else if (topMarginalBracket == 5)
                    bracketRate = TIER5_RATE;
                else if (topMarginalBracket == 4)
                    bracketRate = TIER4_RATE;
                else if (topMarginalBracket == 3)
                    bracketRate = TIER3_RATE;
                else if (topMarginalBracket == 2)
                    bracketRate = TIER2_RATE;
                else if (topMarginalBracket == 1)
                    bracketRate = TIER1_RATE;

                taxOwed.Text = incomeTaxOwed.ToString("C");
                taxRate.Text = bracketRate.ToString("P0");

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
