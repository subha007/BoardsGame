using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BoardsGame
{
    public static class AppConstants
    {
        public static string ExeLocation
        {
            get
            {
                return Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            }
        }

        public static string RelativeBinPath
        {
            get
            {
                return ConfigurationManager.AppSettings["RelativeBinPath"];
            }
        }

        /// <summary>
        /// The config value of all project assemblies name (using regex)
        /// </summary>
        public static string CurrentAssmebliesPattern
        {
            get
            {
                return ConfigurationManager.AppSettings["CurrentAssmebliesPattern"];
            }
        }
    }
}
