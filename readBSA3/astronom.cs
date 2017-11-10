using System;
using System.Collections.Generic;
using System.Text;

namespace readBSA3
{
    public class astronom_
    {
        public int GMT { get; set; }
        public double longitude = 0.6567674; // 37гр37мин48секунд
        public astronom_(int time_zone)
        {
            GMT = time_zone;
        }
        public astronom_()
        {

        }
public double WrRad(int h,int m,
            int sec,int msec)
{
double   rad = Math.PI/12.0*((double)h + (double)m/60.0
               + ((double)sec + (double)msec/1000.0)/3600.0);
return rad;
}
public void RadWr(double rad,out ushort h,out ushort m,out ushort sec)
{
double iint,frac;
if (rad >= 2 * Math.PI) rad = rad - 2 * Math.PI;
if (rad < 0) rad = rad + 2 * Math.PI;
double 	ir = rad*12/Math.PI;
		//frac = modf(ir,&iint);
    iint = Math.Floor(ir);
    frac = ir - iint;
	h = (ushort)(iint);
	ir = frac*60;
		//frac = modf(ir,&iint);
    iint = Math.Floor(ir);
    frac = ir - iint;

	m = (ushort)(iint);
	sec = (ushort)(frac*60);
		return;
}
//*************************************************************************
public void RadGr(double rad, out ushort gr, out ushort min, out ushort sec, out ushort msec)
{
    double iint, frac;
    double ir = rad * 180.0 / Math.PI;
    ir = Math.Abs(ir);
    iint = Math.Floor(ir);
    gr = (ushort)iint;
    frac = ir - iint;
    ir = frac * 60;
    iint = Math.Floor(ir);
    frac = ir - iint;
    min = (ushort)iint;
    ir = frac * 60;
    iint = Math.Floor(ir);
    frac = ir - iint;
    sec = (ushort)iint;
    ir = frac * 1000;
    iint = Math.Round(ir);
    msec = (ushort)iint;
}
public double RadGr(double rad)
{
    return 180 * rad / Math.PI;
}
public void RadWr(double rad, out ushort h, out ushort min, out ushort sec, out ushort msec)
{
    double iint, frac;
    if (rad >= 2 * Math.PI) rad = rad - 2 * Math.PI;
    if (rad < 0) rad = rad + 2 * Math.PI;
    double ir = rad * 12.0 / Math.PI;
    ir = Math.Abs(ir);
    iint = Math.Floor(ir);
    h = (ushort)iint;
    frac = ir - iint;
    ir = frac * 60;
    iint = Math.Floor(ir);
    frac = ir - iint;
    min = (ushort)iint;
    ir = frac * 60;
    iint = Math.Floor(ir);
    frac = ir - iint;
    sec = (ushort)iint;
    ir = frac * 1000;
    //iint = Math.Floor(ir);
    iint = Math.Round(ir);
    msec = (ushort)iint;
}
public double GrRad(double gr, double m, double sec, double ms)
{
    double ir, grrad;
    if ((gr < 0) | (m < 0) | (sec < 0)) ir = -1; else ir = 1;
    grrad = ir * Math.PI / 180 * (Math.Abs(gr) + Math.Abs(m) / 60 + Math.Abs(sec) / 3600 + Math.Abs(ms) / 3600 / 1000);
    return grrad;
}
public double GrRad(double grad)
{
    return grad * Math.PI / 180.0;
}
//*************************************************************************
double Star_time(int id,int im,int iyear)
{
    // по дате выдает звездное время истинное в радианах
    //   исходная программа Шутенков В.Р.  Фортран
double r = 1296000.0;                     //    ! 360.*3600.

    int[] month = new int[] {31,28,31,30,31,30,31,31,30,31,30,31};
    int iday,iy;
    int i;
    double t,sm,p;
    double e,q,d,f,m,l,pl,ps;
    double s0;
    DateTime t_cur;
//--------------------------------------------------------------------
//                        Calculate iday and t
//--------------------------------------------------------------------
	if ((id <=0)|(im <= 0)|(iyear <= 0)) //DecodeDate(Date(),iyear,im,id);
    {
        t_cur = DateTime.Now;
        iyear = t_cur.Year;
        im = t_cur.Month;
        id = t_cur.Day;
    }
	iday = id;
	if(im!=1)
                 {
	i = (iyear/4)*4;
	if(iyear == i) month[1] = 29; else month[1] = 28;
	for  (i = 0;i<im-1;i++) iday += month[i];//iday = iday + month[i];
		 }
	//iy = iyear - 1900;
    iy = iyear-1900;
	iday = (iday-1)+(iy-1)/4;
	t = (double)(iday) + (double)(iy)*365.0;
	t = (t+0.5)/36525.0;                    //   ! 00.01.1900 12h UT

	t = t - 1;                              //   ! 01.01.2000 12h UT1
//--------------------------------------------------------------------
//                    Calculate mean sidereal time
//--------------------------------------------------------------------
	sm = 24110.548410 + 8640184.8128660*t + 0.093104*t*t-
		 0.00000620*t*t*t;

	while (sm <= 0) sm = sm + 86400.0;
	while (sm > 86400) sm = sm - 86400.0;
//--------------------------------------------------------------------
//             Calculate long and short periodic nutation
//--------------------------------------------------------------------
	p = Math.PI/180.0/3600.0;
//{-------------------}
	e = p*(84381.448 - 46.8150*t - 0.00059*t*t + 0.0018130*t*t*t);
//{-------------------}
	q = p*( 450160.280 -   5.0*r*t - 482890.539*t+ 7.455*t*t +
		 0.0080*t*t*t);
	d = p*(1072261.3070 + 1236.0*r*t + 1105601.328*t - 6.891*t*t+
		 0.0190*t*t*t);
	f = p*( 335778.8770 + 1342.0*r*t + 295263.1370*t - 13.2570*t*t+
		 0.0110*t*t*t);
	m = p*(1287099.804 +  99.0*r*t+1292581.2240*t -  0.5770*t*t -
		 0.0120*t*t*t);
	l = p*( 485866.7330+1325.0*r*t + 715922.633*t + 31.3100*t*t+
		 0.0640*t*t*t);
//{*-------------------}
	pl =  -(17.19960 + 0.017420*t)*Math.Sin(q);
	pl = pl + (0.20620 + 0.000020*t)*Math.Sin(2.0*q);
	pl = pl +   0.00460            *Math.Sin(q+2.0*f-2.0*l);
	pl = pl +   0.00110            *Math.Sin(2.0*(l-f));
	pl = pl -   0.00030            *Math.Sin(2.0*(q+f-l));
	pl = pl-   0.00030            * Math.Sin (l-m-d);
	pl = pl-   0.00020            * Math.Sin (q-2.0*d+2.0*f-2.0*m);
	pl = pl+   0.00010            * Math.Sin (q-2.0*f+2.0*l);
	pl = pl-( 1.31870+ 0.000160*t)* Math.Sin (2.0*(q-d+f));
	pl = pl+(  0.14260-0.000340*t)* Math.Sin (m);
	pl = pl-(  0.05170-0.000120*t)* Math.Sin (2.0*q-2.0*d+2.0*f+m);
	pl = pl+(  0.02170-0.000050*t)* Math.Sin (2.0*q-2.0*d+2.0*f-m);
	pl = pl+(  0.01290+0.000010*t)* Math.Sin (q-2.0*d+2.0*f);
	pl = pl+   0.00480            * Math.Sin (2.0*(l-d));
	pl = pl-   0.00220            * Math.Sin (2.0*(f-d));
	pl = pl+(  0.00170-0.000010*t)* Math.Sin (2.0*m);
	pl = pl-   0.00150            * Math.Sin (q+m);
	pl = pl-(  0.00160-0.000010*t)* Math.Sin (2.0*(q-d+f+m));
	pl = pl-   0.00120            * Math.Sin (q-m);
	pl = pl-   0.00060            * Math.Sin (q+2.0*d-2.0*l);
	pl = pl-   0.00050            * Math.Sin (q-2.0*d+2.0*f-m);
	pl = pl+   0.00040            * Math.Sin (q-2.0*d+2.0*l);
	pl = pl+   0.00040            * Math.Sin (q-2.0*d+2.0*f+m);
	pl = pl-   0.00040            * Math.Sin (l-d);
	pl = pl+   0.00010            * Math.Sin (2.0*l+m-2.0*d);
	pl = pl+   0.00010            * Math.Sin (q+2.0*d-2.0*f);
	pl = pl-   0.00010            * Math.Sin (2.0*d-2.0*f+m);
	pl = pl+   0.00010            * Math.Sin (2.0*q+m);
	pl = pl+   0.00010            * Math.Sin (q+d-l);
	pl = pl-   0.00010            * Math.Sin (m+2.0*f-2.0*d);
//{*------------------- }
	ps =   -(  0.22740+0.000020*t)* Math.Sin (2.0*(q+f));
	ps = ps+(  0.07120+0.000010*t)* Math.Sin (l);
	ps = ps-(  0.03860+0.000040*t)* Math.Sin (q+2.0*f);
	ps = ps-   0.03010            * Math.Sin (2.0*q+2.0*f+l);
	ps = ps-   0.01580            * Math.Sin (l-2.0*d);
	ps = ps+   0.01230            * Math.Sin (2.0*q+2.0*f-l);
	ps = ps+   0.00630            * Math.Sin (2.0*d);
	ps = ps+(  0.00630+0.000010*t)* Math.Sin (q+l);
	ps = ps-(  0.00580+0.000010*t)* Math.Sin (q-l);
	ps = ps-   0.00590            * Math.Sin (2.0*q+2.0*d+2.0*f-l);
	ps = ps-   0.00510            * Math.Sin (q+2.0*f+l);
	ps = ps-   0.00380            * Math.Sin (2.0*(q+d+f));
	ps = ps+   0.00290            * Math.Sin (2.0*l);
	ps = ps+   0.00290            * Math.Sin (2.0*q-2.0*d+2.0*f+l);
	ps = ps-   0.00310            * Math.Sin (2.0*(q+f+l));
	ps = ps+   0.00260            * Math.Sin (2.0*f);
	ps = ps+   0.00210            * Math.Sin (q+2.0*f-l);
	ps = ps+   0.00160            * Math.Sin (q+2.0*d-l);
	ps = ps-   0.00130            * Math.Sin (q-2.0*d+l);
	ps = ps-   0.00100            * Math.Sin (q+2.0*d+2.0*f-l);
	ps = ps-   0.00070            * Math.Sin (l+m-2.0*d);
	ps = ps+   0.00070            * Math.Sin (2.0*q+2.0*f+m);
	ps = ps-   0.00070            * Math.Sin (2.0*q+2.0*f-m);
	ps = ps-   0.00080            * Math.Sin (2.0*q+2.0*d+2.0*f+l);
	ps = ps+   0.00060            * Math.Sin (2.0*d+l);
	ps = ps+   0.00060            * Math.Sin (2.0*(q-d+f+l));
	ps = ps-   0.00060            * Math.Sin (q+2.0*d);
	ps = ps-   0.00070            * Math.Sin (q+2.0*d+2.0*f);
	ps = ps+   0.00060            * Math.Sin (q-2.0*d+2.0*f+l);
	ps = ps-   0.00050            * Math.Sin (q-2.0*d);
	ps = ps+   0.00050            * Math.Sin (l-m);
	ps = ps-   0.00050            * Math.Sin (q+2.0*f+2.0*l);
	ps = ps-   0.00040            * Math.Sin (m-2.0*d);
	ps = ps+   0.00040            * Math.Sin (l-2.0*f);
	ps = ps-   0.00040            * Math.Sin (d);
	ps = ps-   0.00030            * Math.Sin (l+m);
	ps = ps+   0.00030            * Math.Sin (l+2.0*f);
	ps = ps-   0.00030            * Math.Sin (2.0*q+2.0*f-m+l);
	ps = ps-   0.00030            * Math.Sin (2.0*q+2.0*d+2.0*f-m-l);
	ps = ps-   0.00020            * Math.Sin (q-2.0*l);
	ps = ps-   0.00030            * Math.Sin (2.0*q+2.0*f+3.0*l);
	ps = ps-   0.00030            * Math.Sin (2.0*q+2.0*d+2.0*f-m);
	ps = ps+   0.00020            * Math.Sin (2.0*q+2.0*f+m+l);
	ps = ps-   0.00020            * Math.Sin (q-2.0*d+2.0*f-l);
	ps = ps+   0.00020            * Math.Sin (q+2.0*l);
	ps = ps-   0.00020            * Math.Sin (2.0*q+l);
	ps = ps+   0.00020            * Math.Sin (3.0*l);
	ps = ps+   0.00020            * Math.Sin (2.0*q+d+2.0*f);
	ps = ps+   0.00010            * Math.Sin (2.0*q-l);
	ps = ps-   0.00010            * Math.Sin (l-4.0*d);
	ps = ps+   0.00010            * Math.Sin (2.0*(q+d+f-l));
	ps = ps-   0.00020            * Math.Sin (2.0*q+4.0*d+2.0*f-l);
	ps = ps-   0.00010            * Math.Sin (2.0*l-4.0*d);
	ps = ps+   0.00010            * Math.Sin (2.0*q-2.0*d+2.0*f+m+l);
	ps = ps-   0.00010            * Math.Sin (q+2.0*d+2.0*f+l);
	ps = ps-   0.00010            * Math.Sin (2.0*q+4.0*d+2.0*f-2.0*l);
	ps = ps+   0.00010            * Math.Sin (2.0*q+4.0*f-l);
	ps = ps+   0.00010            * Math.Sin (l-m-2.0*d);
	ps = ps+   0.00010            * Math.Sin (q-2.0*d+2.0*f+2.0*l);
	ps = ps-   0.00010            * Math.Sin (2.0*(q+d+f+l));
	ps = ps-   0.00010            * Math.Sin (q+2.0*d+l);
	ps = ps+   0.00010            * Math.Sin (2.0*q-2.0*d+4.0*f);
	ps = ps+   0.00010            * Math.Sin (2.0*q-2.0*d+2.0*f+3.0*l);
	ps = ps-   0.00010            * Math.Sin (l+2.0*f-2.0*d);
	ps = ps+   0.00010            * Math.Sin (q+2.0*f+m);
	ps = ps+   0.00010            * Math.Sin (q+2.0*d-m-l);
	ps = ps-   0.00010            * Math.Sin (q-2.0*f);
	ps = ps-   0.00010            * Math.Sin (2.0*q-d+2.0*f);
	ps = ps-   0.00010            * Math.Sin (2.0*d+m);
	ps = ps-   0.00010            * Math.Sin (l-2.0*f-2.0*d);
	ps = ps-   0.00010            * Math.Sin (q+2.0*f-m);
	ps = ps-   0.00010            * Math.Sin (q-2.0*d+m+l);
	ps = ps-   0.00010            * Math.Sin (l-2.0*f+2.0*d);
	ps = ps+   0.00010            * Math.Sin (2.0*(l+d));
	ps = ps-   0.00010            * Math.Sin (2.0*q+4.0*d+2.0*f);
	ps = ps+   0.00010            * Math.Sin (d+m);
//---------------------------------------------------------------------
//                     Calculate true sidereal time
//---------------------------------------------------------------------
	s0 = sm+(pl+ps)/15.0* Math.Cos (e);
//----------------------------------------------------------------------
//-----------------------------------------------------------------------
//	Star_time = M_PI/12*s0/3600.0;
        s0 = Math.PI/12*s0/3600.0;
        return s0;
}
//**********************************************************
public DateTime UTCToStarTime(DateTime t_utc)
{
    /*
      Перевод всемирного времени в звездное. Если t_utc=0, то время текущее
      t_utc и возвращаемое значение в формате TDateTime
    */
int d,month,year;
int h,min,sec,ms;
DateTime dt_cur;
   if (t_utc==DateTime.FromBinary(0))  // текущие время и дата
        {
    dt_cur = DateTime.Now;
    year = dt_cur.Year;
    month = dt_cur.Month;
    d = dt_cur.Day;
    h = dt_cur.Hour;
    min = dt_cur.Minute;
    sec = dt_cur.Second;
    ms = dt_cur.Millisecond;
    //DecodeDate(Date(),year,month,d);
    //DecodeTime(Time(),h,min,sec,ms);
        }
   else
        {
    dt_cur = t_utc;
    year = dt_cur.Year;
    month = dt_cur.Month;
    d = dt_cur.Day;
    h = dt_cur.Hour;
    min = dt_cur.Minute;
    sec = dt_cur.Second;
    ms = dt_cur.Millisecond;
    //DecodeDate(t_utc,year,month,d);
    //DecodeTime(t_utc,h,min,sec,ms);
        }
//
double TD = WrRad(h,min,sec,ms);
	   //TD = (TD-0.7853981)/2.0/M_PI;
	   TD = (TD - Math.PI/12*(double)GMT)/2.0/Math.PI;
       double SM = Star_time(d, month, year) + longitude + (2 * Math.PI + 1.7202764E-02) * TD;
//  float  SM =  Star_time(0,0,0) + 0.6567674 +(2*M_PI + 1.7202764E-02)*TD;
double  ir = SM;
   if (ir >= 2*Math.PI) ir = ir - 2*Math.PI;
ushort gr,m,sc;
   RadWr((double)ir,out gr,out m,out sc);
   DateTime tt = new DateTime(year, month, d, gr, m, sc);
//double   tt = (double)gr/24.0 + (double)m/24.0/60.0
  //                + (double)sc/24.0/60.0/60.0;
//long tt_l = (long)tt;
  // tt = tt.AddSeconds(68);  // 24.07.2015 для БСА
   return tt;
}
public DateTime StarTimeToMT(DateTime dt_star)
{
    // Возвращается местное время с учетом часового пояса (astronom.GMT) и долготы (astronom.longitude)
    DateTime GMST0 = UTCToStarTime(dt_star.Date);

    DateTime GMST = new DateTime(GMST0.Year, GMST0.Month, GMST0.Day,
        dt_star.Hour, dt_star.Minute, dt_star.Second);
    if (GMST < GMST0) GMST = GMST.AddHours(24);
    TimeSpan ts = GMST.Subtract(GMST0);
    double ut = ts.TotalSeconds * 0.9972695664;
    GMST0 = dt_star.Date.AddSeconds(ut);
    return GMST0;
}
public double J_day(DateTime Date)
{
    int Month = Date.Month;
    int Day = Date.Day;
    int Year = Date.Year;

    if (Month < 3)
    {
        Month = Month + 12;
        Year = Year - 1;
    }
    long JulianDay = Day + (153 * Month - 457) / 5 +
    365 * Year + (Year / 4) - (Year / 100) + (Year / 400) + 1721119;
    return (double)JulianDay - 0.5;
}
public double ToJulianDate(DateTime date)
{
    return date.ToOADate() + 2415018.5;
}
public void EPOCH50(DateTime date, ref double ALR, ref double DLR)
{
    /*
    date - дата и время на которые производится пересчет в
    формате DateTime. ALR, DLR - alpha, delta исходные
    при возврате  ALR, DLR заменяются на пересчитанные
    */
    double X9 = 0.91745;
    double X3 = 0.39786;
    double A = 2.23499E-4;
    double B = 9.71615E-5;
    double C = 8.35819E-5;
    double D = 0.211399;
    double E = -0.337571;
    double F = 6.15713E-6;
    double G = 3.49349;
    double H = 12.5666;
    double XI = 4.46513E-5;
    double XJ = 2.66648E-6;
    double XK = 9.93674E-5;
    double XB = 1.39626;
    double T, TJD, ALP, DLP;
    double DET, GHT, PT, SA, SD, CA, CD;
    double SDET, CDET, SGHT, CGHT, SPT, CPT;
    double AL = ALR;
    double DL = DLR;
    TJD = J_day(date);
    T = (TJD - 2433282.0) / 365.25;
    ALP = AL + (A + B * Math.Sin(AL) * Math.Sin(DL) / Math.Cos(DL)) * T;
    DLP = DL + B * Math.Cos(AL) * T;
    ALP = (ALP + AL) / 2.0;
    DLP = (DLP + DL) / 2.0;
    AL = AL + (A + B * Math.Sin(ALP) * Math.Sin(DLP) / Math.Cos(DLP)) * T;
    DL = DL + B * Math.Cos(ALP) * T;
    DET = D + E * T;
    GHT = G + H * T;
    //PT = 2.0*Math.PI*(T-INT(T))-XB;
    PT = 2.0 * Math.PI * (T - Math.Floor(T)) - XB;
    SA = Math.Sin(AL);
    SD = Math.Sin(DL);
    CA = Math.Cos(AL);
    CD = Math.Cos(DL);
    SDET = Math.Sin(DET);
    CDET = Math.Cos(DET);
    SGHT = Math.Sin(GHT);
    CGHT = Math.Cos(GHT);
    SPT = Math.Sin(PT);
    CPT = Math.Cos(PT);
    AL = AL - (C * SDET + F * SGHT) * (X9 + X3 * SA * SD / CD) - (XI * CDET + XJ *
    CGHT) * CA * SD / CD - XK * (CPT * X9 * CA / CD + SPT * SA / CD);
    DL = DL - (C * SDET + F * SGHT) * X3 * CA + (XI * CDET + XJ * CGHT) * SA - XK *
    (CPT * (X3 * CD - X9 * SA * SD) + SPT * CA * SD);
    ALR = AL;
    DLR = DL;
}
public void EPOCH00(DateTime date, ref double ALR, ref double DLR)
{
    double X9 = 0.917493;		// 	X9 = 0.91745;
    double X3 = 0.397753;		//    X3 = 0.39786;
    double A = 2.23645E-4;    //    A = 2.23499E-4;
    double B = 9.71567E-5;		//	B = 9.71615E-5;
    double C = 8.338796E-5; 	//	C = 8.35819E-5;
    double D = 2.182437; 		//	D = 0.211399;
    double E = -0.338831;		//	E = -0.337571;
    //double			F = 6.15713E-6;
    //double			G = 3.49349;
    //double			H = 12.5666;
    double XI = 4.465134E-5;	//	XI = 4.46513E-5;
    //double			XJ = 2.66648E-6;
    double XK = 9.93674E-5;
    double XB = 1.396263;
    double T, TJD, ALP, DLP;
    double DET, GHT, PT, SA, SD, CA, CD;
    double SDET, CDET, SGHT, CGHT, SPT, CPT;
    double AL = ALR;
    double DL = DLR;
    TJD = J_day(date);
    T = (TJD - 2451879.5) / 365.25;  // 2451879.5 jd 01.01.2000 00h
    ALP = AL + (A + B * Math.Sin(AL) * Math.Sin(DL) / Math.Cos(DL)) * T;
    DLP = DL + B * Math.Cos(AL) * T;
    ALP = (ALP + AL) / 2.0;
    DLP = (DLP + DL) / 2.0;
    AL = AL + (A + B * Math.Sin(ALP) * Math.Sin(DLP) / Math.Cos(DLP)) * T;
    DL = DL + B * Math.Cos(ALP) * T;
    DET = D + E * T;
    //			GHT = G+H*T;
    PT = 2.0 * Math.PI * (T - Math.Floor(T)) - XB;
    SA = Math.Sin(AL);
    SD = Math.Sin(DL);
    CA = Math.Cos(AL);
    CD = Math.Cos(DL);
    SDET = Math.Sin(DET);
    CDET = Math.Cos(DET);
    //			SGHT = sin(GHT);
    //			CGHT = cos(GHT);
    SPT = Math.Sin(PT);
    CPT = Math.Cos(PT);
    AL = AL - (C * SDET) * (X9 + X3 * SA * SD / CD) - (XI * CDET) * CA * SD / CD -
    XK * (CPT * X9 * CA / CD + SPT * SA / CD);
    DL = DL - (C * SDET) * X3 * CA + (XI * CDET) * SA - XK *
    (CPT * (X3 * CD - X9 * SA * SD) + SPT * CA * SD);
    ALR = AL;
    DLR = DL;
}
    }
}
