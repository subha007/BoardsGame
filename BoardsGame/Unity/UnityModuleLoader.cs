using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition.Primitives;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BoardsGame
{
    public static class UnityModuleLoader
    {
        /// <summary>
        /// Holds an instance of Unity container (may not be thread safe)
        /// </summary>
        private static IUnityContainer unityContainer;

        /// <summary>
        /// Get an instance of the default requested type from the container
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T Resolve<T>()
        {
            return unityContainer.Resolve<T>();
        }

        /// <summary>
        /// The method to load all the register types used in this Solution
        /// The method loads only those assemblies that are in the <see cref="path"/> location and
        /// the assembly name matches the file name <see cref="pattern"/>
        /// </summary>
        /// <param name="container"></param>
        /// <param name="path">The path of the assemblies to look for</param>
        /// <param name="searchpattern">The Assembly file name pattern</param>
        public static void LoadContainer(IUnityContainer container, string path,
                                        string searchpattern)
        {
            // Save the Unity Container reference
            unityContainer = container;

            // Used to parse the content of the path (directory) for the (pattern) files
            var dirCat = new DirectoryCatalog(path, searchpattern);

            // Imports the type definition IModule from all the assemblies found in the DirectoryCatalog
            // object
            var importDef = BuildImportDefinition();
            try
            {
                // A catalog that combines the elements of ComposablePartCatalog objects.
                // Mandatory to dispose this object
                using (var aggregateCatalog = new AggregateCatalog())
                {
                    aggregateCatalog.Catalogs.Add(dirCat);

                    // A CompositionContainer object serves two major purposes in an application. First, 
                    // it keeps track of which parts are available for composition and what their dependencies
                    // are, and performs composition whenever the set of available parts changes. Second, it 
                    // provides the methods by which the application gets instances of composed parts or fills 
                    // the dependencies of a composable part.
                    using (var componsitionContainer = new CompositionContainer(aggregateCatalog))
                    {
                        IEnumerable<Export> exports = componsitionContainer.GetExports(importDef);
                        IEnumerable<IModule> modules =
                            exports.Select(export => export.Value as IModule).Where(m => m != null);
                        var registrar = new ModuleRegistrar(container);

                        // For each Module object initialize the Unity calls
                        foreach (IModule module in modules)
                        {
                            module.Initialize(registrar);
                        }
                    }
                }
            }
            catch (ReflectionTypeLoadException typeLoadException)
            {
                var builder = new StringBuilder();
                foreach (Exception loaderException in typeLoadException.LoaderExceptions)
                {
                    builder.AppendFormat("{0}\n", loaderException.Message);
                }
                throw new TypeLoadException(builder.ToString(), typeLoadException);
            }
        }

        /// <summary>
        /// Imports the type definition IModule from all the assemblies found in the DirectoryCatalog
        /// object. The type used for loading modules in <see cref="IModule"/>
        /// </summary>
        /// <returns></returns>
        private static ImportDefinition BuildImportDefinition()
        {
            return new ImportDefinition(
            def => true, typeof(IModule).FullName, ImportCardinality.ZeroOrMore, false, false);
        }
    }
}
