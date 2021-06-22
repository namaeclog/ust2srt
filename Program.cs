using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using utauPlugin;
using Microsoft.Win32;
using System.Text.RegularExpressions;

namespace ust2srt
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        public static String VOICEPATH;
        [STAThread]
        static void Main()
        {
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            VOICEPATH = new Regex("\"(.*)\\\\utau.exe\".*").Match((String)Registry.ClassesRoot.OpenSubKey("UTAUSequenceText\\shell\\open\\command").GetValue("")).Groups[1].Value + "\\voice";
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
    class srt
    {
        public double start { get; set; }
        public double stop { get; set; }
        public String text { get; set; }
        public srt(double s, double e, String t)
        {
            this.start = s;
            this.stop = e;
            this.text = t;
        }
    }
}
