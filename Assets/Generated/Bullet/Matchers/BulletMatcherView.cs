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

    static IMatcher<BulletEntity> _matcherView;

    public static IMatcher<BulletEntity> View {
        get {
            if(_matcherView == null) {
                var matcher = (Matcher<BulletEntity>)Matcher<BulletEntity>.AllOf(BulletComponentsLookup.View);
                matcher.componentNames = BulletComponentsLookup.componentNames;
                _matcherView = matcher;
            }

            return _matcherView;
        }
    }
}
