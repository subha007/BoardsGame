using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardsGame
{
    /// <summary>
    /// A wrapper around IUnityContainer for registration. Allows objects 
    /// implementing IModule to register types in unity.
    /// </summary>
    public interface IModuleRegistrar
    {
        void RegisterType<TFrom, TTo>() where TTo : TFrom;
    }
}
