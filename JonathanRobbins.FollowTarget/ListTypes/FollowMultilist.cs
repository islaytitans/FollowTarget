using System.Collections.Generic;
using Sitecore.Shell.Framework.Commands;
using Sitecore.Web;

namespace JonathanRobbins.FollowTarget.ListTypes
{
    public class FollowMultilist : Command
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
                    targetId = form[fieldId + Utility.Selected];

                    if (string.IsNullOrEmpty(targetId))
                    {
                        targetId = form[fieldId + Utility.Unselected];
                    }
                }
            }

            Sitecore.Context.ClientPage.SendMessage(this, "item:load(id=" + targetId + ")");
        }
    }
}
