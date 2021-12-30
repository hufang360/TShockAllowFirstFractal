using System;
using System.Reflection;
using Terraria;
using Terraria.ID;
using TerrariaApi.Server;
using TShockAPI;


namespace Plugin
{
    [ApiVersion(2, 1)]
    public class Plugin : TerrariaPlugin
    {

        #region Plugin Info
        public override string Author => "hufang360";
        public override string Description => "服务端允许生成第一分形";
        public override string Name => "AllowFirstFractal";
        public override Version Version => Assembly.GetExecutingAssembly().GetName().Version;

        public bool isCrack = false;

        #endregion
        public Plugin(Main game) : base(game)
        {
        }

        public override void Initialize()
        {
            ServerApi.Hooks.GameUpdate.Register(this, OnUpdate);
        }

        private void OnUpdate(EventArgs args)
        {
            if(isCrack)
            {
                ServerApi.Hooks.GameUpdate.Deregister(this, OnUpdate);
                return;
            }

            // 将第一分形从弃用列表中移除
            Array.Clear(ItemID.Sets.Deprecated, 4722, 1);

            // 日志
            TShock.Log.Info("已将 第一分形 从弃用列表中移除");

            isCrack = true;
        }

    }
}
