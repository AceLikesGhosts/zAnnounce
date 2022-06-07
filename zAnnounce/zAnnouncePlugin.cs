/**
 * 
 * © 2020 Ace W <acelikesghosts@gmail.com
 * LICENCE LOCATED AT ./LICENCE
 *
 */
using Rocket.Core.Plugins;
using zAnnounce.announcer;
using Logger = Rocket.Core.Logging.Logger;

namespace zAnnounce
{
    public class zAnnouncePlugin : RocketPlugin<zAnnounceConfiguration>
    {
        public static zAnnouncePlugin instance;
        public static Rocket.API.IAsset<zAnnounceConfiguration> config;
        // private TheFlyingAsian metric;

        int versionMajor = 1;
        int versionMinor = 0;
        int versionPatch = 0;

        protected override void Load()
        {
            instance = this;
            config = Configuration;
            // metric = new TheFlyingAsian();

            Logger.Log("zAnnounce by AceLikesGhosts");
            Logger.Log($"Version {versionMajor}.{versionMinor}.{versionPatch}");

            TryAddComponent<Announcer>();
        }

        protected override void Unload()
        {
            base.Unload();
        }
    }
}
