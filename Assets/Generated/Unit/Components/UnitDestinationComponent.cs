//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGenerator.ComponentEntityGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class UnitEntity {

    public DestinationComponent destination { get { return (DestinationComponent)GetComponent(UnitComponentsLookup.Destination); } }
    public bool hasDestination { get { return HasComponent(UnitComponentsLookup.Destination); } }

    public void AddDestination(UnityEngine.Vector2 newPosition) {
        var component = CreateComponent<DestinationComponent>(UnitComponentsLookup.Destination);
        component.position = newPosition;
        AddComponent(UnitComponentsLookup.Destination, component);
    }

    public void ReplaceDestination(UnityEngine.Vector2 newPosition) {
        var component = CreateComponent<DestinationComponent>(UnitComponentsLookup.Destination);
        component.position = newPosition;
        ReplaceComponent(UnitComponentsLookup.Destination, component);
    }

    public void RemoveDestination() {
        RemoveComponent(UnitComponentsLookup.Destination);
    }
}
