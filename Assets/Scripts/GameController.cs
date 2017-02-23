using UnityEngine;

class GameController : MonoBehaviour {

    public Universe Universe;

    void Start() {
        Universe = new Universe();
        Universe.Start();
    }

    void FixedUpdate() {
        Universe.Update();
    }
}
