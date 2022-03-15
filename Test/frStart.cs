using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using pg_class.pg_classes;
using pg_class;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using pg_class.pg_commands;
using NpgsqlTypes;
using Npgsql;
using System.Globalization;

namespace Test
{
    public partial class frStart : Form
    {
        SynchronizationContext ContextUI;
        manager NEW_pg_class;
        public frStart()
        {
            InitializeComponent();
            this.Text = "Правила отношений шаблонов позиций";
            cbDataBase.SelectedIndex = 0;
            cbHost.SelectedIndex = 0;
            //manager.JournalMessageReceived += NEW_pg_class_JournalMessageReceived;
            manager.ManagerStateChange += Manager_ManagerStateChange;
            manager.Mode = eManagerMode.DebugMode;
            System.Threading.Thread tk7 = System.Threading.Thread.CurrentThread;
            ContextUI = WindowsFormsSynchronizationContext.Current;
        }
        private void treeView1_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            TreeNode tn;
            pos_temp ptn = (pos_temp)e.Node.Tag;
            List<pos_temp> ptl = ptn.Pos_Temp_Nested_List_get(false);
            e.Node.Nodes.Clear();
            foreach (pos_temp pt in ptl)
            {
                tn = e.Node.Nodes.Add(pt.ToString());
                tn.Tag = pt;
            }
            //lbState.Text = "Статус: " + manager.State.ToString("g");
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            TreeNode tn;
            treeView1.Nodes.Clear();
            List<pos_temp> ptl = ((conception)comboBox1.SelectedItem).Pos_temp_nested_list_get();
            foreach (pos_temp pt in ptl)
            {
                tn = treeView1.Nodes.Add(pt.ToString());
                tn.Tag = pt;
            }
            lbState.Text = "Статус: " + manager.StateInstance.ToString("g");
        }


        private void btConnect_Click(object sender, EventArgs e)
        {
            pg_class.pg_settings Settings = new pg_class.pg_settings(tbUser.Text, tbPassword.Text, cbHost.Text, cbDataBase.Text, Convert.ToInt32(txtPort.Text));
            NEW_pg_class = manager.Instance();
            NEW_pg_class.Pool_Create(Settings);


            comboBox1.DataSource = NEW_pg_class.Conception_list;
            NEW_pg_class.Info.Current_Configurator = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;

            ///ИЗВРАЩАИТЬСЯ ТУТ
            ///


            List<object_general> og = NEW_pg_class.object_ext_by_id_position(1314);

            List<String> ogj = new List<string>();

            foreach (object_general o in og)
            { 
                ogj.Add(o.ToJson());
            }


            List<String> sm = NEW_pg_class.class_prop_search_method_by_id_class_prop(77186);

            List<eSearchMethods> sm2 = NEW_pg_class.class_prop_search_method_by_id_class_prop2(77194);

            PropSearchСondition arg1 = new PropSearchСondition();
            arg1.IdDefinitionProp = 77186;
            arg1.ValReq = "3";
            arg1.ValMin = "1";
            arg1.ValMax = "2";
            arg1.SearchMethods = eSearchMethods.more_or_equal_and_less_or_equal;

            PropSearchСondition arg2 = new PropSearchСondition();
            arg2.IdDefinitionProp = 77188;
            arg2.ValReq = "3";
            arg2.ValMin = "1";
            arg2.ValMax = "2";
            arg2.SearchMethods = eSearchMethods.more_and_less;

            PropSearchСondition arg3 = new PropSearchСondition();
            arg3.IdDefinitionProp = 77190;
            arg3.ValReq = "3";
            arg3.ValMin = "1";
            arg3.ValMax = "2";
            arg3.SearchMethods = eSearchMethods.more_and_less;

            PropSearchСondition arg4 = new PropSearchСondition();
            arg4.IdDefinitionProp = 77192;
            arg4.ValReqArray = new String[]{"1284", "1288"};
            //arg4.ValReqArray = new String[] { "1284" };
            arg4.ValMin = "1";
            arg4.ValMax = "2";
            arg4.SearchMethods = eSearchMethods.any_array;

            PropSearchСondition arg5 = new PropSearchСondition();
            arg5.IdDefinitionProp = 77194;
            arg5.ValReq = "%желтый%";
            arg5.ValMin = "1";
            arg5.ValMax = "2";
            arg5.SearchMethods = eSearchMethods.like_lower;

            PropSearchСondition[] arrc = new PropSearchСondition[] { arg1, arg2, arg3, arg4 };

            List<object_general> OL = NEW_pg_class.object_by_array_prop(arrc, 1557);

            List<object_general> OL2 = NEW_pg_class.object_ext_by_array_prop(arrc, 1557);

            arg5.SearchMethods = eSearchMethods.like_lower;
            //String[] sr = new string[] { System.Text.Json.JsonSerializer.Serialize(arg) };

            //cmd.Parameters["array_prop"].Value = sr;
            //cmd.Parameters["iid_position"].Value = 930;

            //DataTable dt = new DataTable();
            //cmd.Fill(dt);



            //Json[] args = new json_array_prop(){arg};



            //Выполнение команды: 'class_act_in_group_tree_find_by_name' с параметрами:  iid_group = 186; name_mask = bft69; | Время выполнения: 484,626мс

            //ContextUI.Send(new SendOrPostCallback()

            //=======================


            //command_export ce = NEW_pg_class.export_object_with_prop_by_global_prop_from_pos_to_excel_get_command(gp, p, "lab");

            //Byte[] xls = ce.Export();

            //Byte[] xls = NEW_pg_class.object_by_id_position(1000, eBaseExportFormat.TableEntity);
            /// 
            ///
            /*System.Threading.Thread tk1 = new System.Threading.Thread(task);
             System.Threading.Thread tk2 = new System.Threading.Thread(task);
             System.Threading.Thread tk3 = new System.Threading.Thread(task);
             System.Threading.Thread tk4 = new System.Threading.Thread(task);
             System.Threading.Thread tk5 = new System.Threading.Thread(task);
             System.Threading.Thread tk6 = new System.Threading.Thread(task);
             System.Threading.Thread tk7 = new System.Threading.Thread(task);
             System.Threading.Thread tk8 = new System.Threading.Thread(task);
             System.Threading.Thread tk9 = new System.Threading.Thread(task);
             System.Threading.Thread tk10 = new System.Threading.Thread(task);
             System.Threading.Thread tk11 = new System.Threading.Thread(task);
             System.Threading.Thread tk12 = new System.Threading.Thread(task);
             System.Threading.Thread tk13 = new System.Threading.Thread(task);
             System.Threading.Thread tk14 = new System.Threading.Thread(task);
             System.Threading.Thread tk15 = new System.Threading.Thread(task);
             System.Threading.Thread tk16 = new System.Threading.Thread(task); 
             System.Threading.Thread tk17 = new System.Threading.Thread(task);
             System.Threading.Thread tk18 = new System.Threading.Thread(task);
             System.Threading.Thread tk19 = new System.Threading.Thread(task);
             System.Threading.Thread tk20 = new System.Threading.Thread(task);*/


            /*tk1.Start();
            tk2.Start();
            tk3.Start();
            tk4.Start();
            tk5.Start();
            tk6.Start();
            tk7.Start();
            tk8.Start();
            tk9.Start();
            tk10.Start();
            tk11.Start();
            tk12.Start();
            tk13.Start();
            tk14.Start();
            tk15.Start();
            tk16.Start();
            tk17.Start();
            tk18.Start();
            tk19.Start();
            tk20.Start();*/

            //Version v = new Version(21, 1, 1, 1);

            //NEW_pg_class.Info.Update(true);

            //object_general o = NEW_pg_class.object_ext_by_id(1210);
            //global_prop gp = NEW_pg_class.global_prop_by_id(70);

            //object_prop op = o.Property_by_global_prop(gp);

            //global_prop gp = NEW_pg_class.global_prop_by_id(70);
            //position p = NEW_pg_class.pos_by_id(1304);





            //vclass c = NEW_pg_class.class_act_by_id(650);

            //List<errarg_object_add> we = p.Object_add_for_class_act(c);
            //listBox1.DataSource = we;
            //List<errarg_object_add> we = NEW_pg_class.object_add_for_class_act(650, 1160);



            foreach (eDataType t in  (eDataType[])Enum.GetValues(typeof(eDataType)))
            {
                Console.WriteLine(t.ToString("g"));
            }
            //group g = NEW_pg_class.group_by_id(129);
        }

        private void task()
        {
            List<vclass> cl;
            List<class_prop> cpl;
            Boolean chek;

            Console.WriteLine(String.Format("Поток ID = {0} запущен!", System.Threading.Thread.CurrentThread.ManagedThreadId));
            if (NEW_pg_class != null)
            {
                for (Int64 i = 0; i < 1000; i++)
                {
                    cl = NEW_pg_class.class_act_by_id_parent(650);
                }
            }
            Console.WriteLine(String.Format("Поток ID = {0} завершен!", System.Threading.Thread.CurrentThread.ManagedThreadId));
        }

        private void NEW_pg_class_JournalMessageReceived(object sender, JournalEventArgs e)
        {
            Console.WriteLine(e.ErrorDesc.ToString());
        }

        private void btDisConnect_Click(object sender, EventArgs e)
        {
            manager.Close();
            //lbState.Text = "Статус: " + manager.State.ToString("g");

        }
        private void Manager_ManagerStateChange(object sender, ManagerStateChangeEventArgs e)
        {
            if (e.ManagerState == eManagerState.Connected)
            {
                user tets = manager.Instance().User_current;
            }
            Console.WriteLine(e.Entity.ToString());
        }



        private void ManagerStateChange(Object sender, ManagerStateChangeEventArgs e)
        {
            lbState.Text = "Статус: " + manager.StateInstance.ToString("g");
            if (manager.StateInstance == eManagerState.Connected)
            {
                toolStripStatusLabel2.Text = manager.Instance().user_by_current().ToString();
            }
            else
            {
                toolStripStatusLabel2.Text = "нет";
            }
        }

        

        private void btnFunc_list_Click(object sender, EventArgs e)
        {
            if (manager.StateInstance == eManagerState.Connected)
            {
                FuncList fl = new FuncList(manager.Instance().user_base_function_by_login("EngNSI"));

                fl.Show();
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
