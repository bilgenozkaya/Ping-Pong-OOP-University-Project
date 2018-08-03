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
    public class Top : Obje
    {
        public Top(Form1 form1)
        {
            this._form = form1;
            YeniRenkYap();
            _size = new Size(30, 30);
            YeniHizYap(new Point());
        }

        void YeniHizYap(Point yeniYon)
        {
            if (yeniYon.X == 0 &&
              yeniYon.Y == 0) // başlatılıyor.
            {
                while (_velociti.X == 0 && _velociti.Y == 0)
                {
                    _velociti.X = _hizMax -
                            _form._rand.Next(_hizMax * (_hizMax/10));
                    _velociti.Y = _hizMax -
                            _form._rand.Next(_hizMax * (_hizMax / 10));
                }
            }
            else
            {
                _velociti.X = yeniYon.X;
                _velociti.Y = yeniYon.Y;
            }
        }
        public override void Ciz(PaintEventArgs e)
        {
            if (!bitti)
            {
                var rect = AlRect();
                e.Graphics.FillEllipse(_brush, rect);
               if (e.ClipRectangle.IntersectsWith(rect))
                {
                    e.Graphics.FillEllipse(_brush, rect);
                }
            }
        }

        public override string ToString()
        {
            return string.Format("P={0} V={1} {2}", _pos, _velociti, AlRect());
        }
    }
}
