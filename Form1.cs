using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace printer_application
{
    public partial class Form1 : Form
    {
        int i_FileColomTot, i_FileRowTot, i_FileValueTot;
        string s_userChoice;
        string[] as_ContentRow;
        string[] as_ContentTot;
        Color s_Color = Color.Black;
        public Form1()
        {
            InitializeComponent();
            Cbx_FileNames.Items.Add("mario (colour)");
            Cbx_FileNames.Items.Add("vault boy");
            Cbx_FileNames.Items.Add("evil vault boy");
            Cbx_FileNames.Items.Add("kurby (colour)");
            Cbx_FileNames.Items.Add("link");

        }

        private void Btt_clear_Click(object sender, EventArgs e)
        {
            for (int i_countRow = 0; i_countRow < 23; i_countRow++)
            {
                for (int i_countColom = 0; i_countColom < 23; i_countColom++)
                {
                    this.Tab_printboard.GetControlFromPosition(i_countColom, i_countRow).BackColor = Color.White;
                }
            }
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(Cbx_FileNames.Text))
            {

                s_userChoice = Cbx_FileNames.Text;

                try
                {
                    as_ContentRow = System.IO.File.ReadAllLines(s_userChoice + ".csv");
                    as_ContentTot = System.IO.File.ReadAllText(s_userChoice + ".csv").Split(',');
                }
                catch
                {
                    Lbl_error.Text = "Error no such file, please try again";
                }

                // collom is vert and row is horoz

                i_FileRowTot = as_ContentRow.Length;
                i_FileValueTot = as_ContentTot.Length;
                i_FileColomTot = i_FileValueTot / i_FileRowTot;
                string[,] as_File = new string[i_FileRowTot, i_FileColomTot]; //row,colum    as_file is the .csv file reconstruct as on sting array in program
                int i_count = 0;

                for (int i_countRow = 0; i_countRow < i_FileRowTot; i_countRow++)
                {
                    for (int i_countColom = 0; i_countColom < i_FileRowTot; i_countColom++)
                    {
                        as_File[i_countColom, i_countRow] = as_ContentTot[i_count];
                        i_count++;
                    }
                }

                int i_PrintCheck;
                for (int i_countRow = 0; i_countRow < i_FileRowTot; i_countRow++)
                {
                    for (int i_countColom = 0; i_countColom < i_FileRowTot; i_countColom++)
                    {
                        i_PrintCheck = Convert.ToInt16(as_File[i_countColom, i_countRow]);
                        switch (i_PrintCheck)
                        {
                            case 1:
                                s_Color = Color.PeachPuff;
                                break;
                            case 2:
                                s_Color = Color.Yellow;
                                break;
                            case 3:
                                s_Color = Color.Red;
                                break;
                            case 4:
                                s_Color = Color.Brown;
                                break;
                            case 5:
                                s_Color = Color.Black;
                                break;
                            case 6:
                                s_Color = Color.Blue;
                                break;
                            case 7:
                                s_Color = Color.LightPink;
                                break;
                            case 8:
                                s_Color = Color.HotPink;
                                break;
                            case 9:
                                s_Color = Color.Green;
                                break;
                            case 0:
                                s_Color = Color.White;
                                break;

                        }
                        this.Tab_printboard.GetControlFromPosition(i_countColom, i_countRow).BackColor = s_Color;
                    }
                }
            }
            else { Lbl_error.Text = Lbl_error.Text = "Error no file selected, please try again"; }
        }
    }
}
