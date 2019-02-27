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
            const int TIER1_SINGLE_MAX = 9700, // The highest dollar amount for someone filing as a single in tier 1.
                TIER2_SINGLE_MAX = 39475,      // The highest dollar amount for someone filing as a single in tier 2.
                TIER3_SINGLE_MAX = 84200,      // The highest dollar amount for someone filing as a single in tier 3.
                TIER4_SINGLE_MAX = 160725,     // The highest dollar amount for someone filing as a single in tier 4.
                TIER5_SINGLE_MAX = 204100,     // The highest dollar amount for someone filing as a single in tier 5.
                TIER6_SINGLE_MAX = 510300,     // The highest dollar amount for someone filing as a single in tier 6.

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

            int topMarginalBracket, // The highest bracket the user is in
                incomeTaxOwed,      // The money owed to Uncle Sam
                reportedIncome;     // The income reported by the user

            bool incomeValid; // Our user entered a valid income
            incomeValid = int.TryParse(income.Text, out reportedIncome);

            if (incomeValid)
            {
                // Logic that will eventually happen...
            }
            else
            {
                MessageBox.Show("There was an error processing your taxes. Please ensure your income is reported in whole dollars and try again.",
                    "Form Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
