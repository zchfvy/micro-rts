//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGenerator.MatcherGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using Entitas;

public sealed partial class UnitMatcher {

    static IMatcher<UnitEntity> _matcherTarget;

    public static IMatcher<UnitEntity> Target {
        get {
            if(_matcherTarget == null) {
                var matcher = (Matcher<UnitEntity>)Matcher<UnitEntity>.AllOf(UnitComponentsLookup.Target);
                matcher.componentNames = UnitComponentsLookup.componentNames;
                _matcherTarget = matcher;
            }

            return _matcherTarget;
        }
    }
}
