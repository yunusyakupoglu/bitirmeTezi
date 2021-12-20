using AutoMapper;
using BL.Mappings.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Helpers
{
    public static class ProfileHelper
    {
        public static List<Profile> GetProfiles()
        {
            return new List<Profile>
            {
                new MapProfile()
            };
        }
    }
}
