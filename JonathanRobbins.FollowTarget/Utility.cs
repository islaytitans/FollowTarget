using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sitecore.Data.Fields;

namespace JonathanRobbins.FollowTarget
{
    public class Utility
    {
        public const string Selected = "_selected";
        public const string Unselected = "_unselected";

        public static bool IsDropListField(Field f)
        {
            return (FieldTypeManager.GetField(f) is ValueLookupField
                && !(FieldTypeManager.GetField(f) is GroupedDroplistField));
        }

        public static bool IsGroupedDroplistField(Field f)
        {
            return (FieldTypeManager.GetField(f) is GroupedDroplistField);
        }
    }
}
