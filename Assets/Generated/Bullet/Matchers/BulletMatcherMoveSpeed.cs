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

    static IMatcher<BulletEntity> _matcherMoveSpeed;

    public static IMatcher<BulletEntity> MoveSpeed {
        get {
            if(_matcherMoveSpeed == null) {
                var matcher = (Matcher<BulletEntity>)Matcher<BulletEntity>.AllOf(BulletComponentsLookup.MoveSpeed);
                matcher.componentNames = BulletComponentsLookup.componentNames;
                _matcherMoveSpeed = matcher;
            }

            return _matcherMoveSpeed;
        }
    }
}