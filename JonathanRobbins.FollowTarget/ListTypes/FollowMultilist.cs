using System.Collections.Generic;
using Sitecore.Data;
using Sitecore.Shell.Framework.Commands;
using Sitecore.Web;

namespace JonathanRobbins.FollowTarget.ListTypes
{
    public class FollowMultilist : Command
    {
        public override void Execute(CommandContext context)
        {
            ID id = ID.Null;
            bool isId = false;

            var fieldId = context.Parameters["fieldId"];

            if (!string.IsNullOrEmpty(fieldId))
            {
                var form = System.Web.HttpContext.Current.Request.Form;

                if (form != null)
                {
                    string targetId = form[string.Format("{0}{1}", fieldId, Constants.Selected)];

                    if (string.IsNullOrEmpty(targetId))
                    {
                        targetId = form[string.Format("{0}{1}", fieldId, Constants.Unselected)];
                    }

                    isId = ID.TryParse(targetId, out id);
                }
            }

            Sitecore.Context.ClientPage.SendMessage(this, "item:load(id=" + (isId ? id.ToString() : string.Empty) + ")");
        }
    }
}
