using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace CP22
{
    class ManegerFrames
    {
        public static Frame MainFrame { get; set; } // работа с фреймом
        public static Windows.MainWindows MainWindows { get; set; }//работа с окнами
        public static Windows.Autorisation Autorisation { get; set; }

        private static Users User { get; set; } // блок логина
        private static void LoginUser(Users users)
        {
            User = users;
        }
        public static void LogoutUser() { User = null; }
        public static bool Check_Login()
        {
            if (User == null)
            {
                return false;
            }
            else
            {
                //if usr non spisok
                return true;
            }
        }
        public static string NameUserReturn()
        {
            string name = User.FName + User.LName;
            return name;
        }
        public static bool LoginInSys(string login, PasswordBox password)
        {
            Users  users = PoliclinicaEntities.GetContext().Users.FirstOrDefault(s=>s.Login ==login);
            if (users == null)
            {
                return false;
            }
            if (users.Password != password.Password)
            {
                return false;
            }else
            {
                LoginUser(users);
                return true;
            }    
        }

        //блок поиска
       
    }
}
