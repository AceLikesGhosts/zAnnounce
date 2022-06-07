using Rocket.API;
using System.Collections.Generic;
using UnityEngine;
using Rocket.Unturned.Chat;
using Rocket.API.Extensions;
using Rocket.Unturned.Commands;
using SDG.Unturned;

namespace zAnnounce.commands
{
    class CommandAnnounce : IRocketCommand
    {
        public AllowedCaller AllowedCaller => AllowedCaller.Both;

        public string Name => "announce";

        public string Help => "Rich Announcements";

        public string Syntax => "<message> <color>";

        public List<string> Aliases => new List<string>() { "broadcast", "announcement" };

        public List<string> Permissions => new List<string>() { "zAnnounce.broadcast" };

        public void Execute(IRocketPlayer caller, string[] command)
        {
            Color? color = command.GetColorParameter(0);

            int i = 1;
            if (color == null) i = 0;
            string message = command.GetParameterString(i);

            if (message == null)
            {
                UnturnedChat.Say(caller, "Missing required arguments.", Color.red);
                return;
            }

            ChatManager.serverSendMessage(
                message,
                (color.HasValue) ? (Color)color : Color.green,
                null, 
                null,
                EChatMode.SAY,
                null,
                true
            );
        }
    }
}
