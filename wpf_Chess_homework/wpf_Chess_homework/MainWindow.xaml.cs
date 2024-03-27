using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace wpf_Chess_homework
{
    public partial class MainWindow : Window
    {
        bool  WpFigureClicked, WkFigureClicked;
        double DeltaX, DeltaY;
        bool blackMoved = false;
        Random random = new Random();

        
        public MainWindow()
        {
            InitializeComponent();
        }
        void Window_MouseMove(object sender, MouseEventArgs e)
        {
            if (WpFigureClicked)
                MyWpFigure.Margin = new Thickness(e.GetPosition(this).X - DeltaX,
                e.GetPosition(this).Y - DeltaY,0,0);
            if (WkFigureClicked)
                MyWkFigure.Margin = new Thickness(e.GetPosition(this).X - DeltaX,
                e.GetPosition(this).Y - DeltaY, 0, 0);
        }

        void BlackMove(MouseEventArgs e)
        {
            Image[] Blacks = { MyBnFigure, MyBkFigure, MyBrFigure, MyBbFigure };
            int ind = random.Next(0, Blacks.Length);
            Image blackFig = Blacks[ind];
            if (!Shax_Mat())
            {
                if (blackFig == MyBnFigure) MyBnFigureMove();
                else if (blackFig == MyBkFigure) MyBkFigureMove();
                else if (blackFig == MyBrFigure) MyBrFigureMove();
                else MyBbFigureMove();
            }

        }
        bool Shax_Mat()
        {
            bool done = false;
            double King_l = MyWkFigure.Margin.Left;
            double King_t = MyWkFigure.Margin.Top;
            //dzin e pordzum
            double x = MyBnFigure.Margin.Left;
            double y = MyBnFigure.Margin.Top;
            if (((King_l == x - 100 || King_l == x + 100) && (King_t == y + 50 || King_t == y - 50)) || ((King_l == x - 50 || King_l == x + 50) && (King_t == y - 100 || King_t == y + 100)) && (King_t != x && King_l != y))
            {
                MyBnFigure.Margin = new Thickness(King_l, King_t, 0, 0);
                done = true;
            }
            //navn e pordzum
            x = MyBrFigure.Margin.Left;
            y = MyBrFigure.Margin.Top;
            if ((King_l == x || King_t == y) && (King_l != x || King_t != y))
            {
                MyBrFigure.Margin = new Thickness(King_l, King_t, 0, 0);
                done = true;
            }
            //pixn e pordzum 
            x = MyBbFigure.Margin.Left;
            y = MyBbFigure.Margin.Top;
            if (((King_l - King_t) == (x - y) || (King_l + King_t) == (x + y)) && King_l != x && King_t != y)
            {
                MyBbFigure.Margin = new Thickness(King_l, King_t, 0, 0);
                done = true;
            }
            return done;
        }
        void MyBnFigureMove()
        {
            blackMoved = false;
            double x = MyBnFigure.Margin.Left;
            double y = MyBnFigure.Margin.Top;
            do
            {
                int l = 50 * random.Next(0, 7);
                int t = 50 * random.Next(0, 7);

                if (((l==x-100 || l==x+100)&&(t==y+50 || t==y-50))||((l==x-50 || l==x+50)&&(t==y-100 || t==y+100))&&(t!=x && l!=y))
                {
                    MyBnFigure.Margin = new Thickness(l, t, 0, 0);
                    blackMoved = true;
                }
            } while (blackMoved == false);
        }
        void MyBkFigureMove()
        {
            blackMoved = false;
            double x = MyBkFigure.Margin.Left;
            double y = MyBkFigure.Margin.Top;
            do
            {
                int l = 50 * random.Next(0, 7);
                int t = 50 * random.Next(0, 7);

                if ((l==x+50 || l==x-50)&&(t==y+50 || t==y-50))
                {
                    MyBkFigure.Margin = new Thickness(l, t, 0, 0);
                    blackMoved = true;
                }
            } while (blackMoved == false);
        }
        void MyBrFigureMove()
        {
            blackMoved = false;
            double x = MyBrFigure.Margin.Left;
            double y = MyBrFigure.Margin.Top;
            do
            {
                int l = 50 * random.Next(0, 7);
                int t = 50 * random.Next(0, 7);

                if ((l == x || t == y) && (l != x || t != y))
                {
                    MyBrFigure.Margin = new Thickness(l, t, 0, 0);
                    blackMoved = true;
                }
            } while (blackMoved == false);
        }
        void MyBbFigureMove()
        {
            blackMoved = false;
            double x = MyBbFigure.Margin.Left;
            double y = MyBbFigure.Margin.Top;
            do
            {
                int l = 50 * random.Next(0, 7);
                int t = 50 * random.Next(0, 7);

                if (((l - t) == (x - y) || (l + t) == (x + y)) && l != x && t != y)
                {
                    MyBbFigure.Margin = new Thickness(l, t, 0, 0);
                    blackMoved = true;
                }
            } while (blackMoved == false);
        }
        void MyWpFigure_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == e.LeftButton)
            {
                StackPanel.SetZIndex(MyWpFigure, 1);
                WpFigureClicked = true;
                DeltaX = e.GetPosition(this).X - MyWpFigure.Margin.Left;
                DeltaY = e.GetPosition(this).Y - MyWpFigure.Margin.Top;
            }
        }

        void MyWpFigure_MouseUp(object sender, MouseEventArgs e)
        {
            WpFigureClicked = false;
            MyWpFigure.Margin = new Thickness((int)(MyWpFigure.Margin.Left + 25) / 50 * 50,
(int)(MyWpFigure.Margin.Top + 25) / 50 * 50, 0, 0);
            ramka.Children.Clear();
            BlackMove(e);
        }

        void MyWkFigure_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == e.LeftButton)
            {
                StackPanel.SetZIndex(MyWkFigure, 1);
                DeltaX = e.GetPosition(this).X - MyWkFigure.Margin.Left;
                DeltaY = e.GetPosition(this).Y - MyWkFigure.Margin.Top;
                WkFigureClicked = true;
            }
        }

        void MyWkFigure_MouseUp(object sender, MouseEventArgs e)
        {
            WkFigureClicked = false;
            MyWkFigure.Margin = new Thickness((int)(MyWkFigure.Margin.Left + 25) / 50 * 50,
(int)(MyWkFigure.Margin.Top + 25) / 50 * 50, 0, 0);
            BlackMove(e);
        }

    }
}
