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
            Icon = icon;
            Label = label;
            NavigateTo = navigateTo;
        }
        public string Icon { get; }
        public string Label { get; }
        public Type NavigateTo { get; }

    }
}
