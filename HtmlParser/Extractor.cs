using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HtmlParser
{
    public partial class Extractor : Form
    {
        DataItem _data;
        int _index;
        public static Regex regex = new Regex(@"([\w-]+\.)*[\w-]+@([\w-]+\.)+[\w-]+");
        public Form1 _parent;

        public Extractor()
        {
            InitializeComponent();
        }

        public Extractor(DataItem data, int index, Form1 parent)
        {
            InitializeComponent();

            _data = data;
            _index = index;
            _parent = parent;

            updateListView(_data.dataList);
        }

        private void btnFindEmail_Click(object sender, EventArgs e)
        {
            if (!_data.status.Equals("Download Complete"))
                return;

            string filename = getFileName();
            string file = File.ReadAllText(filename);

            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(file);

            //if (doc.ParseErrors != null && doc.ParseErrors.Count() > 0)
            //    return;

            List<string[]> xpathList = new List<string[]>();
            visitHtmlNode(doc.DocumentNode.SelectSingleNode("//body"), regex, xpathList);

            updateListView(xpathList);
        }

        public string getFileName()
        {
            StringBuilder builder = new StringBuilder();
            string iligal = _data.url.Substring(_data.url.LastIndexOf('/') + 1);
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

            return Convert.ToString(_index) + "_" + builder.ToString();
        }

        private void visitHtmlNode(HtmlAgilityPack.HtmlNode node, Regex regex, List<string[]> xpathList)
        {
            if (node.NodeType == HtmlAgilityPack.HtmlNodeType.Text)
            {
                MatchCollection matches = regex.Matches(node.InnerText);

                if (matches.Count != 0)
                {
                    string matchStr = "";
                    foreach (Match match in matches)
                    {
                        matchStr += match.Value;
                    }

                    xpathList.Add(new string[] { node.XPath, matchStr, null, null, null, null});
                }
            }

            foreach (HtmlAgilityPack.HtmlNode child in node.ChildNodes)
            {
                visitHtmlNode(child, regex, xpathList);
            }
        }

        private void updateListView(List<string[]> xpathList)
        {
            lst.Items.Clear();
            foreach (string[] strArr in xpathList)
            {
                lst.Items.Add(new ListViewItem(strArr));
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _data.dataList.Clear();

            foreach (ListViewItem item in lst.Items)
            {
                string[] strArr = new string[6];
                for (int i = 0; i < 6; i++)
                    strArr[i] = item.SubItems[i].Text;
                _data.dataList.Add(strArr);
            }

            _parent.btnSave_Click(null, null);
        }

        private void btnCutXpath_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in lst.Items)
            {
                string str = item.SubItems[0].Text;
                int found = str.LastIndexOf('/');
                if (found != -1)
                    item.SubItems[0].Text = str.Substring(0, found);
            }
        }

        private void btnSetXpathRelative_Click(object sender, EventArgs e)
        {
            if (lst.SelectedIndices.Count == 0)
                return;

            foreach (ListViewItem item in lst.SelectedItems)
            {
                item.SubItems[2].Text = edt.Text;
            }
        }

        private void btnEvaluate1_Click(object sender, EventArgs e)
        {
            if (lst.SelectedIndices.Count == 0)
                return;

            string filename = getFileName();
            string file = File.ReadAllText(filename);

            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(file);

            Regex humanRegex = new Regex(@"[a-zA-Z][a-zA-Z' \.]*[a-zA-Z]");
            foreach (ListViewItem item in lst.SelectedItems)
            {
                string xpath = item.SubItems[0].Text + item.SubItems[2].Text;

                try
                {
                    HtmlAgilityPack.HtmlNode node = doc.DocumentNode.SelectSingleNode(xpath);
                    if (node == null)
                        continue;

                    string text = node.InnerText.Replace("&nbsp;", "");

                    Match match = humanRegex.Match(text);
                    item.SubItems[3].Text = match.Success ? humanRegex.Match(text).Value : text;
                }
                catch (Exception ex)
                {

                }
            }
                
        }

        private void btnSetRelative1_Click(object sender, EventArgs e)
        {
            new AddName(this, 2, new string[0]).Show();
        }

        private void btnDelNoXpathR1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < lst.Items.Count; )
            {
                ListViewItem item = lst.Items[i];
                if (item.SubItems[2].Text == null || item.SubItems[2].Text == "")
                    lst.Items.RemoveAt(i);
                else
                    i++;
            }

                
        }

        private void btnSetXpathRelative2_Click(object sender, EventArgs e)
        {
            if (lst.SelectedIndices.Count == 0)
                return;

            foreach (ListViewItem item in lst.SelectedItems)
            {
                item.SubItems[4].Text = edt.Text;
            }
        }

        private void btnEvaluate2_Click(object sender, EventArgs e)
        {
            if (lst.SelectedIndices.Count == 0)
                return;

            string filename = getFileName();
            string file = File.ReadAllText(filename);

            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(file);

            //Regex humanRegex = new Regex(@"[a-zA-Z][a-zA-Z' \.]*[a-zA-Z]");
            foreach (ListViewItem item in lst.SelectedItems)
            {
                string xpath = item.SubItems[0].Text + item.SubItems[4].Text;

                try
                {
                    HtmlAgilityPack.HtmlNode node = doc.DocumentNode.SelectSingleNode(xpath);
                    if (node == null)
                        continue;

                    string text = node.InnerText.Replace("&nbsp;", "");

                    item.SubItems[5].Text = text;
                }
                catch (Exception ex)
                {

                }
            }
        }

        private void btnAddName_Click(object sender, EventArgs e)
        {
            new AddName(this, 1, new string[0]).Show();
        }

        public void addName(string[] names)
        {
            foreach (string str in names)
            {
                if (str.Length == 0)
                    continue;

                lst.Items.Add(new ListViewItem(new string[] { "", "", "", str, "", "", }));
            }
        }

        public void addR1(string[] strArr)
        {
            int i = 0;
            foreach (ListViewItem item in lst.SelectedItems)
            {
                if (i <= strArr.Length - 1)
                    item.SubItems[3].Text = strArr[i];
                else
                    item.SubItems[3].Text = "";
                i++;
            }
        }

        public void addR2(string[] strArr)
        {
            int i = 0;
            foreach (ListViewItem item in lst.SelectedItems)
            {
                if (i <= strArr.Length - 1)
                    item.SubItems[5].Text = strArr[i];
                else
                    item.SubItems[5].Text = "";
                i++;
            }
        }

        public void addMail(string[] strArr)
        {
            int i = 0;
            foreach (ListViewItem item in lst.SelectedItems)
            {
                if (i <= strArr.Length - 1)
                    item.SubItems[1].Text = strArr[i];
                else
                    item.SubItems[1].Text = "";
                i++;
            }
        }

        public void addNameCallBack(string[] strArr, int param)
        {
            switch (param)
            {
                case 1:
                    addName(strArr);
                    break;

                case 2:
                    addR1(strArr);
                    break;

                case 3:
                    addR2(strArr);
                    break;
                    
                case 4:
                    addMail(strArr);
                    break;
            }
        }

        private void btnSetRelative2_Click(object sender, EventArgs e)
        {
            string[] r = new string[lst.SelectedItems.Count];
            int i = 0;
            foreach (ListViewItem item in lst.SelectedItems)
            {
                r[i] = item.SubItems[5].Text;
                i++;
            }
            new AddName(this, 3, r).Show();
        }

        private void btnSetEmail_Click(object sender, EventArgs e)
        {
            string[] r = new string[lst.SelectedItems.Count];
            int i = 0;
            foreach (ListViewItem item in lst.SelectedItems)
            {
                r[i] = item.SubItems[1].Text;
                i++;
            }
            new AddName(this, 4, r).Show();
        }

        private void btnFindEmailHref_Click(object sender, EventArgs e)
        {
            if (!_data.status.Equals("Download Complete"))
                return;

            string filename = getFileName();
            string file = File.ReadAllText(filename);

            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(file);

            //if (doc.ParseErrors != null && doc.ParseErrors.Count() > 0)
            //    return;

            List<string[]> xpathList = new List<string[]>();
            visitHtmlNodeHref(doc.DocumentNode.SelectSingleNode("//body"), regex, xpathList);

            updateListView(xpathList);
        }

        private void visitHtmlNodeHref(HtmlAgilityPack.HtmlNode node, Regex regex, List<string[]> xpathList)
        {

            HtmlAgilityPack.HtmlAttribute href = node.Attributes["href"];
            if (href != null)
            {
                MatchCollection matches = regex.Matches(href.Value);
                
                if (matches.Count != 0)
                {
                    string matchStr = "";
                    foreach (Match match in matches)
                    {
                        matchStr += match.Value;
                    }

                    xpathList.Add(new string[] { href.XPath, matchStr, null, null, null, null });
                }
            }

            foreach (HtmlAgilityPack.HtmlNode child in node.ChildNodes)
            {
                visitHtmlNodeHref(child, regex, xpathList);
            }
        }

        public static string GetTextFromAllPages(String pdfPath)
        {
            PdfReader reader = new PdfReader(pdfPath);

            StringWriter output = new StringWriter();

            for (int i = 1; i <= reader.NumberOfPages; i++)
                output.WriteLine(PdfTextExtractor.GetTextFromPage(reader, i, new LocationTextExtractionStrategy()));

            return output.ToString();
        }

        private void btnExtractPdf_Click(object sender, EventArgs e)
        {
            GetTextFromAllPages(getFileName());
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            lst.Items.Clear();
        }
    }


}
