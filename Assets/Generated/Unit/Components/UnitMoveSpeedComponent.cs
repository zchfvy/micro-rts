//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGenerator.ComponentEntityGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class UnitEntity {

    public MoveSpeedComponent moveSpeed { get { return (MoveSpeedComponent)GetComponent(UnitComponentsLookup.MoveSpeed); } }
    public bool hasMoveSpeed { get { return HasComponent(UnitComponentsLookup.MoveSpeed); } }

    public void AddMoveSpeed(float newValue) {
        var component = CreateComponent<MoveSpeedComponent>(UnitComponentsLookup.MoveSpeed);
        component.value = newValue;
        AddComponent(UnitComponentsLookup.MoveSpeed, component);
    }

    public void ReplaceMoveSpeed(float newValue) {
        var component = CreateComponent<MoveSpeedComponent>(UnitComponentsLookup.MoveSpeed);
        component.value = newValue;
        ReplaceComponent(UnitComponentsLookup.MoveSpeed, component);
    }

    public void RemoveMoveSpeed() {
        RemoveComponent(UnitComponentsLookup.MoveSpeed);
    }
}
