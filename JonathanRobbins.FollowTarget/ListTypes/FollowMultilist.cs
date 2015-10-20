using Sitecore.Shell.Framework.Commands;
using Sitecore.Web;

namespace JonathanRobbins.FollowTarget.ListTypes
{
    public class FollowMultilist : Command
    {
        public override void Execute(CommandContext context)
        {
            //SheerResponse.Alert("I am here Jack");

            var targetId = WebUtil.GetFormValue(context.Parameters["fieldId"]);

            Sitecore.Context.ClientPage.SendMessage(this, "item:load(id=" + targetId + ")");
        }
    }
}
