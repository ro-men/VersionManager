using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace VerManagerLibrary_ClassLib.UserControls
{
    public partial class KWForm : UserControl
    {
        private string[] inputData;
        private RevisionClass ORevision;
        private string sLocation = VMLCoordinator.attachmentsFolder + @"\";
        private string sName;
        private string localFilePath;
        private  void SetName()
        {
            int index= 1;
            sName = "KW_CODE_" + ORevision.RevisionID + "_" + index.ToString() + ".txt";
            while (File.Exists(sLocation + sName))
            {
                index++;
                sName = "KW_CODE_" + ORevision.RevisionID + "_" + index.ToString() + ".txt";
            }
        }

        Dictionary<string,string> dataList = new Dictionary<string, string>() 
        {
            { "##Type:##","0" },
            { "##Name:##","" },
            { "##Input_1:##","" },
            { "##Language:##","KW" },
            { "##Value:##","" },
        };

        public KWForm()
        {
            InitializeComponent();
        }

        private void FillDictionary()
        {
            foreach(string key in dataList.Keys.ToList())
            {
                string lineValue = Array.Find(inputData, element => element.Contains(key));
                if (key != "##Value:##")
                {
                    dataList[key] = lineValue.Remove(0, key.Length + 1);
                }
                else
                {
                    try
                    {
                        string kw = String.Join(Environment.NewLine, inputData);
                        dataList[key] = kw.Split(new[] { key }, StringSplitOptions.None)[1].Remove(0,1);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            };
        }
        private void button_Save_Click(object sender, EventArgs e)
        {
            dataList["##Name:##"] = textBox_Name.Text;
            dataList["##Input_1:##"] = textBox_Input_1.Text;
            dataList["##Value:##"] = textBox_Value.Text;
            System.IO.Directory.CreateDirectory(sLocation);
            File.WriteAllLines(localFilePath, dataList.Select(x => x.Key + "\t" + x.Value).ToArray());
            if (!ORevision.Attachments.Contains(localFilePath))
            {
                ORevision.Attachments.Add(localFilePath);
            }
            localParentForm.Close();
        }
        Form localParentForm;
        public void SetParent(Form parentForm)
        {
            localParentForm = parentForm;
        }
        public void InitialInput(string incomingFilePath, bool displayMode, RevisionClass oRevision)
        {
            ORevision = oRevision;
            if (File.Exists(incomingFilePath))
            {
                inputData = System.IO.File.ReadAllLines(incomingFilePath);
                localFilePath = incomingFilePath;
            }
            else
            {
                SetName();
                localFilePath = sLocation + sName;
            }

            button_Save.Visible = !displayMode;
            comboBox_Type.Enabled = !displayMode;
            textBox_Input_1.ReadOnly = displayMode;
            textBox_Name.ReadOnly = displayMode;
            textBox_Value.ReadOnly = displayMode;
            groupBox_Language.Enabled = !displayMode;
            
            if (inputData != null) FillDictionary();
            comboBox_Type.SelectedIndex = Int32.Parse(dataList["##Type:##"]);
            textBox_Name.Text = dataList["##Name:##"];
            textBox_Input_1.Text = dataList["##Input_1:##"];
            textBox_Value.Text = dataList["##Value:##"];
            if (dataList["##Language:##"] == "VB") radioButton_VB.Checked = true;
        }
        private void comboBox_Type_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataList["##Type:##"] = comboBox_Type.SelectedIndex.ToString();
            switch (comboBox_Type.SelectedIndex)
            {
                case 0:
                    label_Input_1.Text = "";
                    textBox_Input_1.Enabled = false;
                    groupBox_Language.Visible = false;
                    break;
                case 1:
                    label_Input_1.Text = "Message";
                    textBox_Input_1.Enabled = true;
                    groupBox_Language.Visible = false;
                    break;
                case 2:
                    label_Input_1.Text = "Sources";
                    textBox_Input_1.Enabled = true;
                    groupBox_Language.Visible = true;
                    break;
                case 3:
                    label_Input_1.Text = "";
                    textBox_Input_1.Enabled = false;
                    groupBox_Language.Visible = false;
                    break;
                case 4:
                    label_Input_1.Text = "Argument(s)";
                    textBox_Input_1.Enabled = true;
                    groupBox_Language.Visible = false;
                    break;
                default:
                    label_Input_1.Text = "Inputs";
                    textBox_Input_1.Enabled = true;
                    groupBox_Language.Visible = false;
                    break;
            }
        }

        private void radioButton_KW_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton_VB.Checked == true) dataList["##Language:##"] = "VB";
        }
    }
}
