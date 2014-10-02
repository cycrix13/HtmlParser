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
        public static Regex regex = new Regex(@"[\w-]+@([\w-]+\.)+[\w-]+");

        public DetailItem()
        {
            InitializeComponent();
        }

        public DetailItem(DataItem data, int index)
        {
            InitializeComponent();
            _data = data;
            _index = index;

            updateFilterListView();
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



            //new EmailXpathList(xpathList).Show();

            //ProcessStartInfo startInfo = new ProcessStartInfo("chrome.exe", filename);
            //Process.Start(startInfo); 
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

                    xpathList.Add(new string[] { node.XPath, matchStr });
                }
            }

            foreach (HtmlAgilityPack.HtmlNode child in node.ChildNodes)
            {
                visitHtmlNode(child, regex, xpathList);
            }
        }

        private void Add_Click(object sender, EventArgs e)
        {
            DataFilter filter = new DataFilter();
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

        private void lstFilter_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            int index = e.ItemIndex;
            DataFilter filter = _data.filterList[index];

            lstFilterDetail.Items.Clear();
            for (int i = 0; i < filter.getCount(); i++)
            {
                ListViewItem item = new ListViewItem(new string[] {filter.getTitle(i), filter.getValue(i)});
                lstFilterDetail.Items.Add(item);
            }
        }

        private void lstFilterDetail_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        int _indexDetail = -1;
        private void lstFilterDetail_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lstFilterDetail.SelectedIndices.Count == 0)
                return;

            int index = lstFilterDetail.SelectedIndices[0];
            _indexDetail = index;
            edtValue.Focus();
        }

        private void edtValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 13)
                return;

            lstFilterDetail.Items[_indexDetail].SubItems[1].Text = edtValue.Text;
        }

        private void btnSet_Click(object sender, EventArgs e)
        {
            if (lstFilter.SelectedIndices.Count == 0)
                return;

            int index = lstFilter.SelectedIndices[0];
            DataFilter filter = _data.filterList[index];

            for (int i = 0; i < filter.getCount(); i++)
                filter.setValue(i, lstFilterDetail.Items[i].SubItems[1].Text);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lstFilter.SelectedIndices.Count == 0)
                return;

            int index = lstFilter.SelectedIndices[0];

            _data.filterList.RemoveAt(index);

            updateFilterListView();
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            string filename = getFileName();
            List<string[]> result = new List<string[]>();
            foreach (DataFilter filter in _data.filterList)
                result.AddRange(filter.filter(filename));

            foreach (string[] strArr in result)
                lstResult.Items.Add(new ListViewItem(strArr[0]));
        }

        public string getFileName()
        {
            return Convert.ToString(_index) + "_" + _data.url.Substring(_data.url.LastIndexOf('/') + 1);
        }
    }
}
