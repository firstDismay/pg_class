using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace pg_class
{
    /// <summary>
    /// Аргумент сообщения журнала событий
    /// </summary>
    public class JournalEventArgs : EventArgs
    {
        #region КОНСТРУКТОРЫ КЛАССА

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        protected JournalEventArgs()
        {
            primaryerrordesc = "";
        }


        /// <summary>
        /// Основной конструктор класса аргумента события
        /// </summary>
        public JournalEventArgs(Int64 ID, eEntity EntityName, Int32 ErrorID, String ErrorDesc, eAction Action , eJournalMessageType MessageType) : this()
        {
            id = ID;
            entityname = EntityName;
            errorid = ErrorID;
            errordesc = ErrorDesc;
            action = Action;
            messagetype = MessageType;
        }

        /// <summary>
        /// Основной конструктор класса аргумента события для работы с сотавными сущностями, данными свойств
        /// </summary>
        public JournalEventArgs(Int64 Id_entity, Int64 Id_prop, eEntity EntityName, Int32 ErrorID, String ErrorDesc, eAction Action, eJournalMessageType MessageType) : this()
        {
            id = Id_entity;
            id_prop = Id_prop;
            entityname = EntityName;
            errorid = ErrorID;
            errordesc = ErrorDesc;
            action = Action;
            messagetype = MessageType;
        }

        /// <summary>
        /// Дополнительный конструктор класса аргумента события
        /// </summary>
        public JournalEventArgs(JournalEventArgs JournalEventArgs) : this()
        {
            id = JournalEventArgs.ID;
            entityname = JournalEventArgs.eEntityName;
            errorid = JournalEventArgs.ErrorID;
            errordesc = JournalEventArgs.ErrorDesc;
            action = JournalEventArgs.Action;
            messagetype = JournalEventArgs.MessageType;
        }



        /// <summary>
        /// Основной конструктор класса аргумента события
        /// </summary>
        public JournalEventArgs(Int64 ID, eEntity EntityName, Int32 ErrorID, String ErrorDesc, String PrimaryErrorDesc, eAction Action, eJournalMessageType MessageType) : this()
        {
            id = ID;
            entityname = EntityName;
            errorid = ErrorID;
            errordesc = ErrorDesc;
            primaryerrordesc = PrimaryErrorDesc;
            action = Action;
            messagetype = MessageType;

        }

        /// <summary>
        /// Дополнительный конструктор для событий методов классов
        /// </summary>
        public JournalEventArgs(ClassChangeEventArgs e) : this()
        {
            action = e.Action;
            if (e.Vclass != null)
            {
                id = e.Vclass.Id;
            }
            entityname = eEntity.vclass;
            errorid = 0;
            errordesc = "Успешное завершение процедуры";
            messagetype = eJournalMessageType.success;
        }

        /// <summary>
        /// Дополнительный конструктор для событий методов свойств классов
        /// </summary>
        public JournalEventArgs(ClassPropChangeEventArgs e) : this()
        {
            action = e.Action;
            if (e.ClassProp != null)
            {
                id = e.ClassProp.Id;
            }
            entityname = eEntity.class_prop;
            errorid = 0;
            errordesc = "Успешное завершение процедуры";
            messagetype = eJournalMessageType.success;
        }

        /// <summary>
        /// Дополнительный конструктор для событий методов свойств классов
        /// </summary>
        public JournalEventArgs(ClassPropObjectValChangeEventArgs e) : this()
        {
            action = e.Action;
            if (e.ClassPropObjectVal != null)
            {
                id = e.ClassPropObjectVal.Id;
            }
            entityname = eEntity.class_prop_object_val;
            errorid = 0;
            errordesc = "Успешное завершение процедуры";
            messagetype = eJournalMessageType.success;
        }

        /// <summary>
        /// Дополнительный конструктор для событий методов свойств классов
        /// </summary>
        public JournalEventArgs(ClassPropUserValChangeEventArgs e) : this()
        {
            action = e.Action;
            id = e.Id_Class_Prop;
            entityname = eEntity.class_prop_user_val;
            errorid = 0;
            errordesc = "Успешное завершение процедуры";
            messagetype = eJournalMessageType.success;
        }

        /// <summary>
        /// Дополнительный конструктор для событий методов свойств объектов
        /// </summary>
        public JournalEventArgs(ObjectPropUserValChangeEventArgs e) : this()
        {
            action = e.Action;
            id = e.Id_object_carrier;
            id_prop = e.Id_class_prop;
            entityname = eEntity.object_prop_user_val;
            errorid = 0;
            errordesc = "Успешное завершение процедуры";
            messagetype = eJournalMessageType.success;
        }
        
        /// <summary>
        /// Дополнительный конструктор для событий методов свойств объектов
        /// </summary>
        public JournalEventArgs(ObjectPropObjectValChangeEventArgs e) : this()
        {
            action = e.Action;
            if (e.ObjectPropObjectVal != null)
            {
                id = e.ObjectPropObjectVal.Id_object_carrier;
                id_prop = e.ObjectPropObjectVal.Id_object_prop;
            }
            entityname = eEntity.object_prop_object_val;
            errorid = 0;
            errordesc = "Успешное завершение процедуры";
            messagetype = eJournalMessageType.success;
        }

        /// <summary>
        /// Дополнительный конструктор для событий методов пользователя
        /// </summary>
        public JournalEventArgs(UserChangeEventArgs e) : this()
        {
            action = e.Action;
            id = 0;
            entityname = eEntity.user;
            errorid = 0;
            errordesc = "Успешное завершение процедуры";
            messagetype = eJournalMessageType.success;
        }

        /// <summary>
        /// Дополнительный конструктор для событий методов роли пользователя пользователя
        /// </summary>
        public JournalEventArgs(RoleUserChangeEventArgs e) : this()
        {
            action = e.Action;
            id = 0;
            entityname = eEntity.role_user;
            errorid = 0;
            errordesc = "Успешное завершение процедуры";
            messagetype = eJournalMessageType.success;
        }

        /// <summary>
        /// Дополнительный конструктор для событий методов правил пересчета
        /// </summary>
        public JournalEventArgs(UnitConversionRuleChangeEventArgs e) : this()
        {
            action = e.Action;
            id = e.IdUnitConversionRule; 
            entityname = eEntity.unit_conversion_rule;
            errorid = 0;
            errordesc = "Успешное завершение процедуры";
            messagetype = eJournalMessageType.success;
        }

        /// <summary>
        /// Дополнительный конструктор для событий методов назначения вещественным классам правил пересчета
        /// </summary>
        public JournalEventArgs(ClassUnitConversionRuleChangeEventArgs e) : this()
        {
            action = e.Action;
            id = e.Id_class;
            entityname = eEntity.class_unit_conversion_rule;
            errorid = 0;
            errordesc = "Успешное завершение процедуры";
            messagetype = eJournalMessageType.success;
        }

        /// <summary>
        /// Дополнительный конструктор для событий методов позиций
        /// </summary>
        public JournalEventArgs(PositionChangeEventArgs e) : this()
        {
            action = e.Action;
            if (e.Position != null)
            {
                id = e.Position.Id;
            }
            entityname = eEntity.position;
            errorid = 0;
            errordesc = "Успешное завершение процедуры";
            messagetype = eJournalMessageType.success;
        }

        /// <summary>
        /// Дополнительный конструктор для событий методов шаблонов позиций
        /// </summary>
        public JournalEventArgs(PosTempNestedListChangeEventArgs e) : this()
        {
            switch (e.Action)
            {
                case eActionPosTempNestedList.addrule:
                case eActionPosTempNestedList.on:
                    action = eAction.Insert;
                    break;
                case eActionPosTempNestedList.delrule: 
                case eActionPosTempNestedList.delallrule:
                case eActionPosTempNestedList.off:
                    action = eAction.Delete;
                    break;
                default:
                    action = eAction.Update;
                    break;
            }
            id = e.PosTemp.Id;
            entityname = eEntity.pos_temp_nested_rule;
            errorid = 0;
            errordesc = "Успешное завершение процедуры";
            messagetype = eJournalMessageType.success;
        }

        /// <summary>
        /// Дополнительный конструктор для событий методов белых листов позиций
        /// </summary>
        public JournalEventArgs(Rulel2_Class_On_PositionListChangeEventArgs e) : this()
        {
            switch (e.Action)
            {
                case eActionRuleList.addrule:
                case eActionRuleList.on:
                    action = eAction.Insert;
                    break;
                case eActionRuleList.delrule:
                case eActionRuleList.delallrule:
                case eActionRuleList.off:
                    action = eAction.Delete;
                    break;
                default:
                    action = eAction.Update;
                    break;
            }
            id = e.Id_position;
            entityname = eEntity.rulel2_class_on_position;
            errorid = 0;
            errordesc = "Успешное завершение процедуры";
            messagetype = eJournalMessageType.success;
        }

        /// <summary>
        /// Дополнительный конструктор для событий методов списка правил назначения типов данных концепции
        /// </summary>
        public JournalEventArgs(Con_Prop_Data_TypeListChangeEventArgs e) : this()
        {
            switch (e.Action)
            {
                case eActionRuleList.addrule:
                case eActionRuleList.on:
                    action = eAction.Insert;
                    break;
                case eActionRuleList.delrule:
                case eActionRuleList.delallrule:
                case eActionRuleList.off:
                    action = eAction.Delete;
                    break;
                case eActionRuleList.updaterule:
                    action = eAction.Update;
                    break;
                default:
                    action = eAction.Update;
                    break;
            }
            id = e.Id_Prop_Data_Type;
            entityname = eEntity.con_prop_data_type;
            errorid = 0;
            errordesc = "Успешное завершение процедуры";
            messagetype = eJournalMessageType.success;
        }

        /// <summary>
        /// Дополнительный конструктор для событий методов элементов списка правил назначения типов данных концепции
        /// </summary>
        public JournalEventArgs(Con_Prop_Data_TypeChangeEventArgs e) : this()
        {
            switch (e.Action)
            {
                case eActionRuleList.addrule:
                case eActionRuleList.on:
                    action = eAction.Insert;
                    break;
                case eActionRuleList.delrule:
                case eActionRuleList.delallrule:
                case eActionRuleList.off:
                    action = eAction.Delete;
                    break;
                case eActionRuleList.updaterule:
                    action = eAction.Update;
                    break;
                default:
                    action = eAction.Update;
                    break;
            }
            id = e.Id_Prop_Data_Type;
            entityname = eEntity.con_prop_data_type;
            errorid = 0;
            errordesc = "Успешное завершение процедуры";
            messagetype = eJournalMessageType.success;
        }

        /// <summary>
        /// Дополнительный конструктор для событий методов разрешений уровня 1 группа на шаблон
        /// </summary>
        public JournalEventArgs(Rulel1_Group_On_Pos_tempListChangeEventArgs e) : this()
        {
            switch (e.Action)
            {
                case eActionRuleList.addrule:
                case eActionRuleList.on:
                    action = eAction.Insert;
                    break;
                case eActionRuleList.delrule:
                case eActionRuleList.delallrule:
                case eActionRuleList.off:
                    action = eAction.Delete;
                    break;
                default:
                    action = eAction.Update;
                    break;
            }
            id = e.Id_pos_temp;
            entityname = eEntity.rulel1_group_on_pos_temp;
            errorid = 0;
            errordesc = "Успешное завершение процедуры";
            messagetype = eJournalMessageType.success;
        }

        /// <summary>
        /// Дополнительный конструктор для событий методов разрешений уровня 1 класс на шаблон
        /// </summary>
        public JournalEventArgs(Rulel1_Class_On_Pos_tempListChangeEventArgs e) : this()
        {
            switch (e.Action)
            {
                case eActionRuleList.addrule:
                case eActionRuleList.on:
                    action = eAction.Insert;
                    break;
                case eActionRuleList.delrule:
                case eActionRuleList.delallrule:
                case eActionRuleList.off:
                    action = eAction.Delete;
                    break;
                default:
                    action = eAction.Update;
                    break;
            }
            id = e.Id_pos_temp;
            entityname = eEntity.rulel1_group_on_pos_temp;
            errorid = 0;
            errordesc = "Успешное завершение процедуры";
            messagetype = eJournalMessageType.success;
        }

        /// <summary>
        /// Дополнительный конструктор для событий методов шаблонов позиций
        /// </summary>
        public JournalEventArgs(PosTempChangeEventArgs e) : this()
        {
            action = e.Action;
            if (e.PosTemp != null)
            {
                id = e.PosTemp.Id;
            }
            entityname = eEntity.position;
            errorid = 0;
            errordesc = "Успешное завершение процедуры";
            messagetype = eJournalMessageType.success;
        }

        /// <summary>
        /// Дополнительный конструктор для событий методов свойств шаблонов
        /// </summary>
        public JournalEventArgs(PosTempPropUserValChangeEventArgs e) : this()
        {
            action = e.Action;
            id = e.Id_PosTempProp;
            entityname = eEntity.pos_temp_prop_user_val;
            errorid = 0;
            errordesc = "Успешное завершение процедуры";
            messagetype = eJournalMessageType.success;
        }

        /// <summary>
        /// Дополнительный конструктор для событий методов свойств позиций
        /// </summary>
        public JournalEventArgs(PositionPropUserValChangeEventArgs e) : this()
        {
            action = e.Action;
            id = e.Id_position_carrier;
            id_prop = e.Id_pos_temp_prop;
            entityname = eEntity.pos_temp_prop_user_val;
            errorid = 0;
            errordesc = "Успешное завершение процедуры";
            messagetype = eJournalMessageType.success;
        }

        /// <summary>
        /// Дополнительный конструктор для событий методов изменения данных значений свойств типа перечисление
        /// </summary>
        public JournalEventArgs(PosTempPropEnumValChangeEventArgs e) : this()
        {
            action = e.Action;
            if (e.PosTempPropEnumVal != null)
            {
                id = e.PosTempPropEnumVal.Id_pos_temp_prop;
            }
            entityname = eEntity.pos_temp_prop_enum_val;
            errorid = 0;
            errordesc = "Успешное завершение процедуры";
            messagetype = eJournalMessageType.success;
        }

        /// <summary>
        /// Дополнительный конструктор для событий методов свойств позиций
        /// </summary>
        public JournalEventArgs(PositionPropEnumValChangeEventArgs e) : this()
        {
            action = e.Action;
            id = e.Id_position_carrier;
            id_prop = e.Id_pos_temp_prop;
            entityname = eEntity.pos_temp_prop_user_val;
            errorid = 0;
            errordesc = "Успешное завершение процедуры";
            messagetype = eJournalMessageType.success;
        }

        /// <summary>
        /// Дополнительный конструктор для событий методов свойств шаблонов
        /// </summary>
        public JournalEventArgs(PosTempPropObjectValChangeEventArgs e) : this()
        {
            action = e.Action;
            if (e.PosTempPropObjectVal != null)
            {
                id = e.PosTempPropObjectVal.Id_pos_temp_prop;
            }
            entityname = eEntity.pos_temp_prop_object_val;
            errorid = 0;
            errordesc = "Успешное завершение процедуры";
            messagetype = eJournalMessageType.success;
        }

        /// <summary>
        /// Дополнительный конструктор для событий методов свойств позиций
        /// </summary>
        public JournalEventArgs(PositionPropObjectValChangeEventArgs e) : this()
        {
            action = e.Action;
            id = e.Id_position_carrier;
            id_prop = e.Id_pos_temp_prop;
            entityname = eEntity.pos_temp_prop_user_val;
            errorid = 0;
            errordesc = "Успешное завершение процедуры";
            messagetype = eJournalMessageType.success;
        }

        /// <summary>
        /// Дополнительный конструктор для событий методов изменения данных значений свойств типа ссылка
        /// </summary>
        public JournalEventArgs(PosTempPropLinkValChangeEventArgs e) : this()
        {
            action = e.Action;
            if (e.PosTempPropLinkVal != null)
            {
                id = e.PosTempPropLinkVal.Id_pos_temp_prop;
            }
            entityname = eEntity.pos_temp_prop_link_val;
            errorid = 0;
            errordesc = "Успешное завершение процедуры";
            messagetype = eJournalMessageType.success;
        }

        /// <summary>
        /// Дополнительный конструктор для событий методов свойств позиций
        /// </summary>
        public JournalEventArgs(PositionPropLinkValChangeEventArgs e) : this()
        {
            action = e.Action;
            id = e.Id_position_carrier;
            id_prop = e.Id_pos_temp_prop;
            entityname = eEntity.pos_temp_prop_user_val;
            errorid = 0;
            errordesc = "Успешное завершение процедуры";
            messagetype = eJournalMessageType.success;
        }

        /// <summary>
        /// Дополнительный конструктор для событий методов объектов
        /// </summary>
        public JournalEventArgs(ObjectChangeEventArgs e) : this()
        {
            action = e.Action;
            if (e.Object_general != null)
            {
                id = e.Object_general.Id;
            }
            entityname = eEntity.vobject;
            errorid = 0;
            errordesc = "Успешное завершение процедуры";
            messagetype = eJournalMessageType.success;
        }

        /// <summary>
        /// Дополнительный конструктор для событий методов групп
        /// </summary>
        public JournalEventArgs(GroupChangeEventArgs e) : this()
        {
            action = e.Action;
            if (e.Group != null)
            {
                id = e.Group.Id;
            }
            entityname = eEntity.group;
            errorid = 0;
            errordesc = "Успешное завершение процедуры";
            messagetype = eJournalMessageType.success;
        }

        /// <summary>
        /// Дополнительный конструктор для событий методов концепций
        /// </summary>
        public JournalEventArgs(ConceptionChangeEventArgs e) : this()
        {
            action = e.Action;
            if (e.Conception != null)
            {
                id = e.Conception.Id;
            }
            entityname = eEntity.conception;
            errorid = 0;
            errordesc = "Успешное завершение процедуры";
            messagetype = eJournalMessageType.success;
        }


        /// <summary>
        /// Дополнительный конструктор для событий методов изменения перечислений для свойств
        /// </summary>
        public JournalEventArgs(PropEnumChangeEventArgs e) : this()
        {
            action = e.Action;
            if (e.PropEnum != null)
            {
                id = e.PropEnum.Id_prop_enum;
            }
            entityname = eEntity.prop_enum;
            errorid = 0;
            errordesc = "Успешное завершение процедуры";
            messagetype = eJournalMessageType.success;
        }

        /// <summary>
        /// Дополнительный конструктор для событий методов изменения элементов перечислений для свойств
        /// </summary>
        public JournalEventArgs(PropEnumValChangeEventArgs e) : this()
        {
            action = e.Action;
            if (e.PropEnumVal != null)
            {
                id = e.PropEnumVal.Id_prop_enum_val;
            }
            entityname = eEntity.prop_enum_val;
            errorid = 0;
            errordesc = "Успешное завершение процедуры";
            messagetype = eJournalMessageType.success;
        }

        /// <summary>
        /// Дополнительный конструктор для событий методов изменения данных значений свойств типа перечисление
        /// </summary>
        public JournalEventArgs(ClassPropEnumValChangeEventArgs e) : this()
        {
            action = e.Action;
            if (e.ClassPropEnumVal != null)
            {
                id = e.ClassPropEnumVal.Id_class_prop;
            }
            entityname = eEntity.class_prop_enum_val;
            errorid = 0;
            errordesc = "Успешное завершение процедуры";
            messagetype = eJournalMessageType.success;
        }

        /// <summary>
        /// Дополнительный конструктор для событий методов изменения данных значений свойств типа перечисление
        /// </summary>
        public JournalEventArgs(ObjectPropEnumValChangeEventArgs e) : this()
        {
            action = e.Action;
            if (e.ObjectPropEnumVal != null)
            {
                id = e.ObjectPropEnumVal.Id_object;
                id_prop = e.ObjectPropEnumVal.Id_class_prop;
            }
            entityname = eEntity.object_prop_enum_val;
            errorid = 0;
            errordesc = "Успешное завершение процедуры";
            messagetype = eJournalMessageType.success;
        }

        /// <summary>
        /// Дополнительный конструктор для событий методов изменения данных значений свойств типа ссылка
        /// </summary>
        public JournalEventArgs(ClassPropLinkValChangeEventArgs e) : this()
        {
            action = e.Action;
            if (e.ClassPropLinkVal != null)
            {
                id = e.ClassPropLinkVal.Id_class_prop;
            }
            entityname = eEntity.class_prop_link_val;
            errorid = 0;
            errordesc = "Успешное завершение процедуры";
            messagetype = eJournalMessageType.success;
        }

        /// <summary>
        /// Дополнительный конструктор для событий методов изменения данных значений свойств типа ссылка
        /// </summary>
        public JournalEventArgs(ObjectPropLinkValChangeEventArgs e) : this()
        {
            action = e.Action;
            if (e.ObjectPropLinkVal!=null)
            {
                id = e.ObjectPropLinkVal.Id_object;
                id_prop = e.ObjectPropLinkVal.Id_class_prop;
            }
            entityname = eEntity.object_prop_link_val;
            errorid = 0;
            errordesc = "Успешное завершение процедуры";
            messagetype = eJournalMessageType.success;
        }

        /// <summary>
        /// Дополнительный конструктор для событий методов изменения глобальных свойств
        /// </summary>
        public JournalEventArgs(GlobalPropChangeEventArgs e) : this()
        {
            action = e.Action;
            if (e.GlobalProp != null)
            {
                id = e.GlobalProp.Id;
            }
            entityname = eEntity.global_prop;
            errorid = 0;
            errordesc = "Успешное завершение процедуры";
            messagetype = eJournalMessageType.success;
        }

        /// <summary>
        /// Дополнительный конструктор для событий методов изменения данных области значений глобальных свойств
        /// </summary>
        public JournalEventArgs(GlobalPropAreaValChangeEventArgs e) : this()
        {
            action = e.Action;
            if (e.GlobalPropAreaVal != null)
            {
                id = e.GlobalPropAreaVal.Id_global_prop;
            }
            entityname = eEntity.global_prop_area_val;
            errorid = 0;
            errordesc = "Успешное завершение процедуры";
            messagetype = eJournalMessageType.success;
        }

        /// <summary>
        /// Дополнительный конструктор для событий методов изменения ссылок на определяющие свойства классов для глобальных свойств
        /// </summary>
        public JournalEventArgs(GlobalPropLinkClassPropChangeEventArgs e) : this()
        {
            action = e.Action;
            if (e.GlobalPropLinkClassProp != null)
            {
                id = e.GlobalPropLinkClassProp.Id_global_prop;
                id_prop = e.GlobalPropLinkClassProp.Id_class_prop_definition;
            }
            entityname = eEntity.global_prop_link_class_prop;
            errorid = 0;
            errordesc = "Успешное завершение процедуры";
            messagetype = eJournalMessageType.success;
        }

        /// <summary>
        /// Дополнительный конструктор для событий методов изменения ссылок на свойства шаблонов позиций для глобальных свойств
        /// </summary>
        public JournalEventArgs(GlobalPropLinkPosTempPropChangeEventArgs e) : this()
        {
            action = e.Action;
            if (e.GlobalPropLinkPosTempProp != null)
            {
                id = e.GlobalPropLinkPosTempProp.Id_global_prop;
                id_prop = e.GlobalPropLinkPosTempProp.Id_pos_temp_prop;
            }
            entityname = eEntity.global_prop_link_pos_temp_prop;
            errorid = 0;
            errordesc = "Успешное завершение процедуры";
            messagetype = eJournalMessageType.success;
        }

        /// <summary>
        /// Дополнительный конструктор для событий методов изменения ссылок на свойства шаблонов позиций для глобальных свойств
        /// </summary>
        public JournalEventArgs(ExportCompletedEventArgs e) : this()
        {
            action = eAction.Execute;
            entityname = eEntity.procedure_export;
            errorid = 0;
            errordesc = "Успешное завершение процедуры";
            messagetype = eJournalMessageType.success;
        }

        /// <summary>
        /// Дополнительный конструктор для событий методов категории документов
        /// </summary>
        public JournalEventArgs(DocCategoryChangeEventArgs e) : this()
        {
            action = e.Action;
            if (e.DocCategory != null)
            {
                id = e.DocCategory.Id;
            }
            entityname = eEntity.doc_category;
            errorid = 0;
            errordesc = "Успешное завершение процедуры";
            messagetype = eJournalMessageType.success;
        }

        /// <summary>
        /// Дополнительный конструктор для событий методов документов
        /// </summary>
        public JournalEventArgs(DocumentChangeEventArgs e) : this()
        {
            action = e.Action;
            if (e.Document != null)
            {
                id = e.Document.Id;
            }
            entityname = eEntity.document;
            errorid = 0;
            errordesc = "Успешное завершение процедуры";
            messagetype = eJournalMessageType.success;
        }

        /// <summary>
        /// Дополнительный конструктор для событий методов файлов документов
        /// </summary>
        public JournalEventArgs(DocFileChangeEventArgs e) : this()
        {
            action = e.Action;
            if (e.DocFile != null)
            {
                id = e.DocFile.Id;
            }
            entityname = eEntity.doc_file;
            errorid = 0;
            errordesc = "Успешное завершение процедуры";
            messagetype = eJournalMessageType.success;
        }

        /// <summary>
        /// Дополнительный конструктор для событий методов ссылок на документы
        /// </summary>
        public JournalEventArgs(DocLinkChangeEventArgs e) : this()
        {
            action = e.Action;
            if (e.DocLink != null)
            {
                id = e.DocLink.Id;
            }
            entityname = eEntity.doc_link;
            errorid = 0;
            errordesc = "Успешное завершение процедуры";
            messagetype = eJournalMessageType.success;
        }
        #endregion

        #region СВОЙСТВА КЛАССА
        private Int64 id = 0;
        private Int64 id_prop = 0;
        private eAction action;
        private eEntity entityname;
        private Int32 errorid;
        private String errordesc;
        private String primaryerrordesc;
        private eJournalMessageType messagetype;

        /// <summary>
        /// Перечисление определяющее тип действия выполняемого методом доступа к БД
        /// </summary>
        public eAction Action { get => action; }

        /// <summary>
        /// Тип сообщения журнала конфигуратора
        /// </summary>
        public eJournalMessageType MessageType
        {
        get
            {
                return messagetype;
            }
        }

        /// <summary>
        /// Идентификатор сущности
        /// </summary>
        public Int64 ID { get => id; }

        /// <summary>
        /// Идентификатор сущности
        /// </summary>
        public Int64 Id_entity { get => id; }

        /// <summary>
        /// Идентификатор сущности
        /// </summary>
        public Int64 Id_prop { get => id_prop; }

        /// <summary>
        /// Наменовании сущности подвергшейся модификации
        /// </summary>
        public String EntityName
        {
            get
            {
                return manager.EntityName(entityname);
            }
        }
        /// <summary>
        /// Перечисление сущности подвергшейся модификации
        /// </summary>
        public eEntity eEntityName
        {
            get
            {
                return entityname;
            }
        }
        /// <summary>
        /// Код завершения операции
        /// </summary>
        public Int32 ErrorID { get => errorid; }

        /// <summary>
        /// Текстовое описание результата операции
        /// </summary>
        public String ErrorDesc
        {
            get
            {
                StringBuilder Result = new StringBuilder();
                Result.Append(errordesc);
                if (!String.IsNullOrEmpty(primaryerrordesc))
                {
                    Result.Append(" Исходное сообщение: ");
                    Result.Append(primaryerrordesc);
                }
                return Result.ToString();
            }
        }

        /// <summary>
        /// Текстовое описание операции
        /// </summary>
        public String ActionDesc
        {
            get
            {
                return manager.ActionDesc(action);
            }
        }
        #endregion
    }
}
