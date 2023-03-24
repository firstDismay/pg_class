using System;
using System.Collections.Generic;

namespace pg_class
{
    partial class manager
    {
        #region Обработка ошибок методов БД

        /// <summary>
        /// Функция определяющая базовый код ошибки сущности
        /// </summary>
        public static eEntity_ErrID Entity_To_ErrID(eEntity Entity)
        {
            eEntity_ErrID Result = eEntity_ErrID.entity;
            eEntity_ErrID TValue;
            if (Dictionary_Entity_To_ErrID.TryGetValue(Entity, out TValue))
                Result = TValue;
            return Result;
        }
        private static readonly Dictionary<eEntity, eEntity_ErrID> Dictionary_Entity_To_ErrID = new Dictionary<eEntity, eEntity_ErrID>()
        {
            { eEntity.entity, eEntity_ErrID.entity },
            { eEntity.pos_prototype, eEntity_ErrID.pos_prototype },
            { eEntity.conception, eEntity_ErrID.conception },
            { eEntity.pos_temp, eEntity_ErrID.pos_temp },
            { eEntity.position, eEntity_ErrID.position },
            { eEntity.vector, eEntity_ErrID.vector },
            { eEntity.link_obj_pos, eEntity_ErrID.link_obj_pos },
            { eEntity.role_base, eEntity_ErrID.role_base },
            { eEntity.user, eEntity_ErrID.user },
            { eEntity.position_prop, eEntity_ErrID.position_prop },
            { eEntity.pos_temp_prop, eEntity_ErrID.pos_temp_prop },
            { eEntity.pos_temp_enum_prop, eEntity_ErrID.pos_temp_enum_prop },
            { eEntity.ticket, eEntity_ErrID.ticket },
            { eEntity.message, eEntity_ErrID.message },
            { eEntity.ticket_prop, eEntity_ErrID.ticket_prop },
            { eEntity.mes_prop, eEntity_ErrID.mes_prop },
            { eEntity.property, eEntity_ErrID.property },
            { eEntity.group, eEntity_ErrID.group },
            { eEntity.vclass, eEntity_ErrID.vclass },
            { eEntity.class_prop, eEntity_ErrID.class_prop},
            { eEntity.vobject, eEntity_ErrID.vobject },
            { eEntity.rulel1_group_on_pos_temp, eEntity_ErrID.rulel1_group_on_pos_temp },
            { eEntity.rulel2_class_on_position, eEntity_ErrID.rulel2_class_on_position },
            { eEntity.pos_temp_nested_rule, eEntity_ErrID.pos_temp_nested_rule },
            { eEntity.unit, eEntity_ErrID.unit },
            { eEntity.unit_conversion_rule, eEntity_ErrID.unit_conversion_rule },
            { eEntity.class_unit_conversion_rule, eEntity_ErrID.class_unit_conversion_rule },
            { eEntity.class_prop_object_val, eEntity_ErrID.class_prop_object_val },
            { eEntity.object_prop_object_val, eEntity_ErrID.object_prop_object_val },
            { eEntity.rulel1_group_on_pos_temp_access, eEntity_ErrID.rulel1_group_on_pos_temp_access },
            { eEntity.rulel2_class_snapshot_on_position, eEntity_ErrID.rulel2_class_snapshot_on_position },
            { eEntity.prop_data_type, eEntity_ErrID.prop_data_type },
            { eEntity.con_prop_data_type, eEntity_ErrID.con_prop_data_type },
            { eEntity.prop_type, eEntity_ErrID.prop_type },
            { eEntity.prop_data_bin_ext, eEntity_ErrID.prop_data_bin_ext },
            { eEntity.object_prop, eEntity_ErrID.object_prop },
            { eEntity.class_prop_user_val, eEntity_ErrID.class_prop_user_val },
            { eEntity.class_prop_enum_val, eEntity_ErrID.class_prop_enum_val },
            { eEntity.object_prop_user_val, eEntity_ErrID.object_prop_user_val },
            { eEntity.object_prop_enum_val, eEntity_ErrID.object_prop_enum_val },
            { eEntity.prop_val_spec, eEntity_ErrID.prop_val_spec },
            { eEntity.prop_enum, eEntity_ErrID.prop_enum },
            { eEntity.prop_enum_val, eEntity_ErrID.prop_enum_val },
            { eEntity.class_prop_link_val, eEntity_ErrID.class_prop_link_val },
            { eEntity.object_prop_link_val, eEntity_ErrID.object_prop_link_val },
            { eEntity.global_prop, eEntity_ErrID.global_prop },
            { eEntity.global_prop_link_class_prop, eEntity_ErrID.global_prop_link_class_prop },
            { eEntity.global_prop_link_pos_temp_prop, eEntity_ErrID.global_prop_link_pos_temp_prop },
            { eEntity.pos_temp_prop_user_val, eEntity_ErrID.pos_temp_prop_user_val },
            { eEntity.pos_temp_prop_enum_val, eEntity_ErrID.pos_temp_prop_enum_val },
            { eEntity.pos_temp_prop_object_val, eEntity_ErrID.pos_temp_prop_object_val },
            { eEntity.pos_temp_prop_link_val, eEntity_ErrID.pos_temp_prop_link_val },
            { eEntity.position_prop_user_val, eEntity_ErrID.position_prop_user_val },
            { eEntity.position_prop_enum_val, eEntity_ErrID.position_prop_enum_val },
            { eEntity.position_prop_object_val, eEntity_ErrID.position_prop_object_val },
            { eEntity.position_prop_link_val, eEntity_ErrID.position_prop_link_val },
            { eEntity.global_prop_area_val, eEntity_ErrID.global_prop_area_val },
            { eEntity.document, eEntity_ErrID.document },
            { eEntity.doc_file, eEntity_ErrID.doc_file },
            { eEntity.doc_link, eEntity_ErrID.doc_link },
            { eEntity.doc_category, eEntity_ErrID.doc_category },
            { eEntity.manager, eEntity_ErrID.manager },
            { eEntity.pool, eEntity_ErrID.pool },
            { eEntity.connect, eEntity_ErrID.connect },
            { eEntity.procedure_export, eEntity_ErrID.procedure_export },
            { eEntity.plan_calendar, eEntity_ErrID.plan_calendar },
            { eEntity.plan, eEntity_ErrID.plan },
            { eEntity.plan_link, eEntity_ErrID.plan_link },
            { eEntity.plan_range, eEntity_ErrID.plan_range },
            { eEntity.plan_range_link, eEntity_ErrID.plan_range_link },
            { eEntity.plan_given_range_plan, eEntity_ErrID.plan_given_range_plan },
            { eEntity.plan_given_range_plan_link, eEntity_ErrID.plan_given_range_plan_link },
            { eEntity.plan_given_range_fact, eEntity_ErrID.plan_given_range_fact },
            { eEntity.plan_given_range_fact_link, eEntity_ErrID.plan_given_range_fact_link },
            { eEntity.plan_transfer_day, eEntity_ErrID.plan_transfer_day },
            { eEntity.plan_holiday, eEntity_ErrID.plan_holiday },
            { eEntity.role_user, eEntity_ErrID.role_user },
            { eEntity.rulel1_class_on_pos_temp, eEntity_ErrID.rulel1_class_on_pos_temp },
            { eEntity.rulel1_class_on_pos_temp_access, eEntity_ErrID.rulel1_class_on_pos_temp_access },
            { eEntity.plan_rule_crossing, eEntity_ErrID.plan_rule_crossing },
            { eEntity.plan_rule_crossing_link, eEntity_ErrID.plan_rule_crossing_link },
            { eEntity.plan_rule_nesting, eEntity_ErrID.plan_rule_nesting },
            { eEntity.plan_rule_nesting_link, eEntity_ErrID.plan_rule_nesting_link },

        };


        /// <summary>
        /// Описания ошибок
        /// </summary>
        public static String SubClass_ErrDesc(eSubClass_ErrID SubClass_ErrID)
        {
            String Result = "Без описания";

            switch (SubClass_ErrID)
            {
                case eSubClass_ErrID.SCE0_Unknown_Error:
                    Result = "Неизвестная ошибка";
                    break;
                case eSubClass_ErrID.SCE1_NonExistent_Entity:
                    Result = "Несуществующая сущность";
                    break;
                case eSubClass_ErrID.SCE2_Violation_Unique:
                    Result = "Нарушение уникальности";
                    break;
                case eSubClass_ErrID.SCE3_Violation_Rules:
                    Result = "Нарушение правил или ограничений";
                    break;
                case eSubClass_ErrID.SCE4_Violation_Rules_Nesting:
                    Result = "Нарушение правил вложенности";
                    break;
                case eSubClass_ErrID.SCE5_Violation_Limitations_Nesting:
                    Result = "Нарушение ограничений вложенности";
                    break;
                case eSubClass_ErrID.SCE6_Over_Limitations_Nesting:
                    Result = "Превышение ограничения вложенности";
                    break;
                case eSubClass_ErrID.SCE7_NonExistent_Inherited_Entity:
                    Result = "Несуществующая наследуемая сущность";
                    break;
                case eSubClass_ErrID.SCE8_NonExistent_Parental_Entity:
                    Result = "Несуществующая родительская сущность";
                    break;
                case eSubClass_ErrID.SCE9_Out_Of_Range:
                    Result = "Выход за пределы допустимых значений";
                    break;
                case eSubClass_ErrID.SCE10_NonExistent_Source_Entity:
                    Result = "Несуществующая исходная сущность";
                    break;
            }
            return Result;
        }
        #endregion
    }
}
