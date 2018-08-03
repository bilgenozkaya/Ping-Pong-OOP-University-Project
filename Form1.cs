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
    public partial class Form1 : Form
    {
        DenetimKolu _denetimKolu;
        Top[] _top;
        const int _topSayisi = 2; // top sayisini cogaltma imkani
        int _canliTopSayisi;
        int _seviyeN;
        int _score = 0;
        Timer _timer;
        public Random _rand = new Random(1);

        public Form1()
        {
            InitializeComponent();
            SetStyle(ControlStyles.AllPaintingInWmPaint |
            ControlStyles.OptimizedDoubleBuffer |
            ControlStyles.DoubleBuffer |
            ControlStyles.UserPaint
            , true);
            Width = 800;
            Height = 500;
            BackColor = Color.Black;

            _denetimKolu = new DenetimKolu(this);
            _top = new Top[_topSayisi];
            _canliTopSayisi = _topSayisi;

            for (int i = 0; i < _topSayisi; i++)
            {
                _top[i] = new Top(this)
                {
                    _pos = new Point(
                        100 + i * 20,
                        200 + i * 20)
                };
            }
            _timer = new Timer();
            _timer.Interval = 15; //msaniye
            _timer.Tick += timerTik;
            _timer.Enabled = true;
        }


        void timerTik(object sender, EventArgs e)
        {
            Point res;
            for (int itop = 0; itop < _topSayisi; itop++)
            {
                // ilk once topun carpacagi yere bakalim
                var top = _top[itop];
                if (!top.bitti)
                {
                    // duvara carpiyor mu
                    res = Carpisma(
                      top,
                      ClientRectangle,
                      icinde: true);
                   
                   
                    if (res.X == 0 && res.Y == 0) //carpmadi ise
                    {
                        // kontol cubuguna carpti ise
                        Beep(400, 10);
                        res = Carpisma(
                          top,
                          _denetimKolu.AlRect(),
                          icinde: false);
                        
                    }
                     
                
                    else
                    { // yere carpti mi
                        if (res.Y == -1)
                        {// yere carpti ise
                            top.bitti = true;
                            Invalidate(top.AlRect());
                            _canliTopSayisi--;
                            
                        }
                        
                    }
                    // topu oynat
                    Invalidate(top.AlRect());
                    top._pos.X += top._velociti.X;
                    top._pos.Y += top._velociti.Y;
                    Invalidate(top.AlRect());
                }
               
            }
            if (_canliTopSayisi == 0)
            {
            
                this._timer.Enabled = false;
                
            }
            this.Text = string.Format(
              " Score = {0}  # Seviye = {1} # Kalan Top Sayisi = {2}",
              _score,
              _seviyeN,
              _canliTopSayisi);        
        }
          Point Carpisma(
          Top top,
          Rectangle rektTest,
          bool icinde)
        {
            var res = new Point();

            int carpismaSayisi = 0;
            if (icinde)
            {
                carpismaSayisi = 1;
            }
            else
            {
                var rekt = top.AlRect();
                rekt = new Rectangle(
                    new Point(
                        rekt.Left + top._velociti.X,
                        rekt.Top + top._velociti.Y),
                    top._size);
                if (rekt.IntersectsWith(rektTest))
                {
                    carpismaSayisi = 1;
                }
            }

            if (top._velociti.X != 0)
            {
                if (top._velociti.X > 0)
                {
                    var kenarX = rektTest.Left;
                    if (icinde)
                    {
                        kenarX = rektTest.Left + rektTest.Width;
                    }
                    if (top._pos.X < kenarX &&
                        top._pos.X +
                        top._size.Width +
                        top._velociti.X >= kenarX)
                    {
                        res.X = -carpismaSayisi;
                    }
                }
                else
                {
                    var kenarX = rektTest.Left + rektTest.Width;
                    if (icinde)
                    {
                        kenarX = rektTest.Left;
                    }
                    if (top._pos.X > kenarX &&
                        top._pos.X +
                        top._velociti.X <= kenarX)
                    {
                        res.X = carpismaSayisi;
                    }
                }
            }
            if (top._velociti.Y != 0)
            {
                if (top._velociti.Y > 0)
                {
                    var kenarY = rektTest.Top;
                    if (icinde)
                    {
                        kenarY = rektTest.Top + rektTest.Height;
                    }
                    if (top._pos.Y < kenarY &&
                        top._pos.Y +
                        top._size.Height +
                        top._velociti.Y >= kenarY)
                    {
                        res.Y = -carpismaSayisi;
                    }
                }
                else
                {
                    var kenarY = rektTest.Top + rektTest.Height;
                    if (icinde)
                    {
                        kenarY = rektTest.Top;
                    }
                    if (top._pos.Y > kenarY &&
                        top._pos.Y +
                        top._velociti.Y <= kenarY)
                    {
                        res.Y = carpismaSayisi;
                    }
                }
            }
            if (res.X != 0) // X yonunde çarpışırsa.
            {
                top._velociti.X =
                    res.X * (1 + _rand.Next(top._hizMax));
            }
            if (res.Y != 0)
            {
                top._velociti.Y =
                    res.Y * (1 + _rand.Next(top._hizMax));
            }

            return res;

        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            _denetimKolu.Ciz(e);
            {
                for (int i = 0; i < _topSayisi; i++)
                {
                    _top[i].Ciz(e);
                }
            }
        }
        protected override void OnMouseMove(MouseEventArgs e)
        {
            _denetimKolu.OnMouseMove(e);
        }

        [DllImport("kernel32.dll")]
        public static extern bool Beep(int BeepFreq, int BeepDuration);
    }
}
