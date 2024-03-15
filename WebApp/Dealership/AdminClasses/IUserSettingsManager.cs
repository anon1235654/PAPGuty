using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityClasses;
namespace AdminClasses
{
    public interface IUserSettingsManager
    {
        bool AddSettings(User user, UserSettings settings);
        bool UpdateSettings(User user, UserSettings settings);
        UserSettings GetSettings(User user); 
        bool CheckSettingsExistence (User user);
    }
}
