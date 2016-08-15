using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardsGame
{
    /// <summary>
    /// A wrapper to register all the internal type with unity
    /// </summary>
    public class ModuleRegistrar : IModuleRegistrar
    {
        /// <summary>
        /// The main Unity Container object
        /// </summary>
        private readonly IUnityContainer _container;

        /// <summary>
        /// The Module register Unity Container constructor
        /// </summary>
        /// <param name="container"></param>
        public ModuleRegistrar(IUnityContainer container)
        {
            this._container = container; //Register interception behaviour if any
        }

        /// <summary>
        /// The method used to resgiter types
        /// </summary>
        /// <typeparam name="TFrom"></typeparam>
        /// <typeparam name="TTo"></typeparam>
        public void RegisterType<TFrom, TTo>() where TTo : TFrom
        {
            this._container.RegisterType<TFrom, TTo>();
        }
    }
}
