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

        public EmailXpathList(string[] xpathList)
        {
            InitializeComponent();

            StringBuilder builder = new StringBuilder();
            foreach (string str in xpathList) {
                builder.Append(str).Append("\r\n");
            }

            textBox.Text = builder.ToString();
        }
    }
}
