using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.IO;
using System.Diagnostics;

namespace HtmlParser
{
    public partial class DetailItem : Form
    {
        DataItem _data;
        int _index;

        public DetailItem()
        {
            InitializeComponent();
        }

        public DetailItem(DataItem data, int index)
        {
            InitializeComponent();
            _data = data;
            _index = index;
        }

        private void btnFindEmail_Click(object sender, EventArgs e)
        {
            Regex regex = new Regex(@"[\w-]+@([\w-]+\.)+[\w-]+");

            if (!_data.status.Equals("Download Complete"))
                return;

            string filename = getFileName(_index);
            string file = File.ReadAllText(filename);

            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(file);

            if (doc.ParseErrors != null && doc.ParseErrors.Count() > 0)
                return;

            List<string> xpathList = new List<string>();
            visitHtmlNode(doc.DocumentNode.SelectSingleNode("//body"), regex, xpathList);

            new EmailXpathList(xpathList.ToArray()).Show();

            ProcessStartInfo startInfo = new ProcessStartInfo("chrome.exe", filename);
            Process.Start(startInfo); 
        }

        private void visitHtmlNode(HtmlAgilityPack.HtmlNode node, Regex regex, List<string> xpathList)
        {
            if (node.NodeType == HtmlAgilityPack.HtmlNodeType.Text && regex.IsMatch(node.InnerText))
            {
                xpathList.Add(node.XPath);
            }

            foreach (HtmlAgilityPack.HtmlNode child in node.ChildNodes)
            {
                visitHtmlNode(child, regex, xpathList);
            }
        }

        public string getFileName(int index)
        {
            return Convert.ToString(index) + "_" + _data.url.Substring(_data.url.LastIndexOf('/') + 1);
        }

        private void Add_Click(object sender, EventArgs e)
        {
            DataFilterXPath filter = new DataFilterXPath();
            _data.filterList.Add(filter);

            updateFilterListView();
        }

        private void updateFilterListView()
        {
            lstFilter.Items.Clear();
            foreach (DataFilter filter in _data.filterList)
            {
                lstFilter.Items.Add(new ListViewItem(filter.getType()));
            }
        }
    }
}
