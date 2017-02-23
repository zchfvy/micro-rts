using UnityEngine;

class DebugControlsController : MonoBehaviour {

    private int team = 0;

    public GameController GameController {
        get {
            return FindObjectOfType<GameController>();
        }
    }

    void FixedUpdate() {
        if (Input.GetKey(KeyCode.X)) {
            var unit = GameController.Universe.Contexts.unit.CreateEntity();
            unit.AddAsset("CircleHollow");
            unit.AddPosition(Vector2.zero);
            unit.AddMoveSpeed(3.0f);
            unit.AddDestination(Random.insideUnitCircle * 5f);
            unit.AddTeam(team);

            team = team == 1 ? 0 : 1;
        }
    }
}
