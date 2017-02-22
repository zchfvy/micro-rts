using UnityEngine;

class DebugControlsController : MonoBehaviour {

    public GameController GameController {
        get {
            return FindObjectOfType<GameController>();
        }
    }

    void FixedUpdate() {
        if (Input.GetKeyDown(KeyCode.X)) {
            var unit = GameController.Universe.Contexts.unit.CreateEntity();
            unit.AddAsset("CircleHollow");
            unit.AddPosition(Vector2.zero);
            unit.AddMoveSpeed(10.0f);
            unit.AddDestination(Vector2.one * 5);
        }
    }
}
