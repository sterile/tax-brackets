/*
 * Grading ID: M5477
 * Program: 2
 * Due Date: Mar 5 2019
 * Course Section: 01
 * Description: This program determines a users marginal tax rate and the amount due.
 */

using System;
using System.Windows.Forms;

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
                if (single.Checked)
                {
                    tierIncome = reportedIncome;

                    if (tierIncome > TIER6_SINGLE_MAX)
                    {
                        topMarginalBracket++;

                        tierIncome -= TIER6_SINGLE_MAX;
                        incomeTaxOwed += tierIncome * TIER7_RATE;
                        tierIncome = TIER6_SINGLE_MAX;
                    }
                    if (tierIncome >= TIER5_SINGLE_MAX)
                    {
                        topMarginalBracket++;

                        tierIncome -= TIER5_SINGLE_MAX;

                        incomeTaxOwed += tierIncome * TIER6_RATE;
                        tierIncome = TIER5_SINGLE_MAX;
                    }
                    if (tierIncome >= TIER4_SINGLE_MAX)
                    {
                        topMarginalBracket++;

                        tierIncome -= TIER4_SINGLE_MAX;

                        incomeTaxOwed += tierIncome * TIER5_RATE;
                        tierIncome = TIER4_SINGLE_MAX;
                    }
                    if (tierIncome >= TIER3_SINGLE_MAX)
                    {
                        topMarginalBracket++;

                        tierIncome -= TIER3_SINGLE_MAX;

                        incomeTaxOwed += tierIncome * TIER4_RATE;
                        tierIncome = TIER3_SINGLE_MAX;
                    }
                    if (tierIncome >= TIER2_SINGLE_MAX)
                    {
                        topMarginalBracket++;

                        tierIncome -= TIER2_SINGLE_MAX;

                        incomeTaxOwed += tierIncome * TIER3_RATE;
                        tierIncome = TIER2_SINGLE_MAX;
                    }
                    if (tierIncome >= TIER1_SINGLE_MAX)
                    {
                        topMarginalBracket++;

                        tierIncome -= TIER1_SINGLE_MAX;

                        incomeTaxOwed += tierIncome * TIER2_RATE;
                        tierIncome = TIER1_SINGLE_MAX;
                    }

                    topMarginalBracket++;

                    incomeTaxOwed += tierIncome * TIER1_RATE;
                    tierIncome = 0;
                }
                else if (marriedJoint.Checked)
                {
                    tierIncome = reportedIncome;

                    if (tierIncome > TIER6_JOINT_MAX)
                    {
                        topMarginalBracket++;

                        tierIncome -= TIER6_JOINT_MAX;

                        incomeTaxOwed += tierIncome * TIER7_RATE;
                        tierIncome = TIER6_JOINT_MAX;
                    }
                    if (tierIncome >= TIER5_JOINT_MAX)
                    {
                        topMarginalBracket++;

                        tierIncome -= TIER5_JOINT_MAX;

                        incomeTaxOwed += tierIncome * TIER6_RATE;
                        tierIncome = TIER5_JOINT_MAX;
                    }
                    if (tierIncome >= TIER4_JOINT_MAX)
                    {
                        topMarginalBracket++;

                        tierIncome -= TIER4_JOINT_MAX;

                        incomeTaxOwed += tierIncome * TIER5_RATE;
                        tierIncome = TIER4_JOINT_MAX;
                    }
                    if (tierIncome >= TIER3_JOINT_MAX)
                    {
                        topMarginalBracket++;

                        tierIncome -= TIER3_JOINT_MAX;

                        incomeTaxOwed += tierIncome * TIER4_RATE;
                        tierIncome = TIER3_JOINT_MAX;
                    }
                    if (tierIncome >= TIER2_JOINT_MAX)
                    {
                        topMarginalBracket++;

                        tierIncome -= TIER2_JOINT_MAX;

                        incomeTaxOwed += tierIncome * TIER3_RATE;
                        tierIncome = TIER2_JOINT_MAX;
                    }
                    if (tierIncome >= TIER1_JOINT_MAX)
                    {
                        topMarginalBracket++;

                        tierIncome -= TIER1_JOINT_MAX;

                        incomeTaxOwed += tierIncome * TIER2_RATE;
                        tierIncome = TIER1_JOINT_MAX;
                    }

                    topMarginalBracket++;

                    incomeTaxOwed += tierIncome * TIER1_RATE;
                    tierIncome = 0;
                }
                else if (headOfHousehold.Checked)
                {
                    tierIncome = reportedIncome;

                    if (tierIncome > TIER6_HEAD_MAX)
                    {
                        topMarginalBracket++;

                        tierIncome -= TIER6_HEAD_MAX;

                        incomeTaxOwed += tierIncome * TIER7_RATE;
                        tierIncome = TIER6_HEAD_MAX;
                    }
                    if (tierIncome >= TIER5_HEAD_MAX)
                    {
                        topMarginalBracket++;

                        tierIncome -= TIER5_HEAD_MAX;

                        incomeTaxOwed += tierIncome * TIER6_RATE;
                        tierIncome = TIER5_HEAD_MAX;
                    }
                    if (tierIncome >= TIER4_HEAD_MAX)
                    {
                        topMarginalBracket++;

                        tierIncome -= TIER4_HEAD_MAX;

                        incomeTaxOwed += tierIncome * TIER5_RATE;
                        tierIncome = TIER4_HEAD_MAX;
                    }
                    if (tierIncome >= TIER3_HEAD_MAX)
                    {
                        topMarginalBracket++;

                        tierIncome -= TIER3_HEAD_MAX;

                        incomeTaxOwed += tierIncome * TIER4_RATE;
                        tierIncome = TIER3_HEAD_MAX;
                    }
                    if (tierIncome >= TIER2_HEAD_MAX)
                    {
                        topMarginalBracket++;

                        tierIncome -= TIER2_HEAD_MAX;

                        incomeTaxOwed += tierIncome * TIER3_RATE;
                        tierIncome = TIER2_HEAD_MAX;
                    }
                    if (tierIncome >= TIER1_HEAD_MAX)
                    {
                        topMarginalBracket++;

                        tierIncome -= TIER1_HEAD_MAX;

                        incomeTaxOwed += tierIncome * TIER2_RATE;
                        tierIncome = TIER1_HEAD_MAX;
                    }

                    topMarginalBracket++;

                    incomeTaxOwed += tierIncome * TIER1_RATE;
                    tierIncome = 0;
                }
                else if (marriedSeparate.Checked)
                {
                    tierIncome = reportedIncome;

                    if (tierIncome > TIER6_SEPARATE_MAX)
                    {
                        topMarginalBracket++;

                        tierIncome -= TIER6_SEPARATE_MAX;

                        incomeTaxOwed += tierIncome * TIER7_RATE;
                        tierIncome = TIER6_SEPARATE_MAX;
                    }
                    if (tierIncome >= TIER5_SEPARATE_MAX)
                    {
                        topMarginalBracket++;

                        tierIncome -= TIER5_SEPARATE_MAX;

                        incomeTaxOwed += tierIncome * TIER6_RATE;
                        tierIncome = TIER5_SEPARATE_MAX;
                    }
                    if (tierIncome >= TIER4_SEPARATE_MAX)
                    {
                        topMarginalBracket++;

                        tierIncome -= TIER4_SEPARATE_MAX;

                        incomeTaxOwed += tierIncome * TIER5_RATE;
                        tierIncome = TIER4_SEPARATE_MAX;
                    }
                    if (tierIncome >= TIER3_SEPARATE_MAX)
                    {
                        topMarginalBracket++;

                        tierIncome -= TIER3_SEPARATE_MAX;

                        incomeTaxOwed += tierIncome * TIER4_RATE;
                        tierIncome = TIER3_SEPARATE_MAX;
                    }
                    if (tierIncome >= TIER2_SEPARATE_MAX)
                    {
                        topMarginalBracket++;

                        tierIncome -= TIER2_SEPARATE_MAX;

                        incomeTaxOwed += tierIncome * TIER3_RATE;
                        tierIncome = TIER2_SEPARATE_MAX;
                    }
                    if (tierIncome >= TIER1_SEPARATE_MAX)
                    {
                        topMarginalBracket++;

                        tierIncome -= TIER1_SEPARATE_MAX;

                        incomeTaxOwed += tierIncome * TIER2_RATE;
                        tierIncome = TIER1_SEPARATE_MAX;
                    }

                    topMarginalBracket++;

                    incomeTaxOwed += tierIncome * TIER1_RATE;
                    tierIncome = 0;
                }

                if (topMarginalBracket == 7)
                {
                    bracketRate = TIER7_RATE;
                }
                else if (topMarginalBracket == 6)
                {
                    bracketRate = TIER6_RATE;
                }
                else if (topMarginalBracket == 5)
                {
                    bracketRate = TIER5_RATE;
                }
                else if (topMarginalBracket == 4)
                {
                    bracketRate = TIER4_RATE;
                }
                else if (topMarginalBracket == 3)
                {
                    bracketRate = TIER3_RATE;
                }
                else if (topMarginalBracket == 2)
                {
                    bracketRate = TIER2_RATE;
                }
                else if (topMarginalBracket == 1)
                {
                    bracketRate = TIER1_RATE;
                }

                taxOwed.Text = incomeTaxOwed.ToString("C");
                taxRate.Text = bracketRate.ToString("P0");
            }
            else
            {
                MessageBox.Show("There was an error processing your taxes. Please ensure your income is reported in whole dollars and try again.",
                    "Form Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
