using System.Text;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using Sitecore.Pipelines.GetFieldLabel;

namespace JonathanRobbins.FollowTarget.Pipelines
{
    public class AddFollowLink
    {
        public void Process(GetFieldLabelArgs args)
        {
            if (!string.IsNullOrEmpty(args.Result))
                return;

            if (args.Field.TypeKey == "droptree" && !args.Field.Name.StartsWith("__"))
            {
                StringBuilder sb = new StringBuilder();

                sb.Append(args.Result);

                LookupField lookupField = (LookupField)args.Field;

                Item item = lookupField.TargetItem;

                if (item != null)
                {
                    string js = "scForm.browser.clearEvent(event || window.event, true); scForm.postRequest('','','','contenteditor:launchtab(url=" + item.ID + ", la=" + item.Language.Name + ", datasource=sitecore)'); return false;";

                    sb.AppendLine("<a onclick=\"" + js + "\" href=\"\">Navigate to: " + item.Name + "</a>");
                }

                args.Result = sb.ToString();
            }
        }
    }
}