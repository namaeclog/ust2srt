using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using utauPlugin;
using UtauVoiceBank;

namespace ust2srt
{
    public partial class Form1 : Form
    {
        public UtauPlugin utauPlugin = null;
        public String vb_path = @".\";
        public Boolean vb_path_checked = false;
        private String filename = "";
        public Form1()
        {
            InitializeComponent();
        }


        private void load_ust_Click(object sender, EventArgs e)
        {
            if(openfile_dialog.ShowDialog() == DialogResult.OK)
            {
                filename = openfile_dialog.FileName;
                utauPlugin = new utauPlugin.UtauPlugin(filename);
                utauPlugin.Input();
                label_selected_filename.Text = Path.GetFileName(filename);
                checkbox_inludes_oto.Enabled = true;
                edit_area.Enabled = true;
                button_export_srt.Enabled = true;
                max_R.Enabled = true;
                edit_area.Text = "";
                Boolean ln_flag = false;
                foreach(Note note in utauPlugin.note)
                {
                    String lyric = note.GetLyric();
                    if (lyric == "R")
                    {
                        if (!ln_flag)
                        {
                            edit_area.Text += "\r\n[R]\r\n";
                            ln_flag = true;
                        }
                        continue;
                    }
                    ln_flag = false;
                    edit_area.Text += "[" + lyric.Replace("[", "{").Replace("]", "}") + "]";
                }
            }
        }

        private void edit_area_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 8) //backapace
            {
                if (edit_area.Text[Math.Max(0, edit_area.SelectionStart - 1)] != '\n')
                {
                    e.Handled = true;
                }
            }
            else if (e.KeyChar != 13) //not enter
            {
                e.Handled = true;
            }
            edit_area.SelectionLength = 0;
        }

        private void export_to_srt(object sender, EventArgs e)
        {
            if (checkbox_inludes_oto.Checked)
            {
                if(!vb_path_checked)
                {
                    if(MessageBox.Show("You enabled the \"includes preuttrance\" option but not location the voice folder.\nNow default voice folder is " + vb_path + "\nAre you sure to continue proccess without locate voice folder?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                    {
                        return;
                    }
                }
                utauPlugin.VoiceDir = utauPlugin.VoiceDir.Replace("%VOICE%", vb_path + "\\");
                utauPlugin.InputVoiceBank();
            }
            VoiceBank vb = utauPlugin.vb;


            FileInfo file = new FileInfo(Path.ChangeExtension(filename, "srt"));
            StreamWriter writer = file.CreateText();



            String[] lines;
            if(max_R.Value == 0) lines = edit_area.Text.Replace("[R]", "").Split("\r\n", StringSplitOptions.RemoveEmptyEntries);
            else lines = edit_area.Text.Split("\r\n", StringSplitOptions.RemoveEmptyEntries);
            int[] lines_length = new int[lines.Length];
            for(int i = 0; i < lines.Length; ++i)
            {
                lines_length[i] = lines[i].Split("[").Length - 1;
            }


            int note_num = 0;
            String left = left_symbol_text.Text, right = right_symbol_text.Text;

            //start time (unit length)
            int start_length = 0;
            int srt_counter = 1;

            for(int j = 0; j < lines_length.Length; ++j)
            {
                String line = "";
                Note first_note = utauPlugin.note[note_num];
                double start_time;
                if (first_note.GetLyric() != "R" && checkbox_inludes_oto.Checked)
                {
                    double pre;
                    if(first_note.PreHasValue())
                    {
                        pre = first_note.GetPre();
                    }
                    else
                    {
                        //子音伸縮率
                        double cv = Math.Pow(2, (1.0 - (first_note.GetVelocity() / 100.0)));
                        String element;
                        Oto oto;
                        if (vb.oto.TryGetValue(first_note.GetLyric(), out oto))
                        {
                            //if element exists in oto
                            element = first_note.GetLyric();
                        }
                        else
                        {
                            //if element don't exists in oto
                            //add prefix
                            element = first_note.GetLyric() + vb.prefixMap[first_note.GetNoteNumName()].Su;
                        }
                        //先行發聲
                        pre = vb.oto[element].Pre;
                    }
                    //修正先行發聲
                    double fp = pre * j;
                    start_time = start_length / 480.0 * (60 / utauPlugin.Tempo) - fp / 1000;
                }
                else
                {
                    start_time = start_length / 480.0 * (60 / utauPlugin.Tempo);
                }
                for(int k = 0; k < lines_length[j]; ++k)
                {
                    Note note = utauPlugin.note[note_num];
                    if (max_R.Value == 0)
                    {
                        while (note.GetLyric() == "R")
                        {
                            note = utauPlugin.note[note_num++];
                            start_length += note.GetLength();
                            note = utauPlugin.note[note_num];
                        }
                    }
                    if (note.GetLyric() == "R" && max_R.Value > 0)
                    {
                        for(int l = 0; l < max_R.Value && note.GetLyric() == "R"; ++l)
                        {
                            line += left + "R" + right;
                            start_length += note.GetLength();
                            note = utauPlugin.note[++note_num];
                        }
                        while (utauPlugin.note[note_num].GetLyric() == "R")
                        {
                            start_length += utauPlugin.note[note_num++].GetLength();
                        }
                    }
                    else if(note.GetLyric() == "R" && max_R.Value == -1)
                    {
                        while(note.GetLyric() == "R")
                        {
                            line += left + "R" + right;
                            start_length += note.GetLength();
                            note = utauPlugin.note[++note_num];
                        }
                    }
                    else
                    {
                        line += left + note.GetLyric() + right;
                        start_length += note.GetLength();
                        ++note_num;
                    }
                }
                double stop_time = start_length / 480.0 * (60 / utauPlugin.Tempo);
                writer.WriteLine(srt_counter);
                TimeSpan start = TimeSpan.FromSeconds(start_time), stop = TimeSpan.FromSeconds(stop_time);
                writer.WriteLine(start.ToString(@"hh\:mm\:ss\,fff") + " --> " + stop.ToString(@"hh\:mm\:ss\,fff"));
                writer.WriteLine(line + "\r\n");
            }
            writer.Close();
            MessageBox.Show("SRT File Exportation Successed to\n" + file.FullName, "Success",MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void locate_voice_dir_Click(object sender, EventArgs e)
        {
            if(locate_vb_dialog.ShowDialog() == DialogResult.OK)
            {
                vb_path = locate_vb_dialog.SelectedPath;
                tooltip_vb_location.SetToolTip(locate_voice_dir, vb_path);
            }
        }

        private void edit_area_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Delete)
            {
                if (edit_area.Text[Math.Max(0, edit_area.SelectionStart)] != '\r')
                {
                    e.SuppressKeyPress = true;
                }
            }
        }

        private void set_cursor(bool direction)
        {
            if(edit_area.Text[Math.Max(0, edit_area.SelectionStart - 1)] != ']' && edit_area.Text[edit_area.SelectionStart] != '[' && edit_area.Text[Math.Max(0, edit_area.SelectionStart)] != '\n' && edit_area.Text[edit_area.SelectionStart] != '\r')
            {
                if(direction) edit_area.SelectionStart = Math.Max(0, edit_area.Text.IndexOf('[', edit_area.SelectionStart));
                else edit_area.SelectionStart = Math.Max(0, edit_area.Text.LastIndexOf('[', edit_area.SelectionStart));
            }
        }

        private void edit_area_Click(object sender, EventArgs e)
        {
            set_cursor(false);
        }

        private void edit_area_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right) set_cursor(true);
            else set_cursor(false);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("dev: 曲名障礙(namaeclog)\ntwitter/@namaeclog\n\nmore about this program please check https://github.com/namaeclog/ust2srt", "About");
        }
    }
}
