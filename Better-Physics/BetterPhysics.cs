using MelonLoader;
using UnityEngine;

namespace BetterPhysics;

public class BetterPhysics : MelonMod {
    public override void OnInitializeMelon() {
        var category = MelonPreferences.CreateCategory("BetterPhysics");

        Physics.defaultSolverIterations = category.CreateEntry("DefaultSolverIterations", Physics.defaultSolverIterations).Value;
        Physics.defaultSolverVelocityIterations = category.CreateEntry("DefaultSolverVelocityIterations", Physics.defaultSolverVelocityIterations).Value;
    }

    public override void OnSceneWasLoaded(int buildIndex, string sceneName) {
        if (sceneName != "Hike_V2" && sceneName != "Hike_V2_Demo") return;

        GameObject.FindWithTag("Character Controller").GetComponent<Rigidbody>().collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
        GameObject.Find("/Item_Hammer").GetComponent<Rigidbody>().collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
    }
}