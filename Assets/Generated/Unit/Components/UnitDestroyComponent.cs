//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGenerator.ComponentEntityGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class UnitEntity {

    static readonly DestroyComponent destroyComponent = new DestroyComponent();

    public bool isDestroy {
        get { return HasComponent(UnitComponentsLookup.Destroy); }
        set {
            if(value != isDestroy) {
                if(value) {
                    AddComponent(UnitComponentsLookup.Destroy, destroyComponent);
                } else {
                    RemoveComponent(UnitComponentsLookup.Destroy);
                }
            }
        }
    }
}
