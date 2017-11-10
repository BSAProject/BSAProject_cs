using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;

namespace readBSA3
{
   public class startime
    {
        public int GMT { get; set; }
        public startime(int time_zone)
        {
            GMT = time_zone;
        }
    double sqr(double a) {
        return a * a;
    }
    public double ToJulianDate(DateTime date)
    {
        return date.ToOADate() + 2415018.5;
    }
        public Pair precess(double alfa, double delt, double t)
        {
            double rs = 4.8481368e-6;
            double am = 46.1 * rs;
            double an = 20.4 * rs;

            double alfa1 = alfa;
            double delta1 = delt;

            double alf=0;
            double del=0;

            for (int i = 0; i < 2; i++)
            {
                alf = alfa - (am + an * Math.Sin(alfa1) * Math.Tan(delta1)) * t;
                del = delt - an * Math.Cos(alfa1) * t;
                alfa1 = (alf + alfa) / 2;
                delta1 = (del + delt) / 2;
            }

            alf /= (15 * rs);
            del /= rs;
            int[] m = new int[4];
            int[] n = new int[4];
            alf /= 3600;
            while (alf >= 24)
                alf -= 24;

            while (alf < 0)
                alf += 24;

            m[1] = (int)alf;
            m[2] = (int)((alf - m[1]) * 60);
            m[3] = (int)(((alf - m[1]) * 60 - m[2]) * 60 + 0.5);

            m[2] += m[3] / 60;
            m[3] %= 60;
            m[1] += m[2] / 60;
            m[2] %= 60;
            m[1] %= 24;

            del /= 3600;
            while (del >= 360)
                del -= 360;

            while (del < 0)
                del += 360;
            n[1] = (int)del;
            n[2] = (int)((del - n[1]) * 60);
            n[3] = (int)(((del - n[1]) * 60 - n[2]) * 60 + 0.5);

            n[2] += n[3] / 60;
            n[3] %= 60;
            n[1] += n[2] / 60;
            n[2] %= 60;
            n[1] %= 24;

            Pair p = new Pair();
            p.First = (new DateTime(2000, 1, 1, m[1], m[2], m[3])).ToString("HH:mm:ss");
            p.Second = String.Format("{0}°{1}.{2}",n[1],n[2],n[3]);
            return p;
        }
        public Pair get_alf(double culm, double delt)
        {
            const double fi = 0.956829;
            const double be = 0.008436;

            double aa = sqr(Math.Sin(fi)) * sqr(Math.Cos(be)) + sqr(Math.Cos(fi));
            double bb = 2 * Math.Sin(fi) * Math.Cos(be) * Math.Sin(delt);
            double cc = sqr(Math.Sin(delt)) - sqr(Math.Cos(fi));

            double x = (bb + Math.Sqrt(sqr(bb) - 4 * aa * cc)) / (2 * aa);
            double y = x * Math.Sin(be) / Math.Cos(delt);
            double z = Math.Sqrt(1 - y * y);

            double t = y / z;
            double alf = culm * Math.PI / 12 + Math.Atan(t);

            return precess(alf, delt, t);
        }
public string StarTime(_file_ops data,long point)   // dateTime UTC
   {
       DateTime time = data.datetime_utc.AddMilliseconds(data.tresolution* point);
       double delta_lucha = data.delta_lucha; /// ????
       DateTime dnow = new DateTime(data.date_begin.Year, data.date_begin.Month, data.date_begin.Day, 0, 0, 0);
       double t = (ToJulianDate(dnow) - ToJulianDate(new DateTime(2000,1,1,0,0,0)) - 1);
       t /= 36525;
       double s0 = 6 + 41 / 60.0 + 50.55 / 3600.0 + 8640184 / 3600.0 * t + 0.093104 / 3600.0 * t * t - 6.27 / 3600.0 * (1e-6) * t * t * t;
       double t_culm = time.Hour + time.Minute/ 60.0 + time.Second / 3600.0;
       double alambda = 2 + 30 / 60.0 + 34 / 3600.0;
       double cnst = 2.7379093e-3;
       double s_culm = s0 + (cnst + 1) * t_culm + alambda;
       Pair res = get_alf(s_culm, delta_lucha);
       if (point != -1)
           return res.First.ToString();
       else
           return res.Second.ToString();

   
      

   }
    }
}
