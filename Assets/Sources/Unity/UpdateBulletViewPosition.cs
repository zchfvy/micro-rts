using System;
using System.Collections.Generic;
using Entitas;

public class UpdateBulletViewPosition : ReactiveSystem<BulletEntity> {
    public UpdateBulletViewPosition(IContext<BulletEntity> context) : base(context) { }

    protected override void Execute(List<BulletEntity> entities) {
        foreach (var unit in entities) {
            unit.view.gameObject.transform.position = unit.position.value;
        }
    }

    protected override bool Filter(BulletEntity entity) {
        return true;
    }

    protected override Collector<BulletEntity> GetTrigger(IContext<BulletEntity> context) {
        return context.CreateCollector(Matcher<BulletEntity>.AllOf(BulletMatcher.View, BulletMatcher.Position));
    }
}
