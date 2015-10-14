using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sitecore.Shell.Framework.Commands;
using Sitecore.Web;

namespace JonathanRobbins.FollowTarget
{
    public class FollowTreelistEx : Command
    {
        public override void Execute(CommandContext context)
        {
            //MAy not be possible due to TreeEx existing within SPEAK UI

            //SheerResponse.Alert("I am here Jack");

            var targetId = WebUtil.GetFormValue(context.Parameters["fieldId"]);

            Sitecore.Context.ClientPage.SendMessage(this, "item:load(id=" + targetId + ")");
        }
    }
}
