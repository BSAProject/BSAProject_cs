using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace readBSA3
{
    public struct _file_ops
    {
        public int recorder;
        public ulong size_header;
        public List<int> modulus;
        public int nbands;
        public DateTime date_begin;
        public DateTime date_end;
        public DateTime time_begin;
        public DateTime time_end;
        public DateTime datetime_utc;
        public string date_begin_str;
        public string date_end_str;
        public string time_begin_str;
        public string time_end_str;
        public long npoints;
        public string source;
        public string alpha;
        public string delta;
        public Single fcentral;
        public Single wb_total;
        public Single tresolution;
        public List<Single> wbands;
        public List<Single> fbands;
        public double delta_lucha;
    };
    public class TCommon
    {
        //public _file_ops fileops;
        public List<Single>[] _pmbb = new List<float>[8];  // данные для 8 лучей
        public List<Single>[,] pmbb_moduls = new List<float>[6, 8];
        public List<List<Single>> l2 = new List<List<float>>();
        public int k;
        public TCommon(int n_beams)
        {
            for (int i = 0; i < n_beams; i++) _pmbb[i] = new List<Single>();
        }
    }
}
