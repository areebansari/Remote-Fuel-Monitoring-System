using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WSMBS;
namespace FuelMonitoring
{
    public partial class FrmDataView : Form
    {
        static int countdown = 10;
        static System.Timers.Timer timer;

        GenralStorage GS = new GenralStorage();
        string subst, PrvRS, PrvKG, Rate, FillCount;
        string Time;
        int RT, NRT, RTB, NRTB;
        int i2 = 0;
        int i = 0;
        int[] FC1 = new int[16];
        int[] FC2 = new int[16];
        int FCDB1, FCDB2;
        int C2;

        int[] counter = new int[16];
        decimal TA1, TA2, TB1, TB2, TNA1, TNA2, TNB1, TNB2;
        int tempval, tempvalh;
        string WSMBS_KEY = "70AB-9CE4-736B-7DD4-174F-3417";
        static Timer _timer; // From System.Timers
        static List<DateTime> _l; // Stores timer results
        
        public FrmDataView()
        {
            InitializeComponent();
            timer = new System.Timers.Timer(1000);
            // Make it repeat. Setting this to false will cause just one event.
            timer.AutoReset = true;
            // Assign the delegate method.
          
            // Start the timer.
            timer.Start();

        }
        //+++++++++++++++++++++++++
        //SIDE------ONE-----START
        //+++++++++++++++++++++++++
        void ReadRegData()
        {

            Int16[] Registers = new Int16[20];
            WSMBS.Result Result;
            Result = wsmbsControl1.ReadHoldingRegisters(1, 0, 20, Registers);
            //if (Result != WSMBS.Result.SUCCESS)
            //{

            //    // chkside1.Checked = false;
            //    ReadRegDataSide2();
            //    // MessageBox.Show(wsmbsControl1.GetLastErrorString());   
            //}



            string hex = Convert.ToString(Registers[0]);

            Int16 val0 = Convert.ToInt16(Registers[0]);

            Int16 val1 = Convert.ToInt16(Registers[1]);
            Int16 val2 = Convert.ToInt16(Registers[2]);
            Int16 val3 = Convert.ToInt16(Registers[3]);
            Int16 val4 = Convert.ToInt16(Registers[4]);
            Int16 val5 = Convert.ToInt16(Registers[5]);
            Int16 val6 = Convert.ToInt16(Registers[6]);
            Int16 val7 = Convert.ToInt16(Registers[7]);
            Int16 val8 = Convert.ToInt16(Registers[8]);
            Int16 val9 = Convert.ToInt16(Registers[9]);
            Int16 val10 = Convert.ToInt16(Registers[10]);
            Int16 val11 = Convert.ToInt16(Registers[11]);
            Int16 val12 = Convert.ToInt16(Registers[12]);
            Int16 val13 = Convert.ToInt16(Registers[13]);
            Int16 val14 = Convert.ToInt16(Registers[14]);
            Int16 val15 = Convert.ToInt16(Registers[15]);
            Int16 val16 = Convert.ToInt16(Registers[16]);
            Int16 val17 = Convert.ToInt16(Registers[17]);
            Int16 val18 = Convert.ToInt16(Registers[18]);
            Int16 val19 = Convert.ToInt16(Registers[19]);

            if (counter[0] == 0)
            {
                FC1[0] = val16;
                FC2[0] = val18;
                FCDB1 = val16;
                FCDB2 = val18;

                //lbl

                counter[0] += 1;
            }


            //string str = System.Uri.HexEscape((char)64);
            //MessageBox.Show(str); // this will show as %40  (  which is the way hex would show in web urls  ) 
            // to show without the %  ,  the following line would apply  .  .  . 
            //MessageBox.Show(str.Substring(1));
            //For Val0
            string hexval = "";
            string[] myArray;

            if (val0 != null && val1 != null && val2 != null && val3 != null)
            {
                i = 0;
                i2 = 0;

                hexval = val0.ToString("X");
                if (hexval.Length == 3)
                {
                    hexval = "0" + hexval;
                }
                if (hexval.Length == 2)
                {
                    hexval = "00" + hexval;
                }
                if (hexval.Length == 1)
                {
                    hexval = "000" + hexval;
                }
                subst = hexval.Substring(2, 2);
                subst += hexval.Substring(0, 2);
                hexval = subst;
                subst = "";
                myArray = new string[hexval.Length];
                for (i = hexval.Length - 1; i2 < 4; i--)
                {

                    myArray[i] = hexval[i].ToString();

                    i2++;
                }
                if (myArray[hexval.Length - 4] == "A" || myArray[hexval.Length - 4] == "B" || myArray[hexval.Length - 4] == "C" || myArray[hexval.Length - 4] == "D" || myArray[hexval.Length - 4] == "E" || myArray[hexval.Length - 4] == "F")
                {

                    GS.reg3 = "";
                }
                else
                {
                    GS.reg3 = myArray[hexval.Length - 4].ToString();
                }
                if (myArray[hexval.Length - 3] == "A" || myArray[hexval.Length - 3] == "B" || myArray[hexval.Length - 3] == "C" || myArray[hexval.Length - 3] == "D" || myArray[hexval.Length - 3] == "E" || myArray[hexval.Length - 3] == "F")
                {
                    GS.reg2 = "";
                }
                else
                {
                    GS.reg2 = myArray[hexval.Length - 3].ToString();
                }

                if (myArray[hexval.Length - 2] == "A" || myArray[hexval.Length - 2] == "B" || myArray[hexval.Length - 2] == "C" || myArray[hexval.Length - 2] == "D" || myArray[hexval.Length - 2] == "E" || myArray[hexval.Length - 2] == "F")
                {
                    GS.reg1 = "";
                }
                else
                {
                    GS.reg1 = myArray[hexval.Length - 2].ToString();
                }


                if (myArray[hexval.Length - 1] == "A" || myArray[hexval.Length - 1] == "B" || myArray[hexval.Length - 1] == "C" || myArray[hexval.Length - 1] == "D" || myArray[hexval.Length - 1] == "E" || myArray[hexval.Length - 1] == "F")
                {
                    GS.reg0 = "";
                }
                else
                {
                    GS.reg0 = myArray[hexval.Length - 1].ToString();
                }

                // For Val1
                i = 0;
                i2 = 0;
                hexval = val1.ToString("X");
                if (hexval.Length == 3)
                {
                    hexval = "0" + hexval;
                }
                if (hexval.Length == 2)
                {
                    hexval = "00" + hexval;
                }
                if (hexval.Length == 1)
                {
                    hexval = "000" + hexval;
                }
                subst = hexval.Substring(2, 2);
                subst += hexval.Substring(0, 2);
                hexval = subst;
                subst = "";
                myArray = new string[hexval.Length];

                for (i = hexval.Length - 1; i2 < 4; i--)
                {

                    myArray[i] = hexval[i].ToString();

                    i2++;
                }
                if (myArray[hexval.Length - 4] == "A" || myArray[hexval.Length - 4] == "B" || myArray[hexval.Length - 4] == "C" || myArray[hexval.Length - 4] == "D" || myArray[hexval.Length - 4] == "E" || myArray[hexval.Length - 4] == "F")
                {
                    GS.reg7 = "";
                }
                else
                {
                    GS.reg7 = myArray[hexval.Length - 4].ToString();
                }
                if (myArray[hexval.Length - 3] == "A" || myArray[hexval.Length - 3] == "B" || myArray[hexval.Length - 3] == "C" || myArray[hexval.Length - 3] == "D" || myArray[hexval.Length - 3] == "E" || myArray[hexval.Length - 3] == "F")
                {
                    GS.reg6 = "";
                }
                else
                {
                    GS.reg6 = myArray[hexval.Length - 3].ToString();
                }

                if (myArray[hexval.Length - 2] == "A" || myArray[hexval.Length - 2] == "B" || myArray[hexval.Length - 2] == "C" || myArray[hexval.Length - 2] == "D" || myArray[hexval.Length - 2] == "E" || myArray[hexval.Length - 2] == "F")
                {
                    GS.reg5 = "";
                }
                else
                {
                    GS.reg5 = myArray[hexval.Length - 2].ToString();
                }


                if (myArray[hexval.Length - 1] == "A" || myArray[hexval.Length - 1] == "B" || myArray[hexval.Length - 1] == "C" || myArray[hexval.Length - 1] == "D" || myArray[hexval.Length - 1] == "E" || myArray[hexval.Length - 1] == "F")
                {
                    GS.reg4 = "";
                }
                else
                {
                    GS.reg4 = myArray[hexval.Length - 1].ToString();
                }


                //For Val2
                i = 0;
                i2 = 0;
                hexval = val2.ToString("X");
                if (hexval.Length == 3)
                {
                    hexval = "0" + hexval;
                }
                if (hexval.Length == 2)
                {
                    hexval = "00" + hexval;
                }
                if (hexval.Length == 1)
                {
                    hexval = "000" + hexval;
                }
                subst = hexval.Substring(2, 2);
                subst += hexval.Substring(0, 2);
                hexval = subst;
                subst = "";
                myArray = new string[hexval.Length];

                for (i = hexval.Length - 1; i2 < 4; i--)
                {

                    myArray[i] = hexval[i].ToString();

                    i2++;
                }

                if (myArray[hexval.Length - 4] == "A" || myArray[hexval.Length - 4] == "B" || myArray[hexval.Length - 4] == "C" || myArray[hexval.Length - 4] == "D" || myArray[hexval.Length - 4] == "E" || myArray[hexval.Length - 4] == "F")
                {
                    GS.reg11 = "";
                }
                else
                {
                    GS.reg11 = myArray[hexval.Length - 4].ToString();
                }
                if (myArray[hexval.Length - 3] == "A" || myArray[hexval.Length - 3] == "B" || myArray[hexval.Length - 3] == "C" || myArray[hexval.Length - 3] == "D" || myArray[hexval.Length - 3] == "E" || myArray[hexval.Length - 3] == "F")
                {
                    GS.reg10 = "";
                }
                else
                {
                    GS.reg10 = myArray[hexval.Length - 3].ToString();
                }

                if (myArray[hexval.Length - 2] == "A" || myArray[hexval.Length - 2] == "B" || myArray[hexval.Length - 2] == "C" || myArray[hexval.Length - 2] == "D" || myArray[hexval.Length - 2] == "E" || myArray[hexval.Length - 2] == "F")
                {
                    GS.reg9 = "";
                }
                else
                {
                    GS.reg9 = myArray[hexval.Length - 2].ToString();
                }


                if (myArray[hexval.Length - 1] == "A" || myArray[hexval.Length - 1] == "B" || myArray[hexval.Length - 1] == "C" || myArray[hexval.Length - 1] == "D" || myArray[hexval.Length - 1] == "E" || myArray[hexval.Length - 1] == "F")
                {
                    GS.reg8 = "";
                }
                else
                {
                    GS.reg8 = myArray[hexval.Length - 1].ToString();
                }

                //For Val3
                i = 0;
                i2 = 0;
                hexval = val3.ToString("X");
                if (hexval.Length == 3)
                {
                    hexval = "0" + hexval;
                }
                if (hexval.Length == 2)
                {
                    hexval = "00" + hexval;
                }
                if (hexval.Length == 1)
                {
                    hexval = "000" + hexval;
                }
                subst = hexval.Substring(2, 2);
                subst += hexval.Substring(0, 2);
                hexval = subst;
                subst = "";
                myArray = new string[hexval.Length];

                for (i = hexval.Length - 1; i2 < 4; i--)
                {

                    myArray[i] = hexval[i].ToString();

                    i2++;
                }


                if (myArray[hexval.Length - 4] == "A" || myArray[hexval.Length - 4] == "B" || myArray[hexval.Length - 4] == "C" || myArray[hexval.Length - 4] == "D" || myArray[hexval.Length - 4] == "E" || myArray[hexval.Length - 4] == "F")
                {
                    GS.reg15 = "";
                }
                else
                {
                    GS.reg15 = myArray[hexval.Length - 4].ToString();
                }
                if (myArray[hexval.Length - 3] == "A" || myArray[hexval.Length - 3] == "B" || myArray[hexval.Length - 3] == "C" || myArray[hexval.Length - 3] == "D" || myArray[hexval.Length - 3] == "E" || myArray[hexval.Length - 3] == "F")
                {
                    GS.reg14 = "";
                }
                else
                {
                    GS.reg4 = myArray[hexval.Length - 3].ToString();
                }

                if (myArray[hexval.Length - 2] == "A" || myArray[hexval.Length - 2] == "B" || myArray[hexval.Length - 2] == "C" || myArray[hexval.Length - 2] == "D" || myArray[hexval.Length - 2] == "E" || myArray[hexval.Length - 2] == "F")
                {
                    GS.reg13 = "";
                }
                else
                {
                    GS.reg13 = myArray[hexval.Length - 2].ToString();
                }


                if (myArray[hexval.Length - 1] == "A" || myArray[hexval.Length - 1] == "B" || myArray[hexval.Length - 1] == "C" || myArray[hexval.Length - 1] == "D" || myArray[hexval.Length - 1] == "E" || myArray[hexval.Length - 1] == "F")
                {
                    GS.reg12 = "";
                }
                else
                {
                    GS.reg12 = myArray[hexval.Length - 1].ToString();
                }
                GS.priceA = GS.reg13 + "" + GS.reg12 + "" + GS.reg15 + "" + GS.reg5 + "." + GS.reg6 + "" + GS.reg7;
                //lblPrice1A.Text = GS.priceA;
                DGFM.Rows[0].Cells[2].Value = GS.priceA;
                GS.KGA = GS.reg14 + "" + GS.reg9 + "" + GS.reg8 + "" + GS.reg1 + "." + GS.reg3 + "" + GS.reg4;
                DGFM.Rows[0].Cells[3].Value = GS.KGA;

                GS.RateA = GS.reg10 + "" + GS.reg11 + "." + GS.reg2 + "" + GS.reg0;
                DGFM.Rows[0].Cells[4].Value = GS.RateA;
                //Val8,9x

                if (val8 < 0)
                {
                    tempval = (val8 + 65535);


                }

                if (tempval > 0)
                {
                    RT = (65536 * val9) + tempval;
                }
                else
                {
                    RT = (65536 * val9) + val8;
                }
                tempval = 0;
                TA1 = Convert.ToDecimal(RT);
                TA2 = TA1 / 100;
                DGFM.Rows[0].Cells[6].Value = Convert.ToString(TA2);


                if (val10 < 0)
                {

                    //val10 += Convert.ToInt16(65535);
                    tempval = (val10 + 65536);

                }
                if (val11 < 0)
                {
                    val11 += Convert.ToInt16(65536);
                }


                if (tempval > 0)
                {
                    NRT = (65536 * val11) + tempval;
                }
                else
                {
                    NRT = (65536 * val11) + val10;
                }
                tempval = 0;

                TNA1 = Convert.ToDecimal(NRT);
                TNA2 = TNA1 / 100;
                DGFM.Rows[0].Cells[5].Value = Convert.ToString(TNA2);


                // lblFCA1.Text = Convert.ToString(val16);
                PrvKG = "0";
                PrvRS = "0";
                Time = "0";
                Rate = "0";
                FillCount = "0";
                selectperviousrecord("1-A");
                DGFM.Rows[0].Cells[8].Value = PrvRS;
                DGFM.Rows[0].Cells[9].Value = PrvKG;
                DGFM.Rows[0].Cells[11].Value = Time;
                DGFM.Rows[0].Cells[7].Value = FillCount;
                DGFM.Rows[0].Cells[10].Value = Rate;

                if (FC1[0] + 1 == val16)
                {
                    InserDataintoDB("1", "1-A", Convert.ToInt16(val16), Convert.ToDecimal(DGFM.Rows[0].Cells[3].Value), Convert.ToDecimal(DGFM.Rows[0].Cells[2].Value), Convert.ToDecimal(DGFM.Rows[0].Cells[4].Value), Convert.ToDecimal(DGFM.Rows[0].Cells[5].Value), Convert.ToDecimal(DGFM.Rows[0].Cells[6].Value));
                    FC1[0] = val16;
                    counter[0] = 0;
                    DGFM.Rows[0].Cells[2].Style.BackColor = Color.Black;
                    DGFM.Rows[0].Cells[3].Style.BackColor = Color.Black;
                }
                if (DGFM.Rows[0].Cells[2].Value != "0000.00" && DGFM.Rows[0].Cells[2].Value != "0" && DGFM.Rows[0].Cells[2].Value != DGFM.Rows[0].Cells[8].Value)
                {
                    DGFM.Rows[0].Cells[2].Style.BackColor = Color.SteelBlue;
                    DGFM.Rows[0].Cells[3].Style.BackColor = Color.SteelBlue;
                }
                else
                {
                    DGFM.Rows[0].Cells[2].Style.BackColor = Color.Black;
                    DGFM.Rows[0].Cells[3].Style.BackColor = Color.Black;
                }

            }

            //+++++++++++++++++++++++++Side B +++++++++++++++++++++++++++++
            //For Val4
            if (val4 != null && val5 != null && val6 != null && val7 != null)
            {
                i = 0;
                i2 = 0;
                hexval = val4.ToString("X");
                if (hexval.Length == 3)
                {
                    hexval = "0" + hexval;
                }
                if (hexval.Length == 2)
                {
                    hexval = "00" + hexval;
                }
                if (hexval.Length == 1)
                {
                    hexval = "000" + hexval;
                }
                subst = hexval.Substring(2, 2);
                subst += hexval.Substring(0, 2);
                hexval = subst;
                subst = "";

                myArray = new string[hexval.Length];

                for (i = hexval.Length - 1; i2 < 4; i--)
                {

                    myArray[i] = hexval[i].ToString();

                    i2++;
                }
                if (myArray[hexval.Length - 4] == "A" || myArray[hexval.Length - 4] == "B" || myArray[hexval.Length - 4] == "C" || myArray[hexval.Length - 4] == "D" || myArray[hexval.Length - 4] == "E" || myArray[hexval.Length - 4] == "F")
                {
                    GS.reg3B = "";
                }
                else
                {
                    GS.reg3B = myArray[hexval.Length - 4].ToString();
                }
                if (myArray[hexval.Length - 3] == "A" || myArray[hexval.Length - 3] == "B" || myArray[hexval.Length - 3] == "C" || myArray[hexval.Length - 3] == "D" || myArray[hexval.Length - 3] == "E" || myArray[hexval.Length - 3] == "F")
                {
                    GS.reg2B = "";
                }
                else
                {
                    GS.reg2B = myArray[hexval.Length - 3].ToString();
                }

                if (myArray[hexval.Length - 2] == "A" || myArray[hexval.Length - 2] == "B" || myArray[hexval.Length - 2] == "C" || myArray[hexval.Length - 2] == "D" || myArray[hexval.Length - 2] == "E" || myArray[hexval.Length - 2] == "F")
                {
                    GS.reg1B = "";
                }
                else
                {
                    GS.reg1B = myArray[hexval.Length - 2].ToString();
                }


                if (myArray[hexval.Length - 1] == "A" || myArray[hexval.Length - 1] == "B" || myArray[hexval.Length - 1] == "C" || myArray[hexval.Length - 1] == "D" || myArray[hexval.Length - 1] == "E" || myArray[hexval.Length - 1] == "F")
                {
                    GS.reg0B = "";
                }
                else
                {
                    GS.reg0B = myArray[hexval.Length - 1].ToString();
                }



                // For Val5
                i = 0;
                i2 = 0;
                hexval = val5.ToString("X");
                if (hexval.Length == 3)
                {
                    hexval = "0" + hexval;
                }
                if (hexval.Length == 2)
                {
                    hexval = "00" + hexval;
                }
                if (hexval.Length == 1)
                {
                    hexval = "000" + hexval;
                }
                subst = hexval.Substring(2, 2);
                subst += hexval.Substring(0, 2);
                hexval = subst;
                subst = "";
                myArray = new string[hexval.Length];

                for (i = hexval.Length - 1; i2 < 4; i--)
                {

                    myArray[i] = hexval[i].ToString();

                    i2++;
                }
                if (myArray[hexval.Length - 4] == "A" || myArray[hexval.Length - 4] == "B" || myArray[hexval.Length - 4] == "C" || myArray[hexval.Length - 4] == "D" || myArray[hexval.Length - 4] == "E" || myArray[hexval.Length - 4] == "F")
                {
                    GS.reg7B = "";
                }
                else
                {
                    GS.reg7B = myArray[hexval.Length - 4].ToString();
                }
                if (myArray[hexval.Length - 3] == "A" || myArray[hexval.Length - 3] == "B" || myArray[hexval.Length - 3] == "C" || myArray[hexval.Length - 3] == "D" || myArray[hexval.Length - 3] == "E" || myArray[hexval.Length - 3] == "F")
                {
                    GS.reg6B = "";
                }
                else
                {
                    GS.reg6B = myArray[hexval.Length - 3].ToString();
                }

                if (myArray[hexval.Length - 2] == "A" || myArray[hexval.Length - 2] == "B" || myArray[hexval.Length - 2] == "C" || myArray[hexval.Length - 2] == "D" || myArray[hexval.Length - 2] == "E" || myArray[hexval.Length - 2] == "F")
                {
                    GS.reg5B = "";
                }
                else
                {
                    GS.reg5B = myArray[hexval.Length - 2].ToString();
                }


                if (myArray[hexval.Length - 1] == "A" || myArray[hexval.Length - 1] == "B" || myArray[hexval.Length - 1] == "C" || myArray[hexval.Length - 1] == "D" || myArray[hexval.Length - 1] == "E" || myArray[hexval.Length - 1] == "F")
                {
                    GS.reg4B = "";
                }
                else
                {
                    GS.reg4B = myArray[hexval.Length - 1].ToString();
                }


                //For Val6
                i = 0;
                i2 = 0;
                hexval = val6.ToString("X");
                if (hexval.Length == 3)
                {
                    hexval = "0" + hexval;
                }
                if (hexval.Length == 2)
                {
                    hexval = "00" + hexval;
                }
                if (hexval.Length == 1)
                {
                    hexval = "000" + hexval;
                }
                subst = hexval.Substring(2, 2);
                subst += hexval.Substring(0, 2);
                hexval = subst;
                subst = "";
                myArray = new string[hexval.Length];

                for (i = hexval.Length - 1; i2 < 4; i--)
                {

                    myArray[i] = hexval[i].ToString();

                    i2++;
                }

                if (myArray[hexval.Length - 4] == "A" || myArray[hexval.Length - 4] == "B" || myArray[hexval.Length - 4] == "C" || myArray[hexval.Length - 4] == "D" || myArray[hexval.Length - 4] == "E" || myArray[hexval.Length - 4] == "F")
                {
                    GS.reg11B = "";
                }
                else
                {
                    GS.reg11B = myArray[hexval.Length - 4].ToString();
                }
                if (myArray[hexval.Length - 3] == "A" || myArray[hexval.Length - 3] == "B" || myArray[hexval.Length - 3] == "C" || myArray[hexval.Length - 3] == "D" || myArray[hexval.Length - 3] == "E" || myArray[hexval.Length - 3] == "F")
                {
                    GS.reg10B = "";
                }
                else
                {
                    GS.reg10B = myArray[hexval.Length - 3].ToString();
                }

                if (myArray[hexval.Length - 2] == "A" || myArray[hexval.Length - 2] == "B" || myArray[hexval.Length - 2] == "C" || myArray[hexval.Length - 2] == "D" || myArray[hexval.Length - 2] == "E" || myArray[hexval.Length - 2] == "F")
                {
                    GS.reg9B = "";
                }
                else
                {
                    GS.reg9B = myArray[hexval.Length - 2].ToString();
                }


                if (myArray[hexval.Length - 1] == "A" || myArray[hexval.Length - 1] == "B" || myArray[hexval.Length - 1] == "C" || myArray[hexval.Length - 1] == "D" || myArray[hexval.Length - 1] == "E" || myArray[hexval.Length - 1] == "F")
                {
                    GS.reg8B = "";
                }
                else
                {
                    GS.reg8B = myArray[hexval.Length - 1].ToString();
                }

                //For Val7
                i = 0;
                i2 = 0;
                hexval = val7.ToString("X");
                if (hexval.Length == 3)
                {
                    hexval = "0" + hexval;
                }
                if (hexval.Length == 2)
                {
                    hexval = "00" + hexval;
                }
                if (hexval.Length == 1)
                {
                    hexval = "000" + hexval;
                }
                subst = hexval.Substring(2, 2);
                subst += hexval.Substring(0, 2);
                hexval = subst;
                subst = "";
                myArray = new string[hexval.Length];

                for (i = hexval.Length - 1; i2 < 4; i--)
                {

                    myArray[i] = hexval[i].ToString();

                    i2++;
                }


                if (myArray[hexval.Length - 4] == "A" || myArray[hexval.Length - 4] == "B" || myArray[hexval.Length - 4] == "C" || myArray[hexval.Length - 4] == "D" || myArray[hexval.Length - 4] == "E" || myArray[hexval.Length - 4] == "F")
                {
                    GS.reg15B = "";
                }
                else
                {
                    GS.reg15B = myArray[hexval.Length - 4].ToString();
                }
                if (myArray[hexval.Length - 3] == "A" || myArray[hexval.Length - 3] == "B" || myArray[hexval.Length - 3] == "C" || myArray[hexval.Length - 3] == "D" || myArray[hexval.Length - 3] == "E" || myArray[hexval.Length - 3] == "F")
                {
                    GS.reg14B = "";
                }
                else
                {
                    GS.reg4B = myArray[hexval.Length - 3].ToString();
                }

                if (myArray[hexval.Length - 2] == "A" || myArray[hexval.Length - 2] == "B" || myArray[hexval.Length - 2] == "C" || myArray[hexval.Length - 2] == "D" || myArray[hexval.Length - 2] == "E" || myArray[hexval.Length - 2] == "F")
                {
                    GS.reg13B = "";
                }
                else
                {
                    GS.reg13B = myArray[hexval.Length - 2].ToString();
                }


                if (myArray[hexval.Length - 1] == "A" || myArray[hexval.Length - 1] == "B" || myArray[hexval.Length - 1] == "C" || myArray[hexval.Length - 1] == "D" || myArray[hexval.Length - 1] == "E" || myArray[hexval.Length - 1] == "F")
                {
                    GS.reg12B = "";
                }
                else
                {
                    GS.reg12B = myArray[hexval.Length - 1].ToString();
                }

                GS.priceB = GS.reg13B + "" + GS.reg12B + "" + GS.reg15B + "" + GS.reg5B + "." + GS.reg6B + "" + GS.reg7B;
                GS.KGB = GS.reg14B + "" + GS.reg9B + "" + GS.reg8B + "" + GS.reg1B + "" + "." + GS.reg3B + "" + GS.reg4B;
                GS.RateB = GS.reg10B + "" + GS.reg11B + "." + GS.reg2B + "" + GS.reg0B;
                DGFM.Rows[1].Cells[2].Value = GS.priceB;
                DGFM.Rows[1].Cells[3].Value = GS.KGB;
                DGFM.Rows[1].Cells[4].Value = GS.RateB;

               

                //Val12,13
                if (val12 < 0)
                {

                    tempval = val12 + 65536;
                }

                if (tempval > 0)
                {
                    RTB = (65536 * val13) + tempval;
                }
                else
                {
                    RTB = (65536 * val13) + val12;
                }
                tempval = 0;

                TB1 = Convert.ToDecimal(RTB);
                TB2 = TB1 / 100;
                 DGFM.Rows[1].Cells[6].Value =  Convert.ToString(TB2);


                if (val14 < 0)
                {

                    tempval = val14 + (65536);

                }
                if (tempval > 0)
                {
                    NRTB = (65536 * val15) + tempval;

                }
                else
                {
                    NRTB = (65536 * val15) + val14;
                }
                tempval = 0;
                TNB1 = Convert.ToDecimal(NRTB);
                TNB2 = TNB1 / 100;
                DGFM.Rows[1].Cells[5].Value  = Convert.ToString(TNB2);

                // lblFCB1.Text = Convert.ToString(val18);
                PrvKG = "0";
                PrvRS = "0";
                Time = "0";
                Rate = "0";
                FillCount = "0";
                selectperviousrecord("1-B");
                DGFM.Rows[1].Cells[8].Value = PrvRS;
                DGFM.Rows[1].Cells[9].Value = PrvKG;
                DGFM.Rows[1].Cells[11].Value = Time;
                DGFM.Rows[1].Cells[7].Value = FillCount;
                DGFM.Rows[1].Cells[10].Value = Rate;
                

                if (FC2[0] + 1 == val18)
                {
                    InserDataintoDB("1", "1-B", Convert.ToInt16(val18), Convert.ToDecimal(DGFM.Rows[1].Cells[3].Value), Convert.ToDecimal(DGFM.Rows[1].Cells[2].Value), Convert.ToDecimal(DGFM.Rows[1].Cells[4].Value), Convert.ToDecimal(DGFM.Rows[1].Cells[5].Value), Convert.ToDecimal(DGFM.Rows[1].Cells[6].Value));
                    //InserDataintoDB("1", "1-B", Convert.ToInt16(val18), Convert.ToDecimal(lblKG1B.Text), Convert.ToDecimal(lblprice1B.Text), Convert.ToDecimal(lblRateB1.Text), Convert.ToDecimal(lblNRTB1.Text), Convert.ToDecimal(lblRTB1.Text));
                    FC2[0] = val18;
                    DGFM.Rows[1].Cells[2].Style.BackColor = Color.Black;
                    DGFM.Rows[1].Cells[3].Style.BackColor = Color.Black;
                }
                if (DGFM.Rows[1].Cells[2].Value != "0000.00" && DGFM.Rows[1].Cells[2].Value != "0" && DGFM.Rows[1].Cells[2].Value != DGFM.Rows[1].Cells[8].Value)
                {
                    DGFM.Rows[1].Cells[2].Style.BackColor = Color.SteelBlue;
                    DGFM.Rows[1].Cells[3].Style.BackColor = Color.SteelBlue;
                }
                else
                {
                    DGFM.Rows[1].Cells[2].Style.BackColor = Color.Black;
                    DGFM.Rows[1].Cells[3].Style.BackColor = Color.Black;
                }

            }



            //label1.Text=(val0.ToString() + "," + val1.ToString() + "," + val2.ToString() + "," + val3.ToString() + "," + val4.ToString() + "," + val5.ToString() + "," + val6.ToString() + "," + val7.ToString());
            // wsmbsControl1.Close();
        }
        //+++++++++++++++++++++++++
        //SIDE------ONE-----END
        //+++++++++++++++++++++++++
        //+++++++++++++++++++++++++
        ////SIDE------TWO-----START
        //+++++++++++++++++++++++++
        void ReadRegDataSide2()
        {
            string reg0, reg1, reg2, reg3, reg4, reg5, reg6, reg7, reg8, reg9, reg10, reg11, reg12, reg13, reg14, reg15;
            string reg0B, reg1B, reg2B, reg3B, reg4B, reg5B, reg6B, reg7B, reg8B, reg9B, reg10B, reg11B, reg12B, reg13B, reg14B, reg15B;
            string priceA, priceB, KGA, KGB, PrvpriceA, PrvpriceB, PrvKGA, PrvKGB, FCA, FCB, NRTotA, NRTotB, RTotA, RTotB, RateA, RateB;

            Int16[] Registers = new Int16[20];
            WSMBS.Result Result;
            Result = wsmbsControl1.ReadHoldingRegisters(2, 0, 20, Registers);
            if (Result != WSMBS.Result.SUCCESS)
            {

                ReadRegData();
            }




            //MessageBox.Show(wsmbsControl1.GetLastErrorString());
            string hex = Convert.ToString(Registers[0]);
            Int16 val0 = Convert.ToInt16(Registers[0]);
            Int16 val1 = Convert.ToInt16(Registers[1]);
            Int16 val2 = Convert.ToInt16(Registers[2]);
            Int16 val3 = Convert.ToInt16(Registers[3]);
            Int16 val4 = Convert.ToInt16(Registers[4]);
            Int16 val5 = Convert.ToInt16(Registers[5]);
            Int16 val6 = Convert.ToInt16(Registers[6]);
            Int16 val7 = Convert.ToInt16(Registers[7]);
            Int16 val8 = Convert.ToInt16(Registers[8]);
            Int16 val9 = Convert.ToInt16(Registers[9]);
            Int16 val10 = Convert.ToInt16(Registers[10]);
            Int16 val11 = Convert.ToInt16(Registers[11]);
            Int16 val12 = Convert.ToInt16(Registers[12]);
            Int16 val13 = Convert.ToInt16(Registers[13]);
            Int16 val14 = Convert.ToInt16(Registers[14]);
            Int16 val15 = Convert.ToInt16(Registers[15]);
            Int16 val16 = Convert.ToInt16(Registers[16]);
            Int16 val17 = Convert.ToInt16(Registers[17]);
            Int16 val18 = Convert.ToInt16(Registers[18]);
            Int16 val19 = Convert.ToInt16(Registers[19]);

            if (counter[1] == 0)
            {
                FC1[1] = val16;
                FC2[1] = val18;
                FCDB1 = val16;
                FCDB2 = val18;
                counter[1] += 1;
            }

            //string str = System.Uri.HexEscape((char)64);
            //MessageBox.Show(str); // this will show as %40  (  which is the way hex would show in web urls  ) 
            // to show without the %  ,  the following line would apply  .  .  . 
            //MessageBox.Show(str.Substring(1));
            //For Val0
            string hexval = "";
            string[] myArray;

            if (val0 != null && val1 != null && val2 != null && val3 != null)
            {
                i = 0;
                i2 = 0;

                hexval = val0.ToString("X");
                if (hexval.Length == 3)
                {
                    hexval = "0" + hexval;
                }
                if (hexval.Length == 2)
                {
                    hexval = "00" + hexval;
                }
                if (hexval.Length == 1)
                {
                    hexval = "000" + hexval;
                }
                subst = hexval.Substring(2, 2);
                subst += hexval.Substring(0, 2);
                hexval = subst;
                subst = "";
                myArray = new string[hexval.Length];
                for (i = hexval.Length - 1; i2 < 4; i--)
                {

                    myArray[i] = hexval[i].ToString();

                    i2++;
                }
                if (myArray[hexval.Length - 4] == "A" || myArray[hexval.Length - 4] == "B" || myArray[hexval.Length - 4] == "C" || myArray[hexval.Length - 4] == "D" || myArray[hexval.Length - 4] == "E" || myArray[hexval.Length - 4] == "F")
                {

                    reg3 = "";
                }
                else
                {
                    reg3 = myArray[hexval.Length - 4].ToString();
                }
                if (myArray[hexval.Length - 3] == "A" || myArray[hexval.Length - 3] == "B" || myArray[hexval.Length - 3] == "C" || myArray[hexval.Length - 3] == "D" || myArray[hexval.Length - 3] == "E" || myArray[hexval.Length - 3] == "F")
                {
                    reg2 = "";
                }
                else
                {
                    reg2 = myArray[hexval.Length - 3].ToString();
                }

                if (myArray[hexval.Length - 2] == "A" || myArray[hexval.Length - 2] == "B" || myArray[hexval.Length - 2] == "C" || myArray[hexval.Length - 2] == "D" || myArray[hexval.Length - 2] == "E" || myArray[hexval.Length - 2] == "F")
                {
                    reg1 = "";
                }
                else
                {
                    reg1 = myArray[hexval.Length - 2].ToString();
                }


                if (myArray[hexval.Length - 1] == "A" || myArray[hexval.Length - 1] == "B" || myArray[hexval.Length - 1] == "C" || myArray[hexval.Length - 1] == "D" || myArray[hexval.Length - 1] == "E" || myArray[hexval.Length - 1] == "F")
                {
                    reg0 = "";
                }
                else
                {
                    reg0 = myArray[hexval.Length - 1].ToString();
                }

                // For Val1
                i = 0;
                i2 = 0;
                hexval = val1.ToString("X");
                if (hexval.Length == 3)
                {
                    hexval = "0" + hexval;
                }
                if (hexval.Length == 2)
                {
                    hexval = "00" + hexval;
                }
                if (hexval.Length == 1)
                {
                    hexval = "000" + hexval;
                }
                subst = hexval.Substring(2, 2);
                subst += hexval.Substring(0, 2);
                hexval = subst;
                subst = "";
                myArray = new string[hexval.Length];

                for (i = hexval.Length - 1; i2 < 4; i--)
                {

                    myArray[i] = hexval[i].ToString();

                    i2++;
                }
                if (myArray[hexval.Length - 4] == "A" || myArray[hexval.Length - 4] == "B" || myArray[hexval.Length - 4] == "C" || myArray[hexval.Length - 4] == "D" || myArray[hexval.Length - 4] == "E" || myArray[hexval.Length - 4] == "F")
                {
                    reg7 = "";
                }
                else
                {
                    reg7 = myArray[hexval.Length - 4].ToString();
                }
                if (myArray[hexval.Length - 3] == "A" || myArray[hexval.Length - 3] == "B" || myArray[hexval.Length - 3] == "C" || myArray[hexval.Length - 3] == "D" || myArray[hexval.Length - 3] == "E" || myArray[hexval.Length - 3] == "F")
                {
                    reg6 = "";
                }
                else
                {
                    reg6 = myArray[hexval.Length - 3].ToString();
                }

                if (myArray[hexval.Length - 2] == "A" || myArray[hexval.Length - 2] == "B" || myArray[hexval.Length - 2] == "C" || myArray[hexval.Length - 2] == "D" || myArray[hexval.Length - 2] == "E" || myArray[hexval.Length - 2] == "F")
                {
                    reg5 = "";
                }
                else
                {
                    reg5 = myArray[hexval.Length - 2].ToString();
                }


                if (myArray[hexval.Length - 1] == "A" || myArray[hexval.Length - 1] == "B" || myArray[hexval.Length - 1] == "C" || myArray[hexval.Length - 1] == "D" || myArray[hexval.Length - 1] == "E" || myArray[hexval.Length - 1] == "F")
                {
                    reg4 = "";
                }
                else
                {
                    reg4 = myArray[hexval.Length - 1].ToString();
                }


                //For Val2
                i = 0;
                i2 = 0;
                hexval = val2.ToString("X");
                if (hexval.Length == 3)
                {
                    hexval = "0" + hexval;
                }
                if (hexval.Length == 2)
                {
                    hexval = "00" + hexval;
                }
                if (hexval.Length == 1)
                {
                    hexval = "000" + hexval;
                }
                subst = hexval.Substring(2, 2);
                subst += hexval.Substring(0, 2);
                hexval = subst;
                subst = "";
                myArray = new string[hexval.Length];

                for (i = hexval.Length - 1; i2 < 4; i--)
                {

                    myArray[i] = hexval[i].ToString();

                    i2++;
                }

                if (myArray[hexval.Length - 4] == "A" || myArray[hexval.Length - 4] == "B" || myArray[hexval.Length - 4] == "C" || myArray[hexval.Length - 4] == "D" || myArray[hexval.Length - 4] == "E" || myArray[hexval.Length - 4] == "F")
                {
                    reg11 = "";
                }
                else
                {
                    reg11 = myArray[hexval.Length - 4].ToString();
                }
                if (myArray[hexval.Length - 3] == "A" || myArray[hexval.Length - 3] == "B" || myArray[hexval.Length - 3] == "C" || myArray[hexval.Length - 3] == "D" || myArray[hexval.Length - 3] == "E" || myArray[hexval.Length - 3] == "F")
                {
                    reg10 = "";
                }
                else
                {
                    reg10 = myArray[hexval.Length - 3].ToString();
                }

                if (myArray[hexval.Length - 2] == "A" || myArray[hexval.Length - 2] == "B" || myArray[hexval.Length - 2] == "C" || myArray[hexval.Length - 2] == "D" || myArray[hexval.Length - 2] == "E" || myArray[hexval.Length - 2] == "F")
                {
                    reg9 = "";
                }
                else
                {
                    reg9 = myArray[hexval.Length - 2].ToString();
                }


                if (myArray[hexval.Length - 1] == "A" || myArray[hexval.Length - 1] == "B" || myArray[hexval.Length - 1] == "C" || myArray[hexval.Length - 1] == "D" || myArray[hexval.Length - 1] == "E" || myArray[hexval.Length - 1] == "F")
                {
                    reg8 = "";
                }
                else
                {
                    reg8 = myArray[hexval.Length - 1].ToString();
                }

                //For Val3
                i = 0;
                i2 = 0;
                hexval = val3.ToString("X");
                if (hexval.Length == 3)
                {
                    hexval = "0" + hexval;
                }
                if (hexval.Length == 2)
                {
                    hexval = "00" + hexval;
                }
                if (hexval.Length == 1)
                {
                    hexval = "000" + hexval;
                }
                subst = hexval.Substring(2, 2);
                subst += hexval.Substring(0, 2);
                hexval = subst;
                subst = "";
                myArray = new string[hexval.Length];

                for (i = hexval.Length - 1; i2 < 4; i--)
                {

                    myArray[i] = hexval[i].ToString();

                    i2++;
                }


                if (myArray[hexval.Length - 4] == "A" || myArray[hexval.Length - 4] == "B" || myArray[hexval.Length - 4] == "C" || myArray[hexval.Length - 4] == "D" || myArray[hexval.Length - 4] == "E" || myArray[hexval.Length - 4] == "F")
                {
                    reg15 = "";
                }
                else
                {
                    reg15 = myArray[hexval.Length - 4].ToString();
                }
                if (myArray[hexval.Length - 3] == "A" || myArray[hexval.Length - 3] == "B" || myArray[hexval.Length - 3] == "C" || myArray[hexval.Length - 3] == "D" || myArray[hexval.Length - 3] == "E" || myArray[hexval.Length - 3] == "F")
                {
                    reg14 = "";
                }
                else
                {
                    reg14 = myArray[hexval.Length - 3].ToString();
                }

                if (myArray[hexval.Length - 2] == "A" || myArray[hexval.Length - 2] == "B" || myArray[hexval.Length - 2] == "C" || myArray[hexval.Length - 2] == "D" || myArray[hexval.Length - 2] == "E" || myArray[hexval.Length - 2] == "F")
                {
                    reg13 = "";
                }
                else
                {
                    reg13 = myArray[hexval.Length - 2].ToString();
                }


                if (myArray[hexval.Length - 1] == "A" || myArray[hexval.Length - 1] == "B" || myArray[hexval.Length - 1] == "C" || myArray[hexval.Length - 1] == "D" || myArray[hexval.Length - 1] == "E" || myArray[hexval.Length - 1] == "F")
                {
                    reg12 = "";
                }
                else
                {
                    reg12 = myArray[hexval.Length - 1].ToString();
                }
                priceA = reg13 + "" + reg12 + "" + reg15 + "" + reg5 + "." + reg6 + "" + reg7;
                DGFM.Rows[2].Cells[2].Value = priceA;
              // lblprice2A.Text = priceA;
                KGA = reg14 + "" + reg9 + "" + reg8 + "" + reg1 + "." + reg3 + "" + reg4;
                DGFM.Rows[2].Cells[3].Value = KGA;
                RateA = reg10 + "" + reg11 + "." + reg2 + "" + reg0;
                DGFM.Rows[2].Cells[4].Value = RateA;
                //Val8,9x

                if (val8 < 0)
                {
                    tempval = (val8 + 65536);


                }

                if (tempval > 0)
                {
                    RT = (65536 * val9) + tempval;
                }
                else
                {
                    RT = (65536 * val9) + val8;
                }
                tempval = 0;
                TA1 = Convert.ToDecimal(RT);
                TA2 = TA1 / 100;
                DGFM.Rows[2].Cells[6].Value = Convert.ToString(TA2);


                if (val10 < 0)
                {

                    //val10 += Convert.ToInt16(65535);
                    tempval = (val10 + 65536);

                }
                if (val11 < 0)
                {
                    val11 += Convert.ToInt16(65536);
                }


                if (tempval > 0)
                {
                    NRT = (65536 * val11) + tempval;
                }
                else
                {
                    NRT = (65536 * val11) + val10;
                }
                tempval = 0;

                TNA1 = Convert.ToDecimal(NRT);
                TNA2 = TNA1 / 100;
                DGFM.Rows[2].Cells[5].Value = Convert.ToString(TNA2);

                PrvKG = "0";
                PrvRS = "0";
                Time = "0";
                Rate = "0";
                FillCount = "0";
                selectperviousrecord("2-A");
                DGFM.Rows[2].Cells[8].Value = PrvRS;
                DGFM.Rows[2].Cells[9].Value = PrvKG;
                DGFM.Rows[2].Cells[11].Value = Time;
                DGFM.Rows[2].Cells[7].Value = FillCount;
                DGFM.Rows[2].Cells[10].Value = Rate;
               
                //lblFCA2.Text = Convert.ToString(val16);


                if (FC1[1] + 1 == val16)
                {

                    InserDataintoDB("2", "2-A", Convert.ToInt16(val16), Convert.ToDecimal(DGFM.Rows[2].Cells[3].Value), Convert.ToDecimal(DGFM.Rows[2].Cells[2].Value), Convert.ToDecimal(DGFM.Rows[2].Cells[4].Value), Convert.ToDecimal(DGFM.Rows[2].Cells[5].Value), Convert.ToDecimal(DGFM.Rows[2].Cells[6].Value));
                    //InserDataintoDB("1", "1-B", Convert.ToInt16(val18), Convert.ToDecimal(lblKG1B.Text), Convert.ToDecimal(lblprice1B.Text), Convert.ToDecimal(lblRateB1.Text), Convert.ToDecimal(lblNRTB1.Text), Convert.ToDecimal(lblRTB1.Text));
                    FC1[1] = val16;
                    DGFM.Rows[2].Cells[2].Style.BackColor = Color.Black;
                    DGFM.Rows[2].Cells[3].Style.BackColor = Color.Black;
                    counter[1] = 0;
                   
                }
                if (DGFM.Rows[2].Cells[2].Value != "0000.00" && DGFM.Rows[2].Cells[2].Value != "0" && DGFM.Rows[2].Cells[2].Value != DGFM.Rows[2].Cells[8].Value)
                {
                    DGFM.Rows[2].Cells[2].Style.BackColor = Color.SteelBlue;
                    DGFM.Rows[2].Cells[3].Style.BackColor = Color.SteelBlue;
                }
                else
                {
                    DGFM.Rows[2].Cells[2].Style.BackColor = Color.Black;
                    DGFM.Rows[2].Cells[3].Style.BackColor = Color.Black;
                }

            }

            //+++++++++++++++++++++++++Side B +++++++++++++++++++++++++++++
            //For Val4
            if (val4 != null && val5 != null && val6 != null && val7 != null)
            {
                i = 0;
                i2 = 0;
                hexval = val4.ToString("X");
                if (hexval.Length == 3)
                {
                    hexval = "0" + hexval;
                }
                if (hexval.Length == 2)
                {
                    hexval = "00" + hexval;
                }
                if (hexval.Length == 1)
                {
                    hexval = "000" + hexval;
                }
                subst = hexval.Substring(2, 2);
                subst += hexval.Substring(0, 2);
                hexval = subst;
                subst = "";

                myArray = new string[hexval.Length];

                for (i = hexval.Length - 1; i2 < 4; i--)
                {

                    myArray[i] = hexval[i].ToString();

                    i2++;
                }
                if (myArray[hexval.Length - 4] == "A" || myArray[hexval.Length - 4] == "B" || myArray[hexval.Length - 4] == "C" || myArray[hexval.Length - 4] == "D" || myArray[hexval.Length - 4] == "E" || myArray[hexval.Length - 4] == "F")
                {
                    reg3B = "";
                }
                else
                {
                    reg3B = myArray[hexval.Length - 4].ToString();
                }
                if (myArray[hexval.Length - 3] == "A" || myArray[hexval.Length - 3] == "B" || myArray[hexval.Length - 3] == "C" || myArray[hexval.Length - 3] == "D" || myArray[hexval.Length - 3] == "E" || myArray[hexval.Length - 3] == "F")
                {
                    reg2B = "";
                }
                else
                {
                    reg2B = myArray[hexval.Length - 3].ToString();
                }

                if (myArray[hexval.Length - 2] == "A" || myArray[hexval.Length - 2] == "B" || myArray[hexval.Length - 2] == "C" || myArray[hexval.Length - 2] == "D" || myArray[hexval.Length - 2] == "E" || myArray[hexval.Length - 2] == "F")
                {
                    reg1B = "";
                }
                else
                {
                    reg1B = myArray[hexval.Length - 2].ToString();
                }


                if (myArray[hexval.Length - 1] == "A" || myArray[hexval.Length - 1] == "B" || myArray[hexval.Length - 1] == "C" || myArray[hexval.Length - 1] == "D" || myArray[hexval.Length - 1] == "E" || myArray[hexval.Length - 1] == "F")
                {
                    reg0B = "";
                }
                else
                {
                    reg0B = myArray[hexval.Length - 1].ToString();
                }



                // For Val5
                i = 0;
                i2 = 0;
                hexval = val5.ToString("X");
                if (hexval.Length == 3)
                {
                    hexval = "0" + hexval;
                }
                if (hexval.Length == 2)
                {
                    hexval = "00" + hexval;
                }
                if (hexval.Length == 1)
                {
                    hexval = "000" + hexval;
                }
                subst = hexval.Substring(2, 2);
                subst += hexval.Substring(0, 2);
                hexval = subst;
                subst = "";
                myArray = new string[hexval.Length];

                for (i = hexval.Length - 1; i2 < 4; i--)
                {

                    myArray[i] = hexval[i].ToString();

                    i2++;
                }
                if (myArray[hexval.Length - 4] == "A" || myArray[hexval.Length - 4] == "B" || myArray[hexval.Length - 4] == "C" || myArray[hexval.Length - 4] == "D" || myArray[hexval.Length - 4] == "E" || myArray[hexval.Length - 4] == "F")
                {
                    reg7B = "";
                }
                else
                {
                    reg7B = myArray[hexval.Length - 4].ToString();
                }
                if (myArray[hexval.Length - 3] == "A" || myArray[hexval.Length - 3] == "B" || myArray[hexval.Length - 3] == "C" || myArray[hexval.Length - 3] == "D" || myArray[hexval.Length - 3] == "E" || myArray[hexval.Length - 3] == "F")
                {
                    reg6B = "";
                }
                else
                {
                    reg6B = myArray[hexval.Length - 3].ToString();
                }

                if (myArray[hexval.Length - 2] == "A" || myArray[hexval.Length - 2] == "B" || myArray[hexval.Length - 2] == "C" || myArray[hexval.Length - 2] == "D" || myArray[hexval.Length - 2] == "E" || myArray[hexval.Length - 2] == "F")
                {
                    reg5B = "";
                }
                else
                {
                    reg5B = myArray[hexval.Length - 2].ToString();
                }


                if (myArray[hexval.Length - 1] == "A" || myArray[hexval.Length - 1] == "B" || myArray[hexval.Length - 1] == "C" || myArray[hexval.Length - 1] == "D" || myArray[hexval.Length - 1] == "E" || myArray[hexval.Length - 1] == "F")
                {
                    reg4B = "";
                }
                else
                {
                    reg4B = myArray[hexval.Length - 1].ToString();
                }


                //For Val6
                i = 0;
                i2 = 0;
                hexval = val6.ToString("X");
                if (hexval.Length == 3)
                {
                    hexval = "0" + hexval;
                }
                if (hexval.Length == 2)
                {
                    hexval = "00" + hexval;
                }
                if (hexval.Length == 1)
                {
                    hexval = "000" + hexval;
                }
                subst = hexval.Substring(2, 2);
                subst += hexval.Substring(0, 2);
                hexval = subst;
                subst = "";
                myArray = new string[hexval.Length];

                for (i = hexval.Length - 1; i2 < 4; i--)
                {

                    myArray[i] = hexval[i].ToString();

                    i2++;
                }

                if (myArray[hexval.Length - 4] == "A" || myArray[hexval.Length - 4] == "B" || myArray[hexval.Length - 4] == "C" || myArray[hexval.Length - 4] == "D" || myArray[hexval.Length - 4] == "E" || myArray[hexval.Length - 4] == "F")
                {
                    reg11B = "";
                }
                else
                {
                    reg11B = myArray[hexval.Length - 4].ToString();
                }
                if (myArray[hexval.Length - 3] == "A" || myArray[hexval.Length - 3] == "B" || myArray[hexval.Length - 3] == "C" || myArray[hexval.Length - 3] == "D" || myArray[hexval.Length - 3] == "E" || myArray[hexval.Length - 3] == "F")
                {
                    reg10B = "";
                }
                else
                {
                    reg10B = myArray[hexval.Length - 3].ToString();
                }

                if (myArray[hexval.Length - 2] == "A" || myArray[hexval.Length - 2] == "B" || myArray[hexval.Length - 2] == "C" || myArray[hexval.Length - 2] == "D" || myArray[hexval.Length - 2] == "E" || myArray[hexval.Length - 2] == "F")
                {
                    reg9B = "";
                }
                else
                {
                    reg9B = myArray[hexval.Length - 2].ToString();
                }


                if (myArray[hexval.Length - 1] == "A" || myArray[hexval.Length - 1] == "B" || myArray[hexval.Length - 1] == "C" || myArray[hexval.Length - 1] == "D" || myArray[hexval.Length - 1] == "E" || myArray[hexval.Length - 1] == "F")
                {
                    reg8B = "";
                }
                else
                {
                    reg8B = myArray[hexval.Length - 1].ToString();
                }

                //For Val7
                i = 0;
                i2 = 0;
                hexval = val7.ToString("X");
                if (hexval.Length == 3)
                {
                    hexval = "0" + hexval;
                }
                if (hexval.Length == 2)
                {
                    hexval = "00" + hexval;
                }
                if (hexval.Length == 1)
                {
                    hexval = "000" + hexval;
                }
                subst = hexval.Substring(2, 2);
                subst += hexval.Substring(0, 2);
                hexval = subst;
                subst = "";
                myArray = new string[hexval.Length];

                for (i = hexval.Length - 1; i2 < 4; i--)
                {

                    myArray[i] = hexval[i].ToString();

                    i2++;
                }


                if (myArray[hexval.Length - 4] == "A" || myArray[hexval.Length - 4] == "B" || myArray[hexval.Length - 4] == "C" || myArray[hexval.Length - 4] == "D" || myArray[hexval.Length - 4] == "E" || myArray[hexval.Length - 4] == "F")
                {
                    reg15B = "";
                }
                else
                {
                    reg15B = myArray[hexval.Length - 4].ToString();
                }
                if (myArray[hexval.Length - 3] == "A" || myArray[hexval.Length - 3] == "B" || myArray[hexval.Length - 3] == "C" || myArray[hexval.Length - 3] == "D" || myArray[hexval.Length - 3] == "E" || myArray[hexval.Length - 3] == "F")
                {
                    reg14B = "";
                }
                else
                {
                    reg14B = myArray[hexval.Length - 3].ToString();
                }

                if (myArray[hexval.Length - 2] == "A" || myArray[hexval.Length - 2] == "B" || myArray[hexval.Length - 2] == "C" || myArray[hexval.Length - 2] == "D" || myArray[hexval.Length - 2] == "E" || myArray[hexval.Length - 2] == "F")
                {
                    reg13B = "";
                }
                else
                {
                    reg13B = myArray[hexval.Length - 2].ToString();
                }


                if (myArray[hexval.Length - 1] == "A" || myArray[hexval.Length - 1] == "B" || myArray[hexval.Length - 1] == "C" || myArray[hexval.Length - 1] == "D" || myArray[hexval.Length - 1] == "E" || myArray[hexval.Length - 1] == "F")
                {
                    reg12B = "";
                }
                else
                {
                    reg12B = myArray[hexval.Length - 1].ToString();
                }

                priceB = reg13B + "" + reg12B + "" + reg15B + "" + reg5B + "." + reg6B + "" + reg7B;
                KGB = reg14B + "" + reg9B + "" + reg8B + "" + reg1B + "" + "." + reg3B + "" + reg4B;
                RateB = reg10B + "" + reg11B + "." + reg2B + "" + reg0B;
                DGFM.Rows[3].Cells[2].Value = priceB;
                DGFM.Rows[3].Cells[3].Value = KGB;
                DGFM.Rows[3].Cells[4].Value = RateB;

            

                //Val12,13
                if (val12 < 0)
                {

                    tempval = val12 + 65536;
                }

                if (tempval > 0)
                {
                    RTB = (65536 * val13) + tempval;
                }
                else
                {
                    RTB = (65536 * val13) + val12;
                }
                tempval = 0;

                TB1 = Convert.ToDecimal(RTB);
                TB2 = TB1 / 100;
                  DGFM.Rows[3].Cells[6].Value = Convert.ToString(TB2);


                if (val14 < 0)
                {

                    tempval = val14 + (65536);

                }
                if (tempval > 0)
                {
                    NRTB = (65536 * val15) + tempval;

                }
                else
                {
                    NRTB = (65536 * val15) + val14;
                }
                tempval = 0;
                TNB1 = Convert.ToDecimal(NRTB);
                TNB2 = TNB1 / 100;
                  DGFM.Rows[3].Cells[5].Value  = Convert.ToString(TNB2);
                PrvKG = "0";
                PrvRS = "0";
                Time = "0";
                Rate = "0";
                FillCount = "0";
                selectperviousrecord("2-B");
                DGFM.Rows[3].Cells[8].Value = PrvRS;
                DGFM.Rows[3].Cells[9].Value = PrvKG;
                DGFM.Rows[3].Cells[11].Value = Time;
                DGFM.Rows[3].Cells[7].Value = FillCount;
                DGFM.Rows[3].Cells[10].Value = Rate;

                // lblFCB2.Text = Convert.ToString(val18);


                if (FC2[1] + 1 == val18)
                {
                    InserDataintoDB("2", "2-B", Convert.ToInt16(val16), Convert.ToDecimal(DGFM.Rows[3].Cells[3].Value), Convert.ToDecimal(DGFM.Rows[3].Cells[2].Value), Convert.ToDecimal(DGFM.Rows[3].Cells[4].Value), Convert.ToDecimal(DGFM.Rows[3].Cells[5].Value), Convert.ToDecimal(DGFM.Rows[3].Cells[6].Value));
                    //InserDataintoDB("1", "1-B", Convert.ToInt16(val18), Convert.ToDecimal(lblKG1B.Text), Convert.ToDecimal(lblprice1B.Text), Convert.ToDecimal(lblRateB1.Text), Convert.ToDecimal(lblNRTB1.Text), Convert.ToDecimal(lblRTB1.Text));
                    FC2[1] = val18;
                    DGFM.Rows[3].Cells[2].Style.BackColor = Color.Black;
                    DGFM.Rows[3].Cells[3].Style.BackColor = Color.Black;
                    counter[1] = 0;


                   
                }
                if (DGFM.Rows[3].Cells[2].Value != "0000.00" && DGFM.Rows[3].Cells[2].Value != "0" && DGFM.Rows[3].Cells[2].Value != DGFM.Rows[3].Cells[8].Value)
                {
                    DGFM.Rows[3].Cells[2].Style.BackColor = Color.SteelBlue;
                    DGFM.Rows[3].Cells[3].Style.BackColor = Color.SteelBlue;
                }
                else
                {
                    DGFM.Rows[3].Cells[2].Style.BackColor = Color.Black;
                    DGFM.Rows[3].Cells[3].Style.BackColor = Color.Black;
                }

            }



            //label1.Text=(val0.ToString() + "," + val1.ToString() + "," + val2.ToString() + "," + val3.ToString() + "," + val4.ToString() + "," + val5.ToString() + "," + val6.ToString() + "," + val7.ToString());
            // wsmbsControl1.Close();
        }
        //+++++++++++++++++++++++++
        //SIDE------TWO-----END
        //+++++++++++++++++++++++++
        //+++++++++++++++++++++++++
        //SIDE------THREE-----START
        //+++++++++++++++++++++++++
        void ReadRegDataSide3()
        {
            string reg0, reg1, reg2, reg3, reg4, reg5, reg6, reg7, reg8, reg9, reg10, reg11, reg12, reg13, reg14, reg15;
            string reg0B, reg1B, reg2B, reg3B, reg4B, reg5B, reg6B, reg7B, reg8B, reg9B, reg10B, reg11B, reg12B, reg13B, reg14B, reg15B;
            string priceA, priceB, KGA, KGB, PrvpriceA, PrvpriceB, PrvKGA, PrvKGB, FCA, FCB, NRTotA, NRTotB, RTotA, RTotB, RateA, RateB;

            Int16[] Registers = new Int16[20];
            WSMBS.Result Result;
            Result = wsmbsControl1.ReadHoldingRegisters(3, 0, 20, Registers);
            if (Result != WSMBS.Result.SUCCESS)
            {

                ReadRegDataSide2();
                //MessageBox.Show(wsmbsControl1.GetLastErrorString());   
            }




            string hex = Convert.ToString(Registers[0]);
            Int16 val0 = Convert.ToInt16(Registers[0]);
            Int16 val1 = Convert.ToInt16(Registers[1]);
            Int16 val2 = Convert.ToInt16(Registers[2]);
            Int16 val3 = Convert.ToInt16(Registers[3]);
            Int16 val4 = Convert.ToInt16(Registers[4]);
            Int16 val5 = Convert.ToInt16(Registers[5]);
            Int16 val6 = Convert.ToInt16(Registers[6]);
            Int16 val7 = Convert.ToInt16(Registers[7]);
            Int16 val8 = Convert.ToInt16(Registers[8]);
            Int16 val9 = Convert.ToInt16(Registers[9]);
            Int16 val10 = Convert.ToInt16(Registers[10]);
            Int16 val11 = Convert.ToInt16(Registers[11]);
            Int16 val12 = Convert.ToInt16(Registers[12]);
            Int16 val13 = Convert.ToInt16(Registers[13]);
            Int16 val14 = Convert.ToInt16(Registers[14]);
            Int16 val15 = Convert.ToInt16(Registers[15]);
            Int16 val16 = Convert.ToInt16(Registers[16]);
            Int16 val17 = Convert.ToInt16(Registers[17]);
            Int16 val18 = Convert.ToInt16(Registers[18]);
            Int16 val19 = Convert.ToInt16(Registers[19]);

            if (counter[2] == 0)
            {
                FC1[2] = val16;
                FC2[2] = val18;
                FCDB1 = val16;
                FCDB2 = val18;
                counter[2] += 1;
            }

            //string str = System.Uri.HexEscape((char)64);
            //MessageBox.Show(str); // this will show as %40  (  which is the way hex would show in web urls  ) 
            // to show without the %  ,  the following line would apply  .  .  . 
            //MessageBox.Show(str.Substring(1));
            //For Val0
            string hexval = "";
            string[] myArray;

            if (val0 != null && val1 != null && val2 != null && val3 != null)
            {
                i = 0;
                i2 = 0;

                hexval = val0.ToString("X");
                if (hexval.Length == 3)
                {
                    hexval = "0" + hexval;
                }
                if (hexval.Length == 2)
                {
                    hexval = "00" + hexval;
                }
                if (hexval.Length == 1)
                {
                    hexval = "000" + hexval;
                }
                subst = hexval.Substring(2, 2);
                subst += hexval.Substring(0, 2);
                hexval = subst;
                subst = "";
                myArray = new string[hexval.Length];
                for (i = hexval.Length - 1; i2 < 4; i--)
                {

                    myArray[i] = hexval[i].ToString();

                    i2++;
                }
                if (myArray[hexval.Length - 4] == "A" || myArray[hexval.Length - 4] == "B" || myArray[hexval.Length - 4] == "C" || myArray[hexval.Length - 4] == "D" || myArray[hexval.Length - 4] == "E" || myArray[hexval.Length - 4] == "F")
                {

                    reg3 = "";
                }
                else
                {
                    reg3 = myArray[hexval.Length - 4].ToString();
                }
                if (myArray[hexval.Length - 3] == "A" || myArray[hexval.Length - 3] == "B" || myArray[hexval.Length - 3] == "C" || myArray[hexval.Length - 3] == "D" || myArray[hexval.Length - 3] == "E" || myArray[hexval.Length - 3] == "F")
                {
                    reg2 = "";
                }
                else
                {
                    reg2 = myArray[hexval.Length - 3].ToString();
                }

                if (myArray[hexval.Length - 2] == "A" || myArray[hexval.Length - 2] == "B" || myArray[hexval.Length - 2] == "C" || myArray[hexval.Length - 2] == "D" || myArray[hexval.Length - 2] == "E" || myArray[hexval.Length - 2] == "F")
                {
                    reg1 = "";
                }
                else
                {
                    reg1 = myArray[hexval.Length - 2].ToString();
                }


                if (myArray[hexval.Length - 1] == "A" || myArray[hexval.Length - 1] == "B" || myArray[hexval.Length - 1] == "C" || myArray[hexval.Length - 1] == "D" || myArray[hexval.Length - 1] == "E" || myArray[hexval.Length - 1] == "F")
                {
                    reg0 = "";
                }
                else
                {
                    reg0 = myArray[hexval.Length - 1].ToString();
                }

                // For Val1
                i = 0;
                i2 = 0;
                hexval = val1.ToString("X");
                if (hexval.Length == 3)
                {
                    hexval = "0" + hexval;
                }
                if (hexval.Length == 2)
                {
                    hexval = "00" + hexval;
                }
                if (hexval.Length == 1)
                {
                    hexval = "000" + hexval;
                }
                subst = hexval.Substring(2, 2);
                subst += hexval.Substring(0, 2);
                hexval = subst;
                subst = "";
                myArray = new string[hexval.Length];

                for (i = hexval.Length - 1; i2 < 4; i--)
                {

                    myArray[i] = hexval[i].ToString();

                    i2++;
                }
                if (myArray[hexval.Length - 4] == "A" || myArray[hexval.Length - 4] == "B" || myArray[hexval.Length - 4] == "C" || myArray[hexval.Length - 4] == "D" || myArray[hexval.Length - 4] == "E" || myArray[hexval.Length - 4] == "F")
                {
                    reg7 = "";
                }
                else
                {
                    reg7 = myArray[hexval.Length - 4].ToString();
                }
                if (myArray[hexval.Length - 3] == "A" || myArray[hexval.Length - 3] == "B" || myArray[hexval.Length - 3] == "C" || myArray[hexval.Length - 3] == "D" || myArray[hexval.Length - 3] == "E" || myArray[hexval.Length - 3] == "F")
                {
                    reg6 = "";
                }
                else
                {
                    reg6 = myArray[hexval.Length - 3].ToString();
                }

                if (myArray[hexval.Length - 2] == "A" || myArray[hexval.Length - 2] == "B" || myArray[hexval.Length - 2] == "C" || myArray[hexval.Length - 2] == "D" || myArray[hexval.Length - 2] == "E" || myArray[hexval.Length - 2] == "F")
                {
                    reg5 = "";
                }
                else
                {
                    reg5 = myArray[hexval.Length - 2].ToString();
                }


                if (myArray[hexval.Length - 1] == "A" || myArray[hexval.Length - 1] == "B" || myArray[hexval.Length - 1] == "C" || myArray[hexval.Length - 1] == "D" || myArray[hexval.Length - 1] == "E" || myArray[hexval.Length - 1] == "F")
                {
                    reg4 = "";
                }
                else
                {
                    reg4 = myArray[hexval.Length - 1].ToString();
                }


                //For Val2
                i = 0;
                i2 = 0;
                hexval = val2.ToString("X");
                if (hexval.Length == 3)
                {
                    hexval = "0" + hexval;
                }
                if (hexval.Length == 2)
                {
                    hexval = "00" + hexval;
                }
                if (hexval.Length == 1)
                {
                    hexval = "000" + hexval;
                }
                subst = hexval.Substring(2, 2);
                subst += hexval.Substring(0, 2);
                hexval = subst;
                subst = "";
                myArray = new string[hexval.Length];

                for (i = hexval.Length - 1; i2 < 4; i--)
                {

                    myArray[i] = hexval[i].ToString();

                    i2++;
                }

                if (myArray[hexval.Length - 4] == "A" || myArray[hexval.Length - 4] == "B" || myArray[hexval.Length - 4] == "C" || myArray[hexval.Length - 4] == "D" || myArray[hexval.Length - 4] == "E" || myArray[hexval.Length - 4] == "F")
                {
                    reg11 = "";
                }
                else
                {
                    reg11 = myArray[hexval.Length - 4].ToString();
                }
                if (myArray[hexval.Length - 3] == "A" || myArray[hexval.Length - 3] == "B" || myArray[hexval.Length - 3] == "C" || myArray[hexval.Length - 3] == "D" || myArray[hexval.Length - 3] == "E" || myArray[hexval.Length - 3] == "F")
                {
                    reg10 = "";
                }
                else
                {
                    reg10 = myArray[hexval.Length - 3].ToString();
                }

                if (myArray[hexval.Length - 2] == "A" || myArray[hexval.Length - 2] == "B" || myArray[hexval.Length - 2] == "C" || myArray[hexval.Length - 2] == "D" || myArray[hexval.Length - 2] == "E" || myArray[hexval.Length - 2] == "F")
                {
                    reg9 = "";
                }
                else
                {
                    reg9 = myArray[hexval.Length - 2].ToString();
                }


                if (myArray[hexval.Length - 1] == "A" || myArray[hexval.Length - 1] == "B" || myArray[hexval.Length - 1] == "C" || myArray[hexval.Length - 1] == "D" || myArray[hexval.Length - 1] == "E" || myArray[hexval.Length - 1] == "F")
                {
                    reg8 = "";
                }
                else
                {
                    reg8 = myArray[hexval.Length - 1].ToString();
                }

                //For Val3
                i = 0;
                i2 = 0;
                hexval = val3.ToString("X");
                if (hexval.Length == 3)
                {
                    hexval = "0" + hexval;
                }
                if (hexval.Length == 2)
                {
                    hexval = "00" + hexval;
                }
                if (hexval.Length == 1)
                {
                    hexval = "000" + hexval;
                }
                subst = hexval.Substring(2, 2);
                subst += hexval.Substring(0, 2);
                hexval = subst;
                subst = "";
                myArray = new string[hexval.Length];

                for (i = hexval.Length - 1; i2 < 4; i--)
                {

                    myArray[i] = hexval[i].ToString();

                    i2++;
                }


                if (myArray[hexval.Length - 4] == "A" || myArray[hexval.Length - 4] == "B" || myArray[hexval.Length - 4] == "C" || myArray[hexval.Length - 4] == "D" || myArray[hexval.Length - 4] == "E" || myArray[hexval.Length - 4] == "F")
                {
                    reg15 = "";
                }
                else
                {
                    reg15 = myArray[hexval.Length - 4].ToString();
                }
                if (myArray[hexval.Length - 3] == "A" || myArray[hexval.Length - 3] == "B" || myArray[hexval.Length - 3] == "C" || myArray[hexval.Length - 3] == "D" || myArray[hexval.Length - 3] == "E" || myArray[hexval.Length - 3] == "F")
                {
                    reg14 = "";
                }
                else
                {
                    reg14 = myArray[hexval.Length - 3].ToString();
                }

                if (myArray[hexval.Length - 2] == "A" || myArray[hexval.Length - 2] == "B" || myArray[hexval.Length - 2] == "C" || myArray[hexval.Length - 2] == "D" || myArray[hexval.Length - 2] == "E" || myArray[hexval.Length - 2] == "F")
                {
                    reg13 = "";
                }
                else
                {
                    reg13 = myArray[hexval.Length - 2].ToString();
                }


                if (myArray[hexval.Length - 1] == "A" || myArray[hexval.Length - 1] == "B" || myArray[hexval.Length - 1] == "C" || myArray[hexval.Length - 1] == "D" || myArray[hexval.Length - 1] == "E" || myArray[hexval.Length - 1] == "F")
                {
                    reg12 = "";
                }
                else
                {
                    reg12 = myArray[hexval.Length - 1].ToString();
                }
                priceA = reg13 + "" + reg12 + "" + reg15 + "" + reg5 + "." + reg6 + "" + reg7;
                DGFM.Rows[4].Cells[2].Value = priceA;
                KGA = reg14 + "" + reg9 + "" + reg8 + "" + reg1 + "." + reg3 + "" + reg4;
                DGFM.Rows[4].Cells[3].Value = KGA;
                RateA = reg10 + "" + reg11 + "." + reg2 + "" + reg0;
                DGFM.Rows[4].Cells[4].Value = RateA;


             

                //Val8,9x

                if (val8 < 0)
                {
                    tempval = (val8 + 65536);


                }

                if (tempval > 0)
                {
                    RT = (65536 * val9) + tempval;
                }
                else
                {
                    RT = (65536 * val9) + val8;
                }
                tempval = 0;
                TA1 = Convert.ToDecimal(RT);
                TA2 = TA1 / 100;
                DGFM.Rows[4].Cells[6].Value  = Convert.ToString(TA2);


                if (val10 < 0)
                {

                    //val10 += Convert.ToInt16(65535);
                    tempval = (val10 + 65536);

                }
                if (val11 < 0)
                {
                    val11 += Convert.ToInt16(65536);
                }


                if (tempval > 0)
                {
                    NRT = (65536 * val11) + tempval;
                }
                else
                {
                    NRT = (65536 * val11) + val10;
                }
                tempval = 0;

                TNA1 = Convert.ToDecimal(NRT);
                TNA2 = TNA1 / 100;
                DGFM.Rows[4].Cells[5].Value = Convert.ToString(TNA2);

                PrvKG = "0";
                PrvRS = "0";
                Time = "0";
                Rate = "0";
                FillCount = "0";
                selectperviousrecord("3-A");
                DGFM.Rows[4].Cells[8].Value = PrvRS;
                DGFM.Rows[4].Cells[9].Value = PrvKG;
                DGFM.Rows[4].Cells[11].Value = Time;
                DGFM.Rows[4].Cells[7].Value = FillCount;
                DGFM.Rows[4].Cells[10].Value = Rate;
                //lblFCA3.Text = Convert.ToString(val16);


                if (FC1[2] + 1 == val16)
                {
                    InserDataintoDB("3", "3-A", Convert.ToInt16(val16), Convert.ToDecimal(DGFM.Rows[4].Cells[3].Value), Convert.ToDecimal(DGFM.Rows[4].Cells[2].Value), Convert.ToDecimal(DGFM.Rows[4].Cells[4].Value), Convert.ToDecimal(DGFM.Rows[4].Cells[5].Value), Convert.ToDecimal(DGFM.Rows[4].Cells[6].Value));
                    //InserDataintoDB("1", "1-B", Convert.ToInt16(val18), Convert.ToDecimal(lblKG1B.Text), Convert.ToDecimal(lblprice1B.Text), Convert.ToDecimal(lblRateB1.Text), Convert.ToDecimal(lblNRTB1.Text), Convert.ToDecimal(lblRTB1.Text));
                    FC1[2] = val16;
                    DGFM.Rows[4].Cells[2].Style.BackColor = Color.Black;
                    DGFM.Rows[4].Cells[3].Style.BackColor = Color.Black;
                    counter[1] = 0;

                    
                }
                if (DGFM.Rows[4].Cells[2].Value != "0000.00" && DGFM.Rows[4].Cells[2].Value != "0" && DGFM.Rows[4].Cells[2].Value != DGFM.Rows[4].Cells[8].Value)
                {
                    DGFM.Rows[4].Cells[2].Style.BackColor = Color.SteelBlue;
                    DGFM.Rows[4].Cells[3].Style.BackColor = Color.SteelBlue;
                }
                else
                {
                    DGFM.Rows[4].Cells[2].Style.BackColor = Color.Black;
                    DGFM.Rows[4].Cells[3].Style.BackColor = Color.Black;
                }

            }

            //+++++++++++++++++++++++++Side B +++++++++++++++++++++++++++++
            //For Val4
            if (val4 != null && val5 != null && val6 != null && val7 != null)
            {
                i = 0;
                i2 = 0;
                hexval = val4.ToString("X");
                if (hexval.Length == 3)
                {
                    hexval = "0" + hexval;
                }
                if (hexval.Length == 2)
                {
                    hexval = "00" + hexval;
                }
                if (hexval.Length == 1)
                {
                    hexval = "000" + hexval;
                }
                subst = hexval.Substring(2, 2);
                subst += hexval.Substring(0, 2);
                hexval = subst;
                subst = "";

                myArray = new string[hexval.Length];

                for (i = hexval.Length - 1; i2 < 4; i--)
                {

                    myArray[i] = hexval[i].ToString();

                    i2++;
                }
                if (myArray[hexval.Length - 4] == "A" || myArray[hexval.Length - 4] == "B" || myArray[hexval.Length - 4] == "C" || myArray[hexval.Length - 4] == "D" || myArray[hexval.Length - 4] == "E" || myArray[hexval.Length - 4] == "F")
                {
                    reg3B = "";
                }
                else
                {
                    reg3B = myArray[hexval.Length - 4].ToString();
                }
                if (myArray[hexval.Length - 3] == "A" || myArray[hexval.Length - 3] == "B" || myArray[hexval.Length - 3] == "C" || myArray[hexval.Length - 3] == "D" || myArray[hexval.Length - 3] == "E" || myArray[hexval.Length - 3] == "F")
                {
                    reg2B = "";
                }
                else
                {
                    reg2B = myArray[hexval.Length - 3].ToString();
                }

                if (myArray[hexval.Length - 2] == "A" || myArray[hexval.Length - 2] == "B" || myArray[hexval.Length - 2] == "C" || myArray[hexval.Length - 2] == "D" || myArray[hexval.Length - 2] == "E" || myArray[hexval.Length - 2] == "F")
                {
                    reg1B = "";
                }
                else
                {
                    reg1B = myArray[hexval.Length - 2].ToString();
                }


                if (myArray[hexval.Length - 1] == "A" || myArray[hexval.Length - 1] == "B" || myArray[hexval.Length - 1] == "C" || myArray[hexval.Length - 1] == "D" || myArray[hexval.Length - 1] == "E" || myArray[hexval.Length - 1] == "F")
                {
                    reg0B = "";
                }
                else
                {
                    reg0B = myArray[hexval.Length - 1].ToString();
                }



                // For Val5
                i = 0;
                i2 = 0;
                hexval = val5.ToString("X");
                if (hexval.Length == 3)
                {
                    hexval = "0" + hexval;
                }
                if (hexval.Length == 2)
                {
                    hexval = "00" + hexval;
                }
                if (hexval.Length == 1)
                {
                    hexval = "000" + hexval;
                }
                subst = hexval.Substring(2, 2);
                subst += hexval.Substring(0, 2);
                hexval = subst;
                subst = "";
                myArray = new string[hexval.Length];

                for (i = hexval.Length - 1; i2 < 4; i--)
                {

                    myArray[i] = hexval[i].ToString();

                    i2++;
                }
                if (myArray[hexval.Length - 4] == "A" || myArray[hexval.Length - 4] == "B" || myArray[hexval.Length - 4] == "C" || myArray[hexval.Length - 4] == "D" || myArray[hexval.Length - 4] == "E" || myArray[hexval.Length - 4] == "F")
                {
                    reg7B = "";
                }
                else
                {
                    reg7B = myArray[hexval.Length - 4].ToString();
                }
                if (myArray[hexval.Length - 3] == "A" || myArray[hexval.Length - 3] == "B" || myArray[hexval.Length - 3] == "C" || myArray[hexval.Length - 3] == "D" || myArray[hexval.Length - 3] == "E" || myArray[hexval.Length - 3] == "F")
                {
                    reg6B = "";
                }
                else
                {
                    reg6B = myArray[hexval.Length - 3].ToString();
                }

                if (myArray[hexval.Length - 2] == "A" || myArray[hexval.Length - 2] == "B" || myArray[hexval.Length - 2] == "C" || myArray[hexval.Length - 2] == "D" || myArray[hexval.Length - 2] == "E" || myArray[hexval.Length - 2] == "F")
                {
                    reg5B = "";
                }
                else
                {
                    reg5B = myArray[hexval.Length - 2].ToString();
                }


                if (myArray[hexval.Length - 1] == "A" || myArray[hexval.Length - 1] == "B" || myArray[hexval.Length - 1] == "C" || myArray[hexval.Length - 1] == "D" || myArray[hexval.Length - 1] == "E" || myArray[hexval.Length - 1] == "F")
                {
                    reg4B = "";
                }
                else
                {
                    reg4B = myArray[hexval.Length - 1].ToString();
                }


                //For Val6
                i = 0;
                i2 = 0;
                hexval = val6.ToString("X");
                if (hexval.Length == 3)
                {
                    hexval = "0" + hexval;
                }
                if (hexval.Length == 2)
                {
                    hexval = "00" + hexval;
                }
                if (hexval.Length == 1)
                {
                    hexval = "000" + hexval;
                }
                subst = hexval.Substring(2, 2);
                subst += hexval.Substring(0, 2);
                hexval = subst;
                subst = "";
                myArray = new string[hexval.Length];

                for (i = hexval.Length - 1; i2 < 4; i--)
                {

                    myArray[i] = hexval[i].ToString();

                    i2++;
                }

                if (myArray[hexval.Length - 4] == "A" || myArray[hexval.Length - 4] == "B" || myArray[hexval.Length - 4] == "C" || myArray[hexval.Length - 4] == "D" || myArray[hexval.Length - 4] == "E" || myArray[hexval.Length - 4] == "F")
                {
                    reg11B = "";
                }
                else
                {
                    reg11B = myArray[hexval.Length - 4].ToString();
                }
                if (myArray[hexval.Length - 3] == "A" || myArray[hexval.Length - 3] == "B" || myArray[hexval.Length - 3] == "C" || myArray[hexval.Length - 3] == "D" || myArray[hexval.Length - 3] == "E" || myArray[hexval.Length - 3] == "F")
                {
                    reg10B = "";
                }
                else
                {
                    reg10B = myArray[hexval.Length - 3].ToString();
                }

                if (myArray[hexval.Length - 2] == "A" || myArray[hexval.Length - 2] == "B" || myArray[hexval.Length - 2] == "C" || myArray[hexval.Length - 2] == "D" || myArray[hexval.Length - 2] == "E" || myArray[hexval.Length - 2] == "F")
                {
                    reg9B = "";
                }
                else
                {
                    reg9B = myArray[hexval.Length - 2].ToString();
                }


                if (myArray[hexval.Length - 1] == "A" || myArray[hexval.Length - 1] == "B" || myArray[hexval.Length - 1] == "C" || myArray[hexval.Length - 1] == "D" || myArray[hexval.Length - 1] == "E" || myArray[hexval.Length - 1] == "F")
                {
                    reg8B = "";
                }
                else
                {
                    reg8B = myArray[hexval.Length - 1].ToString();
                }

                //For Val7
                i = 0;
                i2 = 0;
                hexval = val7.ToString("X");
                if (hexval.Length == 3)
                {
                    hexval = "0" + hexval;
                }
                if (hexval.Length == 2)
                {
                    hexval = "00" + hexval;
                }
                if (hexval.Length == 1)
                {
                    hexval = "000" + hexval;
                }
                subst = hexval.Substring(2, 2);
                subst += hexval.Substring(0, 2);
                hexval = subst;
                subst = "";
                myArray = new string[hexval.Length];

                for (i = hexval.Length - 1; i2 < 4; i--)
                {

                    myArray[i] = hexval[i].ToString();

                    i2++;
                }


                if (myArray[hexval.Length - 4] == "A" || myArray[hexval.Length - 4] == "B" || myArray[hexval.Length - 4] == "C" || myArray[hexval.Length - 4] == "D" || myArray[hexval.Length - 4] == "E" || myArray[hexval.Length - 4] == "F")
                {
                    reg15B = "";
                }
                else
                {
                    reg15B = myArray[hexval.Length - 4].ToString();
                }
                if (myArray[hexval.Length - 3] == "A" || myArray[hexval.Length - 3] == "B" || myArray[hexval.Length - 3] == "C" || myArray[hexval.Length - 3] == "D" || myArray[hexval.Length - 3] == "E" || myArray[hexval.Length - 3] == "F")
                {
                    reg14B = "";
                }
                else
                {
                    reg14B = myArray[hexval.Length - 3].ToString();
                }

                if (myArray[hexval.Length - 2] == "A" || myArray[hexval.Length - 2] == "B" || myArray[hexval.Length - 2] == "C" || myArray[hexval.Length - 2] == "D" || myArray[hexval.Length - 2] == "E" || myArray[hexval.Length - 2] == "F")
                {
                    reg13B = "";
                }
                else
                {
                    reg13B = myArray[hexval.Length - 2].ToString();
                }


                if (myArray[hexval.Length - 1] == "A" || myArray[hexval.Length - 1] == "B" || myArray[hexval.Length - 1] == "C" || myArray[hexval.Length - 1] == "D" || myArray[hexval.Length - 1] == "E" || myArray[hexval.Length - 1] == "F")
                {
                    reg12B = "";
                }
                else
                {
                    reg12B = myArray[hexval.Length - 1].ToString();
                }

                priceB = reg13B + "" + reg12B + "" + reg15B + "" + reg5B + "." + reg6B + "" + reg7B;
                KGB = reg14B + "" + reg9B + "" + reg8B + "" + reg1B + "" + "." + reg3B + "" + reg4B;
                RateB = reg10B + "" + reg11B + "." + reg2B + "" + reg0B;
                DGFM.Rows[5].Cells[2].Value = priceB;
                DGFM.Rows[5].Cells[3].Value = KGB;
                DGFM.Rows[5].Cells[4].Value = RateB;


                //Val12,13
                if (val12 < 0)
                {

                    tempval = val12 + 65536;
                }

                if (tempval > 0)
                {
                    RTB = (65536 * val13) + tempval;
                }
                else
                {
                    RTB = (65536 * val13) + val12;
                }
                tempval = 0;

                TB1 = Convert.ToDecimal(RTB);
                TB2 = TB1 / 100;
                DGFM.Rows[5].Cells[6].Value   = Convert.ToString(TB2);


                if (val14 < 0)
                {

                    tempval = val14 + (65536);

                }
                if (tempval > 0)
                {
                    NRTB = (65536 * val15) + tempval;

                }
                else
                {
                    NRTB = (65536 * val15) + val14;
                }
                tempval = 0;
                TNB1 = Convert.ToDecimal(NRTB);
                TNB2 = TNB1 / 100;
                DGFM.Rows[5].Cells[5].Value = Convert.ToString(TNB2);
                PrvKG = "0";
                PrvRS = "0";
                Time = "0";
                Rate = "0";
                FillCount = "0";
                selectperviousrecord("3-B");
                DGFM.Rows[5].Cells[8].Value = PrvRS;
                DGFM.Rows[5].Cells[9].Value = PrvKG;
                DGFM.Rows[5].Cells[11].Value = Time;
                DGFM.Rows[5].Cells[7].Value = FillCount;
                DGFM.Rows[5].Cells[10].Value = Rate;
                //lblFCB3.Text = Convert.ToString(val18);


                if (FC2[2] + 1 == val18)
                {
                    InserDataintoDB("3", "3-B", Convert.ToInt16(val16), Convert.ToDecimal(DGFM.Rows[5].Cells[3].Value), Convert.ToDecimal(DGFM.Rows[5].Cells[2].Value), Convert.ToDecimal(DGFM.Rows[5].Cells[4].Value), Convert.ToDecimal(DGFM.Rows[5].Cells[5].Value), Convert.ToDecimal(DGFM.Rows[5].Cells[6].Value));
                    //InserDataintoDB("1", "1-B", Convert.ToInt16(val18), Convert.ToDecimal(lblKG1B.Text), Convert.ToDecimal(lblprice1B.Text), Convert.ToDecimal(lblRateB1.Text), Convert.ToDecimal(lblNRTB1.Text), Convert.ToDecimal(lblRTB1.Text));
                    FC2[2] = val18;
                    DGFM.Rows[5].Cells[2].Style.BackColor = Color.Black;
                    DGFM.Rows[5].Cells[3].Style.BackColor = Color.Black;
                    counter[1] = 0;

                   
                }
                if (DGFM.Rows[5].Cells[2].Value != "0000.00" && DGFM.Rows[5].Cells[2].Value != "0" && DGFM.Rows[5].Cells[2].Value != DGFM.Rows[5].Cells[8].Value)
                {
                    DGFM.Rows[5].Cells[2].Style.BackColor = Color.SteelBlue;
                    DGFM.Rows[5].Cells[3].Style.BackColor = Color.SteelBlue;
                }
                else
                {
                    DGFM.Rows[5].Cells[2].Style.BackColor = Color.Black;
                    DGFM.Rows[5].Cells[3].Style.BackColor = Color.Black;
                }
            }



            //label1.Text=(val0.ToString() + "," + val1.ToString() + "," + val2.ToString() + "," + val3.ToString() + "," + val4.ToString() + "," + val5.ToString() + "," + val6.ToString() + "," + val7.ToString());
            // wsmbsControl1.Close();
        }

        private void selectperviousrecord(string side)
        {

            using (FuelMonitoring.FuelMDataContext context = new FuelMonitoring.FuelMDataContext())
            {



                var maxid = (from mid in context.FillReadingDatas
                             where mid.Slaveside == side
                             select (mid.FillID)).Max();
                //  MessageBox.Show(maxid.ToString());
                var FillRead = from FR in context.FillReadingDatas
                               where FR.FillID == maxid
                               select FR;

                if (FillRead.Any())
                {
                    foreach (var objedata in FillRead)
                    {
                        PrvKG = objedata.KG.ToString();
                        PrvRS = objedata.Price.ToString();
                        Time = objedata.FillDate;
                        FillCount = objedata.Fillcounter.ToString();
                        Rate = objedata.Rate.ToString();
                    }
                }






            }



        }
        private void InserDataintoDB(string Slaveid, string SlaveSide, int FC, decimal KG, decimal Price, decimal Rate, decimal NRtot, decimal RTot)
        {
            using (FuelMDataContext fd = new FuelMDataContext())
            {
                FillReadingData FRD = new FillReadingData();

                FRD.FillTime = System.DateTime.Now.ToLongTimeString();
                FRD.FillDate = System.DateTime.Now.ToString();
                FRD.Slaveno = Slaveid;
                FRD.Slaveside = SlaveSide;
                FRD.Fillcounter = FC;
                FRD.KG = KG;
                FRD.Price = Price;
                FRD.Rate = Rate;
                FRD.NonResetTot = NRtot;
                FRD.ResetableTot = RTot;
                fd.FillReadingDatas.InsertOnSubmit(FRD);
                fd.SubmitChanges();


            }

        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            //Int16[] Registers = new Int16[20];
            //WSMBS.Result Result;
            //timer2.Tick += new EventHandler(timer2_Tick);
            //timer2.Interval = 60000;
            //timer2.Enabled = true;
            //timer2.Start();
           // CurrentTime.Text = DateTime.Now.ToString("dd-MM-yyyy hh:mm:ss");
            OK();
            //   timer2.Stop();
            //Result = wsmbsControl1.ReadHoldingRegisters(1, 0, 20, Registers);
            //if (Result != WSMBS.Result.SUCCESS)
            //{
            //    chkside1.Checked = false;
            //}
            //else
            //{
            //    chkside1.Checked = true;
            //}
            //chkside1.Checked = false;
            //    if (chkside1.Checked)
            //    {
            //        ReadRegData();
            //        System.Threading.Thread.Sleep(25);
            //        timer1.Stop();
            //        timer1.Start();
            //    }


            // Result = wsmbsControl1.ReadHoldingRegisters(2, 0, 20, Registers);
            // if (Result != WSMBS.Result.SUCCESS)
            // {
            //     chkside2.Checked = false;
            // }
            // else
            // {
            //     chkside2.Checked = true;
            // }
            //     if (chkside2.Checked)
            //     {
            //         ReadRegDataSide2();
            //         System.Threading.Thread.Sleep(25);
            //         timer1.Stop();
            //         timer1.Start();

            //     }

            //Result = wsmbsControl1.ReadHoldingRegisters(3, 0, 20, Registers);
            //if (Result != WSMBS.Result.SUCCESS)
            //{
            //    chkside3.Checked = false;
            //}
            //else
            //{
            //    chkside3.Checked = true;
            //}
            //    if (chkside3.Checked)
            //    {
            //        ReadRegDataSide3();
            //        System.Threading.Thread.Sleep(25);
            //        timer1.Stop();
            //        timer1.Start();

            //    }

            //System.Threading.Thread.Sleep(25);
            //timer1.Stop();
            //ReadRegDataSide3();
            //timer1.Start();
            //ReadRegDataSide4();
            // ReadRegDataSide5();
            //ReadRegDataSide6();
            //ReadRegDataSide7();
            //ReadRegDataSide8();
            //ReadRegDataSide9();
            //ReadRegDataSide10();
            //ReadRegDataSide11();
            //ReadRegDataSide12();
            //ReadRegDataSide13();
            //ReadRegDataSide14();
            //ReadRegDataSide15();
            //ReadRegDataSide16();

        }

        public void OK()
        {


            Int16[] Registers = new Int16[20];
            WSMBS.Result Result;
            if (Convert.ToBoolean(DGFM.Rows[0].Cells[0].Value) != false)
            {
                Result = wsmbsControl1.ReadHoldingRegisters(1, 0, 20, Registers);
                if (Result == WSMBS.Result.SUCCESS)
                {
                    //timer1.Start();
                    ReadRegData();
                    System.Threading.Thread.Sleep(25);
                    timer1.Stop();
                    timer1.Start();


                }
                else
                {
                    DGFM.Rows[0].Cells[0].Value = false;
                }
                


            }
         
            //if (chkside2.Checked)
            //{
            //    Result = wsmbsControl1.ReadHoldingRegisters(2, 0, 20, Registers);
            //    if (Result == WSMBS.Result.SUCCESS)
            //    {
            //        ReadRegDataSide2();
            //        System.Threading.Thread.Sleep(25);
            //        timer1.Stop();
            //        timer1.Start();


            //    }
            //    else
            //    {


            //        chkside2.Checked = false;
            //        FC1[1] = 0;
            //        FC2[1] = 0;
            //        counter[1] = 0;

            //    }
            //}



            //if (chkside3.Checked)
            //{
            //    Result = wsmbsControl1.ReadHoldingRegisters(3, 0, 20, Registers);
            //    if (Result == WSMBS.Result.SUCCESS)
            //    {

            //        ReadRegDataSide3();
            //        System.Threading.Thread.Sleep(25);
            //        timer1.Stop();
            //        timer1.Start();
            //    }
            //    else
            //    {

            //        chkside3.Checked = false;
            //        FC1[2] = 0;
            //        FC2[2] = 0;
            //        counter[2] = 0;
            //    }
            //}


        }
        
        private void FrmDataView_Load(object sender, EventArgs e)
        {
           
      General();
            //MessageBox.Show("FALS");
            frmFuelmonitoring fm = new frmFuelmonitoring();
            fm.Size = new System.Drawing.Size(300, 600);
            WSMBS.Result Result;
            wsmbsControl1.LicenseKey(WSMBS_KEY);
            wsmbsControl1.Mode = WSMBS.Mode.RTU;
            wsmbsControl1.PortName = "COM1";
            wsmbsControl1.BaudRate = 38400;
            wsmbsControl1.StopBits = 1;
            wsmbsControl1.Parity = WSMBS.Parity.Even;
            wsmbsControl1.ResponseTimeout = 1000;




            Result = wsmbsControl1.Open();
            if (Result == WSMBS.Result.SUCCESS)
            {
                System.Threading.Thread.Sleep(25);
                timer2.Stop();
                
                timer1.Tick += new EventHandler(timer1_Tick);
                timer1.Interval = 20;
                timer1.Enabled = true;
                timer1.Start();
            }
            if (Result == WSMBS.Result.SUCCESS)
            {
                System.Threading.Thread.Sleep(25);
                timer1.Stop();
               
                timer2.Tick += new EventHandler(timer2_Tick);
                timer2.Interval = 2000;
                timer2.Enabled = true;
                timer2.Start();
            }
           // dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.GreenYellow;
            DGFM.EnableHeadersVisualStyles = false; 
            DGFM.Rows.Add(31);
            //DGFM.Rows[0].Cells[0].Value = true;
           // dataGridView1.Rows[0].Cells[0].Size.Height=System.;
           
        }
        void General()
        {

            //DGFM.Rows[0].Cells[1].Style.BackColor = Color.GreenYellow;
            //DGFM.Rows[1].Cells[1].Style.BackColor = Color.GreenYellow;
            //DGFM.Rows[2].Cells[1].Style.BackColor = Color.GreenYellow;
            //DGFM.Rows[3].Cells[1].Style.BackColor = Color.GreenYellow;
            //DGFM.Rows[4].Cells[1].Style.BackColor = Color.GreenYellow;
            //DGFM.Rows[5].Cells[1].Style.BackColor = Color.GreenYellow;
            //DGFM.Rows[6].Cells[1].Style.BackColor = Color.GreenYellow;
            //DGFM.Rows[7].Cells[1].Style.BackColor = Color.GreenYellow;
            //DGFM.Rows[8].Cells[1].Style.BackColor = Color.GreenYellow;
            //DGFM.Rows[9].Cells[1].Style.BackColor = Color.GreenYellow;
            //DGFM.Rows[10].Cells[1].Style.BackColor = Color.GreenYellow;
            //DGFM.Rows[11].Cells[1].Style.BackColor = Color.GreenYellow;
            DGFM.Rows[0].Cells[1].Value = "1-A";
            //DGFM.Rows[1].Cells[1].Value = "1-B";
            //DGFM.Rows[2].Cells[1].Value = "2-A";
            //DGFM.Rows[3].Cells[1].Value = "2-B";
            //DGFM.Rows[4].Cells[1].Value = "3-A";
            //DGFM.Rows[5].Cells[1].Value = "3-B";
            //DGFM.Rows[6].Cells[1].Value = "4-A";
            //DGFM.Rows[7].Cells[1].Value = "4-B";
            //DGFM.Rows[8].Cells[1].Value = "5-A";
            //DGFM.Rows[9].Cells[1].Value = "5-B";
            //DGFM.Rows[10].Cells[1].Value = "6-A";
            //DGFM.Rows[11].Cells[1].Value = "6-B";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DGFM.Rows[0].Cells[0].Value = true;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            Int16[] Registers = new Int16[20];
            WSMBS.Result Result;
            if (Convert.ToBoolean(DGFM.Rows[0].Cells[0].Value) == false)
            {
                Result = wsmbsControl1.ReadHoldingRegisters(1, 0, 20, Registers);
                if (Result == WSMBS.Result.SUCCESS)
                {
                    System.Threading.Thread.Sleep(25);
                    timer2.Stop();
                    timer2.Start();

                    DGFM.Rows[0].Cells[0].Value = true;
                   
                }


                }
        }

       
    }
}
