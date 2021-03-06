﻿using System;
using System.Collections.Generic;
using System.Linq;
using Sitecore;
using Sitecore.Data;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using Sitecore.Shell.Framework.Commands;
using Sitecore.Web;

namespace JonathanRobbins.FollowTarget.LinkTypes
{
    public class FollowDroptree : Command
    {
        public override void Execute(CommandContext context)
        {
            ID id = ID.Null;

            string target = WebUtil.GetFormValue(context.Parameters["fieldId"]);

            Item item = context.Items.FirstOrDefault();

            if (item != null && !string.IsNullOrEmpty(target))
            {
                bool parsed = ID.TryParse(target, out id);

                if (!parsed)
                {
                    foreach (Field field in item.Fields.Where(Utility.IsDroptreeField))
                    {
                        if (field.HasValue && !string.IsNullOrEmpty(field.Source))
                        {
                            Item targetItem = item.Database.GetItem(field.Value);
                            if (targetItem == null)
                                continue;

                            if (target.Contains("/"))
                            {
                                target = target.Substring(target.LastIndexOf("/", StringComparison.CurrentCultureIgnoreCase) + 1);
                            }

                            if (targetItem.DisplayName.Equals(target, StringComparison.InvariantCultureIgnoreCase))
                            {
                                id = targetItem.ID;
                                break;
                            }
                        }
                    }
                }
            }

            Sitecore.Context.ClientPage.SendMessage(this, "item:load(id=" + (id != ID.Null ? id.ToString() : string.Empty) + ")");
        }
    }
}
