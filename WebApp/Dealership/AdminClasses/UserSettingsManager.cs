using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityClasses;
using DataAccess;
namespace AdminClasses
{
    public class UserSettingsManager:IUserSettingsManager
    {
        public UserSettingsManager() { }
        public bool AddSettings(User user, UserSettings settings)
        {
            return UserSettingsDBHelper.AddSettings(user, settings);
        }
        
        public UserSettings GetSettings(User user)
        {
            return UserSettingsDBHelper.GetSettings(user);
            
        }

        public bool CheckSettingsExistence(User user)
        {
            return UserSettingsDBHelper.CheckSettingExistence(user);
        }

        public bool UpdateSettings(User user, UserSettings settings)
        {
            return UserSettingsDBHelper.UpdateSettings(user, settings);
            
        }
    }
}
