using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HtmlParser
{
    public partial class EmailXpathList : Form
    {
        public EmailXpathList()
        {
            InitializeComponent();
        }

        public EmailXpathList(List<string[]> xpathList)
        {
            InitializeComponent();

            foreach (string[] strArr in xpathList) {
                lst.Items.Add(new ListViewItem(strArr));
            }

            this.Location = new Point();
            this.StartPosition = FormStartPosition.Manual;
        }
    }
}
