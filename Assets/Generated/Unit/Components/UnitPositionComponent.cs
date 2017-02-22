//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGenerator.ComponentEntityGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class UnitEntity {

    public PositionComponent position { get { return (PositionComponent)GetComponent(UnitComponentsLookup.Position); } }
    public bool hasPosition { get { return HasComponent(UnitComponentsLookup.Position); } }

    public void AddPosition(UnityEngine.Vector2 newValue) {
        var component = CreateComponent<PositionComponent>(UnitComponentsLookup.Position);
        component.value = newValue;
        AddComponent(UnitComponentsLookup.Position, component);
    }

    public void ReplacePosition(UnityEngine.Vector2 newValue) {
        var component = CreateComponent<PositionComponent>(UnitComponentsLookup.Position);
        component.value = newValue;
        ReplaceComponent(UnitComponentsLookup.Position, component);
    }

    public void RemovePosition() {
        RemoveComponent(UnitComponentsLookup.Position);
    }
}