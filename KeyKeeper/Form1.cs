﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Management;
using System.IO;

namespace KeyKeeper
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// Список флеш накопителей
        /// </summary>
        List<USBInfo> DI;
        /// <summary>
        /// Данные дял комбобокса 
        /// </summary>
        Dictionary<string, string> comboSource;
        delegate void DelegateUSBBox();
        /// <summary>
        /// Обновление списка доступных флеш накопителей
        /// </summary>
        void UpdateUSBBox()
        {
            if (USBBox.InvokeRequired)
            {
                DelegateUSBBox d = new DelegateUSBBox(UpdateUSBBox);
                USBBox.Invoke(d, new object[] { });
            }
            else
            {
                DI = new List<USBInfo>();
                USBBox.DisplayMember = "Value";
                USBBox.ValueMember = "Key";
                comboSource = new Dictionary<string, string>();
                ReadUSBFlashDrivers(comboSource);
                if (comboSource.Count < 1)
                    USBBox.DataSource = new BindingSource(null, null);
                USBBox.DataSource = new BindingSource(comboSource, null);
            }
        }

        public Form1()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Обработка событий по подкючению-изъятию флеш накопителей
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">Событие</param>
        private void DeviceUpToDate(object sender, EventArrivedEventArgs e)
        {
            UpdateUSBBox();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="plainText"></param>
        /// <returns></returns>
        private string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }
        /// <summary>
        /// Декодирование Base64
        /// </summary>
        /// <param name="base64EncodedData"></param>
        /// <returns></returns>
        private string Base64Decode(string base64EncodedData)
        {
            try
            {
                var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
                return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
            }
            catch (Exception ex)
            {
                return "0";
            }
        }

        private string parseSerialFromDeviceID(string deviceId)
        {
            string[] splitDeviceId = deviceId.Split('\\');
            string[] serialArray;
            string serial;
            int arrayLen = splitDeviceId.Length - 1;

            serialArray = splitDeviceId[arrayLen].Split('&');
            serial = serialArray[0];

            return serial;
        }

        private string parseVenFromDeviceID(string deviceId)
        {
            string[] splitDeviceId = deviceId.Split('\\');
            string Ven;
            //Разбиваем строку на несколько частей. 
            //Каждая чаcть отделяется по символу &
            string[] splitVen = splitDeviceId[1].Split('&');

            Ven = splitVen[1].Replace("VEN_", "");
            Ven = Ven.Replace("_", " ");
            return Ven;
        }

        private string parseProdFromDeviceID(string deviceId)
        {
            string[] splitDeviceId = deviceId.Split('\\');
            string Prod;
            //Разбиваем строку на несколько частей. 
            //Каждая чаcть отделяется по символу &
            string[] splitProd = splitDeviceId[1].Split('&');

            Prod = splitProd[2].Replace("PID_", ""); ;
            Prod = Prod.Replace("_", " ");
            return Prod;
        }

        private string parseRevFromDeviceID(string deviceId)
        {
            string[] splitDeviceId = deviceId.Split('\\');
            string Rev;
            //Разбиваем строку на несколько частей. 
            //Каждая чаcть отделяется по символу &
            string[] splitRev = splitDeviceId[1].Split('&');

            Rev = splitRev[3].Replace("VID_", ""); ;
            Rev = Rev.Replace("_", " ");
            return Rev;
        }
        /// <summary>
        /// Разбавление мусором данных
        /// </summary>
        /// <param name="Hash">Строка для разбавления</param>
        /// <returns></returns>
        private string garbageAdditor(string Hash)
        {
            Random rnd = new Random();
            for (int i = 0; i < Hash.Length; i += 2)
                Hash = Hash.Insert(i, Convert.ToChar(97 + rnd.Next(25)).ToString());
            return Hash;
        }
        /// <summary>
        /// Сбор мусора из строки
        /// </summary>
        /// <param name="garbagedHash">Строка с мусором</param>
        /// <returns></returns>
        private string garbageCollector(string garbagedHash)
        {
            int hashLength = garbagedHash.Length;
            for (int i = hashLength - 2; i >= 0; i -= 2)
                garbagedHash = garbagedHash.Remove(i, 1);
            return garbagedHash;
        }
        /// <summary>
        /// Передача параметров для генерации ключа-лицензии
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            if (DI.Count != 0)
            {
                string[] Properties = new string[9];
                Properties[0] = LicenceType.Text;
                Properties[1] = WorkDate.Value.ToShortDateString();
                Properties[2] = Environment.UserName;
                Properties[3] = Environment.MachineName;
                Properties[4] = Environment.OSVersion.VersionString;
                Properties[5] = GMailLogin.Text;
                Properties[6] = GMailPass.Text;
                Properties[7] = ClientID.Text;
                Properties[8] = ClientSecret.Text;

                if (DI[USBBox.SelectedIndex].CreateKey(Properties))
                    MessageBox.Show("The key was created!", "Key Generator", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("The key was not created!", "Key Generator", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }
        /// <summary>
        /// Чтение параметров флеш накопителей и
        /// занесение в список доступных
        /// </summary>
        /// <param name="comboSource"></param>
        private void ReadUSBFlashDrivers(Dictionary<string, string> comboSource)
        {
            string diskName = string.Empty;
            //Получение списка накопителей подключенных через интерфейс USB
            foreach (System.Management.ManagementObject drive in
                      new System.Management.ManagementObjectSearcher(
                       "select * from Win32_DiskDrive where InterfaceType='USB'").Get())
            {
                //Получаем букву накопителя
                foreach (System.Management.ManagementObject partition in
                new System.Management.ManagementObjectSearcher(
                    "ASSOCIATORS OF {Win32_DiskDrive.DeviceID='" + drive["DeviceID"]
                      + "'} WHERE AssocClass = Win32_DiskDriveToDiskPartition").Get())
                {
                    foreach (System.Management.ManagementObject disk in
                 new System.Management.ManagementObjectSearcher(
                        "ASSOCIATORS OF {Win32_DiskPartition.DeviceID='"
                          + partition["DeviceID"]
                          + "'} WHERE AssocClass = Win32_LogicalDiskToPartition").Get())
                    {
                        //Получение буквы устройства
                        diskName = disk["Name"].ToString().Trim();
                        //listBox1.Items.Add("Буква накопителя=" + diskName);
                    }
                }
                decimal dSize = Math.Round((Convert.ToDecimal(
              new System.Management.ManagementObject("Win32_LogicalDisk.DeviceID='"
                      + diskName + "'")["Size"]) / 1073741824), 2);
                comboSource.Add(DI.Count.ToString(), diskName + drive["Model"].ToString().Trim() + " (" + dSize.ToString() + ") GB");
                DI.Add(new USBInfo(diskName, drive["Model"].ToString().Trim(), dSize, parseSerialFromDeviceID(drive["PNPDeviceID"].ToString().Trim())));
            }

        }
        /// <summary>
        /// Отслеживаем подключение накопителей
        /// </summary>
        void USBInsert()
        {
            ManagementEventWatcher watcherRemove = new ManagementEventWatcher();
            WqlEventQuery query = new WqlEventQuery("SELECT * FROM __InstanceCreationEvent WITHIN 2 WHERE TargetInstance ISA 'Win32_USBHub'");
            watcherRemove.EventArrived += new EventArrivedEventHandler(DeviceUpToDate);
            watcherRemove.Query = query;
            watcherRemove.Start();
            watcherRemove.WaitForNextEvent();
        }
        /// <summary>
        /// Отслеживаем изъятие накопителей
        /// </summary>
        void USBRemove()
        {
            ManagementEventWatcher watcherInsert = new ManagementEventWatcher();
            WqlEventQuery query = new WqlEventQuery("SELECT * FROM __InstanceDeletionEvent WITHIN 2 WHERE TargetInstance ISA 'Win32_USBHub'");
            watcherInsert.EventArrived += new EventArrivedEventHandler(DeviceUpToDate);
            watcherInsert.Query = query;
            watcherInsert.Start();
            watcherInsert.WaitForNextEvent();
        }
        /// <summary>
        /// Инициализация формы,
        /// запуск потоков проверки флеш накопителей
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            DI = new List<USBInfo>();
            USBBox.DisplayMember = "Value";
            USBBox.ValueMember = "Key";
            comboSource = new Dictionary<string, string>();
            ReadUSBFlashDrivers(comboSource);
            USBBox.DataSource = new BindingSource(comboSource, null);
            System.Threading.Thread watcherInsert = new System.Threading.Thread(USBInsert);
            watcherInsert.Start();
            System.Threading.Thread watcherRemove = new System.Threading.Thread(USBRemove);
            watcherRemove.Start();
        }
        /// <summary>
        /// Открытие файла лицензии и
        /// расшифрование его содержимого
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.InitialDirectory = Directory.GetCurrentDirectory();
            openFileDialog1.Filter = "Licence file (*.key)|*.key|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if (openFileDialog1.OpenFile() != null)
                    {
                        USBInfo f = DI.Select(x => { string.Compare(x.Letter, openFileDialog1.FileName.Remove(openFileDialog1.FileName.IndexOf(':'))); return x; }).ToList()[0];
                        List<string> Params = f.CheckKey(openFileDialog1.FileName);
                        foreach (string item in Params)
                        {
                            richTextBox1.AppendText(item + "\n");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
        }
    }
}