/*
 * Grading ID: M5477
 * Program: 2
 * Due Date: Mar 7 2019
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

                TIER1_SEPARATE_MAX = 9700,   // The highest dollar amount for someone filing separately in tier 1.
                TIER2_SEPARATE_MAX = 39475,  // The highest dollar amount for someone filing separately in tier 2.
                TIER3_SEPARATE_MAX = 84200,  // The highest dollar amount for someone filing separately in tier 3.
                TIER4_SEPARATE_MAX = 160725, // The highest dollar amount for someone filing separately in tier 4.
                TIER5_SEPARATE_MAX = 204100, // The highest dollar amount for someone filing separately in tier 5.
                TIER6_SEPARATE_MAX = 306175; // The highest dollar amount for someone filing seperately in tier 6.

            const double TIER1_RATE = .1, // The 2019 tax rate for tier 1.
                TIER2_RATE = .12,         // The 2019 tax rate for tier 2.
                TIER3_RATE = .22,         // The 2019 tax rate for tier 3.
                TIER4_RATE = .24,         // The 2019 tax rate for tier 4.
                TIER5_RATE = .32,         // The 2019 tax rate for tier 5.
                TIER6_RATE = .35,         // The 2019 tax rate for tier 6.
                TIER7_RATE = .37;         // The 2019 tax rate for tier 7.

            double bracketRate = 0, // The highest bracket percentage rate
                incomeTaxOwed = 0;  // The money owed to Uncle Sam

            uint reportedIncome, // The income reported by the user
                
                declaredMargin1 = 0, // The highest income for the marginal bracket 1.
                declaredMargin2 = 0, // The highest income for the marginal bracket 2.
                declaredMargin3 = 0, // The highest income for the marginal bracket 3.
                declaredMargin4 = 0, // The highest income for the marginal bracket 4.
                declaredMargin5 = 0, // The highest income for the marginal bracket 5.
                declaredMargin6 = 0; // The highest income for the marginal bracket 6.

            bool incomeValid; // (Hopefully) our user entered a valid income
            incomeValid = uint.TryParse(income.Text, out reportedIncome);

            if (incomeValid)
            {
                if (single.Checked)
                {
                    declaredMargin1 = TIER1_SINGLE_MAX;
                    declaredMargin2 = TIER2_SINGLE_MAX;
                    declaredMargin3 = TIER3_SINGLE_MAX;
                    declaredMargin4 = TIER4_SINGLE_MAX;
                    declaredMargin5 = TIER5_SINGLE_MAX;
                    declaredMargin6 = TIER6_SINGLE_MAX;
                }
                else if (marriedJoint.Checked) {
                    declaredMargin1 = TIER1_JOINT_MAX;
                    declaredMargin2 = TIER2_JOINT_MAX;
                    declaredMargin3 = TIER3_JOINT_MAX;
                    declaredMargin4 = TIER4_JOINT_MAX;
                    declaredMargin5 = TIER5_JOINT_MAX;
                    declaredMargin6 = TIER6_JOINT_MAX;
                }
                else if (headOfHousehold.Checked) {
                    declaredMargin1 = TIER1_HEAD_MAX;
                    declaredMargin2 = TIER2_HEAD_MAX;
                    declaredMargin3 = TIER3_HEAD_MAX;
                    declaredMargin4 = TIER4_HEAD_MAX;
                    declaredMargin5 = TIER5_HEAD_MAX;
                    declaredMargin6 = TIER6_HEAD_MAX;
                }
                else if (marriedSeparate.Checked) {
                    declaredMargin1 = TIER1_SEPARATE_MAX;
                    declaredMargin2 = TIER2_SEPARATE_MAX;
                    declaredMargin3 = TIER3_SEPARATE_MAX;
                    declaredMargin4 = TIER4_SEPARATE_MAX;
                    declaredMargin5 = TIER5_SEPARATE_MAX;
                    declaredMargin6 = TIER6_SEPARATE_MAX;
                }

                if (reportedIncome <= declaredMargin1) {
                    incomeTaxOwed += reportedIncome * TIER1_RATE;
                    bracketRate = TIER1_RATE;
                }
                if (reportedIncome <= declaredMargin2) {
                    incomeTaxOwed += (reportedIncome - declaredMargin1) * TIER2_RATE;
                    bracketRate = TIER2_RATE;
                }
                if (reportedIncome <= declaredMargin3) {
                    incomeTaxOwed += (reportedIncome - declaredMargin2) * TIER3_RATE;
                    bracketRate = TIER3_RATE;
                }
                if (reportedIncome <= declaredMargin4) {
                    incomeTaxOwed += (reportedIncome - declaredMargin3) * TIER4_RATE;
                    bracketRate = TIER4_RATE;
                }
                if (reportedIncome <= declaredMargin5) {
                    incomeTaxOwed += (reportedIncome - declaredMargin4) * TIER5_RATE;
                    bracketRate = TIER5_RATE;
                }
                if (reportedIncome <= declaredMargin6) {
                    incomeTaxOwed += (reportedIncome - declaredMargin5) * TIER6_RATE;
                    bracketRate = TIER6_RATE;
                }
                if (reportedIncome > declaredMargin6) {
                    incomeTaxOwed += (reportedIncome - declaredMargin6) * TIER7_RATE;
                    bracketRate = TIER7_RATE;
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