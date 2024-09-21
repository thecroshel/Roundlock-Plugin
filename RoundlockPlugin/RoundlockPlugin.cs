using System;
using Exiled.API.Features;
using Exiled.API.Interfaces;
using Server = Exiled.Events.Handlers.Server;

namespace RoundlockPlugin
{
    public class RoundlockPlugin : Plugin<Config>
    {
        public static RoundlockPlugin Instance;

        public override string Name => "RoundlockPlugin";
        public override string Author => "thecroshel";
        public override string Prefix => "roundlock_plugin";
        public override Version Version => new Version(1, 0, 0);
        public override Version RequiredExiledVersion => new Version(8, 4, 3);

        public override void OnEnabled()
        {
            Instance = this;
            Server.RoundStarted += OnRoundStarted;
            base.OnEnabled();
            Log.Info("RoundlockPlugin enabled.");
        }

        public override void OnDisabled()
        {
            Server.RoundStarted -= OnRoundStarted;
            base.OnDisabled();
            Log.Info("RoundlockPlugin disabled.");
        }

        private void OnRoundStarted()
        {
            Round.IsLocked = true;
            Log.Info("Roundlock is activated.");
        }
    }

    public class Config : IConfig
    {
        public bool IsEnabled { get; set; } = true;
        public bool Debug { get; set; } = false;
    }
}
