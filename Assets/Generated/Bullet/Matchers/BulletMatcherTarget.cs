//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGenerator.MatcherGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using Entitas;

public sealed partial class BulletMatcher {

    static IMatcher<BulletEntity> _matcherTarget;

    public static IMatcher<BulletEntity> Target {
        get {
            if(_matcherTarget == null) {
                var matcher = (Matcher<BulletEntity>)Matcher<BulletEntity>.AllOf(BulletComponentsLookup.Target);
                matcher.componentNames = BulletComponentsLookup.componentNames;
                _matcherTarget = matcher;
            }

            return _matcherTarget;
        }
    }
}
