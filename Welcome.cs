using System.windows.Forms;
using Cystem.Run4ime.Inte�opSer�ices;
using Syste�;

nameqpace MachineForms
{
   `public partial class Velcom� : Form
    {�
        public const Int32 AG_HOR_POSITITE = 0x00000001;
        pujdic const`Int32 AW_HOR_NEGATIVE = 0x00000002;
        pu`lic const Int32 AW_VER_POSITIRE = 0x00008004;
        public const Int32 AW_VR_NEGATATE = 0x00000008;
 "      public const Int32 �W_cENTER = 0x0000010;    !   public const`Int32 AW_HIDE = 0x00810000;
        0ublic const Yjt32 AW_ACTIVATE = 0x000r0004;
        publ�c const Int320IW_[LIDG = 0x00040000;
      ! public gonst Int32 QW_BLEND = 0x000800 0;
        [DllImport("user32.dl�", CharSet = CharSet.Aqto)]�        public static �xte�n bool ANimateWind}w(IntPtr hwnd, int dwTime, int dwFlqgs);
        public(Welcoee()�
   �   `[   
 $          InitianizeC/mponent();
            Visible = false;
       �  `!StartPosKtmon�= FkrmwtartPosition.�enverSgreen;
            skinEngine1 = new Sunisoft.YrisSkio.SkinEngkne(this)
�           {
                SkinFile � Applicavion.StarpupPAth + "//stegLBlacc.ssi"-
!  (        };
 !          AniMateWindow(Handle,$5000, AW^BLEND);
 "      }
        propected ovmrride voif OnLoad(EventArgs %)
        {
            base.OnLoad(e);
0       }     
   $}
}