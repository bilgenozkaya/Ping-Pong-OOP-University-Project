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
    public class DenetimKolu : Obje
    {
        public int _hiz = 10;
        public DenetimKolu(Form1 form)
        {
            _form = form;
            _brush = Brushes.Green;
            _pos = new Point(10, _form.Height - 80);
            _size = new Size(150, 10);
        }
        public override void Ciz(PaintEventArgs e)
        {
            var rect = AlRect();
            if (e.ClipRectangle.IntersectsWith(rect))
            {
                e.Graphics.FillRectangle(_brush, rect);
            }
        }
        internal void OnMouseMove(MouseEventArgs e)
        {
            _form.Invalidate(AlRect());
            _pos.X = e.X;
            _form.Invalidate(AlRect());
        }

    }
}
