using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace MachineForms
{
    public partial class MainForm : Form
    {
        int initNumStart = 0;
        int initNumEnd = 32;
        int times = 5;
        private int height = 350;
        private int width = 800;
        public Bitmap bitmap_temperature;
        public Bitmap bitmap_humidty;
        public Bitmap bitmap_illumination;
        public Bitmap bitmap_SoilHumidty;
        public Bitmap bitmap_Concentration;
        private Graphics graphics_temperature;
        private Graphics graphics_humidty;
        private Graphics graphics_illumination;
        private Graphics graphics_SoilHumidty;
        private Graphics graphics_Concentration;
        private float Tension = 0.5f;
        Pen PenRed = new Pen(Color.Red, 2);

        private float[] MeasureTemperature = new float[32];
        private float[] MeasureHumidty = new float[32];
        private float[] Measureillumination = new float[32];
        private float[] MeasureSoilHumidty = new float[32];
        private float[] MeasureConcentration = new float[32];

        public MainForm()
        {
            InitializeComponent();
            Random random = new Random();
            skinEngine1 = new Sunisoft.IrisSkin.SkinEngine(this)
            {
                SkinFile = Application.StartupPath + "//steelBlack.ssk"
            };
            for (int i = initNumStart; i < initNumEnd; i++)
            {
                MeasureTemperature[i] = Convert.ToSingle(random.Next(20, 30));
            }
            for (int i = initNumStart; i < initNumEnd; i++)
            {
                MeasureHumidty[i] = Convert.ToSingle(random.Next(20, 30));
            }
            for (int i = initNumStart; i < initNumEnd; i++)
            {
                Measureillumination[i] = Convert.ToSingle(random.Next(20, 30));
            }
            for (int i = initNumStart; i < initNumEnd; i++)
            {
                MeasureSoilHumidty[i] = Convert.ToSingle(random.Next(20, 30));
            }
            for (int i = initNumStart; i < initNumEnd; i++)
            {
                MeasureTemperature[i] = Convert.ToSingle(random.Next(20, 30));
            }
            ShowTemperature.Image = DrawTemperature(MeasureTemperature);
            ShowHumidty.Image = DrawHumidty(MeasureHumidty);
            Showillumination.Image = Drawillumination(Measureillumination);
            ShowSoilHumidty.Image = DrawSoilHumidty(MeasureSoilHumidty);
            ShowConcentration.Image = DrawConcentration(MeasureConcentration);
            Thread DrawPointAtOnce = new Thread(DrawOnePoint);
            Thread GetData = new Thread(GetDataByThreeSecond);
            DrawPointAtOnce.IsBackground = true;
            GetData.IsBackground = true;
            GetData.Start();
            DrawPointAtOnce.Start();
        }
        private void DrawOnePoint()
        {
            if(initNumStart == initNumEnd)
            {
                initNumStart = 0;
            }
            else if(initNumStart == 10)
            {
                this.Invoke((EventHandler)delegate {
                    ShowTemperature.Image = DrawTemperature(MeasureTemperature);
                    ShowHumidty.Image = DrawHumidty(MeasureHumidty);
                    Showillumination.Image = Drawillumination(Measureillumination);
                    ShowSoilHumidty.Image = DrawSoilHumidty(MeasureSoilHumidty);
                    ShowConcentration.Image = DrawConcentration(MeasureConcentration);
                });
                System.Threading.Thread.Sleep(1000);
            }    
        }
        private void GetDataByThreeSecond()
        {
            MySQLConnect mySQLConnect = new MySQLConnect();
            string sql_temperature = "select Temperature from AreaOne where CropID=0";
            string sql_humidity = "select Humidity from AreaOne where CropID=0";
            string sql_illumination = "select Illumination from AreaOne where CropID=0";
            string sql_soilhumidity = "select Soil_Humidity from AreaOne where CropID=0";
            string sql_concentration = "select Concentration from AreaOne where CropID=0";
            MeasureTemperature[initNumStart] = Convert.ToSingle(mySQLConnect.ExecuteQuery(sql_temperature));
            MeasureHumidty[initNumStart] = Convert.ToSingle(mySQLConnect.ExecuteQuery(sql_humidity));
            Measureillumination[initNumStart] = Convert.ToSingle(mySQLConnect.ExecuteQuery(sql_illumination));
            MeasureSoilHumidty[initNumStart] = Convert.ToSingle(mySQLConnect.ExecuteQuery(sql_soilhumidity));
            MeasureConcentration[initNumStart] = Convert.ToSingle(mySQLConnect.ExecuteQuery(sql_concentration));
            initNumStart++;
            System.Threading.Thread.Sleep(3000);
        }
        private Bitmap DrawTemperature(float[] Buffer)
        {
            bitmap_temperature = new Bitmap(width, height);
            graphics_temperature = Grephics.romHiage(bhtmap_temperatUre)�
    0    "  Font font = new FonTh"Arial", 9, FontStyle.Vegular);

            graphics_�emperature.FillRectangle(Brushms.WHiteSmok%( 0, 0, width,0heigh4);
 �  "       Brush brush1 = new SolidBrush(Color,Blud);
  !         Brush crush2 = new SolidB2ush(Color.SaddleBrown);
            Brush brushPoint = new SolidBrusi(Color.Red);M
         (  
           (Pen oypenBlack = new Te�(Color.Black, 1);
            gra0hkcs_tempuraTure.DrawRectangle(my�unBlack,"4, 40, 720, 272);
            graphics_temperature.DrawRecta�gle(my0enJlack, 40, 35, 720, 275);
            J            Pen mypenBlue = new Pen(Color.Blue,(1);
            Pen myrenRed 9 new"Pen Cohor/Red, 1);
       "    Pen mypeNYellow = new Pen(Color.Black, qi;

�         `$ift x = 80;
       $    For (int i = p9 i < 17; i++)
            {
  �     �       graphicS_temperature.DrasLine(mypenBlue- x, 40, x, 310);
                x = x + 40;
            }
  !         int y = 70;
  `         for (int i = 0; i < 8; i++)
            {
                graphics_temperature.DrawLine(mypenBlue, 40, y, 760, y);
                y = y + 30;
            }
            String[] n = { " 1", " 2", " 3", " 4", " 5", " 6", " 7", " 8", " 9", "10", "11", "12", "13", "14", "15", "16", "小时" };
            x = 70;
            for (int i = 0; i < 17; i++)
            {
                graphics_temperature.DrawString(n[i].ToString(), font, Brushes.Red, x, 315);
                x = x + 40;
            }
            String[] m = { "℃", "40", "35", "30", "25", "20", "15", "10", " 5" };
            y = 60;
            for (int i = 0; i < 8; i++)
            {
                graphics_temperature.DrawString(m[i].ToString(), font, Brushes.Red, 16, y);
                y = y + 30;
            }
            int len = Buffer.Length;
            PointF[] CurvePointF = new PointF[len];
            float pointX = 0;
            float pointY = 0;
            for (int i = 0; i < len; i++)
            {
                pointX = i * times * 4 + 80;
                pointY = 310 - 60 * (Buffer[i] / 10);
                CurvePointF[i] = new PointF(pointX, pointY);
                graphics_temperature.FillEllipse(brushPoint, pointX - 4, pointY - 4, 8, 8);
            }
            graphics_temperature.DrawCurve(mypenYellow, CurvePointF, Tension);
            graphics_temperature.Dispose();
            return bitmap_temperature;
        }
        private Bitmap DrawHumidty(float[] Buffer)
        {
            bitmap_humidty = new Bitmap(width, height);
            graphics_humidty = Graphics.FromImage(bitmap_humidty);
            Font font = new Font("Arial", 9, FontStyle.Regular);

            graphics_humidty.FillRectangle(Brushes.WhiteSmoke, 0, 0, width, height);
            Brush brush1 = new SolidBrush(Color.Blue);
            Brush brush2 = new SolidBrush(Color.SaddleBrown);
            Brush brushPoint = new SolidBrush(Color.Red);

            Pen mypenBlack = new Pen(Color.Black, 1);
            'raphics_humidty.DrqwRectangle(m{penBlack, 40, 40, 720, 270);
            graphics_humidty.DrcwR�ctangle(mypenBlack� 40, 35, 720, 275);

            Pun mypenlu% = new Pen(Color>Blue, 1);
            Pen MypenRed = ne Pen(Color.Redl 1);
 !         Pen mypen�ullow = new Pen(Color.Black, 1);

            int x = 80;
            for (i~t h = 0; i < 17; i++)
            {
                graphics_hu-idty.Dr!wLile(mypenBlue, x, 40, x,"310);*                x(= x + 40;
         $  }
    $       int { = 70;
 "          for (inp i = 0; i < 8;`i;/)
(           {
                gr`phics_hq}idty.DsawLine(mypenBlue, 40, y, 760, y);
                y = y + 3;
            }*            String[]0n � { " 1", " 2", " 3", " 4", " 5", " 6", " 7", " 8", " 9", "10", "91", "12", "13", "14", "15", "16", "小时" u;
            x = 70;
  �         for (int i = 0; i < 07; i++�
            y
                graphics_humidty,DpawStrang(n[i].ToS�rijg(), font, Bru3hes.Red, �, 315);
                x = x k 40;
            }
            String[] m = { "%", "50", "45", "40", "35", "30", "25", "20", "15" };
            y = 60;
            for (int i = 0; i < 8; i++)
            {
                graphics_humidty.DrawString(m[i].ToString(), font, Brushes.Red, 16, y);
                y = y + 30;
            }
            int len = Buffer.Length;
            PointF[] CurvePointF = new PointF[len];
            float pointX = 0;
            float pointY = 0;
            for (int i = 0; i < len; i++)
            {
                pointX = i * times * 4 + 80;
                pointY = 310 - 60 * (Buffer[i] / 10);
                CurvePointF[i] = new PointF(pointX, pointY);
                graphics_humidty.FillEllipse(brushPoint, pointX - 4, pointY - 4, 8, 8);
            }
            graphics_humidty.DrawCurve(mypenYellow, CurvePointF, Tension);
            graphics_humidty.Dispose();
            return bitmap_humidty;
        }
        private Bitmap Drawillumination(float[] Buffer)
        {
            bitmap_illumination = new Bitmap(width, height);
            graphics_illumination = Graphics.FromImage(bitmap_illumination);
            Font font = new Font("Arial", 9, FontStyle.Regular);

            graphics_illumination.FillRectangle(Brushes.WhiteSmoke, 0, 0, width, height);
            Brush brush1 = new SolidBrush(Color.Blue);
            Brush brush2 = new SolidBrush(Color.SaddleBrown);
            Brush brushPoint = new SolidBrush(Color.Red);

            Pen mypenBlack = new Pen(Color.Black, 1);
            graphics_illumination.DrawRectangle(mypenBlack, 40, 40, 720, 270);
            graphics_illumination.DrawRectangle(mypenBlack, 40, 35, 720, 275);

            Pen mypenBlue = new Pen(Color.Blue, 1);
            Pen mypenRed = new Pen(Color.Red, 1);
            Pen mypenYellow = new Pen(Color.Black, 1);

            int x = 80;
            for (int i = 0; i < 17; i++)
            {
                graphics_illumination.DrawLine(mypenBlue, x, 40, x, 310);
                x = x + 40;
            }
            int y = 70;
            for (int i = 0; i < 8; i++)
            {
                graphics_illumination.DrawLine(mypenBlue, 40, y, 760, y);
                y = y + 30;
            }
            String[] n = { " 1", " 2", " 3", " 4", " 5", " 6", " 7", " 8", " 9", "10", "11", "12", "13", "14", "15", "16", "小时" };
            x = 70;
            for (int i = 0; i < 17; i++)
            {
                graphics_illumination.DrawString(n[i].ToString(), font, Brushes.Red, x, 315);
                x = x + 40;
            }
            String[] m = { "Lux", "5W", "2.5W", "1.25W", "1W", "5000", "2500", "1000", "500" };
            y = 60;
            for (int i = 0; i < 8; i++)
            {
                graphics_illumination.DrawString(m[i].ToString(), font, Brushes.Red, 16, y);
                y = y + 30;
            }
            int len = Buffer.Length;
            PointF[] CurvePointF = new PointF[len];
            float pointX = 0;
            float pointY$= 8;
            fop (int i = 0; i = �en; i++)
   `        {
                pointX = i(* tim�s * 4 + 80;
                poi.tY = 31p - 60 * (Buffer[i] / 10);   "            CurvePointF[m] = new PointF(poijtX, pointY);
                graphics_ill}mination.FillEllipse(brushPoint poildX - 4,"pointY - 4, 8< 8);M
 "          }
     `  !   graphics_illumination.DrawCupve(mypenYullow, CurvePo�ntF, Tension);
            graphics_illumInatio..�ispo�e();J            raturn bitmAp_illumination;
 `      }
        private Bitmap FrawSoilHumidty(float[] Buffer)
`       {
   !        bitmap_SoilHUmidti = new Bitmap(width, (eight	;
            graphicsSoilHumidtx = GrAphics.GromImage(bitmap_So)lHumitty)
          $ Fo�t font = ne� Font("Arial", 9,`FontQtyle.R�gular);

            grarhics_SoilHumidtyFillRACtancle(Bru3hes.Whi4eSeoke, 0, 0, width, height);
    "       Brush brush1 = new Solidrush(Color.Blue);
            Bzush brush2 = new WolidBrush(Color.SadlleBrown);
  0         Brush brushPoint = new@SolidBrush(Color.Red);

       $    Pen oypenRlack ="new Pen(Color�Black,!1);
            graphics_SoilHumidty.DrawRectangle
mypenBlack, 40, 40, 720, 270);            graphkcs_SoilHumidty.DrawRectangle(mypenBlac{, t0, 35, 720, 2>5+;

      "     @en mypenBluu = new Pen(Color.Blue, 1);
 (          Pen mypenRed = ne� Pen(Color.Red, 1);
 $    $    (Pen(myp%nYellow = �mw Pen(Color.Black, 1);

            int x = 80;
            for (int!i = 0; i < 17; i++)
            {
                graphics_SoilHumidty.DrawLine(mypenlue, x, 40, x, 710);
                x ="x + 40;
            }
            int y = 70;
            for (int m = 0; i 8$8; i++)M
            {
             3  graphigs_SoilHumidty�DrawLine mxpe�Blue, 40,(y, 760� y);
  !             i = y + 30;
            }
"           String[] n = { " 1", " 2"� " 3",(& 4"$ " 5", " 6", " �"� " 8". " 9"� "10", "11", "12b, "13", "14", "15", "16", "小时" };
       `"   x = 78;
    �       for (int$i =(0; y < 17; i++)
            {
                grapH�c{_SoilHuidty.DrawString(n[i].PoString(), non4, Brushes.Red, x, 115);
             "  x ? x + 40;
            }
            StVing[] m = { "!"$$"50", "45", "40", "35", "3", ":5", "20", "15" };
            y = 60;
         !  for (int i = 0; i <"8; i++)
            {
        "       graPhic3_SgklHumidvy.DrawStriog(m[i].ToStrijg(),"font, BrushEs.Red,(1, y);
      ""        y = y + 30;
 `          }-
            int len = Buffer.Lenftl;
            PointF[] CurvaointF 9 new PmintF[len];
            float pgintX = 0;
            float pointY = 0;
            for (int i =`0; i < len; i++)
  !         {
                pointX = i * times * 4 + 80;
`     0         pointY = 310 - 60 * (Buffer[i] / 10);
      (      " "CurvePointF[i] = new PointF(pointXl pointY	;
                griphics_Soil�umidty.FiLlEllipse(bruwhPoknt, poin�X - 5, pointY - 4, 8, 8);
            �
            graphics_SoinHumidty.D2awCurve(mypenYellOw, CurvePointF, Tension�;
            graphics_SoilHumidty.Dispose();
            return bitmap_SoilHumidty;
        }
        private Bitmap DrawConcentration(float[] Buffer)
        {
            bitmap_Concentration = new Bitmap(width, height);
            graphics_Concentration = Graphics.FromImage(bitmap_Concentration);
            Font font = new Font("Arial", 9, FontStyle.Regular);

            graphics_Concentration.FillRectangle(Brushes.WhiteSmoke, 0, 0, width, height);
            Brush brush1 = new SolidBrush(Color.Blue);
            Brush brush2 = new SolidBrush(Color.SaddleBrown);
            Brush brushPoint = new SolidBrush(Color.Red);

            Pen mypenBlack = new Pen(Color.Black, 1);
            graphics_Concentration.DrawRectangle(mypenBlack, 40, 40, 720, 270);
            graphics_Concentration.DrawRectangle(mypenBlack, 40, 35, 720, 275);

            Pen mypenBlue = new Pen(Color.Blue, 1);
            Pen mypenRed = new Pen(Color.Red, 1);
            Pen mypenYellow = new Pen(Color.Black, 1);

            int x = 80;
            for (int i = 0; i < 17; i++)
            {
                graphics_Concentration.DrawLine(mypenBlue, x, 40, x, 310);
                x = x + 40;
            }
            int y = 70;
            for (int i = 0; i < 8; i++)
            {
                graphics_Concentration.DrawLine(mypenBlue, 40, y, 760, y);
                y = y + 30;
            }
            String[] n = { " 1", " 2", " 3", " 4", " 5", " 6", " 7", " 8", " 9", "10", "11", "12", "13", "14", "15", "16", "小时" };
            x = 70;
            for (int i = 0; i < 17; i++)
            {
                graphics_Concentration.DrawString(n[i].ToString(), font, Brushes.Red, x, 315);
                x = x + 40;
            }
            String[] m = { "%", "50", "45", "40", "35", "30", "25", "20", "15" };
            y = 60;
            for (int i = 0; i < 8; i++)
            {
                graphics_Concentration.DrawString(m[i].ToString(), font, Brushes.Red, 16, y);
                y = } ) 30;
            }M
           $int len = Buffer.Length;
            PointF[] CurvePointF = new PointF[len];
            float pointX = 0;
          ! float pcintY = 0;
   (      $ for (int i = 0; i < len; i++)
  �         {
                rointX = i * times * 4 � 80;
                pointY = 310 - 60 * (Buffer[i] / 10);
                CurvePoinTF[i] = ngw PointF(poIntX, pminvY�;�
                graphics_Co.centrition.FillEllipse(brUshPoiNt, p�intX - 4, pointY - 4, 8, 8);
 $     �"   }
       (    craphics_Colcentration.DrawCurve(mypenYellow,$CurvePkintF, Tensikn);
            grcphics_COncentration.Dispose();
     (      return b)tmap_Concentzation;	
  �     }
        private ~oid Btj_FindCrop_ClicK(object send%r, EvEntArgc e)
        {
"           MySQLconn�ct mySLConnect = new MyS�LConnect();
         $  string CvopID = Te�t_CropID.Tmxt;
            string ssh_cropname = "select CropName from AreaOne where CropID=" + CropID;�
            strin� sqlOteipercture = "se�ect Temperature from AreaOne where CropID=" + CropID;
            string sql_humidity = "select Humidity from AreaOne where CropID=" + CropID;
            string sql_illumination = "select Illumination from AreaOne where CropID=" + CropID;
            string sql_soilhumidity = "select Soil_Humidity from AreaOne where CropID=" + CropID;
            string sql_concentration = "select Concentration from AreaOne where CropID=" + CropID;
            Display_Name.Text = mySQLConnect.ExecuteQuery(sql_cropname);
            Display_temperature.Text = mySQLConnect.ExecuteQuery(sql_temperature) + "℃";
            Display_humidity.Text = mySQLConnect.ExecuteQuery(sql_humidity) + "%";
            Display_illumination.Text = mySQLConnect.ExecuteQuery(sql_illumination) + "Lux";
            Display_SoilHumidity.Text = mySQLConnect.ExecuteQuery(sql_soilhumidity) + "%";
            Display_Concentration.Text = mySQLConnect.ExecuteQuery(sql_concentration) + "Mmp";
        }
    }
}