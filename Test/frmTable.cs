using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test
{
    public partial class frmTable : Form
    {
        public frmTable()
        {
            InitializeComponent();
        }

        public frmTable(DataTable dt) : this()
        {
            dataGridView1.DataSource = dt;
        }
    }
}
