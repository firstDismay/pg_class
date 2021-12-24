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

            //***************************************************************************
            if (ConceptionChange != null)
            {
                foreach (ConceptionChangeEventHandler d in ConceptionChange.GetInvocationList())
                {
                    ConceptionChange -= d;
                }
            }
            //***************************************************************************
            if (GroupChange != null)
            {
                foreach (GroupChangeEventHandler d in GroupChange.GetInvocationList())
                {
                    GroupChange -= d;
                }
            }
            //ClassChange
            if (ClassChange != null)
            {
                foreach (ClassChangeEventHandler d in ClassChange.GetInvocationList())
                {
                    ClassChange -= d;
                }
            }

            //GlobalPropChange
            if (GlobalPropChange != null)
            {
                foreach (GlobalPropChangeEventHandler d in GlobalPropChange.GetInvocationList())
                {
                    GlobalPropChange -= d;
                }
            }

            //GlobalPropLinkClassPropChange
            if (GlobalPropLinkClassPropChange != null)
            {
                foreach (GlobalPropLinkClassPropChangeEventHandler d in GlobalPropLinkClassPropChange.GetInvocationList())
                {
                    GlobalPropLinkClassPropChange -= d;
                }
            }

            //GlobalPropLinkClassPropChange
            if (GlobalPropLinkPosTempPropChange != null)
            {
                foreach (GlobalPropLinkClassPropChangeEventHandler d in GlobalPropLinkClassPropChange.GetInvocationList())
                {
                    GlobalPropLinkClassPropChange -= d;
                }
            }

            //ClassPropChange
            if (ClassPropChange != null)
            {
                foreach (ClassPropChangeEventHandler d in ClassPropChange.GetInvocationList())
                {
                    ClassPropChange -= d;
                }
            }

            //ClassPropObjectValChange
            if (ClassPropObjectValChange != null)
            {
                foreach (ClassPropObjectValChangeEventHandler d in ClassPropObjectValChange.GetInvocationList())
                {
                    ClassPropObjectValChange -= d;
                }
            }

            //ClassPropUserValChange
            if (ClassPropUserValChange != null)
            {
                foreach (ClassPropUserValChangeEventHandler d in ClassPropUserValChange.GetInvocationList())
                {
                    ClassPropUserValChange -= d;
                }
            }

            //ClassPropEnumValChange
            if (ClassPropEnumValChange != null)
            {
                foreach (ClassPropEnumValChangeEventHandler d in ClassPropEnumValChange.GetInvocationList())
                {
                    ClassPropEnumValChange -= d;
                }
            }

            //ClassPropObjectValChange
            if (ClassPropObjectValChange != null)
            {
                foreach (ClassPropObjectValChangeEventHandler d in ClassPropObjectValChange.GetInvocationList())
                {
                    ClassPropObjectValChange -= d;
                }
            }

            //ClassPropLinkValChange
            if (ClassPropLinkValChange != null)
            {
                foreach (ClassPropLinkValChangeEventHandler d in ClassPropLinkValChange.GetInvocationList())
                {
                    ClassPropLinkValChange -= d;
                }
            }

            //PropEnumChange
            if (PropEnumChange != null)
            {
                foreach (PropEnumChangeEventHandler d in PropEnumChange.GetInvocationList())
                {
                    PropEnumChange -= d;
                }
            }

            //PropEnumValChange
            if (PropEnumValChange != null)
            {
                foreach (PropEnumValChangeEventHandler d in PropEnumValChange.GetInvocationList())
                {
                    PropEnumValChange -= d;
                }
            }

            //ObjectChange
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

            //ObjectPropUserValChange
            if (ObjectPropUserValChange != null)
            {
                foreach (ObjectPropUserValChangeEventHandler d in ObjectPropUserValChange.GetInvocationList())
                {
                    ObjectPropUserValChange -= d;
                }
            }

            //ObjectPropEnumValChange
            if (ObjectPropEnumValChange != null)
            {
                foreach (ObjectPropEnumValChangeEventHandler d in ObjectPropEnumValChange.GetInvocationList())
                {
                    ObjectPropEnumValChange -= d;
                }
            }

            //ObjectPropObjectValChange
            if (ObjectPropObjectValChange != null)
            {
                foreach (ObjectPropObjectValChangeEventHandler d in ObjectPropObjectValChange.GetInvocationList())
                {
                    ObjectPropObjectValChange -= d;
                }
            }

            //ObjectPropLinkValChange
            if (ObjectPropLinkValChange != null)
            {
                foreach (ObjectPropLinkValChangeEventHandler d in ObjectPropLinkValChange.GetInvocationList())
                {
                    ObjectPropLinkValChange -= d;
                }
            }

            //ObjectPosNestedListListChange
            if (Rulel1_Group_On_Pos_tempListChange != null)
            {
                foreach (Rulel1_Group_On_Pos_tempListChangeEventHandler d in Rulel1_Group_On_Pos_tempListChange.GetInvocationList())
                {
                    Rulel1_Group_On_Pos_tempListChange -= d;
                }
            }
            //ObjectPosWhiteListChange
            if (Rulel2_Class_On_PositionListChange != null)
            {
                foreach (Rulel2_Class_On_PositionListChangeEventHandler d in Rulel2_Class_On_PositionListChange.GetInvocationList())
                {
                    Rulel2_Class_On_PositionListChange -= d;
                }
            }

            //Con_Prop_Data_TypeListChange
            if (Con_Prop_Data_TypeListChange != null)
            {
                foreach (Con_Prop_Data_TypeListChangeEventHandler d in Con_Prop_Data_TypeListChange.GetInvocationList())
                {
                    Con_Prop_Data_TypeListChange -= d;
                }
            }
            
            //PosTempChange
            if (PosTempChange != null)
            {
                foreach (PosTempChangeEventHandler d in PosTempChange.GetInvocationList())
                {
                    PosTempChange -= d;
                }
            }
            
            //PosTempNestedListChange
            if (PosTempNestedListChange != null)
            {
                foreach (PosTempNestedListChangeEventHandler d in PosTempNestedListChange.GetInvocationList())
                {
                    PosTempNestedListChange -= d;
                }
            }
            //PosTempPropChange
            if (PosTempPropChange != null)
            {
                foreach (PosTempPropChangeEventHandler d in PosTempPropChange.GetInvocationList())
                {
                    PosTempPropChange -= d;
                }
            }

            //PosTempPropUserValChange
            if (PosTempPropUserValChange != null)
            {
                foreach (PosTempPropUserValChangeEventHandler d in PosTempPropUserValChange.GetInvocationList())
                {
                    PosTempPropUserValChange -= d;
                }
            }

            //PosTempPropEnumValChange
            if (PosTempPropEnumValChange != null)
            {
                foreach (PosTempPropEnumValChangeEventHandler d in PosTempPropEnumValChange.GetInvocationList())
                {
                    PosTempPropEnumValChange -= d;
                }
            }

            //PosTempPropObjectValChange
            if (PosTempPropObjectValChange != null)
            {
                foreach (PosTempPropObjectValChangeEventHandler d in PosTempPropObjectValChange.GetInvocationList())
                {
                    PosTempPropObjectValChange -= d;
                }
            }

            //PosTempPropLinkValChange
            if (PosTempPropLinkValChange != null)
            {
                foreach (PosTempPropLinkValChangeEventHandler d in PosTempPropLinkValChange.GetInvocationList())
                {
                    PosTempPropLinkValChange -= d;
                }
            }

            //PositionChange
            if (PositionChange != null)
            {
                foreach (PositionChangeEventHandler d in PositionChange.GetInvocationList())
                {
                    PositionChange -= d;
                }
            }

            //PositionPropUserValChange
            if (PositionPropUserValChange != null)
            {
                foreach (PositionPropUserValChangeEventHandler d in PositionPropUserValChange.GetInvocationList())
                {
                    PositionPropUserValChange -= d;
                }
            }

            //PositionPropEnumValChange
            if (PositionPropEnumValChange != null)
            {
                foreach (PositionPropEnumValChangeEventHandler d in PositionPropEnumValChange.GetInvocationList())
                {
                    PositionPropEnumValChange -= d;
                }
            }

            //PositionPropObjectValChange
            if (PositionPropObjectValChange != null)
            {
                foreach (PositionPropObjectValChangeEventHandler d in PositionPropObjectValChange.GetInvocationList())
                {
                    PositionPropObjectValChange -= d;
                }
            }

            //PositionPropLinkValChange
            if (PositionPropLinkValChange != null)
            {
                foreach (PositionPropLinkValChangeEventHandler d in PositionPropLinkValChange.GetInvocationList())
                {
                    PositionPropLinkValChange -= d;
                }
            }

            //PositionChangeLock
            if (PositionChangeLock != null)
            {
                foreach (PositionChangeEventHandler d in PositionChangeLock.GetInvocationList())
                {
                    PositionChangeLock -= d;
                }
            }
            //UserChange
            if (UserChange != null)
            {
                foreach (UserChangeEventHandler d in UserChange.GetInvocationList())
                {
                    UserChange -= d;
                }
            }

            //RoleUserChange
            if (RoleUserChange != null)
            {
                foreach (RoleUserChangeEventHandler d in RoleUserChange.GetInvocationList())
                {
                    RoleUserChange -= d;
                }
            }

            //UnitConversionRuleChange;
            if (UnitConversionRuleChange != null)
            {
                foreach (UnitConversionRuleChangeEventHandler d in UnitConversionRuleChange.GetInvocationList())
                {
                    UnitConversionRuleChange -= d;
                }
            }
            //UserChangeEventHandler UserChange;
            if (UserChange != null)
            {
                foreach (UserChangeEventHandler d in UserChange.GetInvocationList())
                {
                    UserChange -= d;
                }
            }

            //ClassUnitConversionRuleListChange
            if (ClassUnitConversionRuleListChange != null)
            {
                foreach (ClassUnitConversionRuleChangeEventHandler d in ClassUnitConversionRuleListChange.GetInvocationList())
                {
                    ClassUnitConversionRuleListChange -= d;
                }
            }

            //DocCategoryChange
            if (DocCategoryChange != null)
            {
                foreach (DocCategoryChangeEventHandler d in DocCategoryChange.GetInvocationList())
                {
                    DocCategoryChange -= d;
                }
            }

            //DocumentChange
            if (DocumentChange != null)
            {
                foreach (DocumentChangeEventHandler d in DocumentChange.GetInvocationList())
                {
                    DocumentChange -= d;
                }
            }

            //DocFileChange
            if (DocFileChange != null)
            {
                foreach (DocFileChangeEventHandler d in DocFileChange.GetInvocationList())
                {
                    DocFileChange -= d;
                }
            }

            //DocLinkChange
            if (DocLinkChange != null)
            {
                foreach (DocLinkChangeEventHandler d in DocLinkChange.GetInvocationList())
                {
                    DocLinkChange -= d;
                }
            }

            //ClassPropSort
            if (ClassPropSort != null)
            {
                foreach (ClassPropSortEventHandler d in ClassPropSort.GetInvocationList())
                {
                    ClassPropSort -= d;
                }
            }

            //PosTempPropSort
            if (PosTempPropSort != null)
            {
                foreach (PosTempPropSortEventHandler d in PosTempPropSort.GetInvocationList())
                {
                    PosTempPropSort -= d;
                }
            }

            //PositionSort
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
