using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
//using System.Threading;
using WSMBS;
using System.Configuration;


namespace FuelMonitoring
{
    public partial class frmFuelmonitoring : Form
    {
      
        GenralStorage GS = new GenralStorage();
        string subst, PrvRS, PrvKG, Rate, FillCount;
        string Time,Slaveside;
        int RT, NRT, RTB, NRTB;
        int i2=0;
        int i=0;
        int[] FC1 =new int[16];
        int[] FC2 =new int[16];
        int  FCDB1, FCDB2;
        int  C2;
      
        int[] counter=new int[16] ;
        int tempcount1,tempcount2,tempcount3;
        int count,count1,count2;
        decimal TA1, TA2, TB1, TB2, TNA1, TNA2, TNB1, TNB2;
        int tempval,tempvalh;
        string WSMBS_KEY = "70AB-9CE4-736B-7DD4-174F-3417";
        static Timer _timer; // From System.Timers
        static List<DateTime> _l; // Stores timer results
        
        static string strCon = ConfigurationManager.ConnectionStrings["FM"].ConnectionString;

        public frmFuelmonitoring()
        {
            InitializeComponent();
           
           // btnconnect.Click += new EventHandler(btnconnect_Click);
           //Application.Run(new FrmDataView);
          // timer1.Tick+= new EventHandler(timer1_Tick);
          
            
           // Enable the timer
           
            //label.Location = new Point(100, 100);
            ////label.AutoSize = true;
            ////label.Text = String.Empty;
            
            //this.Controls.Add(label1);
        }









        void Gen_ReadRegData(byte slaveid)
        {

            Int16[] Registers = new Int16[22];
            WSMBS.Result Result;
            Result = wsmbsControl1.ReadHoldingRegisters(slaveid, 0, 22, Registers);
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
            Int16 val20 = Convert.ToInt16(Registers[20]);//serialno
            Int16 val21 = Convert.ToInt16(Registers[21]);//serialno
            if (slaveid == 1)
            {
                if (counter[0] == 0)
                {
                    FC1[0] = val16;
                    FC2[0] = val18;

                    //lbl

                    counter[0] += 1;
                }
            }

            if (slaveid == 2)
            {
                if (counter[1] == 0)
                {
                    FC1[1] = val16;
                    FC2[1] = val18;

                    //lbl

                    counter[1] += 1;
                }
            }
            if (slaveid == 3)
            {
                if (counter[2] == 0)
                {
                    FC1[2] = val16;
                    FC2[2] = val18;

                    //lbl

                    counter[2] += 1;
                }
            }
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
                
               
                GS.KGA = GS.reg14 + "" + GS.reg9 + "" + GS.reg8 + "" + GS.reg1 + "." + GS.reg3 + "" + GS.reg4;
              
                GS.RateA = GS.reg10 + "" + GS.reg11 + "." + GS.reg2 + "" + GS.reg0;
               
                if (slaveid == 1)
                {
                    lblPrice1A.Text = GS.priceA;
                    lblKG1A.Text = GS.KGA;
                    lblRatA1.Text = GS.RateA;
                }
                if (slaveid == 2)
                {
                    lblprice2A.Text = GS.priceA;
                    lblKG2A.Text = GS.KGA;
                    lblRatA2.Text = GS.RateA;
                }
                if (slaveid == 3)
                {
                    lblprice3A.Text = GS.priceA;
                    lblKG3A.Text = GS.KGA;
                    lblRatA3.Text = GS.RateA;
                }
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
                if (slaveid == 1)
                {

                    lblRT1A.Text = Convert.ToString(TA2);
                }
                if (slaveid == 2)
                {
                
                    lblRTA2.Text = Convert.ToString(TA2);
                }
                if (slaveid == 3)
                {

                    lblRTA3.Text = Convert.ToString(TA2);
                }
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
                if (slaveid == 1)
                {

                    lblNRTA1.Text = Convert.ToString(TNA2);
                }
                if (slaveid == 2)
                {
                    lblNRTA2.Text = Convert.ToString(TNA2);
                }
                if (slaveid == 3)
                {
                    lblNRTA3.Text = Convert.ToString(TNA2);
                }
                //lblFCA1.Text = Convert.ToString(val16);
                PrvKG = "0";
                PrvRS = "0";
                Time = "0";
                Rate = "0";
                FillCount = "0";
                if (slaveid == 1)
                {
                    Slaveside = "1-A";
                }
                else if (slaveid == 2)
                {
                    Slaveside = "2-A";
                }
                else if (slaveid == 3)
                {
                    Slaveside = "3-A";
                }
                
                selectperviousrecord(Slaveside);
                if (slaveid == 1)
                {

                    lblPrvprice1A.Text = PrvRS;
                    lblPrvKG1A.Text = PrvKG;
                    lblTime1A.Text = Time;
                    lblFCA1.Text = FillCount;
                    lblLastRat1A.Text = Rate;
                }
                if (slaveid == 2)
                {

                    lblPrvprice2A.Text = PrvRS;
                    lblPrvKG2A.Text = PrvKG;
                    lblTimeA2.Text = Time;
                    lblFCA2.Text = FillCount;
                    lblLastRat2A.Text = Rate;
                }
                if (slaveid == 3)
                {

                    lblPrvprice3A.Text = PrvRS;
                    lblPrvKG3A.Text = PrvKG;
                    lblTimeA3.Text = Time;
                    lblFCA3.Text = FillCount;
                    lblLastRat3A.Text = Rate;
                }
                selectSerialno(Slaveside,val20,Convert.ToInt16(FillCount));
                if (slaveid == 1)
                {
                    if (FC1[0] + 1 == val16)
                    {
                        InserDataintoDB(slaveid.ToString(), "1-A", Convert.ToInt16(val16), Convert.ToDecimal(GS.KGA), Convert.ToDecimal(GS.priceA), Convert.ToDecimal(GS.RateA), Convert.ToDecimal(TNA2), Convert.ToDecimal(TA2), val20);
                        FC1[0] = val16;
                        counter[0] = 0;
                        lblPrice1A.BackColor = Color.Black;
                        lblKG1A.BackColor = Color.Black;
                    }
                    //if (Convert.ToInt16(FillCount) < val16)
                    //{
                    //    InserDataintoDB(slaveid.ToString(), Slaveside.ToString(), Convert.ToInt16(val16), Convert.ToDecimal(GS.KGA), Convert.ToDecimal(GS.priceA), Convert.ToDecimal(GS.RateA), Convert.ToDecimal(TNA2), Convert.ToDecimal(TA2), val20);
                    //    FC1[0] = val16;
                    //    counter[0] = 0;
                    //    lblPrice1A.BackColor = Color.Black;
                    //    lblKG1A.BackColor = Color.Black;
                    //}
                }
                if (slaveid == 2)
                {
                    if (FC1[1] + 1 == val16)
                    {
                        InserDataintoDB(slaveid.ToString(),"2-A", Convert.ToInt16(val16), Convert.ToDecimal(GS.KGA), Convert.ToDecimal(GS.priceA), Convert.ToDecimal(GS.RateA), Convert.ToDecimal(TNA2), Convert.ToDecimal(TA2), val20);
                        FC1[1] = val16;
                        counter[1] = 0;
                        lblPrice1A.BackColor = Color.Black;
                        lblKG1A.BackColor = Color.Black;
                    }
                    //if (Convert.ToInt16(FillCount) < val16)
                    //{
                    //    InserDataintoDB(slaveid.ToString(), Slaveside.ToString(), Convert.ToInt16(val16), Convert.ToDecimal(GS.KGA), Convert.ToDecimal(GS.priceA), Convert.ToDecimal(GS.RateA), Convert.ToDecimal(TNA2), Convert.ToDecimal(TA2), val20);
                    //    FC1[1] = val16;
                    //    counter[1] = 0;
                    //    lblPrice1A.BackColor = Color.Black;
                    //    lblKG1A.BackColor = Color.Black;
                    //}
                }
                if (slaveid == 3)
                {
                    if (FC1[2] + 1 == val16)
                    {
                        InserDataintoDB(slaveid.ToString(), "3-A", Convert.ToInt16(val16), Convert.ToDecimal(GS.KGA), Convert.ToDecimal(GS.priceA), Convert.ToDecimal(GS.RateA), Convert.ToDecimal(TNA2), Convert.ToDecimal(TA2), val20);
                        FC1[2] = val16;
                        counter[2] = 0;
                        lblPrice1A.BackColor = Color.Black;
                        lblKG1A.BackColor = Color.Black;
                    }
                    //if (Convert.ToInt16(FillCount) < val16)
                    //{
                    //    InserDataintoDB(slaveid.ToString(), Slaveside.ToString(), Convert.ToInt16(val16), Convert.ToDecimal(GS.KGA), Convert.ToDecimal(GS.priceA), Convert.ToDecimal(GS.RateA), Convert.ToDecimal(TNA2), Convert.ToDecimal(TA2), val20);
                    //    FC1[2] = val16;
                    //    counter[2] = 0;
                    //    lblPrice1A.BackColor = Color.Black;
                    //    lblKG1A.BackColor = Color.Black;
                    //}
                }
                if (lblPrice1A.Text != "0000.00" && lblPrice1A.Text != "0" && lblPrice1A.Text != lblPrvprice1A.Text)
                {
                    lblPrice1A.BackColor = Color.SteelBlue;
                    lblKG1A.BackColor = Color.SteelBlue;
                }
                else
                {
                    lblPrice1A.BackColor = Color.Black;
                    lblKG1A.BackColor = Color.Black;
                }
                if (lblprice2A.Text != "0000.00" && lblprice2A.Text != "0" && lblprice2A.Text != lblPrvprice2A.Text)
                {
                    lblprice2A.BackColor = Color.SteelBlue;
                    lblKG2A.BackColor = Color.SteelBlue;
                }
                else
                {
                    lblprice2A.BackColor = Color.OliveDrab;
                    lblKG2A.BackColor = Color.OliveDrab;
                }
                if (lblprice3A.Text != "0000.00" && lblprice3A.Text != "0" && lblprice3A.Text != lblPrvprice3A.Text)
                {
                    lblprice3A.BackColor = Color.SteelBlue;
                    lblKG3A.BackColor = Color.SteelBlue;
                }
                else
                {
                    lblprice3A.BackColor = Color.Black;
                    lblKG3A.BackColor = Color.Black;
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
                if (slaveid == 1)
                {

                    lblprice1B.Text = GS.priceB;
                    lblKG1B.Text = GS.KGB;
                    lblRateB1.Text = GS.RateB;
                }
                if (slaveid == 2)
                {
                    lblprice2B.Text = GS.priceB;
                    lblKG2B.Text = GS.KGB;
                    lblRatB2.Text = GS.RateB;
                }
                if (slaveid == 3)
                {
                    lblprice3B.Text = GS.priceB;
                    lblKG3B.Text = GS.KGB;
                    lblRatB3.Text = GS.RateB;
                }
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
                if (slaveid == 1)
                {

                    lblRTB1.Text = Convert.ToString(TB2);
                }
                if (slaveid == 2)
                {
                    lblRTB2.Text = Convert.ToString(TB2);
                }
                if (slaveid == 3)
                {
                    lblRTB3.Text = Convert.ToString(TB2);
                }
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
                if (slaveid == 1)
                {

                    lblNRTB1.Text = Convert.ToString(TNB2);
                }
                if (slaveid == 2)
                {
                    lblNRTB2.Text = Convert.ToString(TNB2);

                }
                if (slaveid == 3)
                {
                    lblNRTB3.Text = Convert.ToString(TNB2);

                }


                //lblFCB1.Text = Convert.ToString(val18);
                PrvKG = "0";
                PrvRS = "0";
                Time = "0";
                Rate = "0";
                FillCount = "0";
                if (slaveid == 1)
                {
                    Slaveside = "1-B";
                }
                else if (slaveid == 2)
                {
                    Slaveside = "2-B";
                }
                else if (slaveid == 3)
                {
                    Slaveside = "3-B";
                }
                
                if (slaveid == 1)
                {
                    selectperviousrecord("1-B");
                    lblPrvprice1B.Text = PrvRS;
                    lblPrvKG1B.Text = PrvKG;
                    lblTimeB1.Text = Time;
                    lblLastRat1B.Text = Rate;
                    lblFCB1.Text = FillCount;
                }
              
                if (slaveid == 2)
                {
                    selectperviousrecord("2-B");
                    lblPrvprice2B.Text = PrvRS;
                    lblPrvKG2B.Text = PrvKG;
                    lblTimeB2.Text = Time;
                    lblLastRat2B.Text = Rate;
                    lblFCB2.Text = FillCount;
                }
              
                if (slaveid == 3)
                {
                    selectperviousrecord("3-B");
                    lblPrvprice3B.Text = PrvRS;
                    lblPrvKG3B.Text = PrvKG;
                    lblTimeB3.Text = Time;
                    lblLastRat3B.Text = Rate;
                    lblFCB3.Text = FillCount;
                }
                selectSerialno(Slaveside, val20, Convert.ToInt16(FillCount));
                if (slaveid == 1)
                {
                    if (FC2[0] + 1 == val18)
                    {
                        InserDataintoDB(slaveid.ToString(), "1-B", Convert.ToInt16(val18), Convert.ToDecimal(GS.KGB), Convert.ToDecimal(GS.priceB), Convert.ToDecimal(GS.RateB), Convert.ToDecimal(TNB2), Convert.ToDecimal(TB2), val20);
                        FC2[0] = val18;
                        lblprice1B.BackColor = Color.Black;
                        lblKG1B.BackColor = Color.Black;
                    }
                    //if (Convert.ToInt16(FillCount) < val18)
                    //{
                    //    InserDataintoDB(slaveid.ToString(), Slaveside.ToString(), Convert.ToInt16(val18), Convert.ToDecimal(GS.KGB), Convert.ToDecimal(GS.priceB), Convert.ToDecimal(GS.RateB), Convert.ToDecimal(TNB2), Convert.ToDecimal(TB2), val21);
                    //    FC2[0] = val18;
                    //    lblprice1B.BackColor = Color.Black;
                    //    lblKG1B.BackColor = Color.Black;
                    //}
                }
                if (slaveid == 2)
                {
                    if (FC2[1] + 1 == val18)
                    {
                        InserDataintoDB(slaveid.ToString(), "2-B", Convert.ToInt16(val18), Convert.ToDecimal(GS.KGB), Convert.ToDecimal(GS.priceB), Convert.ToDecimal(GS.RateB), Convert.ToDecimal(TNB2), Convert.ToDecimal(TB2), val20);
                        FC2[1] = val18;
                        lblprice1B.BackColor = Color.Black;
                        lblKG1B.BackColor = Color.Black;
                    }
                    //if (Convert.ToInt16(FillCount) < val18)
                    //{
                    //    InserDataintoDB(slaveid.ToString(), Slaveside.ToString(), Convert.ToInt16(val18), Convert.ToDecimal(GS.KGB), Convert.ToDecimal(GS.priceB), Convert.ToDecimal(GS.RateB), Convert.ToDecimal(TNB2), Convert.ToDecimal(TB2), val21);
                    //    FC2[1] = val18;
                    //    lblprice1B.BackColor = Color.Black;
                    //    lblKG1B.BackColor = Color.Black;
                    //}
                }
                if (slaveid == 3)
                {
                    if (FC2[2] + 1 == val18)
                    {
                        InserDataintoDB(slaveid.ToString(), "3-B", Convert.ToInt16(val18), Convert.ToDecimal(GS.KGB), Convert.ToDecimal(GS.priceB), Convert.ToDecimal(GS.RateB), Convert.ToDecimal(TNB2), Convert.ToDecimal(TB2), val20);
                        FC2[2] = val18;
                        lblprice1B.BackColor = Color.Black;
                        lblKG1B.BackColor = Color.Black;
                    }
                    //if (Convert.ToInt16(FillCount) < val18)
                    //{
                    //    InserDataintoDB(slaveid.ToString(), Slaveside.ToString(), Convert.ToInt16(val18), Convert.ToDecimal(GS.KGB), Convert.ToDecimal(GS.priceB), Convert.ToDecimal(GS.RateB), Convert.ToDecimal(TNB2), Convert.ToDecimal(TB2), val21);
                    //    FC2[2] = val18;
                    //    lblprice1B.BackColor = Color.Black;
                    //    lblKG1B.BackColor = Color.Black;
                    //}
                }

                if (lblprice1B.Text != "0" && lblprice1B.Text != "0000.00" && lblprice1B.Text != lblPrvprice1B.Text)
                {
                    lblprice1B.BackColor = Color.SteelBlue;
                    lblKG1B.BackColor = Color.SteelBlue;
                }
                else
                {
                    lblprice1B.BackColor = Color.Black;
                    lblKG1B.BackColor = Color.Black;
                }
                if (lblprice2B.Text != "0" && lblprice2B.Text != "0000.00" && lblprice2B.Text != lblPrvprice2B.Text)
                {
                    lblprice2B.BackColor = Color.SteelBlue;
                    lblKG2B.BackColor = Color.SteelBlue;
                }
                else
                {
                    lblprice2B.BackColor = Color.OliveDrab;
                    lblKG2B.BackColor = Color.OliveDrab;
                }
                if (lblprice3B.Text != "0" && lblprice3B.Text != "0000.00" && lblprice3B.Text != lblPrvprice3B.Text)
                {
                    lblprice3B.BackColor = Color.SteelBlue;
                    lblKG3B.BackColor = Color.SteelBlue;
                }
                else
                {
                    lblprice3B.BackColor = Color.Black;
                    lblKG3B.BackColor = Color.Black;
                }
            }



            //label1.Text=(val0.ToString() + "," + val1.ToString() + "," + val2.ToString() + "," + val3.ToString() + "," + val4.ToString() + "," + val5.ToString() + "," + val6.ToString() + "," + val7.ToString());
            // wsmbsControl1.Close();
        }







        private void selectSerialno(string side, int serialno, int FC)
        {
            using (FuelMDataContext context = new FuelMDataContext(strCon))
            {
                var FillRead = from FR in context.CardMonitors

                               where FR.Slaveside == side && FR.Serialno == serialno && FR.Status == "ACTIVE"
                               select FR;

                if (FillRead.Any())
                {

                }
                else
                {
                    var FilRead = from FR in context.CardMonitors

                                  where FR.Slaveside == side && FR.Status == "ACTIVE"
                                   
                                   select FR;
                    if (FilRead.Any())
                    {
                        foreach (var objedata in FilRead)
                        {
                            int sno =Convert.ToInt32( objedata.Serialno);

                            var CM = from cam in context.CardMonitors
                                     where cam.Serialno == sno 
                                     select cam;
                            foreach (var ob in CM)
                            {
                                ob.Status = "DEACTIVE";
                                ob.DeActiveDate = DateTime.Now;
                                
                            }
                            context.SubmitChanges();
                        }
                        


                        
                    }
                    InsertCard(serialno, side, FC);

                }
            }
        }
       
        private void selectperviousrecord(string side)
        {
           
            using (FuelMDataContext context = new FuelMDataContext(strCon))
                {

                    //if (context.FillReadingDatas.Any())
                    //{
                    var CheckData = from data in context.FillReadingDatas
                                    where data.Slaveside == side
                                    select data;
                    if (CheckData.Any())
                    {
                        var maxid = (from mid in context.FillReadingDatas
                                     where mid.Slaveside == side
                                     select (mid.FillID)).Max();
                    
                  //  MessageBox.Show(maxid.ToString());
                    //new { a = c.CustomerID, b = c.Country } equals new 
                //{ a = o.CustomerID, b = "USA" }

                    // from o in dataContext.Orders.Where
                //(a => a.CustomerID == c.CustomerID || c.Country == "USA")
                    
                        var FillRead = from FR in context.FillReadingDatas
                                       //from Cm in context.CardMonitors.Where(a=>a.Slaveside==FR.Slaveside && FR.Serialno==a.Serialno) 
                                       where FR.FillID == maxid
                                       select FR;
                    
                    if (FillRead.Any())
                    {
                    foreach(var objedata in FillRead)
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
            
        
        
        }
        void InsertCard(int serialno,string slaveside,int FC)
        { 
        using (FuelMDataContext CM = new FuelMDataContext(strCon))
            {
                CardMonitor CAM = new CardMonitor();
                CAM.Serialno =serialno;
                CAM.Slaveside = slaveside;
            CAM.Fillcounter=FC;
            CAM.Datetime = DateTime.Now;
            CAM.Status = "ACTIVE";
            CM.CardMonitors.InsertOnSubmit(CAM);
            CM.SubmitChanges();
            }
        }
        private void InserDataintoDB(string Slaveid,string SlaveSide,int FC,decimal KG,decimal Price,decimal Rate,decimal NRtot,decimal RTot,int serialno)
        
{
            using (FuelMDataContext fd = new FuelMDataContext(strCon))
            {
                FillReadingData FRD = new FillReadingData();
              
                FRD.FillTime = DateTime.Now.ToLongTimeString();
                FRD.FillDate = DateTime.Now.ToString();
                FRD.Slaveno = Slaveid;
                FRD.Slaveside = SlaveSide;
                FRD.Fillcounter = FC;
                FRD.KG = KG;
                FRD.Price = Price;
                FRD.Rate = Rate;
                FRD.NonResetTot = NRtot;
                FRD.ResetableTot = RTot;
                FRD.Date = DateTime.Now;
                FRD.Serialno = serialno;
                fd.FillReadingDatas.InsertOnSubmit(FRD);
                fd.SubmitChanges();
                
            
            }
            
        
        }
        private void InsertCommError(int Counter, string Dispensor, DateTime date,string Status)
        {
            using (FuelMDataContext fd = new FuelMDataContext(strCon))
            {
                ErrorCommLog ECL = new ErrorCommLog();

                ECL.Counter = Counter;
                ECL.Dispensor = Dispensor;
                ECL.DateTime = date;
                ECL.Status = Status;
                fd.ErrorCommLogs.InsertOnSubmit(ECL);
                fd.SubmitChanges();
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            //Int16[] Registers = new Int16[20];
            //WSMBS.Result Result;
           // tempcount = 0;
            CurrentTime.Text = DateTime.Now.ToString("dd-MM-yyyy hh:mm:ss");
            OK();
           

        
      
            
        }

        public void OK()
        {
           
           
            Int16[] Registers = new Int16[22];
            WSMBS.Result Result;
            if (chkside1.Checked)
            {
                tempcount3 += 1;
                Result = wsmbsControl1.ReadHoldingRegisters(1, 0, 22, Registers);
                if (Result == WSMBS.Result.SUCCESS)
                {
                    if (count==0)
                    {
                        InsertCommError(tempcount3, "1", DateTime.Now, "ACTIVE");
                    }
                    
                    //timer1.Start();
                    Gen_ReadRegData(1);
                   // ReadRegData();
                    System.Threading.Thread.Sleep(5);
                    timer1.Stop();
                    timer1.Start();
                    count++;

                }
                else
                {
                    if (tempcount3>0)
                    {
                        InsertCommError(tempcount3, "1", DateTime.Now, "DEACTIVE");
                        count = 0;
                    }
                    
                    if (tempcount3 > 5)
                    {
                        
                       
                        chkside1.Checked = false;
                        FC1[0] = 0;
                        FC2[0] = 0;
                        counter[0] = 0;

                    }
                }

            }
          


            if (chkside2.Checked)
            {
                tempcount2 += 1;
                Result = wsmbsControl1.ReadHoldingRegisters(2, 0, 22, Registers);
                if (Result == WSMBS.Result.SUCCESS)
                {
                   // ReadRegDataSide2();
                    if (count1 == 0)
                    {
                        InsertCommError(tempcount2, "2", DateTime.Now, "ACTIVE");
                    }
                    Gen_ReadRegData(2);
                    System.Threading.Thread.Sleep(5);
                    timer1.Stop();
                    timer1.Start();
                    count1++;

                }
                else
                {
                    if (tempcount2 > 0)
                    {
                        InsertCommError(tempcount2, "2", DateTime.Now, "DEACTIVE");
                        count1 = 0;
                    }
                    if (tempcount2 > 5)
                    {
                        
                        chkside2.Checked = false;
                        FC1[1] = 0;
                        FC2[1] = 0;
                        counter[1] = 0;
                    }
                }
            }
           
            
            if (chkside3.Checked)
            {
                tempcount1 += 1;
                Result = wsmbsControl1.ReadHoldingRegisters(3, 0, 22, Registers);
                if (Result == WSMBS.Result.SUCCESS)
                {
                    if (count2 == 0)
                    {
                        InsertCommError(tempcount1, "3", DateTime.Now, "ACTIVE");
                    }
                    Gen_ReadRegData(3);
                    System.Threading.Thread.Sleep(5);
                    timer1.Stop();
                    timer1.Start();
                    count2++;
                }
                else
                {
                    if (tempcount1 > 0)
                    {
                        InsertCommError(tempcount1, "3", DateTime.Now, "DEACTIVE");
                        count2 = 0;
                    }
                    if (tempcount1 > 5)
                    {
                        
                        chkside3.Checked = false;
                        FC1[2] = 0;
                        FC2[2] = 0;
                        counter[2] = 0;
                    }
                }
            }
           
         


            }
        
          
         
            
    

        private void frmFuelmonitoring_Load(object sender, EventArgs e)
        {


            frmFuelmonitoring fm = new frmFuelmonitoring();
            fm.Size = new System.Drawing.Size(300, 600);
            WSMBS.Result Result;
            wsmbsControl1.LicenseKey(WSMBS_KEY);
            wsmbsControl1.Mode = WSMBS.Mode.RTU;
            wsmbsControl1.PortName = "COM1";
            wsmbsControl1.BaudRate = 38400;
            wsmbsControl1.StopBits = 1;
            wsmbsControl1.Parity = WSMBS.Parity.Even;
            wsmbsControl1.ResponseTimeout = 100;




            Result = wsmbsControl1.Open();
            if (Result == WSMBS.Result.SUCCESS)
            {
                //System.Threading.Thread.Sleep(25);
                //timer2.Stop();
                timer1.Tick += new EventHandler(timer1_Tick);
                timer1.Interval =5;
                timer1.Enabled = true;
                timer1.Start();
                //timer2.Start();
                timer2.Tick += new EventHandler(timer2_Tick);
                timer2.Interval = 20000;
                timer2.Enabled = true;
                timer2.Start();

                this.Controls.Add(label1);

                //ReadRegDataTemp();


            }
         


            
        }
        void autocheck()
        {
            Int16[] Registers = new Int16[20];
            WSMBS.Result Result;
            if (!chkside1.Checked || !chkside2.Checked || !chkside3.Checked)
            {
                Result = wsmbsControl1.ReadHoldingRegisters(1, 0, 20, Registers);
                if (Result == WSMBS.Result.SUCCESS)
                {
                    chkside1.Checked = true;
                }
                Result = wsmbsControl1.ReadHoldingRegisters(2, 0, 20, Registers);
                if (Result == WSMBS.Result.SUCCESS)
                {
                    chkside2.Checked = true;
                }
                Result = wsmbsControl1.ReadHoldingRegisters(3, 0, 20, Registers);
                if (Result == WSMBS.Result.SUCCESS)
                {
                    chkside3.Checked = true;
                }
                //timer2.Start();

            }
            if (!chkside2.Checked)
            {
                Result = wsmbsControl1.ReadHoldingRegisters(2, 0, 20, Registers);
                if (Result == WSMBS.Result.SUCCESS)
                {
                    chkside2.Checked = true;
                }
                //timer2.Stop();
                //timer2.Start();

            }
            if (!chkside3.Checked)
            {
                //tempcount += 1;
                //if (tempcount < 6)
                //{
                    Result = wsmbsControl1.ReadHoldingRegisters(3, 0, 20, Registers);
                    if (Result == WSMBS.Result.SUCCESS)
                    {
                        chkside3.Checked = true;
                    }
                    //timer2.Stop();
                    //timer2.Start();

                //}
            }
            //timer2.Stop();
            //timer1.Start();
            //OK();
        
        }
        private void timer2_Tick(object sender, EventArgs e)
        {
            Int16[] Registers = new Int16[20];
            WSMBS.Result Result;
            if (!chkside1.Checked || !chkside2.Checked || !chkside3.Checked)
            {
                Result = wsmbsControl1.ReadHoldingRegisters(1, 0, 20, Registers);
                if (Result == WSMBS.Result.SUCCESS)
                {
                    chkside1.Checked = true;
                    tempcount3 = 0;
                }
                System.Threading.Thread.Sleep(25);
                timer2.Stop();
                timer1.Start();
                //System.Threading.Thread.Sleep(25);
                Result = wsmbsControl1.ReadHoldingRegisters(2, 0, 20, Registers);
                if (Result == WSMBS.Result.SUCCESS)
                {
                    chkside2.Checked = true;
                    tempcount2 = 0;
                }
                System.Threading.Thread.Sleep(25);
                timer2.Stop();
                timer1.Start();
                Result = wsmbsControl1.ReadHoldingRegisters(3, 0, 20, Registers);
                if (Result == WSMBS.Result.SUCCESS)
                {
                    chkside3.Checked = true;
                    tempcount1 = 0;
                }
                System.Threading.Thread.Sleep(25);
                timer2.Stop();
                timer1.Start();
                timer2.Start();

            }
            //autocheck();
            
            //timer2.Stop();
            //timer2.Enabled = false;
            ////timer1.Interval = 20;
            ////timer1.Enabled = true;
            //timer1.Start();
            //timer1.Tick += new EventHandler(timer1_Tick);
           
           
            
           
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void lblFCB16_Click(object sender, EventArgs e)
        {

        }

        private void lblFCB10_Click(object sender, EventArgs e)
        {

        }

        private void lblPrvKG11A_Click(object sender, EventArgs e)
        {

        }

        private void lblPrvprice16A_Click(object sender, EventArgs e)
        {

        }

        private void lblTimeA16_Click(object sender, EventArgs e)
        {

        }

        private void lblTimeA13_Click(object sender, EventArgs e)
        {

        }

        private void lblTimeA14_Click(object sender, EventArgs e)
        {

        }

        private void lblTimeA12_Click(object sender, EventArgs e)
        {

        }

        private void lblRTB16_Click(object sender, EventArgs e)
        {

        }

        private void lblRTB12_Click(object sender, EventArgs e)
        {

        }

        private void lblRTA12_Click(object sender, EventArgs e)
        {

        }

        private void lblRTA11_Click(object sender, EventArgs e)
        {

        }

        private void lblRTA15_Click(object sender, EventArgs e)
        {

        }

        private void lblTimeB16_Click(object sender, EventArgs e)
        {

        }

        private void lblTimeB14_Click(object sender, EventArgs e)
        {

        }

        private void lblTimeB12_Click(object sender, EventArgs e)
        {

        }

        private void lblTimeB10_Click(object sender, EventArgs e)
        {

        }

        private void lblRTB14_Click(object sender, EventArgs e)
        {

        }

        private void lblNRTB16_Click(object sender, EventArgs e)
        {

        }

        private void lblNRTB15_Click(object sender, EventArgs e)
        {

        }

        private void lblNRTB14_Click(object sender, EventArgs e)
        {

        }

        private void lblNRTB13_Click(object sender, EventArgs e)
        {

        }

        private void lblPrvprice10B_Click(object sender, EventArgs e)
        {

        }

        private void lblLastRat10B_Click(object sender, EventArgs e)
        {

        }

        private void lblNRTB10_Click(object sender, EventArgs e)
        {

        }

        private void lblFCA16_Click(object sender, EventArgs e)
        {

        }

        private void lblPrvprice16B_Click(object sender, EventArgs e)
        {

        }

        private void lblPrvKG16B_Click(object sender, EventArgs e)
        {

        }

        private void lblTimeA15_Click(object sender, EventArgs e)
        {

        }

        private void lblNRTB12_Click(object sender, EventArgs e)
        {

        }

        private void lblNRTB11_Click(object sender, EventArgs e)
        {

        }

        private void lblLastRat16B_Click(object sender, EventArgs e)
        {

        }

        private void lblPrvKG10B_Click(object sender, EventArgs e)
        {

        }

        private void lblTimeA11_Click(object sender, EventArgs e)
        {

        }

        private void lblNRTA16_Click(object sender, EventArgs e)
        {

        }

        private void lblNRTA15_Click(object sender, EventArgs e)
        {

        }

        private void lblNRTA14_Click(object sender, EventArgs e)
        {

        }

        private void lblNRTA13_Click(object sender, EventArgs e)
        {

        }

        private void lblNRTA12_Click(object sender, EventArgs e)
        {

        }

        private void lblNRTA11_Click(object sender, EventArgs e)
        {

        }

        private void lblRTB15_Click(object sender, EventArgs e)
        {

        }

        private void lblTimeB15_Click(object sender, EventArgs e)
        {

        }

        private void lblTimeB13_Click(object sender, EventArgs e)
        {

        }

        private void lblTimeB11_Click(object sender, EventArgs e)
        {

        }

        private void lblRTA14_Click(object sender, EventArgs e)
        {

        }

        private void lblRTA13_Click(object sender, EventArgs e)
        {

        }

        private void lblLastRat11A_Click(object sender, EventArgs e)
        {

        }

        private void lblFCA11_Click(object sender, EventArgs e)
        {

        }

        private void lblRTB13_Click(object sender, EventArgs e)
        {

        }

        private void lblRTB10_Click(object sender, EventArgs e)
        {

        }

        private void lblRTB11_Click(object sender, EventArgs e)
        {

        }

        private void lblRTA16_Click(object sender, EventArgs e)
        {

        }

        private void lblPrvprice11A_Click(object sender, EventArgs e)
        {

        }

        private void lblFCB15_Click(object sender, EventArgs e)
        {

        }

  
   
      
       

      
    }
}
