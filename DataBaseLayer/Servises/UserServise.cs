using DataBaseLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DataBaseLayer.Models.Models;

namespace DataBaseLayer.Servises
{
    public class UserServise
    {
        private readonly LevelRepository _levelRepository;
        private readonly UserRepository _userRepository;

        public UserServise()
        {
            _levelRepository = new LevelRepository();
            _userRepository = new UserRepository();
        }

        public bool UpdateImage(Level level)
        {
            if (level == null) return false;

            if(!level.IsAvailable) return false;

            var user = _userRepository.Retrieve();
            
            User firstUser = user[0];

            if (level.Name == "Level 6") 
            {
                //Console.WriteLine(user[0].IsAura + " " + user[0].Name + ' ' + user[0].Sex + " " + user[0].IsSword);
                firstUser.IsSword = true;
                firstUser.ImageId = 2;
                return _userRepository.Update(firstUser); 
            }
            else //if (level.Name =="Level 12")
            {
                firstUser.IsArmor = true;
                firstUser.ImageId = 3;
                return _userRepository.Update(firstUser);
            }

            /*if (level.Name == "Level 18")
            {
                firstUser.IsSword = true;
                firstUser.ImageId = 2;
                return _userRepository.Update(firstUser);
            } else if (level.Name == "Level 32")
            {
                firstUser.IsBoots = true;
                firstUser.ImageId = 2;
                return _userRepository.Update(firstUser);
            } else if (level.Name == "Level 35")
            {
                firstUser.IsFlashlight = true;
                firstUser.ImageId = 2;
                return _userRepository.Update(firstUser);
            } else if (level.Name == "Level 45")
            {
                firstUser.IsArmor = true;
                firstUser.ImageId = 2;
                return _userRepository.Update(firstUser);
            } else if (level.Name == "Level 59")
            {
                firstUser.IsAmulet = true;
                firstUser.ImageId = 2;
                return _userRepository.Update(firstUser);
            } else if (level.Name == "Level 70")
            {
                firstUser.IsAura = true;
                firstUser.ImageId = 2;
                return _userRepository.Update(firstUser);
            }*/

            return false;
        }
    }

    


}
