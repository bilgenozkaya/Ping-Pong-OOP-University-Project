/****************************************************************************
**					  SAKARYA ÜNİVERSİTESİ
**			BİLGİSAYAR VE BİLİŞİM BİLİMLERİ FAKÜLTESİ
**				  BİLGİSAYAR MÜHENDİSLİĞİ BÖLÜMÜ
**			     NESNEYE DAYALI PROGRAMLAMA DERSİ
**					2014-2015 BAHAR DÖNEMİ
**	
**				ÖDEV NUMARASI..........: Proje Ödevi
**				ÖĞRENCİ ADI............: Bilgen TEKESHANOSKA
**				ÖĞRENCİ NUMARASI.......: B121210102
**              DERSİN ALINDIĞI GRUP...: 2-A
****************************************************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjeNDP
{
    public abstract class Obje
    {
        public Brush _brush;
        public Point _pos;
        public Size _size;
        public Form1 _form;
        public Point _velociti;// vector... hizi
        public int _hizMax = 10;
        public bool bitti;
        public abstract void Ciz(PaintEventArgs e);
        static int renk = 0xffffff;

        public Rectangle AlRect()
        {
            return new Rectangle(
              _pos.X,
              _pos.Y,
              _size.Width,
              _size.Height);
        }
       public void YeniRenkYap()
        {
            var yeniRenk = Color.FromArgb(
                            (byte)(0xff), //opak
                            (byte)(renk & 0xff), //kirmizi
                            (byte)((renk >> 4) & 0xff),//yesil
                            (byte)((renk >> 8) & 0xff) //mavi
                            );
            _brush = new SolidBrush(yeniRenk);
            renk -= 100; // renk degistir.
        }
    }
}
