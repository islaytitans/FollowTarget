using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sitecore.Diagnostics;
using Sitecore.Shell.Framework.Commands;
using Sitecore.Web.UI.Sheer;

namespace JonathanRobbins.FollowTarget
{
    public class FollowTarget : Command
    {
        public override void Execute(CommandContext context)
        {
            throw new NotImplementedException();
        }

        public void HandleMessage(Message message)
        {
            Assert.ArgumentNotNull(message, "message");

            if (message["id"] == this.ID)
            {
                switch (message.Name)
                {
                    case "contentlink:internallink":
                        this.Insert("/sitecore/shell/Applications/Dialogs/Internal link.aspx");
                        return;

                    case "contentlink:bucketlink":
                        this.Insert("/sitecore/shell/Applications/Dialogs/Bucket link.aspx");
                        return;

                    case "contentlink:media":
                        this.Insert("/sitecore/shell/Applications/Dialogs/Media link.aspx");
                        return;

                    case "contentlink:externallink":
                        this.Insert("/sitecore/shell/Applications/Dialogs/External link.aspx");
                        return;

                    case "contentlink:anchorlink":
                        this.Insert("/sitecore/shell/Applications/Dialogs/Anchor link.aspx");
                        return;

                    case "contentlink:mailto":
                        this.Insert("/sitecore/shell/Applications/Dialogs/Mail link.aspx");
                        return;

                    case "contentlink:javascript":
                        this.Insert("/sitecore/shell/Applications/Dialogs/Javascript link.aspx");
                        return;

                    case "contentlink:follow":
                        this.Follow();
                        return;

                    case "contentlink:clear":
                        this.ClearLink();
                        return;
                }
            }
        }
    }
}
