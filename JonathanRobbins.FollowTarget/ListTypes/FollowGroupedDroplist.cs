using System.Collections.Generic;
using System.Linq;
using Sitecore.Data;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using Sitecore.Install.Files;
using Sitecore.Shell.Framework.Commands;
using Sitecore.Web;
using Sitecore.Web.UI.Sheer;

namespace JonathanRobbins.FollowTarget.ListTypes
{
    public class FollowGroupedDroplist : Command
    {
        public override void Execute(CommandContext context)
        {
            ID id = ID.Null;

            Item item = context.Items[0];

            var targetName = WebUtil.GetFormValue(context.Parameters["fieldId"]);

            if (item != null && !string.IsNullOrEmpty(targetName))
            {
                foreach (Field field in item.Fields.Where(Utility.IsGroupedDroplistField))
                {
                    if (field.HasValue && field.Value.Equals(targetName) && !string.IsNullOrEmpty(field.Source))
                    {
                        var grandChildren = new List<Item>();

                        Item sourceItem = item.Database.GetItem(field.Source);

                        if (sourceItem != null)
                        {
                            grandChildren = (from c in sourceItem.Children
                                select c.GetChildren()).SelectMany(g => g).ToList();
                        }
                        else
                        {
                            List<Item> children = Utility.GetItemsFromQuery(field.Source, item).ToList();

                            grandChildren = (from c in children
                                             select c.GetChildren()).SelectMany(g => g).ToList();
                        }

                        Item targetItem = grandChildren.FirstOrDefault(c => c.Name == targetName);

                        if (targetItem != null)
                        {
                            id = targetItem.ID;
                            break;
                        }
                    }
                }
            }

            Sitecore.Context.ClientPage.SendMessage(this, "item:load(id=" + (id != ID.Null ? id.ToString() : string.Empty) + ")");
        }
    }
}
