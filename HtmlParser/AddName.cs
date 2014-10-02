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
    public partial class AddName : Form
    {
        Extractor _parent;
        int _param;

        public AddName()
        {
            InitializeComponent();
        }

        public AddName(Extractor parent, int param, string[] lines)
        {
            InitializeComponent();

            _parent = parent;
            _param = param;

            StringBuilder builder = new StringBuilder();
            foreach (string str in lines)
                builder.Append(str).Append("\r\n");

            edt.Text = builder.ToString();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            string[] lines = edt.Text.Split(new char[] {'\r', '\n'}, StringSplitOptions.RemoveEmptyEntries);
            _parent.addNameCallBack(lines, _param);
        }
    }
}
