using Vintagestory.API.Common;
using Vintagestory.API.Util;
using Vintagestory.GameContent;

[assembly: ModInfo("Drop Vines Anyway",
    Authors = new[] { "Craluminum2413" })]

namespace DropVinesAnyway;

class Core : ModSystem
{
    public override bool ShouldLoad(EnumAppSide forSide) => forSide == EnumAppSide.Server;

    public override void Start(ICoreAPI api)
    {
        base.Start(api);
        if (api.Side != EnumAppSide.Server) return;
        api.RegisterBlockBehaviorClass("DropVinesAnyway", typeof(BlockBehaviorDropVinesAnyway));
        api.World.Logger.Event("started 'Drop Vines Anyway' mod");
    }

    public override void AssetsFinalize(ICoreAPI api)
    {
        foreach (var block in api.World.Blocks)
        {
            if (block is not BlockVines) continue;

            block.BlockBehaviors = block.BlockBehaviors.Append(new BlockBehaviorDropVinesAnyway(block));
        }
    }
}