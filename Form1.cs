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
        public String original_vb_name = "";
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
                original_vb_name = utauPlugin.VoiceDir;
                label_selected_filename.Text = Path.GetFileName(filename);
                checkbox_inludes_oto.Enabled = true;
                checkbox_all_prefix.Enabled = true;
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
            if (checkbox_inludes_oto.Checked || checkbox_all_prefix.Checked)
            {
                if(!vb_path_checked)
                {
                    if(MessageBox.Show("You enabled the \"includes preutterance\" option but not locate the UTAU\\voice folder.\nNow default voice folder is " + vb_path + "\nAre you sure to continue proccess without locating voice folder?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                    {
                        return;
                    }
                }
                try
                {
                    utauPlugin.VoiceDir = original_vb_name.Replace("%VOICE%", vb_path + "\\");
                    utauPlugin.InputVoiceBank();
                }
                catch(Exception ex)
                {
                    MessageBox.Show("VoiceBank data load failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            VoiceBank vb = utauPlugin.vb;





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
            List<srt> srtlist = new List<srt>();

            for(int j = 0; j < lines_length.Length; ++j)
            {
                String line = "";
                Note first_note = utauPlugin.note[note_num];
                double start_time;
                if (first_note.GetLyric() != "R" && checkbox_inludes_oto.Checked)
                {
                    double pre;
                    double cv = 1;
                    if (first_note.PreHasValue())
                    {
                        pre = first_note.GetPre();
                    }
                    else
                    {
                        //子音伸縮率
                        cv = Math.Pow(2, (1.0 - (first_note.GetVelocity() / 100.0)));
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
                            element = vb.prefixMap[first_note.GetNoteNumName()].Pre + first_note.GetLyric() + vb.prefixMap[first_note.GetNoteNumName()].Su;
                        }
                        //先行發聲
                        pre = vb.oto[element].Pre;
                    }
                    //修正先行發聲
                    double fp = pre * cv;
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
                        Oto oto;
                        if (checkbox_all_prefix.Checked && !vb.oto.TryGetValue(note.GetLyric(), out oto))
                        {
                            line += left + vb.prefixMap[note.GetNoteNumName()].Pre + note.GetLyric() + vb.prefixMap[note.GetNoteNumName()].Su + right;
                        }
                        else
                        {
                            line += left + note.GetLyric() + right;
                        }
                        start_length += note.GetLength();
                        ++note_num;
                    }
                }
                double stop_time = start_length / 480.0 * (60 / utauPlugin.Tempo);
                srtlist.Add(new srt(start_time, stop_time, line));
                ++srt_counter;
            }
            FileInfo file = new FileInfo(Path.ChangeExtension(filename, "srt"));
            StreamWriter writer = file.CreateText();
            if(checkbox_inludes_oto.Checked && checkbox_remove_overlap.Checked)
            {
                for (int m = 0; m < srtlist.Count() - 1; ++m)
                {
                    srtlist[m].stop = srtlist[m + 1].start;
                    if (srtlist[m].stop - srtlist[m].start < 0.001)
                    {
                        srtlist.RemoveAt(m);
                        m--;
                        srtlist[m].stop = srtlist[m + 1].start;
                    }
                }
            }
            int n = 1;
            foreach(srt line in srtlist)
            {
                writer.WriteLine(n);
                TimeSpan start = TimeSpan.FromSeconds(line.start), stop = TimeSpan.FromSeconds(line.stop);
                writer.WriteLine(start.ToString(@"hh\:mm\:ss\,fff") + " --> " + stop.ToString(@"hh\:mm\:ss\,fff"));
                writer.WriteLine(line.text + "\r\n");
                ++n;
            }
            writer.Close();
            MessageBox.Show("SRT File Exportation Successed at\n" + file.FullName, "Success",MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void locate_voice_dir_Click(object sender, EventArgs e)
        {
            if(locate_vb_dialog.ShowDialog() == DialogResult.OK)
            {
                vb_path = locate_vb_dialog.SelectedPath;
                vb_path_checked = true;
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
        private void warn_if_null_voicedir()
        {
            if(!vb_path_checked) MessageBox.Show("Enable this function need to locate folder \"UTAU\\voice\"", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void checkbox_inludes_oto_CheckedChanged(object sender, EventArgs e)
        {
            if(checkbox_inludes_oto.Checked)
            {
                warn_if_null_voicedir();
            }
            if (checkbox_inludes_oto.Checked) checkbox_remove_overlap.Enabled = true;
            else checkbox_remove_overlap.Enabled = false;
        }

        private void checkbox_all_prefix_CheckedChanged(object sender, EventArgs e)
        {
            if (checkbox_all_prefix.Checked) warn_if_null_voicedir();
        }
    }
}
