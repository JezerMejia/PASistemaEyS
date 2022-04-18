using System;
using Cairo;
namespace SistemaEySLibrary
{
    [System.ComponentModel.ToolboxItem(true)]
    public class ClockWidget : Gtk.DrawingArea
    {

        // This is a tes from Leo Corea

        public int Width = 150;
        public int Height = 150;
        public ClockWidget()
        {
            this.Realized += this.printColors;
        }

        string GdkColorToRGB(Gdk.Color color)
        {
            return $"{color.Red/257};{color.Green/257};{color.Blue/257}";
        }

        void printColors(Object sender, EventArgs args)
        {
            Gtk.Style style = this.Style;

            Console.WriteLine("Base colors");
            Gdk.Color[] colors = style.BaseColors;
            int i = 0;
            foreach (Gdk.Color color in colors)
            {
                Console.WriteLine($"{i}: {GdkColorToRGB(color)}");
                i++;
            }

            Console.WriteLine("Light colors");
            colors = style.LightColors;
            i = 0;
            foreach (Gdk.Color color in colors)
            {
                Console.WriteLine($"{i}: {GdkColorToRGB(color)}");
                i++;
            }
            Console.WriteLine("Mid colors");
            colors = style.MidColors;
            i = 0;
            foreach (Gdk.Color color in colors)
            {
                Console.WriteLine($"{i}: {GdkColorToRGB(color)}");
                i++;
            }
            Console.WriteLine("Foregrounds colors");
            colors = style.Foregrounds;
            i = 0;
            foreach (Gdk.Color color in colors)
            {
                Console.WriteLine($"{i}: {GdkColorToRGB(color)}");
                i++;
            }
            Console.WriteLine("Background colors");
            colors = style.Backgrounds;
            i = 0;
            foreach (Gdk.Color color in colors)
            {
                Console.WriteLine($"{i}: {GdkColorToRGB(color)}");
                i++;
            }
        }

        public void DrawClock()
        {
            this.GdkWindow.Clear();
            this.DrawRing();
            this.DrawHourLine();
            this.DrawMinuteLine();
            this.DrawSecondLine();
        }
        protected void DrawRing()
        {
            int clockAmount = 0;
            double rotateAmount = 0;
            Gdk.Window drawingArea = this.GdkWindow;

            while (clockAmount < 12)
            {
                Cairo.Context ring = Gdk.CairoHelper.Create(drawingArea);

                Cairo.PointD point1, point2;

                point1 = new Cairo.PointD(this.Width * 2 / 5, 0);
                point2 = new Cairo.PointD(this.Width * 7 / 15, 0);

                ring.Antialias = Cairo.Antialias.Default;
                ring.Translate(this.Width / 2, this.Height / 2);
                ring.Rotate(rotateAmount);
                ring.LineWidth = 3;
                ring.MoveTo(point1);
                ring.LineTo(point2);
                ring.LineCap = LineCap.Round;

                Gtk.Style style = this.Style;
                Gdk.Color color = style.Foregrounds[4];

                ring.SetSourceColor(
                    new Cairo.Color(
                            color.Red / 65535f,
                            color.Green / 65535f,
                            color.Blue / 65535f
                        )
                    );
                ring.Stroke();

                ring.GetTarget().Dispose();
                ring.Dispose();

                clockAmount++;
                rotateAmount += (Math.PI * 2) / 12;
            }
        }
        protected void DrawHourLine()
        {
            Gdk.Window drawingArea = this.GdkWindow;
            Cairo.Context line = Gdk.CairoHelper.Create(drawingArea);

            PointD point1, point2;

            point1 = new PointD(0, 0);
            point2 = new PointD(0, -this.Height * 4 / 15);

            line.Antialias = Cairo.Antialias.Default;
            line.Translate(this.Width / 2, this.Height / 2);
            line.Rotate(this.CalculateHoursToRadian());
            line.LineWidth = 4;
            line.MoveTo(point1);
            line.LineTo(point2);
            line.LineCap = LineCap.Round;

            Gtk.Style style = this.Style;
            Gdk.Color color = style.BaseColors[3];

            line.SetSourceColor(
                new Cairo.Color(
                        color.Red / 65535f,
                        color.Green / 65535f,
                        color.Blue / 65535f
                    )
                );
            line.Stroke();

            line.GetTarget().Dispose();
            line.Dispose();
        }
        public void DrawMinuteLine()
        {
            Gdk.Window drawingArea = this.GdkWindow;
            Cairo.Context line = Gdk.CairoHelper.Create(drawingArea);

            PointD point1, point2;

            point1 = new Cairo.PointD(0, 0);
            point2 = new Cairo.PointD(0, -this.Height * 1 / 3);

            line.Antialias = Cairo.Antialias.Default;
            line.Translate(this.Width / 2, this.Height / 2);
            line.Rotate(CalculateMinutesToRadian());
            line.LineWidth = 4;
            line.MoveTo(point1);
            line.LineTo(point2);
            line.LineCap = LineCap.Round;

            Gtk.Style style = this.Style;
            Gdk.Color color = style.Foregrounds[0];

            line.SetSourceColor(
                new Cairo.Color(
                        color.Red / 65535f,
                        color.Green / 65535f,
                        color.Blue / 65535f
                    )
                );
            line.Stroke();

            line.GetTarget().Dispose();
            line.Dispose();
        }
        public void DrawSecondLine()
        {
            Gdk.Window drawingArea = this.GdkWindow;
            Cairo.Context line = Gdk.CairoHelper.Create(drawingArea);

            Cairo.PointD point1, point2;

            point1 = new Cairo.PointD(0, 0);
            point2 = new Cairo.PointD(0, -this.Height * 2 / 5);

            line.Antialias = Cairo.Antialias.Default;
            line.Translate(75, 75);
            line.Rotate(CalculateSecondsToRadian());
            line.LineWidth = 2;
            line.MoveTo(point1);
            line.LineTo(point2);
            line.LineCap = LineCap.Round;

            Gtk.Style style = this.Style;
            Gdk.Color color = style.Foregrounds[0];

            line.SetSourceColor(
                new Cairo.Color(
                        color.Red / 65535f,
                        color.Green / 65535f,
                        color.Blue / 65535f
                    )
                );
            line.Stroke();

            line.GetTarget().Dispose();
            line.Dispose();
        }
        protected double CalculateHoursToRadian()
        {
            int currentHour = DateTime.Now.Hour;
            int currentMinute = DateTime.Now.Minute;
            if (currentHour > 12) currentHour -= 12;

            double hourDegree = 30 * currentHour + currentMinute / 2;
            double hourRadian = hourDegree * Math.PI / 180;
            return hourRadian;
        }
        protected double CalculateMinutesToRadian()
        {
            int currentMinute = DateTime.Now.Minute;
            double minutesRadian = (6 * currentMinute) * Math.PI / 180;
            return minutesRadian;
        }
        protected double CalculateSecondsToRadian()
        {
            int currentSecond = DateTime.Now.Second;
            double minutesRadian = (6 * currentSecond) * Math.PI / 180;
            return minutesRadian;
        }

        protected override bool OnButtonPressEvent(Gdk.EventButton ev)
        {
            // Insert button press handling code here.
            return base.OnButtonPressEvent(ev);
        }
        protected override bool OnExposeEvent(Gdk.EventExpose ev)
        {
            base.OnExposeEvent(ev);
            this.DrawClock();
            return true;
        }
        protected override void OnSizeAllocated(Gdk.Rectangle allocation)
        {
            base.OnSizeAllocated(allocation);
            // Insert layout code here.
        }
        protected override void OnSizeRequested(ref Gtk.Requisition requisition)
        {
            // Calculate desired size here.
            requisition.Height = this.Width;
            requisition.Width = this.Height;
        }
    }
}
