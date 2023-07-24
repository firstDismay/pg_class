using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pg_class
{
    public class def_converter
    {
        /// <summary>
        /// Пользовательское представление символьного обозначения метода поиска
        /// </summary>    
        public static eAction StringToAction(String Action)
        {
            eAction Result = eAction.AnyAction;
            eAction TValue;
            if (Action != null)
            {
                if (Dictionary_Action.TryGetValue(Action, out TValue))
                    Result = TValue;
            }
            return Result;
        }

        private static readonly Dictionary<String, eAction> Dictionary_Action = new Dictionary<String, eAction>()
        {
            { "anyaction",  eAction.AnyAction},
            { "select",  eAction.Select},
            { "insert",  eAction.Insert},
            { "update",  eAction.Update},
            { "delete",  eAction.Delete},
            { "move",  eAction.Move},
            { "lock",  eAction.Lock},
            { "unlock",  eAction.UnLock},
            { "copy",  eAction.Copy},
            { "connect",  eAction.Connect},
            { "reconnect",  eAction.ReConnect},
            { "disconnect",  eAction.DisConnect},
            { "execute",  eAction.Execute},
            { "init",  eAction.Init},
            { "clone",  eAction.Clone},
            { "rollback",  eAction.RollBack},
            { "clear",  eAction.Clear},
            { "cast",  eAction.Cast},
            { "insert_mass",  eAction.Insert_mass},
            { "merging",  eAction.Merging},
            { "include",  eAction.Include},
            { "exclude",  eAction.Exclude},
            { "restore",  eAction.Restore}
        };

    }
}
