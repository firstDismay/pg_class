using pg_class.pg_classes;
using pg_class.pg_commands;
using pg_class.pg_exceptions;
using System;

namespace pg_class
{
    public partial class manager
    {
        /// <summary>
        /// Метод изменяет указанную категорию документов
        /// </summary>
        public doc_category doc_category_upd(Int64 iid, String iname, String idesc, Boolean ion_grouping, Boolean ion)
        {
            doc_category doc_category = null;
            Int32 error;
            String desc_error;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("doc_category_upd");
            if (cmdk != null)
            {
                if (!cmdk.Access)
                {
                    throw new AccessDataBaseException(404, String.Format(@"Отказано в доступе к методу: {0}!", cmdk.CommandText));
                }
            }
            else
            {
                throw new AccessDataBaseException(405, String.Format(@"Не найден метод: {0}!", cmdk.CommandText));
            }

            cmdk.Parameters["iid"].Value = iid;
            cmdk.Parameters["iname"].Value = iname;
            cmdk.Parameters["idesc"].Value = idesc;
            cmdk.Parameters["ion_grouping"].Value = ion_grouping;
            cmdk.Parameters["ion"].Value = ion;
            cmdk.ExecuteNonQuery();

            doc_category = doc_category_by_id(iid);
            if (doc_category != null)
            {
                //Генерируем событие изменения категории документов
                DocCategoryChangeEventArgs e = new DocCategoryChangeEventArgs(doc_category, eAction.Update);
                DocCategoryOnChange(e);
            }
            //Возвращаем сущность
            return doc_category;
        }

        /// <summary>
        /// Метод изменяет указанную категорию документов
        /// </summary>
        public doc_category doc_category_upd(doc_category Doc_category)
        {
            return doc_category_upd(Doc_category.Id, Doc_category.Name, Doc_category.Desc, Doc_category.On_grouping, Doc_category.On);
        }

        //ACCESS
        /// <summary>
        /// Проверка прав доступа к методу
        /// </summary>
        public Boolean doc_category_upd(out eAccess Access)
        {
            Boolean Result = false;
            Access = eAccess.NotFound;
            NpgsqlCommandKey cmdk;

            cmdk = CommandByKey("doc_category_upd");
            if (cmdk != null)
            {
                Result = cmdk.Access;
                if (Result)
                {
                    Access = eAccess.Success;
                }
                else
                {
                    Access = eAccess.NotAvailable;
                }
            }
            return Result;
        }
    }
}