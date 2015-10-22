using System.Collections.Generic;
using System.Linq;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using Sitecore.Shell.Framework.Commands;
using Sitecore.Web;
using Sitecore.Web.UI.Sheer;

namespace JonathanRobbins.FollowTarget.ListTypes
{
    public class FollowGroupedDroplist : Command
    {
        public override void Execute(CommandContext context)
        {
            string id = string.Empty;

            Item item = context.Items[0];

            var targetName = WebUtil.GetFormValue(context.Parameters["fieldId"]);

            if (item != null && !string.IsNullOrEmpty(targetName))
            {
                foreach (Field field in item.Fields.Where(Utility.IsGroupedDroplistField))
                {
                    if (field.HasValue && field.Value.Equals(targetName) && !string.IsNullOrEmpty(field.Source))
                    {
                        Item sourceItem = item.Database.GetItem(field.Source);

                        if (sourceItem != null)
                        {
                            List<Item> grandChildren = (from c in sourceItem.Children
                                select c.GetChildren()).SelectMany(g => g).ToList();

                            Item targetItem = grandChildren.FirstOrDefault(c => c.Name == targetName);

                            if (targetItem != null)
                            {
                                id = targetItem.ID.ToString();
                                break;
                            }
                        }
                    }
                }
            }

            Sitecore.Context.ClientPage.SendMessage(this, "item:load(id=" + id + ")");
        }
    }
}
