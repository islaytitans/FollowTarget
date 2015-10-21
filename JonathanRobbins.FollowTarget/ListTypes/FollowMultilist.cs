using System.Collections.Generic;
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

            var form = System.Web.HttpContext.Current.Request.Form;

            Dictionary<string, string> values = new Dictionary<string, string>();

            int j = 100;
            
            foreach (var i in form.AllKeys)
            {
                values.Add(i != null ? i : j.ToString(), form[i]);
                j++;
            }

            var id = form[context.Parameters["fieldId"] + "_selected"];

            Sitecore.Context.ClientPage.SendMessage(this, "item:load(id=" + id + ")");

            
        }
    }
}
