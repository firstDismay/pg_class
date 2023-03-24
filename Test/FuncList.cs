using pg_class.pg_classes;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Test
{
    public partial class FuncList : Form
    {
        public FuncList()
        {
            InitializeComponent();
        }

        public FuncList(List<function> Func_list) : this()
        {
            if (Func_list.Count > 0)
            {
                foreach (function func in Func_list)
                {
                    ListViewItem li = listView1.Items.Add(func.Name);
                    li.SubItems.Add(func.Args.ToString());
                    li.SubItems.Add(func.Access.ToString());
                    li.SubItems.Add(func.Argsignature);
                    li.SubItems.Add(func.Desc);
                }

                this.Text = "Список функций БД: " + Func_list.Count.ToString();
            }

        }
    }
}
