using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardsGame
{
    public class UnityConsoleFactory
    {
        /// <summary>
        /// Initializes the Unity Container
        /// </summary>
        /// <param name="container"></param>
        protected void ConfigureContainer(IUnityContainer container)
        {
            UnityModuleLoader.LoadContainer(container,
                                AppConstants.RelativeBinPath,
                                AppConstants.CurrentAssmebliesPattern);
        }
    }
}
