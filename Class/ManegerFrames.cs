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
        private static Role Role { get; set; }
        private static void RoleInput()
        {
            Role = PoliclinicaEntities.GetContext().Role.FirstOrDefault(s => s.ID == User.Role);
        }

        private static void RoleOutlog() { Role = null; }
        private static void LoginUser(Users users)
        {
            User = users;
            RoleInput();
            AccessLevel = Role_level();
        }
        public static bool[] AccessLevel = new bool[3]; //bufer
        public static void LogoutUser() { User = null; Role = null; }
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
        public static bool[] Role_level()
        {
            bool[] result = new bool[3];
                result[0] = false; // AdminAccess
                result[1] = false; // Operator
                result[2] = false; // Doctor
            if (Role == null) {
                return result; }
            else 
            {
                if (Role.AdminAccess == true) 
                {
                    result[0] = true;
                }
                if (Role.OperatorAccess== true)
                {
                    result[1] = true;
                }
                if (Role.DoctorAccess== true)
                {
                    result[2] = true;
                }

                return result;
            }
        }
        public static string NameUserReturn()
        {
            if (Check_Login()) 
            {
                string name = User.FName.ToString() +" " + User.LName.ToString();
                return name;
            }
            return null;
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
