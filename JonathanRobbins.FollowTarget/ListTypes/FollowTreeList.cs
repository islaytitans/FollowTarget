using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sitecore.Shell.Framework.Commands;

namespace JonathanRobbins.FollowTarget.ListTypes
{
    public class FollowTreelist : Command
    {
        public override void Execute(CommandContext context)
        {
            string targetId = string.Empty;

            var fieldId = context.Parameters["fieldId"];

            if (!string.IsNullOrEmpty(fieldId))
            {
                var form = System.Web.HttpContext.Current.Request.Form;

                if (form != null)
                {
                    string rawValue = string.Empty;

                    rawValue = form[fieldId + Utility.Selected];

                    if (string.IsNullOrEmpty(rawValue))
                    {
                        rawValue = form[fieldId + Utility.Unselected];
                    }

                    targetId = rawValue.Substring(rawValue.LastIndexOf("|", StringComparison.InvariantCultureIgnoreCase) + 1);
                }
            }

            Sitecore.Context.ClientPage.SendMessage(this, "item:load(id=" + targetId + ")");
        }
    }
}
