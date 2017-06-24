using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrameworkContracts;
using SaveGames.FileAccess;
using System.Xml.Linq;
using OpenTK;
using System.Diagnostics;

namespace KillCommandoSetup
{
    public partial class Form1 : Form
    {
        private string _configFile;
        private string _gameLocation;

        public Form1(string configFile, string gameLocation)
        {
            _configFile = configFile;
            _gameLocation = gameLocation;

            InitializeComponent();

            try
            {
                FillBoxes();
            }
            catch(Exception ex)
            {
                MessageBox.Show("An error occured while reading the game config (please configure it manually): " + ex.Message);
            }  
        }

        private void FillBoxes()
        {
            IXmlFileSerializer serializer = new FileSerializer();

            XDocument configFile = serializer.LoadFile(_configFile);
            
            XElement settings = configFile.Element("configuration").Element("appSettings");
            IEnumerable<XElement> values = settings.Elements("add");
            List<XElement> list = values.ToList();

            int volumeMusic = 0;
            int volumeSounds = 0;
            int resolutionX = 0;
            int resolutionY = 0;
            int mouseSensitivity = 1;
            bool invertMouse = false;

            foreach(XElement element in list)
            {
                XAttribute key = element.Attribute("key");
                XAttribute value = element.Attribute("value");

                switch (key.Value)
                {
                    case "ResolutionX":
                        resolutionX = int.Parse(value.Value);
                        break;
                    case "ResolutionY":
                        resolutionY = int.Parse(value.Value);
                        break;
                    case "MusicVolume":
                        volumeMusic = int.Parse(value.Value);
                        break;
                    case "SoundVolume":
                        volumeSounds = int.Parse(value.Value);
                        break;
                    case "MouseSensitivity":
                        mouseSensitivity = int.Parse(value.Value);
                        break;
                    case "InvertMouse":
                        invertMouse = bool.Parse(value.Value);
                        break;
                }
            }

            if (invertMouse)
                checkBox1.Checked = true;

            for (int i = 0; i < 105; i += 5)
            {
                comboBox2.Items.Add(i.ToString());
                if (i == volumeMusic)
                    comboBox2.SelectedIndex = comboBox2.Items.Count - 1;

                comboBox3.Items.Add(i.ToString());
                if (i == volumeSounds)
                    comboBox3.SelectedIndex = comboBox3.Items.Count - 1;
            }

            for (int i = 1; i < 31; i++)
            {
                mousecComboBox.Items.Add(i.ToString());
                if (i == mouseSensitivity)
                    mousecComboBox.SelectedIndex = mousecComboBox.Items.Count - 1;
            }

            List<string> resolutions = new List<string>();
            string configResolution = resolutionX + "x" + resolutionY;

            List<Tuple<int, int>> resolutionPairs = new List<Tuple<int, int>>();

            foreach (DisplayResolution resolution in DisplayDevice.Default.AvailableResolutions)
            { 
                if (!resolutionPairs.Any(x=>x.Item1 == resolution.Width && x.Item2 == resolution.Height))
                    resolutionPairs.Add(new Tuple<int,int>(resolution.Width, resolution.Height));
            }

            int sumMax = resolutionPairs.Max(x => x.Item1 + x.Item2);
            Tuple<int, int> maxResolution = resolutionPairs.Find(x => x.Item1 + x.Item2 == sumMax);
            string maxResolutionText = maxResolution.Item1 + "x" + maxResolution.Item2;

            foreach (Tuple<int, int> pair in resolutionPairs)
            {
                string concatinatedResolution = pair.Item1 + "x" + pair.Item2;

                resolutions.Add(concatinatedResolution);
                comboBox1.Items.Add(concatinatedResolution);

                if (resolutionX > 0)
                {
                    if (configResolution.Equals(concatinatedResolution))
                        comboBox1.SelectedIndex = comboBox1.Items.Count - 1; 
                }
                else 
                {
                    if (maxResolutionText.Equals(concatinatedResolution))
                        comboBox1.SelectedIndex = comboBox1.Items.Count - 1; 
                } 
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SaveConfig();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occured while saving the game config (please configure it manually): " + ex.Message);
            }

            Process game = new Process();
            game.StartInfo.FileName = _gameLocation;

          
            game.Start();

            Close();
        }

        private void SaveConfig()
        {
            string volumeMusic = comboBox2.SelectedItem != null ? comboBox2.SelectedItem.ToString() : comboBox2.Text;
            string volumeSounds = comboBox3.SelectedItem != null ? comboBox3.SelectedItem.ToString() : comboBox3.Text;
            string mouseSens = mousecComboBox.SelectedItem != null ? mousecComboBox.SelectedItem.ToString() : mousecComboBox.Text;

            string concatinatedResolution = comboBox1.SelectedItem.ToString();

            string[] res = concatinatedResolution.Split('x');

            string resolutionX = res[0];
            string resolutionY = res[1];

            bool invertMouse = checkBox1.Checked;

            IXmlFileSerializer serializer = new FileSerializer();

            XDocument configFile = serializer.LoadFile(_configFile);

            XElement settings = configFile.Element("configuration").Element("appSettings");
            IEnumerable<XElement> values = settings.Elements("add");
            List<XElement> list = values.ToList();

            foreach (XElement element in list)
            {
                XAttribute key = element.Attribute("key");
                XAttribute value = element.Attribute("value");

                switch (key.Value)
                {
                    case "ResolutionX":
                        value.Value = resolutionX;
                        break;
                    case "ResolutionY":
                        value.Value = resolutionY;
                        break;
                    case "MusicVolume":
                        value.Value = volumeMusic;
                        break;
                    case "SoundVolume":
                        value.Value = volumeSounds;
                        break;
                    case "MouseSensitivity":
                        value.Value = mouseSens;
                        break;
                    case "InvertMouse":
                        value.Value = invertMouse ? "true" : "false";
                        break;
                }
            }

            serializer.SaveFile(_configFile, configFile);
        }
    }
}
