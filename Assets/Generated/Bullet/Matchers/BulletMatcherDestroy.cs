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

    static IMatcher<BulletEntity> _matcherDestroy;

    public static IMatcher<BulletEntity> Destroy {
        get {
            if(_matcherDestroy == null) {
                var matcher = (Matcher<BulletEntity>)Matcher<BulletEntity>.AllOf(BulletComponentsLookup.Destroy);
                matcher.componentNames = BulletComponentsLookup.componentNames;
                _matcherDestroy = matcher;
            }

            return _matcherDestroy;
        }
    }
}
