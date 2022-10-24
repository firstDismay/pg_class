using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pg_class
{
    public partial class manager
    {
        /// <summary>
        /// Метод очищает лист подписок на события менеджера данных
        /// </summary>
        private void InvocationListClear()
        {
            //Обнуление подписок на события 
            if (ConceptionChange != null)
            {
                foreach (ConceptionChangeEventHandler d in ConceptionChange.GetInvocationList())
                {
                    ConceptionChange -= d;
                }
            }

            if (GroupChange != null)
            {
                foreach (GroupChangeEventHandler d in GroupChange.GetInvocationList())
                {
                    GroupChange -= d;
                }
            }

            if (ClassChange != null)
            {
                foreach (ClassChangeEventHandler d in ClassChange.GetInvocationList())
                {
                    ClassChange -= d;
                }
            }

            if (GlobalPropChange != null)
            {
                foreach (GlobalPropChangeEventHandler d in GlobalPropChange.GetInvocationList())
                {
                    GlobalPropChange -= d;
                }
            }

            if (GlobalPropLinkClassPropChange != null)
            {
                foreach (GlobalPropLinkClassPropChangeEventHandler d in GlobalPropLinkClassPropChange.GetInvocationList())
                {
                    GlobalPropLinkClassPropChange -= d;
                }
            }

            if (GlobalPropLinkPosTempPropChange != null)
            {
                foreach (GlobalPropLinkClassPropChangeEventHandler d in GlobalPropLinkClassPropChange.GetInvocationList())
                {
                    GlobalPropLinkClassPropChange -= d;
                }
            }

            if (ClassPropChange != null)
            {
                foreach (ClassPropChangeEventHandler d in ClassPropChange.GetInvocationList())
                {
                    ClassPropChange -= d;
                }
            }

            if (ClassPropObjectValChange != null)
            {
                foreach (ClassPropObjectValChangeEventHandler d in ClassPropObjectValChange.GetInvocationList())
                {
                    ClassPropObjectValChange -= d;
                }
            }

            if (ClassPropUserValChange != null)
            {
                foreach (ClassPropUserValChangeEventHandler d in ClassPropUserValChange.GetInvocationList())
                {
                    ClassPropUserValChange -= d;
                }
            }

            if (ClassPropEnumValChange != null)
            {
                foreach (ClassPropEnumValChangeEventHandler d in ClassPropEnumValChange.GetInvocationList())
                {
                    ClassPropEnumValChange -= d;
                }
            }

            if (ClassPropObjectValChange != null)
            {
                foreach (ClassPropObjectValChangeEventHandler d in ClassPropObjectValChange.GetInvocationList())
                {
                    ClassPropObjectValChange -= d;
                }
            }

            if (ClassPropLinkValChange != null)
            {
                foreach (ClassPropLinkValChangeEventHandler d in ClassPropLinkValChange.GetInvocationList())
                {
                    ClassPropLinkValChange -= d;
                }
            }

            if (PropEnumChange != null)
            {
                foreach (PropEnumChangeEventHandler d in PropEnumChange.GetInvocationList())
                {
                    PropEnumChange -= d;
                }
            }

            if (PropEnumValChange != null)
            {
                foreach (PropEnumValChangeEventHandler d in PropEnumValChange.GetInvocationList())
                {
                    PropEnumValChange -= d;
                }
            }

            if (ObjectChange != null)
            {
                foreach (ObjectChangeEventHandler d in ObjectChange.GetInvocationList())
                {
                    ObjectChange -= d;
                }
            }

            if (ObjectPropObjectValChange != null)
            {
                foreach (ObjectPropObjectValChangeEventHandler d in ObjectPropObjectValChange.GetInvocationList())
                {
                    ObjectPropObjectValChange -= d;
                }
            }

            if (ObjectPropUserValChange != null)
            {
                foreach (ObjectPropUserValChangeEventHandler d in ObjectPropUserValChange.GetInvocationList())
                {
                    ObjectPropUserValChange -= d;
                }
            }

            if (ObjectPropEnumValChange != null)
            {
                foreach (ObjectPropEnumValChangeEventHandler d in ObjectPropEnumValChange.GetInvocationList())
                {
                    ObjectPropEnumValChange -= d;
                }
            }

            if (ObjectPropObjectValChange != null)
            {
                foreach (ObjectPropObjectValChangeEventHandler d in ObjectPropObjectValChange.GetInvocationList())
                {
                    ObjectPropObjectValChange -= d;
                }
            }

            if (ObjectPropLinkValChange != null)
            {
                foreach (ObjectPropLinkValChangeEventHandler d in ObjectPropLinkValChange.GetInvocationList())
                {
                    ObjectPropLinkValChange -= d;
                }
            }

            if (Rulel1_Group_On_Pos_tempListChange != null)
            {
                foreach (Rulel1_Group_On_Pos_tempListChangeEventHandler d in Rulel1_Group_On_Pos_tempListChange.GetInvocationList())
                {
                    Rulel1_Group_On_Pos_tempListChange -= d;
                }
            }

            if (Rulel2_Class_On_PositionListChange != null)
            {
                foreach (Rulel2_Class_On_PositionListChangeEventHandler d in Rulel2_Class_On_PositionListChange.GetInvocationList())
                {
                    Rulel2_Class_On_PositionListChange -= d;
                }
            }

            if (Con_Prop_Data_TypeListChange != null)
            {
                foreach (Con_Prop_Data_TypeListChangeEventHandler d in Con_Prop_Data_TypeListChange.GetInvocationList())
                {
                    Con_Prop_Data_TypeListChange -= d;
                }
            }
            
            if (PosTempChange != null)
            {
                foreach (PosTempChangeEventHandler d in PosTempChange.GetInvocationList())
                {
                    PosTempChange -= d;
                }
            }
            
            if (PosTempNestedListChange != null)
            {
                foreach (PosTempNestedListChangeEventHandler d in PosTempNestedListChange.GetInvocationList())
                {
                    PosTempNestedListChange -= d;
                }
            }

            if (PosTempPropChange != null)
            {
                foreach (PosTempPropChangeEventHandler d in PosTempPropChange.GetInvocationList())
                {
                    PosTempPropChange -= d;
                }
            }

            if (PosTempPropUserValChange != null)
            {
                foreach (PosTempPropUserValChangeEventHandler d in PosTempPropUserValChange.GetInvocationList())
                {
                    PosTempPropUserValChange -= d;
                }
            }

            if (PosTempPropEnumValChange != null)
            {
                foreach (PosTempPropEnumValChangeEventHandler d in PosTempPropEnumValChange.GetInvocationList())
                {
                    PosTempPropEnumValChange -= d;
                }
            }

            if (PosTempPropObjectValChange != null)
            {
                foreach (PosTempPropObjectValChangeEventHandler d in PosTempPropObjectValChange.GetInvocationList())
                {
                    PosTempPropObjectValChange -= d;
                }
            }

            if (PosTempPropLinkValChange != null)
            {
                foreach (PosTempPropLinkValChangeEventHandler d in PosTempPropLinkValChange.GetInvocationList())
                {
                    PosTempPropLinkValChange -= d;
                }
            }

            if (PositionChange != null)
            {
                foreach (PositionChangeEventHandler d in PositionChange.GetInvocationList())
                {
                    PositionChange -= d;
                }
            }

            if (PositionPropUserValChange != null)
            {
                foreach (PositionPropUserValChangeEventHandler d in PositionPropUserValChange.GetInvocationList())
                {
                    PositionPropUserValChange -= d;
                }
            }

            if (PositionPropEnumValChange != null)
            {
                foreach (PositionPropEnumValChangeEventHandler d in PositionPropEnumValChange.GetInvocationList())
                {
                    PositionPropEnumValChange -= d;
                }
            }

            if (PositionPropObjectValChange != null)
            {
                foreach (PositionPropObjectValChangeEventHandler d in PositionPropObjectValChange.GetInvocationList())
                {
                    PositionPropObjectValChange -= d;
                }
            }

            if (PositionPropLinkValChange != null)
            {
                foreach (PositionPropLinkValChangeEventHandler d in PositionPropLinkValChange.GetInvocationList())
                {
                    PositionPropLinkValChange -= d;
                }
            }

            if (PositionChangeLock != null)
            {
                foreach (PositionChangeEventHandler d in PositionChangeLock.GetInvocationList())
                {
                    PositionChangeLock -= d;
                }
            }

            if (UserChange != null)
            {
                foreach (UserChangeEventHandler d in UserChange.GetInvocationList())
                {
                    UserChange -= d;
                }
            }

            if (RoleUserChange != null)
            {
                foreach (RoleUserChangeEventHandler d in RoleUserChange.GetInvocationList())
                {
                    RoleUserChange -= d;
                }
            }

            if (UnitConversionRuleChange != null)
            {
                foreach (UnitConversionRuleChangeEventHandler d in UnitConversionRuleChange.GetInvocationList())
                {
                    UnitConversionRuleChange -= d;
                }
            }

            if (UserChange != null)
            {
                foreach (UserChangeEventHandler d in UserChange.GetInvocationList())
                {
                    UserChange -= d;
                }
            }

            if (ClassUnitConversionRuleListChange != null)
            {
                foreach (ClassUnitConversionRuleChangeEventHandler d in ClassUnitConversionRuleListChange.GetInvocationList())
                {
                    ClassUnitConversionRuleListChange -= d;
                }
            }

            if (DocCategoryChange != null)
            {
                foreach (DocCategoryChangeEventHandler d in DocCategoryChange.GetInvocationList())
                {
                    DocCategoryChange -= d;
                }
            }

            if (DocumentChange != null)
            {
                foreach (DocumentChangeEventHandler d in DocumentChange.GetInvocationList())
                {
                    DocumentChange -= d;
                }
            }

            if (DocFileChange != null)
            {
                foreach (DocFileChangeEventHandler d in DocFileChange.GetInvocationList())
                {
                    DocFileChange -= d;
                }
            }

            if (DocLinkChange != null)
            {
                foreach (DocLinkChangeEventHandler d in DocLinkChange.GetInvocationList())
                {
                    DocLinkChange -= d;
                }
            }

			if (LogCategoryChange != null)
			{
				foreach (LogCategoryChangeEventHandler d in LogCategoryChange.GetInvocationList())
				{
					LogCategoryChange -= d;
				}
			}

			if (LogChange != null)
			{
				foreach (LogChangeEventHandler d in LogChange.GetInvocationList())
				{
					LogChange -= d;
				}
			}

			if (LogLinkChange != null)
			{
				foreach (LogLinkChangeEventHandler d in LogLinkChange.GetInvocationList())
				{
					LogLinkChange -= d;
				}
			}

			if (ClassPropSort != null)
            {
                foreach (ClassPropSortEventHandler d in ClassPropSort.GetInvocationList())
                {
                    ClassPropSort -= d;
                }
            }

            if (PosTempPropSort != null)
            {
                foreach (PosTempPropSortEventHandler d in PosTempPropSort.GetInvocationList())
                {
                    PosTempPropSort -= d;
                }
            }

            if (PositionSort != null)
            {
                foreach (PositionSortEventHandler d in PositionSort.GetInvocationList())
                {
                    PositionSort -= d;
                }
            }

            //Завершение сесии ведения журнала
            //Вызов события журнала
            JournalEventArgs me = new JournalEventArgs(0, eEntity.manager, 0, "Сессия журнала закрыта", eAction.DisConnect, eJournalMessageType.information);
            JournalMessageOnReceived(me);
        }
    }
}
