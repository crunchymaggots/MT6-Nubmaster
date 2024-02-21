using System;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        OpenFileDialog openOriginal = new OpenFileDialog();
        OpenFileDialog openNew = new OpenFileDialog();
        OpenFileDialog openLoop = new OpenFileDialog();

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            if (lbOriginalPath.Text != "Current File:   " + Path.GetFileName(openOriginal.FileName))  //No .nub file selected
            {
                MessageBox.Show("Please select a .nub song to act as a donor file.\n\nDo not worry, it will NOT be overwritten.", "Missing .nub file",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            if (lbNewPath.Text != "Current File:   " + Path.GetFileName(openNew.FileName))  //No .snd file selected
            {
                MessageBox.Show("Please select a .snd file. Dingus.", "Missing .snd file", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            FileInfo sndInfo = new FileInfo(openNew.FileName);
            long sampleLengthLong = sndInfo.Length;
            int sampleLengthInt = Convert.ToInt32(sampleLengthLong);
            
            if (tbLoopStart.Text == "")  //No loop start declared
            {
                MessageBox.Show("Please specify (in samples) the point at which the song loop should start.\n\nThis is the transition from the song intro to the main loop body.", "Loop point missing", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (tbLoopEnd.Text == "")  //No loop end declared
            {
                MessageBox.Show("Please specify (in samples) the point at which the song loop should end.\n\nThis is the point where the song goes back to the start of the loop", "Loop point missing", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int sampleLoopStartInt;
            int sampleLoopEndInt;
            if (Int32.TryParse(tbLoopStart.Text, out sampleLoopStartInt) && Int32.TryParse(tbLoopEnd.Text, out sampleLoopEndInt)) { }  //Ensure that the loop value is actually a number
            else
            {
                MessageBox.Show("Not a valid number, dingus.", "C'mon, man", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (sampleLoopStartInt < 0 || sampleLoopStartInt > 1000000000 || sampleLoopEndInt < 0 || sampleLoopEndInt > 1000000000)  //Ensure that the loop point is a sensible value
            {
                MessageBox.Show("Just don't.", "Son,", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            sampleLoopStartInt = sampleLoopStartInt * 4;
            sampleLoopEndInt = sampleLoopEndInt * 4;
            if (sampleLoopStartInt > sampleLengthInt || sampleLoopEndInt > sampleLengthInt)  //Ensure that the loop occurs before the song ends
            {
                MessageBox.Show("Your loop point is occurring after the song has already ended.", "Loop occurs after song has ended.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (sampleLoopStartInt > sampleLoopEndInt)  //Ensure that the loop occurs before the song ends
            {
                MessageBox.Show("Your loop start is occuring after the loop end has already happened.\n\nDon't do that. It goes the other way.", "Loop occurs after song has ended.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string FILE_NAME = Path.GetFileName(openOriginal.FileName);

            if (File.Exists(FILE_NAME))  //Prevent overwriting of existing files
            {
                MessageBox.Show("There is already a .nub file in the same folder as this application with this file name.\n\nThis program will not (intentionally) overwrite existing .nub files for safety. Please move it somewhere else or delete it.", "File Already Exists", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            BinaryReader inputNubFile = new BinaryReader(File.OpenRead(openOriginal.FileName));
            BinaryReader inputSndFile = new BinaryReader(File.OpenRead(openNew.FileName));

            using (FileStream fs = new FileStream(FILE_NAME, FileMode.CreateNew))
            {
                using (BinaryWriter outputNubFile = new BinaryWriter(fs))
                {
                    //Clone the header data from source file from 0x00 to 0xFF
                    for (int i = 0x0; i <= 0xFF; i++)
                    {
                        inputNubFile.BaseStream.Position = i;
                        outputNubFile.Write(inputNubFile.ReadByte());
                    }

                    //Subtract nessisary value from total file length, and write to header
                    sampleLengthInt = sampleLengthInt - 1792;
                    byte[] intLengthBytes = BitConverter.GetBytes(sampleLengthInt);
                    outputNubFile.BaseStream.Position = 0x44;
                    for (int i = 0; i < 4; i++)
                    {
                        outputNubFile.Write(intLengthBytes[i]);
                    }

                    //Write loop start point to header
                    byte[] intLoopBytes = BitConverter.GetBytes(sampleLoopStartInt);
                    outputNubFile.BaseStream.Position = 0x50;
                    for (int i = 0; i < 4; i++)
                    {
                        outputNubFile.Write(intLoopBytes[i]);
                    }

                    //Write loop length to header
                    int sampleDiff = sampleLoopEndInt - 1792 - sampleLoopStartInt;
                    if (sampleDiff < sampleLoopStartInt || sampleLoopEndInt <= 0 || sampleDiff <= 0)
                    {
                        sampleDiff = 0;
                    }
                    byte[] intDiffBytes = BitConverter.GetBytes(sampleDiff);
                    outputNubFile.BaseStream.Position = 0x54;
                    for (int i = 0; i < 4; i++)
                    {
                        outputNubFile.Write(intDiffBytes[i]);
                    }

                    //Write Song Data from snd file
                    byte[] buffer = new byte[1024];
                    int bytesRead;
                    inputSndFile.BaseStream.Position = 0x0;
                    outputNubFile.BaseStream.Position = 0x100;
                    while ((bytesRead = inputSndFile.Read(buffer, 0, 1024)) > 0)
                    {
                        outputNubFile.Write(buffer, 0, bytesRead);
                    }
                }
            }
            inputNubFile.Close();
            MessageBox.Show(".nub File Generated", "Operation Complete", MessageBoxButtons.OK);
        }

        private void btnOpenOriginal_Click(object sender, EventArgs e)
        {
            openOriginal.Filter = "nub File (*.nub)|*.nub";
            openOriginal.ShowDialog();
            if (openOriginal.FileName != "")
            { lbOriginalPath.Text = "Current File:   " + Path.GetFileName(openOriginal.FileName); }
            else
            { lbOriginalPath.Text = "Current File:   None"; }
        }

        private void btnOpenSND_Click(object sender, EventArgs e)
        {
            openNew.Filter = "snd File (*.snd)|*.snd";
            openNew.ShowDialog();
            if (openNew.FileName != "")
            {
                lbNewPath.Text = "Current File:   " + Path.GetFileName(openNew.FileName);
                btnNoLoop.Enabled = true;
                btnLoopUseFile.Enabled = true;
                btnLoopWhole.Enabled = true;

                FileInfo sndFull = new FileInfo(openNew.FileName);
                long sampleLengthLong = sndFull.Length;
                sampleLengthLong = (sampleLengthLong / 4);
                string sampleLengthStr = Convert.ToString(sampleLengthLong);

                tbLoopEnd.Text = sampleLengthStr;
            }
            else
            {
                lbNewPath.Text = "Current File:   None";
                btnNoLoop.Enabled = false;
                btnLoopUseFile.Enabled = false;
                btnLoopWhole.Enabled = false;
            }
        }

        private void btnLoopUseFile_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Instructions: Select a version of your .snd file, where the end of the track is where you want the loop to start from.\n\nIn other words, select a copy of the song that only contains the intro.", "How to Use", MessageBoxButtons.OK);
            openLoop.Filter = "snd File (*.snd)|*.snd";
            openLoop.ShowDialog();
            if (openLoop.FileName != "")
            {
                FileInfo sndLoop = new FileInfo(openLoop.FileName);
                long sampleLoopLong = sndLoop.Length;
                sampleLoopLong = (sampleLoopLong / 4);
                string sampleLoopStr = Convert.ToString(sampleLoopLong);

                FileInfo sndFull = new FileInfo(openNew.FileName);
                long sampleLengthLong = sndFull.Length;
                sampleLengthLong = (sampleLengthLong / 4);
                string sampleLengthStr = Convert.ToString(sampleLengthLong);

                tbLoopStart.Text = sampleLoopStr;
                tbLoopEnd.Text = sampleLengthStr;
            }
        }

        private void btnNoLoop_Click(object sender, EventArgs e)
        {
            tbLoopStart.Text = "0";
            tbLoopEnd.Text = "0";
        }

        private void btnLoopWhole_Click(object sender, EventArgs e)
        {
            if (openNew.FileName == "") { return; }

            FileInfo sndFull = new FileInfo(openNew.FileName);
            long sampleLengthLong = sndFull.Length;
            sampleLengthLong = (sampleLengthLong / 4);
            string sampleLengthStr = Convert.ToString(sampleLengthLong);

            tbLoopStart.Text = "0";
            tbLoopEnd.Text = sampleLengthStr;
        }
    }
}
