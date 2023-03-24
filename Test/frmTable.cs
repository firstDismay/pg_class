using System.Data;
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
