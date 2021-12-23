using SRML;
using SRML.SR;
using SRML.SR.SaveSystem;
using SRML.SR.Translation;
using UnityEngine;

namespace PowerStorageMod
{
    public class PowerStorageMain : ModEntryPoint
    {

        public override void PreLoad()
        {
            HarmonyInstance.PatchAll();
        }

        public override void Load()
        {
            GameObject gameObject = new GameObject("").CreatePrefabCopy();
            PowerStorageGadget psg = gameObject.AddComponent<PowerStorageGadget>();
            GadgetRegistry.RegisterBlueprintLock(PowerStorageIds.ENERGY_GENERATOR, (GadgetRegistry.BlueprintLockCreateDelegate)(x => x.CreateBasicLock(PowerStorageIds.ENERGY_GENERATOR, Gadget.Id.NONE, ProgressDirector.ProgressType.MOCHI_SEEN_FINAL_CHAT, 3f)));
            GadgetDefinition icon = SRSingleton<GameContext>.Instance.LookupDirector.GetGadgetDefinition(Gadget.Id.TELEPORTER_GOLD);
            GadgetDefinition prefab = ScriptableObject.CreateInstance<GadgetDefinition>();
            prefab.id = PowerStorageIds.ENERGY_GENERATOR;
            prefab.pediaLink = PediaDirector.Id.UTILITIES;
            prefab.blueprintCost = 30000;
            prefab.buyCountLimit = -1;
            prefab.icon = icon.icon;
            prefab.craftCosts = new GadgetDefinition.CraftCost[]{
				new GadgetDefinition.CraftCost
				{
					id = Identifiable.Id.QUICKSILVER_PLORT,
					amount = 12
				},
				new GadgetDefinition.CraftCost
				{
					id = Identifiable.Id.QUANTUM_PLORT,
					amount = 12
				},
				new GadgetDefinition.CraftCost
				{
					id = Identifiable.Id.QUICKSILVER_SLIME,
					amount = 1
				}
			};

            PowerStorageIds.ENERGY_GENERATOR.GetTranslation().SetNameTranslation("Energy Generator").SetDescriptionTranslation("An engine that generates energy for quicksilver slimes.");
            LookupRegistry.RegisterGadget(prefab);
			GadgetRegistry.ClassifyGadget(PowerStorageIds.ENERGY_GENERATOR, GadgetRegistry.GadgetClassification.MISC);
            AmmoRegistry.RegisterRefineryResource(Identifiable.Id.QUICKSILVER_SLIME);
        }

        public override void PostLoad()
        {

        }

    }
}
