using BoardsGame.Input;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace BoardsGame
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class ArgTypeAttribute : Attribute
    {
        private string[] options;

        public string[] Options { get { return options; } }
        public string HelpStringResource { get; set; }
        public string Help
        {
            get
            {
                return GetResourceValue(this.HelpStringResource);
            }
        }
        public bool IsMandatory { get; set; }
        public string ErrorStringResource { get; set; }
        public string ErrorString
        {
            get
            {
                return GetResourceValue(this.ErrorStringResource);
            }
        }

        public bool IsValueFoundNext { get; set; }

        public ArgTypeAttribute(string[] opts)
        {
            this.options = opts;
            this.IsMandatory = false;
            this.IsValueFoundNext = true;
        }

        private string GetResourceValue(string key)
        {
            return ArgsTypeResource.ResourceManager.GetString(key, ArgsTypeResource.Culture);
        }
    }
}
