//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGenerator.MatcherGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using Entitas;

public sealed partial class GlobalsMatcher {

    static IMatcher<GlobalsEntity> _matcherClock;

    public static IMatcher<GlobalsEntity> Clock {
        get {
            if(_matcherClock == null) {
                var matcher = (Matcher<GlobalsEntity>)Matcher<GlobalsEntity>.AllOf(GlobalsComponentsLookup.Clock);
                matcher.componentNames = GlobalsComponentsLookup.componentNames;
                _matcherClock = matcher;
            }

            return _matcherClock;
        }
    }
}
