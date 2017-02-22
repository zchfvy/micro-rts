using Entitas.Unity;
using UnityEngine;

class InputController : MonoBehaviour {

    public UnitEntity SelectedEntity;
    public GameController GameController {
        get {
            return FindObjectOfType<GameController>();
        }
    }

    void Update() {

        if (Input.GetMouseButtonDown(0)) {

            var rayStart = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            var hit = Physics2D.Raycast(rayStart, Vector2.zero, 0);
            
            if (hit.transform != null) {
                var link = hit.transform.GetComponent<EntityLink>();
                if (link != null) {
                    var entity = link.entity as UnitEntity;
                    if (entity != null) {
                        SelectedEntity = entity;
                    }
                }
            }
        }

        if (Input.GetMouseButtonDown(1)) {
            if (SelectedEntity != null) {
                var input = GameController.Universe.Contexts.input.CreateEntity();
                var dest = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                input.AddInputUnitTarget(SelectedEntity);
                input.AddSetUnitDestination(dest);
            }
        }
    }
}
