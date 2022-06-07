using Rocket.API;
using System.Xml.Serialization;

namespace zAnnounce.announcer
{
    public sealed class Message
    {
        [XmlAttribute("Text")]
        public string Text;

        [XmlAttribute("Color")]
        public string Color;

        [XmlAttribute("Icon")]
        public string Icon;

        [XmlAttribute("Rich")]
        public bool Rich;

        public Message(string text, string color, string icon, bool rich)
        {
            Text = text;
            Color = color;
            Icon = icon;
            Rich = rich;
        }
        public Message()
        {
            Text = "";
            Color = "";
            Icon = "";
            Rich = false;
        }
    }

    public class zAnnounceConfiguration : IRocketPluginConfiguration
    {
        public int delay;
        public bool inOrder;

        [XmlArrayItem("Message")]
        [XmlArray(ElementName = "Messages")]
        public Message[] Messages;

        public void LoadDefaults()
        {
            delay = 1;
            inOrder = true;
            Messages = new Message[]
            {
                new Message("This is an example broadcast.", "Green", "", true),
                new Message("This plugin was made by https://github.com/acelikesghosts", "", "Green", true),
                new Message("By the way, Weslie", "Green", "", true),
                new Message("The delay is in seconds.", "Green", "", true),
                new Message("Change it <3", "Green", "", true),
                new Message("and btw", "Green", "", true),
                new Message("it only supports base game colors", "Green", "", true)
            };
        }
    }
}
