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

    static IMatcher<UnitEntity> _matcherAttackTarget;

    public static IMatcher<UnitEntity> AttackTarget {
        get {
            if(_matcherAttackTarget == null) {
                var matcher = (Matcher<UnitEntity>)Matcher<UnitEntity>.AllOf(UnitComponentsLookup.AttackTarget);
                matcher.componentNames = UnitComponentsLookup.componentNames;
                _matcherAttackTarget = matcher;
            }

            return _matcherAttackTarget;
        }
    }
}
