//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGenerator.ContextGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using Entitas;

public sealed partial class UnitContext : Context<UnitEntity> {

    public UnitContext()
        : base(
            UnitComponentsLookup.TotalComponents,
            0,
            new ContextInfo(
                "Unit",
                UnitComponentsLookup.componentNames,
                UnitComponentsLookup.componentTypes
            )
        ) {
    }
}
