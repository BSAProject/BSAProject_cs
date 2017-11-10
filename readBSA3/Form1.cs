using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
using System.IO;
using System.Threading;
using System.Runtime.InteropServices;
using System.Management;
using System.Diagnostics;
using System.Web.UI;

namespace readBSA3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            file_ops.modulus = new List<int>();
            file_ops.wbands = new List<float>();
            file_ops.fbands = new List<float>();
            //for (int i = 0; i < pmbb.Count(); i++) pmbb[i] = new List<Single>();
            nrb_checked = GetRadioIndex(groupBox1);
            astronom = new astronom_(comboBox_gmt.SelectedIndex);
            StarTime = new startime(comboBox_gmt.SelectedIndex);
            comboBox_gmt.SelectedIndex = 4;

            //TCommon common = new TCommon();
        }

        _file_ops file_ops = new _file_ops();
        List<_file_ops> files_ops = new List<_file_ops>();
        List<Single>[] p_beams_all = new List<float>[8];
        List<DateTime> x_axes = new List<DateTime>();

        double GMT = 4; //  Time_zone

        TCommon common = new TCommon(8);
        public astronom_ astronom;
        public startime StarTime;

        int nrb_checked = 1;  // checked module number
        List<string> files_names = new List<string>();  // имена файлов
        string extention = ".pnt";
        int GetRadioIndex(GroupBox group)
        {
            foreach (System.Windows.Forms.Control control in group.Controls)
                if (control is RadioButton)
                    if (((RadioButton)control).Checked)
                        return int.Parse(control.Tag.ToString());
            return -1;
        }
        void ChartRefresh()
        {
            int module = GetRadioIndex(groupBox1) - 1;
            int spectr = cBox_spectr.SelectedIndex;
            long index;

            for (int i = 0; i < 8; i++)
            {
                index = GetIndex(module, i, spectr);
                tChart1.Series[i].Clear();
                tChart1.Series[i].Add(x_axes.ToArray(),
                    p_beams_all[index].ToArray());
            }

            textBox1.Text = "";
            foreach (string s in files_names)
            {
                textBox1.AppendText(Path.GetFileName(s) + "\r\n");
            }
            GC.Collect();
            GC.WaitForPendingFinalizers();


        }
        public string GetFileNameByTl(DateTime dt_local, int recorder)
        {
            //  имя файла по локальному времени
            string s_name = "";
            DateTime t_name = dt_local.AddHours(1);
            s_name = t_name.ToString("ddMMyy_HH") + "_N" + recorder.ToString("0") + "_00";
            s_name += extention;
            return s_name;
        }

        private void button_read_Click(object sender, EventArgs e)
        {

            System.IO.FileStream fstr;
            System.IO.StreamReader strf;
            System.IO.BinaryReader bf;
            //List<Single> pmbb;
            string s;
            char[] delimiterChars = { ' ', '\t' };
            string[] words;
            int numpar;
            ulong size_header;
            DateTime date_utc = new DateTime();
            DateTime time_utc = new DateTime();

            //if OpenFileDialog1.ShowDialog()= DialogResult.OK
            openFileDialog1.Filter = "shortdata|*.pnt|longdata|*.pnthr|All files|*.*";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    fstr = new System.IO.FileStream(openFileDialog1.FileName, System.IO.FileMode.Open);
                }
                catch (Exception E)
                {
                    tBmessages.AppendText(E.Message);
                    return;
                }
                //-----
                strf = new System.IO.StreamReader(fstr);
                size_header = 0;
                s = strf.ReadLine();
                words = s.Split(delimiterChars, 2, StringSplitOptions.RemoveEmptyEntries);
                if (words.Length <= 1)
                {
                    MessageBox.Show(openFileDialog1.FileName, "Неверный формат файла");
                    strf.Close();
                    fstr.Close();
                    return;
                }
                if (words[0] != "numpar")
                {
                    MessageBox.Show(openFileDialog1.FileName, "Неверный формат файла");
                    strf.Close();
                    fstr.Close();
                    return;
                }


                numpar = Convert.ToInt32(words[1]);
                size_header += (ulong)s.Length + 1; // "\r\n"
                tBmessages.Text = "";

                //------------------номер регистратора---------------------------
                char[] _delimiterChars = { ' ', '\t', '_' };
                string[] _words = Path.GetFileNameWithoutExtension(openFileDialog1.FileName).Split(_delimiterChars,
                    StringSplitOptions.RemoveEmptyEntries);
                string _s = _words[2]; _s = _s.Replace("N", "");
                file_ops.recorder = Convert.ToInt32(_s);
                //--------обработка заголовка-------------------------
                CultureInfo culture_en = new CultureInfo("en-US");
                CultureInfo culture_ru = new CultureInfo("ru-RU");
                try
                {
                    for (int i = 0; i < numpar - 1; i++)
                    {
                        s = strf.ReadLine();
                        tBmessages.AppendText(s + "\r\n");
                        size_header += (ulong)s.Length + 1;
                        words = s.Split(delimiterChars, StringSplitOptions.RemoveEmptyEntries);
                        words[0] = words[0].ToLower();
                        switch (words[0])
                        {
                            case "source":
                                file_ops.source = words[1];
                                break;
                            case "alpha":
                                file_ops.alpha = words[1];
                                break;
                            case "delta":
                                file_ops.delta = words[1];
                                break;
                            case "fcentral":
                                file_ops.fcentral = Convert.ToSingle(words[1], culture_en);
                                break;
                            case "npoints":
                                file_ops.npoints = Convert.ToUInt32(words[1]);
                                break;
                            case "wb_total":
                                file_ops.fcentral = Convert.ToSingle(words[1], culture_en);
                                break;
                            case "tresolution":
                                file_ops.tresolution = Convert.ToSingle(words[1], culture_en);
                                break;
                            case "date_begin":
                                file_ops.date_begin = Convert.ToDateTime(words[1], culture_ru);
                                file_ops.date_begin_str = words[1];
                                date_utc = Convert.ToDateTime(words[3], culture_ru);
                                break;
                            case "date_end":
                                file_ops.date_end = Convert.ToDateTime(words[1], culture_ru);
                                file_ops.date_end_str = words[1];
                                break;
                            case "time_begin":
                                file_ops.time_begin = Convert.ToDateTime(words[1], culture_en);
                                file_ops.time_begin_str = words[1];
                                time_utc = Convert.ToDateTime(words[3], culture_en);
                                break;
                            case "time_end":
                                file_ops.time_end = Convert.ToDateTime(words[1], culture_en);
                                file_ops.time_end_str = words[1];
                                break;
                            case "modulus":
                                file_ops.modulus.Clear();
                                for (int k = 1; k < words.Length; k++) file_ops.modulus.Add(Convert.ToInt32(words[k]));
                                break;
                            case "nbands":
                                file_ops.nbands = Convert.ToInt32(words[1]);
                                //UD_band.Maximum = file_ops.nbands+1;
                                break;
                            case "wbands":
                                file_ops.wbands.Clear();
                                for (int k = 1; k < words.Length; k++) file_ops.wbands.Add(Convert.ToSingle(words[k], culture_en));
                                break;
                            case "fbands":
                                file_ops.fbands.Clear();
                                for (int k = 1; k < words.Length; k++) file_ops.fbands.Add(Convert.ToSingle(words[k], culture_en));
                                break;
                        }  // switch
                    }  // for (int i = 0; i < numpar-1; i++)
                }
                catch (Exception)
                {
                    MessageBox.Show(s, "Ошибка при обработке строки");
                    strf.Close();
                    fstr.Close();
                    return;
                }
                //----------------------------------------------------
                file_ops.date_begin = file_ops.date_begin.Add(new TimeSpan(file_ops.time_begin.Hour,
                    file_ops.time_begin.Minute, file_ops.time_begin.Second));
                file_ops.date_end = file_ops.date_end.Add(new TimeSpan(file_ops.time_end.Hour,
                    file_ops.time_end.Minute, file_ops.time_end.Second));

                file_ops.datetime_utc = date_utc.Add(new TimeSpan(time_utc.Hour,
                    time_utc.Minute, time_utc.Second));


                //
                int nmodule = GetRadioIndex(groupBox1);

                long nmodule_;
                if (!file_ops.modulus.Contains(nmodule))
                {
                    MessageBox.Show("Выбран неактивный модуль", "Ошибка при выборе номера модуля");
                    strf.Close();
                    fstr.Close();
                    return;
                }
                else nmodule_ = nmodule - 1;

                bf = new System.IO.BinaryReader(fstr);
                //  полное чтение и хранение файла данных
                bf.BaseStream.Position = (long)size_header;
                int buf_length = (file_ops.nbands + 1) * 8; // точка во вх.данных для 1-го модуля
                int nbeams_all = buf_length * file_ops.modulus.Count; // для всех модулей
                if (p_beams_all.Length != nbeams_all)
                {
                    Array.Resize(ref p_beams_all, nbeams_all);
                }
                for (int i = 0; i < p_beams_all.Length; i++)
                {
                    if (p_beams_all[i] == null) p_beams_all[i] = new List<float>((int)file_ops.npoints);
                    p_beams_all[i].Clear();
                }
                byte[] buf_1p = new byte[nbeams_all * sizeof(float)];

                float[] buf_float = new float[nbeams_all];
                int size = Marshal.SizeOf(buf_1p[0]) * buf_1p.Length;
                IntPtr pnt = Marshal.AllocHGlobal(size);
                pB_load.Visible = true;
                pB_load.Maximum = 100;
                pB_load.Value = 0;

                //
                /*
                p_beams_all:
                 * index[]  module  spectr  beam
                 * 0           0    0       0
                 * 1           0    1       0
                 * 2           0    2       0
                 * ---------------------------
                 * nbands      0    nbands  0
                 * nbands+1    0    0       1
                 * nbands+2    0    1       1
                 * ---------------------------
                 * nbands*2    0    nbands  1
                 * nbands*2+1  0    0       2
                 * --------------------------
                 * nbands*3    0    nbands  2
                 * --------------------------
                 * nbands*7    0    0       7
 
                */
                for (long i = 0; i < file_ops.npoints; i++)
                {
                    buf_1p = bf.ReadBytes(buf_1p.Length);
                    Marshal.Copy(buf_1p, 0, pnt, buf_1p.Length);
                    Marshal.Copy(pnt, buf_float, 0, buf_float.Length);
                    for (int im = 0; im < file_ops.modulus.Count; im++) // module
                        for (int ib = 0; ib < 8; ib++) // beam into module
                            for (int ispectr = 0; ispectr <= file_ops.nbands; ispectr++)
                            {
                                p_beams_all[im * (file_ops.nbands + 1) * 8 + (file_ops.nbands + 1) * ib + ispectr].Add
                                    (buf_float[im * (file_ops.nbands + 1) * 8 + (file_ops.nbands + 1) * ib + ispectr]);
                            }
                    if (((double)i / (double)file_ops.npoints) * 100 > (double)pB_load.Value)
                    {
                        pB_load.Value++;
                        //this.Refresh();
                        //this.Invalidate();
                        Application.DoEvents();
                    }

                }
                pB_load.Visible = false;
                buf_float = null;

                Marshal.FreeHGlobal(pnt);

                ///
                //for (int i = 0; i < 8; i++) tChart1.Series[i].Clear();
                //List<DateTime> x_axes = new List<DateTime>();
                DateTime t = file_ops.date_begin;
                x_axes.Clear();
                for (long i = 0; i < file_ops.npoints; i++)
                    x_axes.Add(t.AddMilliseconds((double)i * file_ops.tresolution));
                int module = GetRadioIndex(groupBox1) - 1;
                string[] nspectr = new string[file_ops.nbands + 1];
                cBox_spectr.Items.Clear();
                for (int i = 1; i <= file_ops.nbands + 1; i++)
                {
                    nspectr[i - 1] = i.ToString("0");

                }
                bf.Close();
                strf.Close();
                fstr.Close();
                files_ops.Clear();
                files_ops.Add(file_ops);
                files_names.Clear();
                files_names.Add(openFileDialog1.FileName);
                cBox_spectr.Items.AddRange(nspectr);
                cBox_spectr.SelectedIndex = file_ops.nbands;
                label_path.Text = Path.GetDirectoryName(files_names[0]);


            }  //if (openFileDialog1.ShowDialog() == DialogResult.OK)
        }

        private bool GetDataByFileName(string name_last, ref _file_ops file_ops, ref List<Single>[] pmbb)
        {
            System.IO.FileStream fstr;
            System.IO.StreamReader strf;
            System.IO.BinaryReader bf;
            //List<Single> pmbb;
            string s;
            char[] delimiterChars = { ' ', '\t' };
            string[] words;
            int numpar;
            ulong size_header;
            try
            {
                fstr = new System.IO.FileStream(name_last, System.IO.FileMode.Open);
            }
            catch (Exception E)
            {
                tBmessages.AppendText(E.Message);
                return false;
            }
            //-----
            strf = new System.IO.StreamReader(fstr);
            size_header = 0;
            s = strf.ReadLine();
            words = s.Split(delimiterChars, 2, StringSplitOptions.RemoveEmptyEntries);
            if (words.Length <= 1)
            {
                //MessageBox.Show(openFileDialog1.FileName, "Неверный формат файла");
                strf.Close();
                fstr.Close();
                return false;
            }
            if (words[0] != "numpar")
            {
                //MessageBox.Show(openFileDialog1.FileName, "Неверный формат файла");
                strf.Close();
                fstr.Close();
                return false;
            }


            numpar = Convert.ToInt32(words[1]);
            size_header += (ulong)s.Length + 1; // "\r\n"
            tBmessages.Text = "";

            //------------------номер регистратора---------------------------
            char[] _delimiterChars = { ' ', '\t', '_' };
            string[] _words = Path.GetFileNameWithoutExtension(name_last).Split(_delimiterChars,
                StringSplitOptions.RemoveEmptyEntries);
            string _s = _words[2]; _s = _s.Replace("N", "");
            file_ops.recorder = Convert.ToInt32(_s);
            //--------обработка заголовка-------------------------
            CultureInfo culture_en = new CultureInfo("en-US");
            CultureInfo culture_ru = new CultureInfo("ru-RU");
            try
            {
                for (int i = 0; i < numpar - 1; i++)
                {
                    s = strf.ReadLine();
                    tBmessages.AppendText(s + "\r\n");
                    size_header += (ulong)s.Length + 1;
                    words = s.Split(delimiterChars, StringSplitOptions.RemoveEmptyEntries);
                    words[0] = words[0].ToLower();
                    switch (words[0])
                    {
                        case "source":
                            file_ops.source = words[1];
                            break;
                        case "alpha":
                            file_ops.alpha = words[1];
                            break;
                        case "delta":
                            file_ops.delta = words[1];
                            break;
                        case "fcentral":
                            file_ops.fcentral = Convert.ToSingle(words[1], culture_en);
                            break;
                        case "npoints":
                            file_ops.npoints = Convert.ToUInt32(words[1]);
                            break;
                        case "wb_total":
                            file_ops.fcentral = Convert.ToSingle(words[1], culture_en);
                            break;
                        case "tresolution":
                            file_ops.tresolution = Convert.ToSingle(words[1], culture_en);
                            break;
                        case "date_begin":
                            file_ops.date_begin = Convert.ToDateTime(words[1], culture_ru);
                            file_ops.date_begin_str = words[1];
                            break;
                        case "date_end":
                            file_ops.date_end = Convert.ToDateTime(words[1], culture_ru);
                            file_ops.date_end_str = words[1];
                            break;
                        case "time_begin":
                            file_ops.time_begin = Convert.ToDateTime(words[1], culture_en);
                            file_ops.time_begin_str = words[1];
                            break;
                        case "time_end":
                            file_ops.time_end = Convert.ToDateTime(words[1], culture_en);
                            file_ops.time_end_str = words[1];
                            break;
                        case "modulus":
                            file_ops.modulus.Clear();
                            for (int k = 1; k < words.Length; k++) file_ops.modulus.Add(Convert.ToInt32(words[k]));
                            break;
                        case "nbands":
                            file_ops.nbands = Convert.ToInt32(words[1]);
                            //UD_band.Maximum = file_ops.nbands+1;
                            break;
                        case "wbands":
                            file_ops.wbands.Clear();
                            for (int k = 1; k < words.Length; k++) file_ops.wbands.Add(Convert.ToSingle(words[k], culture_en));
                            break;
                        case "fbands":
                            file_ops.fbands.Clear();
                            for (int k = 1; k < words.Length; k++) file_ops.fbands.Add(Convert.ToSingle(words[k], culture_en));
                            break;
                    }  // switch
                }  // for (int i = 0; i < numpar-1; i++)
            }
            catch (Exception)
            {
                //MessageBox.Show(s, "Ошибка при обработке строки");
                strf.Close();
                fstr.Close();
                return false;
            }
            //----------------------------------------------------
            file_ops.date_begin = file_ops.date_begin.Add(new TimeSpan(file_ops.time_begin.Hour,
                file_ops.time_begin.Minute, file_ops.time_begin.Second));
            file_ops.date_end = file_ops.date_end.Add(new TimeSpan(file_ops.time_end.Hour,
                file_ops.time_end.Minute, file_ops.time_end.Second));
            //
            int nmodule = GetRadioIndex(groupBox1);

            long nmodule_;
            if (!file_ops.modulus.Contains(nmodule))
            {
                //MessageBox.Show("Выбран неактивный модуль", "Ошибка при выборе номера модуля");
                strf.Close();
                fstr.Close();
                return false;
            }
            else nmodule_ = nmodule - 1;
            bf = new System.IO.BinaryReader(fstr);
            bf.BaseStream.Position=(long)size_header;
            int buf_length = (file_ops.nbands + 1) * 8; // точка во вх.данных для 1-го модуля
            int nbeams_all = buf_length * file_ops.modulus.Count; // для всех модулей

            byte[] buf_1p = new byte[nbeams_all * sizeof(float)];

            float[] buf_float = new float[nbeams_all];
            int size = Marshal.SizeOf(buf_1p[0]) * buf_1p.Length;
            IntPtr pnt = Marshal.AllocHGlobal(size);
            pB_load.Visible = true;
            //pB_load.Maximum = (int)(file_ops.npoints/100)+1;
            pB_load.Maximum = 100;
            pB_load.Value = 0;
//
            for (long i = 0; i < file_ops.npoints; i++)
            {
                buf_1p = bf.ReadBytes(buf_1p.Length);
                Marshal.Copy(buf_1p, 0, pnt, buf_1p.Length);
                Marshal.Copy(pnt, buf_float, 0, buf_float.Length);
                for (int im = 0; im < file_ops.modulus.Count; im++) // module
                    for (int ib = 0; ib < 8; ib++) // beam into module
                        for (int ispectr = 0; ispectr <= file_ops.nbands; ispectr++)
                        {
                            pmbb[im * (file_ops.nbands + 1) * 8 + (file_ops.nbands + 1) * ib + ispectr].Add
                                (buf_float[im * (file_ops.nbands + 1) * 8 + (file_ops.nbands + 1) * ib + ispectr]);
                        }
                if (((double)i / (double)file_ops.npoints) * 100 > (double)pB_load.Value)
                {
                    pB_load.Value++;
                    //this.Refresh();
                    //this.Invalidate();
                    Application.DoEvents();
                }

            }
            pB_load.Visible = false;

            Marshal.FreeHGlobal(pnt);

            ///

//
            bf.Close();
            strf.Close();
            fstr.Close();

            return true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //file_ops.modulus = new List<int>();
            //file_ops.wbands = new List<float>();
            //file_ops.fbands = new List<float>();


            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Rectangle form = this.Bounds;
            Point loc_chart = new Point();

            //using (Bitmap bitmap = new Bitmap(form.Width, form.Height))
            using (Bitmap bitmap = new Bitmap(tChart1.Width, tChart1.Height))
            {
                using (Graphics graphic =
                    Graphics.FromImage(bitmap))
                {

                    loc_chart.X = form.Location.X + tChart1.Location.X + tabControl1.Location.X + 5 + 4;
                    loc_chart.Y = form.Location.Y + tabControl1.Location.Y + tChart1.Location.Y+24 +  21 + 6 + 3 + 1;
                   
                    graphic.CopyFromScreen(loc_chart, Point.Empty, tChart1.Size);
                }
                //bitmap.Save("C://test.jpg", System.Drawing.Imaging.ImageFormat.Png);
                System.IO.MemoryStream stream = new System.IO.MemoryStream();
                bitmap.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                Bitmap bmp = new Bitmap(stream);
                Clipboard.SetDataObject(bmp);
            } 

        }
        private long GetIndex(int module,int beam,int spectr)
        {
            /*
             * module 0-5
             * beam 0-7
             * spectr 0-nbands
             */
            long index = spectr + (file_ops.nbands + 1) * beam + module * (file_ops.nbands + 1) * 8;
            return index;
        }

        private void tChart1_MouseMove(object sender, MouseEventArgs e)
        {
            if (files_ops.Count == 0) return;
            double YF,XF;
            DateTime dt;
            //XF = e.X; 
            //YF = e.Y;
            XF=tChart1.Axes.Bottom.CalcPosPoint(e.X);
            dt = DateTime.FromOADate(XF);

            YF = tChart1.Axes.Left.CalcPosPoint(e.Y);
            //long seconds = (long)(dt.Hour * 3600 + dt.Minute * 60 + dt.Second) -
                //(long)(file_ops.time_begin.Hour * 3600 + file_ops.time_begin.Minute * 60 + file_ops.time_begin.Second);
            long msec = (long)(dt - files_ops.First().date_begin).TotalMilliseconds;
            DateTime t_UTC = astronom.UTCToStarTime(dt);
            //long msec = (long)((float)seconds * 1000 / file_ops.tresolution);
            msec =  (long)((float)msec/ file_ops.tresolution);
            _file_ops file_ops_utc = files_ops.First();
            file_ops_utc.delta_lucha = 0.89;
            string s = StarTime.StarTime(file_ops_utc, msec);
            //string s = t_UTC.AddSeconds(67.5).ToString("HH:mm:ss");
            label_position.Text = "X=" + msec.ToString() + "  " + dt.ToString("dd:MM:yyy HH:mm:ss:F00")
                + " Y=" + YF.ToString("#0.000")
            +"   StarTime =" + t_UTC.ToString("HH:mm:ss")
            + "  STBSA:" + s;
            
        }


        private void rBmodule1_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton r = (RadioButton)sender;
            if (!r.Checked) return;
            int i = GetRadioIndex(groupBox1);
            if (i == nrb_checked) return;
            nrb_checked = i;
            if (p_beams_all[0] == null) return;
            //MessageBox.Show("Checked module is:" + nrb_checked.ToString());
            ChartRefresh();

        }

        private void button_p1h_rigth_Click(object sender, EventArgs e)
        {
            if (files_names.Count == 0)
            {
                MessageBox.Show("Нет ни одного прочитанного файла!");
                return;
            }
            string extension = Path.GetExtension(files_names.Last());
            if (extension!=".pnt")
            {
                //MessageBox.Show(Path.GetFileName(files_names.Last()), "Этот режим только для коротких данных: "); return;
            }

            string name_last = GetFileNameByTl(files_ops.Last().date_end.AddMinutes(1), file_ops.recorder);
            name_last = Path.GetFileNameWithoutExtension(name_last) + extension;
            name_last = Path.GetDirectoryName(files_names.Last()) + "\\" + name_last;
            int buf_length = (file_ops.nbands + 1) * 8; // точка во вх.данных для 1-го модуля
            int nbeams_all = buf_length * file_ops.modulus.Count; // для всех модулей

            List<Single>[] _pmbb = new List<float>[nbeams_all];  // данные для 8 лучей
            _file_ops file_ops_t = new _file_ops();
            file_ops_t.modulus = new List<int>();
            file_ops_t.wbands = new List<float>();
            file_ops_t.fbands = new List<float>();
            for (int i = 0; i < _pmbb.Count(); i++) _pmbb[i] = new List<Single>();

            if (!GetDataByFileName(name_last, ref file_ops_t, ref _pmbb))
            {
                MessageBox.Show(name_last,"Ошибка при чтении файла: "); return;
            }
            DateTime t = file_ops_t.date_begin;
            //List<DateTime> xvt = new List<DateTime>();
            //List<Double> yv = new List<double>();
            //long count_points = 0;

            //for (int i = 0; i < files_ops.Count; i++) count_points += files_ops[i].npoints;
            //for (long i = 0; i < count_points; i++) xvt.Add(DateTime.FromOADate(tChart1.Series[0].XValues.Value[i]));
            //for (long i = 0; i < _pmbb[0].Count(); i++) xvt.Add(t.AddMilliseconds((double)i * file_ops_t.tresolution));
            for (long i = 0; i < _pmbb[0].Count(); i++) x_axes.Add(t.AddMilliseconds((double)i * file_ops_t.tresolution));

            for (int i = 0; i < _pmbb.Length; i++) p_beams_all[i].AddRange(_pmbb[i]);


/*
                for (int b = 0; b < 8; b++)
                {
                    yv.Clear();
                    for (long i = 0; i < count_points; i++) yv.Add(tChart1.Series[b].YValues.Value[i]);
                    for (int i = 0; i < file_ops_t.npoints; i++) yv.Add((double)_pmbb[b][i]);
                    tChart1.Series[b].Clear();
                    tChart1.Series[b].Add(xvt.ToArray(), yv.ToArray());
                }
*/
/*
            for (int b = 0; b < 8; b++)
            {
                t = file_ops_t.date_begin;
                for (int i = 0; i < _pmbb[b].Count; i++)
                {
                    tChart1.Series[b].Add(t.AddMilliseconds((double)i * file_ops_t.tresolution), _pmbb[b][i]);
                }
            }
*/
//--------------------------------------
            for (int i = 0; i < _pmbb.Length; i++) _pmbb[i].Clear();
            files_ops.Add(file_ops_t);
            files_names.Add(name_last);
            ChartRefresh();

        }

        private void button_m1h_rigth_Click(object sender, EventArgs e)
        {
            if (files_names.Count <= 1) return;
            int ind_rem = 0;
            for (int i = 0; i < files_ops.Count - 1; i++) ind_rem += (int)files_ops[i].npoints;
            //ind_rem = ind_rem - 1;
                x_axes.RemoveRange(ind_rem, (int)files_ops.Last().npoints);
            for (int i = 0; i < p_beams_all.Length; i++) p_beams_all[i].RemoveRange(ind_rem, (int)files_ops.Last().npoints);
            files_names.RemoveAt(files_names.Count - 1);
            files_ops.RemoveAt(files_ops.Count - 1);
            ChartRefresh();

        }

        private void button_p1h_left_Click(object sender, EventArgs e)
        {
            if (files_names.Count == 0)
            {
                MessageBox.Show("Нет ни одного прочитанного файла!");
                return;
            }
            string extension = Path.GetExtension(files_names.Last());
            if (extension != ".pnt")
            {
                //MessageBox.Show(Path.GetFileName(files_names.Last()), "Этот режим только для коротких данных: "); return;
            }

            string name_first = GetFileNameByTl(files_ops.First().date_end.AddHours(-1.992), file_ops.recorder);
            name_first = Path.GetFileNameWithoutExtension(name_first) + extension;
            name_first = Path.GetDirectoryName(files_names.Last()) + "\\" + name_first;
            int buf_length = (file_ops.nbands + 1) * 8; // точка во вх.данных для 1-го модуля
            int nbeams_all = buf_length * file_ops.modulus.Count; // для всех модулей

            List<Single>[] _pmbb = new List<float>[nbeams_all];  // данные для 8 лучей
            _file_ops file_ops_t = new _file_ops();
            file_ops_t.modulus = new List<int>();
            file_ops_t.wbands = new List<float>();
            file_ops_t.fbands = new List<float>();
            for (int i = 0; i < _pmbb.Count(); i++) _pmbb[i] = new List<Single>();

            if (!GetDataByFileName(name_first, ref file_ops_t, ref _pmbb))
            {
                MessageBox.Show(name_first, "Ошибка при чтении файла: "); return;
            }
            DateTime t = file_ops_t.date_begin;
            List<DateTime> xvt = new List<DateTime>();
            List<Double> yv = new List<double>();

            //for (int i = 0; i < files_ops.Count; i++) count_points += files_ops[i].npoints;
            for (long i=0;i < _pmbb[0].Count();i++) xvt.Add(t.AddMilliseconds((double)i * file_ops_t.tresolution));
            x_axes.InsertRange(0, xvt);
            //for (long i = 0; i < count_points; i++) xvt.Add(DateTime.FromOADate(tChart1.Series[0].XValues.Value[i]));
            for (int i = 0; i < p_beams_all.Length; i++) p_beams_all[i].InsertRange(0, _pmbb[i]);
/*
                for (int b = 0; b < 8; b++)
                {
                    yv.Clear();
                    for (int i = 0; i < file_ops_t.npoints; i++) yv.Add((double)_pmbb[b][i]);
                    for (long i = 0; i < count_points; i++) yv.Add(tChart1.Series[b].YValues.Value[i]);
                    tChart1.Series[b].Clear();

                    tChart1.Series[b].Add(xvt.ToArray(), yv.ToArray());
                }
 */

            files_ops.Insert(0, file_ops_t);
            files_names.Insert(0, name_first);
            ChartRefresh();

        }

        private void button_m1h_left_Click(object sender, EventArgs e)
        {
            if (files_names.Count <= 1) return;
/*
            for (int b = 0; b < 8; b++)
            {
                tChart1.Series[b].Delete(0, (int)files_ops.First().npoints);
            }
 */
            x_axes.RemoveRange(0, (int)files_ops.First().npoints);
            for (int i = 0; i < p_beams_all.Length; i++) p_beams_all[i].RemoveRange(0, (int)files_ops.First().npoints);
            files_names.RemoveAt(0);
            files_ops.RemoveAt(0);
            ChartRefresh();

        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (p_beams_all != null)
            {
                for (int i = 0; i < p_beams_all.Length; i++)
                    if (p_beams_all[i] != null) p_beams_all[i].Clear();
            }
/*  Инициализация сборщика мусора
            GC.Collect();
            GC.WaitForPendingFinalizers();
 */ 
        }


        private void cBox_spectr_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChartRefresh();
        }

        private void comboBox_gmt_SelectedIndexChanged(object sender, EventArgs e)
        {
            astronom.GMT = Convert.ToInt32(comboBox_gmt.Items[comboBox_gmt.SelectedIndex]);
            StarTime.GMT = Convert.ToInt32(comboBox_gmt.Items[comboBox_gmt.SelectedIndex]);
        }

        public void m2(Pair p)
        {
            //Pair pi = new Pair();
            p.First = Convert.ToInt32(p.First) * 2;
            p.Second = p.Second + "mult2";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
/*
            int f = 2;
            string s = "Second ";

            Pair p1 = new Pair(f,s);
            //p1.First = f;
            //p1.Second = s;
            MessageBox.Show(f.GetType()+" Value:" + p1.First.ToString(), s.GetType() + " Value:" + p1.Second.ToString());
            m2(p1);
            MessageBox.Show(p1.First.GetType()+" Value:" + p1.First.ToString(), p1.Second.GetType() + " Value:" + p1.Second.ToString());
*/
            //Pair p = new Pair("","");
            //p = StarTime.precess((new DateTime(2000,1,1,15,0,0).ToOADate()), 22, 100);
            //MessageBox.Show(p.First.GetType()+" Value:" + p.First.ToString(), p.Second.GetType() + " Value:" + p.Second.ToString());
/*            
            DateTime t = new DateTime(2000, 1, 1, 16, 30, 30);
            double d1 = t.ToOADate();
            TimeSpan ts = new TimeSpan(1, 30, 0);
            double d2 = ts.TotalHours;
            t = t.AddHours(d2);
            double d = t.ToOADate();
            MessageBox.Show(d.ToString());
*/
            string s = StarTime.StarTime(file_ops, 32341);

        }

    }
//-------------------------------------------------------------------
}
