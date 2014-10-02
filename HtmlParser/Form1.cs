using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Xml.Serialization;
using System.Text.RegularExpressions;
using HtmlAgilityPack;
using System.Diagnostics;

namespace HtmlParser
{
    public partial class Form1 : Form
    {
        private const int MAX_CLIENT = 5;

        List<DataItem> _data = new List<DataItem>();
        int _downloadingCount = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            OpenFileDialog openDlg = new OpenFileDialog();

            if (openDlg.ShowDialog() != DialogResult.OK)
                return;
            
            string[] lines = File.ReadAllLines(openDlg.FileName);

            for (int i = 0; i < lines.Length; i++)
            {
                DataItem item = new DataItem();
                item.url = lines[i];
                _data.Add(item);
            }

            updateView();
        }

        public void updateView()
        {
            for (int i = 0; i < _data.Count; i++)
            {
                if (lstData.Items.Count - 1 < i)
                {
                    lstData.Items.Add(new ListViewItem(new string[] { "", "", "", ""}));
                }
                else if (!_data[i].dirty)
                    continue;

                lstData.Items[i].SubItems[0].Text = Convert.ToString(i);
                lstData.Items[i].SubItems[1].Text = _data[i].url;
                lstData.Items[i].SubItems[2].Text = _data[i].status;
                if (_data[i].dataList.Count > 0)
                    lstData.Items[i].SubItems[3].Text = Convert.ToString(_data[i].dataList.Count);

                _data[i].dirty = false;
            }
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            startDownload();
        }

        private void startDownload()
        {
            if (_downloadingCount < MAX_CLIENT)
            {
                int index = -1;
                for (int i = 0; i < _data.Count; i++)
                    if (!_data[i].downloaded) {
                        index = i;
                        break;
                    }

                if (index == -1)
                    return;

                WebClient webClient = new WebClient();
                DownloadListener listener = new DownloadListener(this, index);
                webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(listener.Completed);
                webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(listener.ProgressChanged);
                string fileName = getFileName(index);
                webClient.DownloadFileAsync(new Uri(_data[index].url), fileName);
                _data[index].downloaded = true;
                _data[index].status = "Downloading...";
                _data[index].dirty = true;
                _downloadingCount++;

                updateView();

                startDownload();
            }
        }

        public string getFileName(int index)
        {
            StringBuilder builder = new StringBuilder();
            string iligal = _data[index].url.Substring(_data[index].url.LastIndexOf('/') + 1);
            foreach (char ch in iligal) {
                if ((ch >= 'a' && ch <= 'z') ||
                    (ch >= 'A' && ch <= 'Z') ||
                    (ch >= '0' && ch <= '9') ||
                    ch == '_' ||
                    ch == '.' ||
                    ch == '-' ||
                    ch == '%') {
                    builder.Append(ch);
                }
            }

            return Convert.ToString(index) + "_" + builder.ToString();
        }

        class DownloadListener
        {
            public int index;
            public Form1 thiz;

            public DownloadListener(Form1 thiz, int index)
            {
                this.thiz = thiz;
                this.index = index;
            }

            public void Completed(object sender, AsyncCompletedEventArgs e)
            {
                if (e.Error == null)
                    thiz._data[index].status = "Download Complete";
                else
                    thiz._data[index].status = "Download Failed";

                thiz._data[index].dirty = true;
                thiz.updateView();

                thiz._downloadingCount--;
                thiz.startDownload();
            }

            public void ProgressChanged(object sender, DownloadProgressChangedEventArgs e)
            {
                thiz._data[index].status = "Downloading(" + e.ProgressPercentage + "%)";
                thiz._data[index].dirty = true;
                thiz.updateView();
            }
        }

        public void btnSave_Click(object sender, EventArgs e)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<DataItem>));

            string filename = "Data.xml";
            StreamWriter writer = new StreamWriter(filename);
            serializer.Serialize(writer, _data);
            writer.Close();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<DataItem>));

            string filename = "Data.xml";
            TextReader reader = new StreamReader(filename);
            _data = (List<DataItem>)serializer.Deserialize(reader);
            reader.Close();

            foreach (DataItem item in _data)
                item.dirty = true;

            updateView();
        }

        private void btnParse_Click(object sender, EventArgs e)
        {
            //Regex regex = new Regex(@"[\w-]+@([\w-]+\.)+[\w-]+");

            //for (int i = 0; i < _data.Count; i++)
            //{
            //    if (!_data[i].status.Equals("Download Complete"))
            //        continue;

            //    string filename = getFileName(i);
            //    string file = File.ReadAllText(filename);

            //    HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            //    doc.LoadHtml(file);

            //    if (doc.ParseErrors != null && doc.ParseErrors.Count() > 0)
            //        continue;

            //    List<string> xpathList = new List<string>();
            //    visitHtmlNode(doc.DocumentNode.SelectSingleNode("//body"), regex, xpathList);

            //    _data[i].matches = xpathList.ToArray();
            //}
        }

        static public void visitHtmlNode(HtmlAgilityPack.HtmlNode node, Regex regex, List<string> xpathList)
        {
            if (node.NodeType ==  HtmlAgilityPack.HtmlNodeType.Text && regex.IsMatch(node.InnerText))
            {
                xpathList.Add(node.XPath);
            }

            foreach (HtmlAgilityPack.HtmlNode child in node.ChildNodes)
            {
                visitHtmlNode(child, regex, xpathList);
            }
        }

        private void lstData_DoubleClick(object sender, EventArgs e)
        {

        }

        private void lstData_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lstData.SelectedIndices.Count == 0)
                return;

            int index = lstData.SelectedIndices[0];
            new Extractor(_data[index], index, this).Show();

            ProcessStartInfo startInfo = new ProcessStartInfo("chrome.exe", _data[index].url);
            Process.Start(startInfo); 
        }

        private void btnAssign_Click(object sender, EventArgs e)
        {
            if (lstData.SelectedIndices.Count == 0)
                return;

            int index = lstData.SelectedIndices[0];

            OpenFileDialog dlg = new OpenFileDialog();
            if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                _data[index].downloaded = true;
                _data[index].status = "Download Complete";
                _data[index].dirty = true;
                string filename = dlg.SafeFileName;
                File.Move(dlg.SafeFileName, getFileName(index));
                //dlg.FileName

                updateView();
            }

        }

        private void btnExtract_Click(object sender, EventArgs e)
        {
            StreamWriter os = new StreamWriter("Extractor.csv");

            foreach (DataItem item in _data)
            {
                foreach (string[] strArr in item.dataList)
                {
                    string name = strArr[3].Trim();
                    string email = strArr[1].Trim();
                    string tel = strArr[5].Trim();

                    string firstName, lastname;
                    int spaceIndex = name.IndexOf(' ');
                    if (name.IndexOf(' ') == -1)
                    {
                        firstName = name;
                        lastname = "";
                    }
                    else
                    {
                        firstName = name.Substring(0, spaceIndex);
                        lastname = name.Substring(spaceIndex + 1);
                    }

                    string line = new StringBuilder().Append(firstName).Append(',')
                        .Append(lastname).Append(',')
                        .Append(email).Append(',')
                        .Append(tel).ToString();
                    os.WriteLine(line);
                }
            }

            
            
            os.Close();
        }
    }

    //public abstract class DataFilter
    //{
    //    abstract public int getCount();
    //    abstract public string getTitle(int index);
    //    abstract public string getValue(int index);
    //    abstract public void setValue(int index, string value);
    //    abstract public string getType();
    //    abstract public List<string[]> filter(string fileName);
    //}

    public class DataFilter
    {
        public string xpath;
        public string xpathRelative;

        public int getCount() 
        {
            return 2;
        }

        public string getTitle(int index)
        {
            switch (index)
            {
                case 0:
                    return "xpath";
                case 1:
                    return "xpathRelative";
                default:
                    return "";
            }
        }

        public string getValue(int index)
        {
            switch (index)
            {
                case 0:
                    return xpath;
                case 1:
                    return xpathRelative;
                default:
                    return "";
            }
        }

        public void setValue(int index, string value)
        {
            switch (index)
            {
                case 0:
                    xpath = value;
                    break;
                case 1:
                    xpathRelative = value;
                    break;
            }
        }

        public string getType()
        {
            return "DataFilterXPath";
        }

        public List<string[]> filter(string filename)
        {
            string file = File.ReadAllText(filename);

            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(file);
            
            if (doc.ParseErrors != null && doc.ParseErrors.Count() > 0)
                return new List<string[]>();

            string docXpath = doc.DocumentNode.XPath;
            HtmlAgilityPack.HtmlNodeCollection nodes = doc.DocumentNode.SelectNodes(xpath);

            List<string[]> result = new List<string[]>();
            foreach (HtmlAgilityPack.HtmlNode node in nodes) {
                if (DetailItem.regex.IsMatch(node.InnerText))
                    result.Add(new string[] { node.InnerText });    
            }

            return result;
        }
    }

    public class DataItem
    {
        public string url;
        public bool downloaded = false;
        //public string[] matches;
        public List<string[]> dataList = new List<string[]>();
        public string status;

        public List<DataFilter> filterList = new List<DataFilter>();

        public bool dirty = true;
    }
}
