using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;
using System.Data;
using System.Security.Cryptography;

namespace pg_class.pg_classes
{
    /// <summary>
    /// Класс файла документов 
    /// </summary>
    public partial class log_category
    {
		#region ДОБАВИТЬ

		/// <summary>
		/// Метод добавляет новую запись журнала
		/// </summary>
		public log log_add(String iuser_author, DateTime idatetime,
									 String ititle, String imessage, String iclass_body, String ibody,
									 Int64 iid_entity, Int64 iid_entity_instance, Int64 iid_sub_entity_instance)
        {
            return Manager.log_add(id, iuser_author, idatetime,
									 ititle, imessage, iclass_body, ibody,
									 iid_entity, iid_entity_instance, iid_sub_entity_instance);
        }

		/// <summary>
		/// Метод добавляет новую запись журнала
		/// </summary>
		public log log_add(String iuser_author, DateTime idatetime,
									 String ititle, String imessage, String iclass_body, String ibody,
									 user User)
		{
			return Manager.log_add(id, iuser_author, idatetime,
									 ititle, imessage, iclass_body, ibody,
									 User.EntityID, User.Id, -1);
		}

		/// <summary>
		/// Метод добавляет новую запись журнала
		/// </summary>
		public log log_add(String iuser_author, DateTime idatetime,
									 String ititle, String imessage, String iclass_body, String ibody,
									 pos_temp Pos_temp)
		{
			return Manager.log_add(id, iuser_author, idatetime,
									 ititle, imessage, iclass_body, ibody,
									 Pos_temp.EntityID, Pos_temp.Id, -1);
		}

		/// <summary>
		/// Метод добавляет новую запись журнала
		/// </summary>
		public log log_add(String iuser_author, DateTime idatetime,
									 String ititle, String imessage, String iclass_body, String ibody,
									 pos_temp_prop Pos_temp_prop)
		{
			return Manager.log_add(id, iuser_author, idatetime,
									 ititle, imessage, iclass_body, ibody,
									 Pos_temp_prop.EntityID, Pos_temp_prop.Id, -1);
		}

		/// <summary>
		/// Метод добавляет новую запись журнала
		/// </summary>
		public log log_add(String iuser_author, DateTime idatetime,
									 String ititle, String imessage, String iclass_body, String ibody,
									 position Position)
		{
			return Manager.log_add(id, iuser_author, idatetime,
									 ititle, imessage, iclass_body, ibody,
									 Position.EntityID, Position.Id, -1);
		}

		/// <summary>
		/// Метод добавляет новую запись журнала
		/// </summary>
		public log log_add(String iuser_author, DateTime idatetime,
									 String ititle, String imessage, String iclass_body, String ibody,
									 position_prop Position_prop)
		{
			return Manager.log_add(id, iuser_author, idatetime,
									 ititle, imessage, iclass_body, ibody,
									 Position_prop.EntityID, Position_prop.Id_position_prop, Position_prop.Id_position_carrier);
		}

		/// <summary>
		/// Метод добавляет новую запись журнала
		/// </summary>
		public log log_add(String iuser_author, DateTime idatetime,
									 String ititle, String imessage, String iclass_body, String ibody,
									 object_general Object_general)
		{
			return Manager.log_add(id, iuser_author, idatetime,
									 ititle, imessage, iclass_body, ibody,
									 Object_general.EntityID, Object_general.Id, -1);
		}

		/// <summary>
		/// Метод добавляет новую запись журнала
		/// </summary>
		public log log_add(String iuser_author, DateTime idatetime,
									 String ititle, String imessage, String iclass_body, String ibody,
									 object_prop Object_prop)
		{
			return Manager.log_add(id, iuser_author, idatetime,
									 ititle, imessage, iclass_body, ibody,
									 Object_prop.EntityID, Object_prop.Id_class_prop, Object_prop.Id_object_carrier);
		}

		/// <summary>
		/// Метод добавляет новую запись журнала
		/// </summary>
		public log log_add(String iuser_author, DateTime idatetime,
									 String ititle, String imessage, String iclass_body, String ibody,
									 group Group)
		{
			return Manager.log_add(id, iuser_author, idatetime,
									 ititle, imessage, iclass_body, ibody,
									 Group.EntityID, Group.Id, -1);
		}

		/// <summary>
		/// Метод добавляет новую запись журнала
		/// </summary>
		public log log_add(String iuser_author, DateTime idatetime,
									 String ititle, String imessage, String iclass_body, String ibody,
									 vclass Class)
		{
			return Manager.log_add(id, iuser_author, idatetime,
									 ititle, imessage, iclass_body, ibody,
									 Class.EntityID, Class.Id, -1);
		}

		/// <summary>
		/// Метод добавляет новую запись журнала
		/// </summary>
		public log log_add(String iuser_author, DateTime idatetime,
									 String ititle, String imessage, String iclass_body, String ibody,
									 class_prop Class_prop)
		{
			return Manager.log_add(id, iuser_author, idatetime,
									 ititle, imessage, iclass_body, ibody,
									 Class_prop.EntityID, Class_prop.Id, -1);
		}

		/// <summary>
		/// Метод добавляет новую запись журнала
		/// </summary>
		public log log_add(String iuser_author, DateTime idatetime,
									 String ititle, String imessage, String iclass_body, String ibody,
									 document Document)
		{
			return Manager.log_add(id, iuser_author, idatetime,
									 ititle, imessage, iclass_body, ibody,
									 Document.EntityID, Document.Id, -1);
		}
		#endregion

		#region УДАЛИТЬ
		/// <summary>
		/// Метод удаляет указанную запись журнала
		/// </summary>
		public void log_del(Int64 iid_log)
        {
            Manager.log_del(iid_log);
        }

		/// <summary>
		/// Метод удаляет указанную запись журнала
		/// </summary>
		public void log_del(log Log)
        {
            Manager.log_del(Log.Id);
        }
        #endregion

        #region ВЫБРАТЬ
        /// <summary>
        /// Лист записей журнала по идентификатору категории
        /// </summary>
        public List<log> log_list_get()
        {
			return Manager.log_by_id_category(Id);
		}

		/// <summary>
		/// Лист записей журнала по идентификатору категории и маске заголовка
		/// </summary>
		public List<log> log_by_title(String ititle)
        {
            return Manager.log_by_msk_title_id_category(ititle, Id);
        }

		/// <summary>
		/// Лист записей журнала по идентификатору категории и маске сообщения
		/// </summary>
		public List<log> log_by_message(String ititle)
		{
			return Manager.log_by_msk_message_id_category(ititle, Id);
		}
		#endregion
	}
}
