using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;

// TO ADD: show name of input file for servers in the status bar.
namespace SNMPCrawl
{
    /* SNMPCrawl
     * Copyright 2011 Chris Bebry
     * 
     * Release Notes:
     *      0.2.1 :
     *          -Added radio buttons to choose the version of SNMP user wishes to use.
     *          -Did a little cleanup, changed an instance of checking for blank/null to use the string utility.
     *          -Fixed a bug that would output a blank file if we were repeatedly using the same single server file.
     *          -Increased pixel size of numServersLoadedLabel.
     *      0.2.0 : 
     *          -Resolved issue with memory leaks in the COM object causing the earlier speed-up procedure to fail.
     *          -Cleared outputList after each save, so multiple uses in a single program instance can occur serially.
     *      0.1.1 : 
     *          -Fixed "processing current server" index value on status bar. It was incorrectly one less than what it should've been.
     *          -Greatly sped up processing of successful snmpwalks so that the process closes after confirming the walk is a success.
     *          -Fixed some output grammar to know when the number of servers is plural or singular.
     *          -Removed overseen duplicate status field update when loading a server file.
     *          -Added status label which states whether or not the SNMPwalk file has been loaded.
     * */
    public partial class Form1 : Form
    {
        private const string OUTPUT_FOR_UNKNOWNHOST = "Server {0} is an unknown host.";
        private const string OUTPUT_FOR_TIMEOUT = "Server {0} is timing out.";
        private const string OUTPUT_FOR_SUCCESSFUL = "Server {0} is successful.";

        private const string VERSION_1 = "1";
        private const string VERSION_2c = "2c";
        private const string VERSION_3 = "3";

        private string _currVersion = "";

        string snmpwalkFilepath { get; set; }
        string serverListFilepath { get; set; }
        private string serverName;
        private List<string> serverList;
        private List<string> outputFile;

        private Process _p;

        private string _prevServ = "";
        private string _lastResult = "";

        public Form1()
        {
            InitializeComponent();

            serverList = new List<string>();
            outputFile = new List<string>();
            snmpwalkFilepath = "";
            serverName = "";
        }

        private void submitBtn_Click(object sender, EventArgs e)
        {
            object temp = ValidateForm() ? XRunCrawl() : ValidateErrorMessage();
        }

        private object ValidateErrorMessage()
        {
            MessageBox.Show("Please input a Community, locate the file for snmpwalk, or load a server list.");
            return default(object);
        }

        /* OLD VERSION
        private object RunCrawl()
        {
            //do stuff
            string community = communityTextBox.Text;
            foreach (string server in serverList)
            {
                serverName = server;
                Process p = new Process();
                p.StartInfo.FileName = snmpwalkFilepath;

                p.StartInfo.Arguments = "-v 2c -c " + community + " " + server;
                p.StartInfo.RedirectStandardOutput = true;
                p.StartInfo.RedirectStandardError = true;
                p.StartInfo.UseShellExecute = false;
                p.EnableRaisingEvents = true;
                p.StartInfo.CreateNoWindow = true;

                //output handlers
                p.OutputDataReceived += p_DataReceived;
                p.ErrorDataReceived += p_DataReceived;

                p.Start();
                p.BeginErrorReadLine();
                p.BeginOutputReadLine();
                numServersLoadedLabel.Text = "Processing Server " + (outputFile.Count+1) + @"/" + serverList.Count;
                p.WaitForExit();
            }

            numServersLoadedLabel.Text = "Processed all " + serverList.Count + " servers";

            SaveOutputFile();

            MessageBox.Show("done");

            return default(object);
        }
        */
        private object XRunCrawl()
        {
            string community = communityTextBox.Text;
            _currVersion = GetVersion();
            _prevServ = "";

            foreach (string server in serverList)
            {
                serverName = server;
                _p = null;
                _p = new Process();
                _p.StartInfo.FileName = snmpwalkFilepath;

                _p.StartInfo.Arguments = "-v " + _currVersion + " -c " + community + " " + server;
                _p.StartInfo.RedirectStandardOutput = true;
                _p.StartInfo.RedirectStandardError = true;
                _p.StartInfo.UseShellExecute = false;
                _p.EnableRaisingEvents = true;
                _p.StartInfo.CreateNoWindow = true;

                //output handlers
                _p.OutputDataReceived += p_DataReceived;
                _p.ErrorDataReceived += p_DataReceived;

                _p.Start();
                _p.BeginErrorReadLine();
                _p.BeginOutputReadLine();
                numServersLoadedLabel.Text = "Processing Server " + (outputFile.Count + 1) + @"/" + serverList.Count;
                _p.WaitForExit();
            }

            if (serverList.Count == 1)
            {
                numServersLoadedLabel.Text = "Processed the " + serverList.Count + " server";
            }
            else
            {
                numServersLoadedLabel.Text = "Processed all " + serverList.Count + " servers";
            }
            

            SaveOutputFile();
            outputFile.Clear();
            //MessageBox.Show("done");

            return default(object);
        }

        #region Version
        private string GetVersion()
        {
            if (radioVers1.Checked)
            {
                return VERSION_1;
            } 
            else if (radioVers2c.Checked)
            {
                return VERSION_2c;
            }
            else if (radioVers3.Checked)
            {
                return VERSION_3;
            }
            //if for some reason all fails, default to:
            return VERSION_2c;
        }
        #endregion Version

        #region Validation
        private bool ValidateForm()
        {
            if (communityTextBox.Text != "" &&
                snmpwalkFilepath != "" &&
                serverList.Count != 0) //good
            {
                return true;
            }
            else //bad
            {
                return false;
            }
        }
        #endregion Validation

        public void p_DataReceived(object sender, DataReceivedEventArgs e)
        {
            //output will be in e.Data;
            string output = e.Data;
            if (_prevServ != serverName) //to avoid redundancy
            {
                if (!String.IsNullOrEmpty(output)) //ignore blank outputs
                {
                    //MessageBox.Show(output);
                    //if (output.Substring(0, 7) == "Timeout")
                    if (output.IndexOf("Timeout") != -1) //if Timeout exists. <-- this version was a change for version 3 snmpwalk calls
                    {
                        outputFile.Add(String.Format(OUTPUT_FOR_TIMEOUT, serverName));
                        // MessageBox.Show(String.Format(OUTPUT_FOR_TIMEOUT, serverName));
                        _lastResult = OUTPUT_FOR_TIMEOUT;
                    }
                    else if (output.Substring(0, 22) == "snmpwalk: Unknown host")
                    {
                        outputFile.Add(String.Format(OUTPUT_FOR_UNKNOWNHOST, serverName));
                        // MessageBox.Show(String.Format(OUTPUT_FOR_UNKNOWNHOST, serverName));
                        _lastResult = OUTPUT_FOR_UNKNOWNHOST;
                    }
                    else
                    {
                        outputFile.Add(String.Format(OUTPUT_FOR_SUCCESSFUL, serverName));
                        //MessageBox.Show(String.Format(OUTPUT_FOR_SUCCESSFUL, serverName));
                        _lastResult = OUTPUT_FOR_SUCCESSFUL;
                    }
                }

                _prevServ = serverName;
            }
            else
            {
                if (_p != null)
                {
                    try
                    {
                        if (_lastResult == OUTPUT_FOR_SUCCESSFUL)
                        {
                            _p.Kill();
                        }
                        else
                        {
                            _p.Close();
                        }
                    }
                    catch //im not proud of this, but it works.
                    {
                        //hidden catch haha.
                        //MessageBox.Show(x.ToString());
                    }
                }
            }

        }
        #region Exit
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion Exit

        #region LoadServerList
        private void LoadServerList(string filepath)
        {
            serverList.Clear();
            using (StreamReader sr = new StreamReader(filepath))
            {
                while(!sr.EndOfStream)
                {
                    serverList.Add(sr.ReadLine());
                }
                if (serverList.Count == 1)
                {
                    numServersLoadedLabel.Text = serverList.Count + " server loaded.";
                }
                else
                {
                    numServersLoadedLabel.Text = serverList.Count + " servers loaded.";
                }
            }
        }

        private void loadServerListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = "c:\\";
            ofd.Filter = "All files (*.*)|*.*";
            ofd.FilterIndex = 2;
            ofd.RestoreDirectory = true;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    LoadServerList(ofd.FileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error. Could not read file from disk. Original error: " + ex.Message);
                }
            }

        }
        #endregion LoadServerList

        private void SaveOutputFile()
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Text File|*.txt";
            sfd.Title = "Save the output text file";
            if (sfd.ShowDialog() != DialogResult.Cancel)
            {
                if (sfd.FileName != "")
                {
                    System.IO.File.WriteAllLines(sfd.FileName, outputFile);
                }
            }
            else
            {
                MessageBox.Show("Cancel was clicked. In order to save the file, you must run the report again and specify a valid filename.");
            }
        }

        private void setSNMPWalkFilepathToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = "c:\\";
            ofd.Filter = "SNMPWALK.EXE|snmpwalk.exe";
            ofd.FilterIndex = 2;
            ofd.RestoreDirectory = true;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    snmpwalkFilepath = ofd.FileName;
                    snmpwalkLoadedLabel.Text = "SNMPwalk Loaded";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error. Could not read file from disk. Original error: " + ex.Message);
                }
            }
        }


        #region JUNK
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        #endregion JUNK
    }
}
