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

    static IMatcher<UnitEntity> _matcherDealDamage;

    public static IMatcher<UnitEntity> DealDamage {
        get {
            if(_matcherDealDamage == null) {
                var matcher = (Matcher<UnitEntity>)Matcher<UnitEntity>.AllOf(UnitComponentsLookup.DealDamage);
                matcher.componentNames = UnitComponentsLookup.componentNames;
                _matcherDealDamage = matcher;
            }

            return _matcherDealDamage;
        }
    }
}