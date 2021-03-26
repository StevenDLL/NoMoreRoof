using BepInEx;
using HarmonyLib;
using UnityEngine;

namespace NoMoreRoof
{
    [BepInPlugin(modGUID, modName, modVersion)]
    [BepInProcess("valheim.exe")]
    public class NoMoreRoof : BaseUnityPlugin
    {
        private const string modGUID = "StevenDLL.NoMoreRoof";
        private const string modName = "NoMoreRoof By StevenDLL";
        private const string modVersion = "0.0.0.1";
        private readonly Harmony harmony = new Harmony(modGUID);

        void Awake()
        {

            harmony.PatchAll();

        }
        [HarmonyPatch(typeof(CraftingStation), "Start")]
        class Crafting_Patches
        {
            [HarmonyPrefix]
            static void setCraftingPatch(ref bool ___m_craftRequireRoof, ref bool ___m_craftRequireFire)
            {
                ___m_craftRequireRoof = false;
                ___m_craftRequireFire = false;

            }
        }

 

        [HarmonyPatch]
        class Bed_Patches
        {
            [HarmonyPrefix]
            [HarmonyPatch(typeof(Bed), "CheckFire")]
            static bool setCheckFire(ref bool __result)
            {
               
                __result = true;
                return false;

            }

            [HarmonyPrefix]
            [HarmonyPatch(typeof(Bed), "CheckWet")]
            static bool setCheckWet(ref bool __result)
            {
                __result = true;
                return false;
            }

            [HarmonyPrefix]
            [HarmonyPatch(typeof(Bed), "CheckExposure")]
            static bool setCheckExposure(ref bool __result)
            {
                __result = true;
                return false;
            }
        }

    }
}
