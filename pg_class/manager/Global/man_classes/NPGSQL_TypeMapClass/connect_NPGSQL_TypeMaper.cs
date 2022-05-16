using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using pg_class.pg_exceptions;
using System.Data;
using System.Net.Sockets;
using pg_class.pg_commands;

namespace pg_class.poolcn
{
    internal partial class connect
    {
        /// <summary>
        /// Сопоставление композитных типов
        /// </summary>
        protected void npgsql_type_map(NpgsqlConnection cn)
        {
            if (cn.State == ConnectionState.Open)
            {
                //NpgsqlConnection.GlobalTypeMapper.UseJsonNet();
                //cn.TypeMapper.UseJsonNet();
                cn.TypeMapper.Reset();
                cn.TypeMapper.MapComposite<pg_argument>("bpd.argument");
                cn.TypeMapper.MapComposite<pg_tblcol2>("bpd.tblcol2");
                cn.TypeMapper.MapComposite<pg_errarg2>("bpd.errarg2");

                cn.TypeMapper.MapComposite<pg_vclass_prop>("bpd.vclass_prop");
                cn.TypeMapper.MapComposite<pg_vobject_prop>("bpd.vobject_prop");

                cn.TypeMapper.MapComposite<pg_vdoc_file>("bpd.vdoc_file");
                cn.TypeMapper.MapComposite <pg_vdoc_link>("bpd.vdoc_link");
                cn.TypeMapper.MapComposite<pg_vdoc_category>("bpd.vdoc_category");

                cn.TypeMapper.MapEnum<pg_day_type>("bpd.day_type");
                cn.TypeMapper.MapEnum<pg_range_work_type>("bpd.range_work_type");
                cn.TypeMapper.MapEnum<pg_range_work_state>("bpd.range_work_state");

                cn.TypeMapper.MapEnum<pg_action_sql>("bpd.action_sql");
            }
        }
    }
}
