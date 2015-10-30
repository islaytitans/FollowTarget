using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;

namespace JonathanRobbins.FollowTarget
{
    public class Utility
    {
        public static bool IsDropListField(Field f)
        {
            return (FieldTypeManager.GetField(f) is ValueLookupField
                && !(FieldTypeManager.GetField(f) is GroupedDroplistField));
        }

        public static bool IsGroupedDroplistField(Field f)
        {
            return (FieldTypeManager.GetField(f) is GroupedDroplistField);
        }

        public static bool IsDroptreeField(Field f)
        {
            return (FieldTypeManager.GetField(f) is ReferenceField);
        }

        public static IEnumerable<Item> GetItemsFromQuery(string query, Item contextItem)
        {
            string queryPath = query.Replace(Constants.QueryPrefix, contextItem.Paths.FullPath);
            return contextItem.Database.SelectItems(queryPath);
        }
    }
}
