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

    static IMatcher<UnitEntity> _matcherPosition;

    public static IMatcher<UnitEntity> Position {
        get {
            if(_matcherPosition == null) {
                var matcher = (Matcher<UnitEntity>)Matcher<UnitEntity>.AllOf(UnitComponentsLookup.Position);
                matcher.componentNames = UnitComponentsLookup.componentNames;
                _matcherPosition = matcher;
            }

            return _matcherPosition;
        }
    }
}
