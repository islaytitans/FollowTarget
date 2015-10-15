using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sitecore.Shell.Framework.Commands;
using Sitecore.Web;

namespace JonathanRobbins.FollowTarget
{
    public class FollowDropLink : Command
    {
        public override void Execute(CommandContext context)
        {
            var targetId = WebUtil.GetFormValue(context.Parameters["fieldId"]);

            Sitecore.Context.ClientPage.SendMessage(this, "item:load(id=" + targetId + ")");
        }
    }
}
