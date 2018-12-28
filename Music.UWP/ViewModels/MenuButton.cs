using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music.UWP.ViewModels
{
    class MenuButton
    {
        public MenuButton(string label, string icon, Type navigateTo)
        {
            this.icon = icon;
            this.label = label;
            this.navigateTo = navigateTo;
        }
        
        private string icon;
        public string Icon { get { return icon; } }

        private string label;
        public string Label { get { return label; } }

        private Type navigateTo;
        public Type NavigateTo { get { return navigateTo; } }

    }
}
