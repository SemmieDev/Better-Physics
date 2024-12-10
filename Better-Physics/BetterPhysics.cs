using MelonLoader;
using UnityEngine;

namespace BetterPhysics;

public class BetterPhysics : MelonMod {
    private MelonPreferences_Entry<float> fixedTimestep = null!;

    public override void OnInitializeMelon() {
        var category = MelonPreferences.CreateCategory("BetterPhysics");

        fixedTimestep = category.CreateEntry("FixedTimestep", Time.fixedDeltaTime);
        Physics.defaultSolverIterations = category.CreateEntry("DefaultSolverIterations", Physics.defaultSolverIterations).Value;
        Physics.defaultSolverVelocityIterations = category.CreateEntry("DefaultSolverVelocityIterations", Physics.defaultSolverVelocityIterations).Value;
    }

    public override void OnSceneWasLoaded(int buildIndex, string sceneName) {
        Time.fixedDeltaTime = fixedTimestep.Value;

        if (sceneName != "Hike_V2" && sceneName != "Hike_V2_Demo") return;

        GameObject.FindWithTag("Character Controller").GetComponent<Rigidbody>().collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
        GameObject.Find("/Item_Hammer").GetComponent<Rigidbody>().collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
    }
}