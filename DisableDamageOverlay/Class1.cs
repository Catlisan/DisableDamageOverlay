using System.Reflection;
using HarmonyLib;

public static class MarseyPatch
{
    
   
    public static Assembly ContentClient = null;

    public static string Name = "DamageOverlay Patch";
    public static string Description = "Disable damage overlay by Catlisan";
}

[HarmonyPatch]
public static class CombatOverlayPatch
{
    private static MethodBase TargetMethod() 
    {
        var CombatOverlay = MarseyPatch.ContentClient.GetType("Content.Client.UserInterface.Systems.DamageOverlays.Overlays.DamageOverlay")!;
        return CombatOverlay.GetMethod("Draw", BindingFlags.NonPublic | BindingFlags.Instance);
    }

  
    [HarmonyPrefix]
    private static bool PrefSkip()
    {
        return false;
    }
}