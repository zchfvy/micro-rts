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

    static IMatcher<BulletEntity> _matcherDealDamage;

    public static IMatcher<BulletEntity> DealDamage {
        get {
            if(_matcherDealDamage == null) {
                var matcher = (Matcher<BulletEntity>)Matcher<BulletEntity>.AllOf(BulletComponentsLookup.DealDamage);
                matcher.componentNames = BulletComponentsLookup.componentNames;
                _matcherDealDamage = matcher;
            }

            return _matcherDealDamage;
        }
    }
}
