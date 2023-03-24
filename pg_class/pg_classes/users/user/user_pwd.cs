using System;

namespace pg_class.pg_classes
{ /// <summary>
  /// Класс пользователей БД учеет
  /// </summary>
    public partial class user
    {
        #region МЕТОДЫ КЛАССА

        /// <summary>
        /// Установить пароль пользователя
        /// </summary>
        public void Pwd_set(String oldpwd, String newpwd1, String newpwd2)
        {
            Manager.user_pwd_set(Login, oldpwd, newpwd1, newpwd1);
        }
        /// <summary>
        /// Сбросить пароль пользователя
        /// </summary>
        public void Pwd_reset(String newpwd1, String newpwd2)
        {
            Manager.user_pwd_reset(Login, newpwd1, newpwd1);
        }
        /// <summary>
        /// Метод определяет доступномть смены пароля для указанного пользователя
        /// </summary>
        public Boolean Pwd_can_change(user usr_change_login)
        {
            return Manager.user_pwd_can_change(this, usr_change_login);
        }
        #endregion
    }
}
