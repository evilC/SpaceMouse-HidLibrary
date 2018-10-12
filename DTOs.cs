using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceMouse_HidLibrary
{
    public enum BindingType { Axis, Button }

    public struct SpaceMouseUpdate
    {
        public BindingType BindingType { get; set; }
        public int Index { get; set; }
        public int Value { get; set; }
    }
}
