using System;
using System.Collections.Generic;
using Entitas;

public class DealUnitDamage : ReactiveSystem<BulletEntity> {
    public DealUnitDamage(BulletContext bullets) : base (bullets) { }

    protected override void Execute(List<BulletEntity> bullets) {
        foreach (var bullet in bullets) {
            if (bullet.hasTarget && bullet.target.value != null && bullet.target.value.retainCount > 0) {
                if (UnityEngine.Random.Range(0f, 1f) < bullet.dealDamage.chance) { // TODO - make deterministic
                    var target = bullet.target.value;
                    target.isDestroy = true;
                }
            }
            bullet.isDestroy = true; // Delete the bullet
        }
    }

    protected override bool Filter(BulletEntity entity) {
        return true;
    }

    protected override Collector<BulletEntity> GetTrigger(IContext<BulletEntity> context) {
        return context.CreateCollector(BulletMatcher.TimeToHit, GroupEvent.Removed);
    }
}
