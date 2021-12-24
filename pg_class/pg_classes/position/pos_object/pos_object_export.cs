using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using pg_class.pg_commands;

namespace pg_class.pg_classes
{
    public partial class position
    {
        #region МЕТОДЫ ЭКСПОРТА

        //-=EXPORT TO EXCEL=-**************************************************************************
        /// <summary>
        /// Лист представлений объектов по шаблону имени объекта в указанной позиции
        /// object_by_name
        /// </summary>
        public Byte[] Object_by_name_export(String name_mask, Boolean on_internal, eBaseExportFormat ExportFormat)
        {
            return Manager.object_by_name_id_pos(name_mask, Id, on_internal, ExportFormat); 
        }

        /// <summary>
        /// Команда экспорта листа представлений объектов по шаблону имени объекта в указанной позиции
        /// object_in_position_tree_find_by_name
        /// </summary>
        public command_export Object_by_name_command_export(String name_mask, Boolean on_internal, eBaseExportFormat ExportFormat)
        {
            return Manager.object_by_name_id_pos_command_export(name_mask, Id, on_internal, ExportFormat); ;
        }

        /// <summary>
        /// Эксопрт объектов позиции экспорт в Excel
        /// </summary>
        public Byte[] Object_list_export(eBaseExportFormat ExportFormat)
        {
            return Manager.object_by_id_position(Id, ExportFormat); 
        }

        /// <summary>
        /// Команда экспорта объектов позиции экспорт в Excel
        /// </summary>
        public command_export Object_list_command_export(eBaseExportFormat ExportFormat)
        {
            return Manager.object_by_id_position_command_export(Id, ExportFormat);
        }
        #endregion
    }
}