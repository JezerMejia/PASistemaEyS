using System;
using Cairo;
namespace SistemaEySLibrary
{
    [System.ComponentModel.ToolboxItem(true)]
    public class ClockWidget : Gtk.DrawingArea
    {
        public int Width = 150;
        public int Height = 150;
        public ClockWidget()
        {
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

                ring.SetSourceColor(new Cairo.Color(0.95, 0.95, 0.95));
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

            line.SetSourceColor(new Cairo.Color(0.5, 0.1, 0.1));
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

            line.SetSourceColor(new Cairo.Color(0.95, 0.95, 0.95));
            line.Stroke();

            line.GetTarget().Dispose();
            line.Dispose();
        }
        public void DrawSecondLine()
        {
            Gdk.Window drawingArea = this.GdkWindow;
            Cairo.Context ring = Gdk.CairoHelper.Create(drawingArea);

            Cairo.PointD point1, point2;

            point1 = new Cairo.PointD(0, 0);
            point2 = new Cairo.PointD(0, -this.Height * 2 / 5);

            ring.Antialias = Cairo.Antialias.Default;
            ring.Translate(75, 75);
            ring.Rotate(CalculateSecondsToRadian());
            ring.LineWidth = 2;
            ring.MoveTo(point1);
            ring.LineTo(point2);
            ring.LineCap = LineCap.Round;

            ring.SetSourceColor(new Cairo.Color(0.95, 0.95, 0.95));
            ring.Stroke();

            ring.GetTarget().Dispose();
            ring.Dispose();
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
