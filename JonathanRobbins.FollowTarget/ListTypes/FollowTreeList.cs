using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sitecore.Data;
using Sitecore.Shell.Framework.Commands;

namespace JonathanRobbins.FollowTarget.ListTypes
{
    public class FollowTreelist : Command
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
                    string rawValue = string.Empty;

                    rawValue = form[string.Format("{0}{1}", fieldId, Constants.Selected)];

                    if (string.IsNullOrEmpty(rawValue))
                    {
                        rawValue = form[string.Format("{0}{1}", fieldId, Constants.AllSelected)];
                    }

                    string targetId = rawValue.Substring(rawValue.LastIndexOf("|", StringComparison.InvariantCultureIgnoreCase) + 1);

                    isId = ID.TryParse(targetId, out id);
                }
            }

            Sitecore.Context.ClientPage.SendMessage(this, "item:load(id=" + (isId ? id.ToString() : string.Empty) + ")");
        }
    }
}
