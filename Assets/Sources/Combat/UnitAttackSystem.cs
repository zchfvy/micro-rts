using System;
using System.Collections.Generic;
using Entitas;

public class UnitAttackSystem : ReactiveSystem<UnitEntity> {
    private BulletContext _bullets;

    public UnitAttackSystem(Context<UnitEntity> unitContext, BulletContext bullets) : base(unitContext) {
        _bullets = bullets;
    }

    protected override void Execute(List<UnitEntity> entities) {
        foreach (var entity in entities) {
            entity.AddShootingCooldown(0.25f); // TODO  - this is temporaty value
            var bullet = _bullets.CreateEntity();
            bullet.AddPosition(entity.position.value);
            bullet.AddTarget(entity.attackTarget.target);
            bullet.AddDealDamage(0.3f);
            bullet.AddMoveSpeed(10.0f);
            bullet.AddAsset("Dot");
        }
    }

    protected override bool Filter(UnitEntity entity) {
        return ! entity.hasShootingCooldown;
    }

    protected override Collector<UnitEntity> GetTrigger(IContext<UnitEntity> context) {
        return context.CreateCollector(UnitMatcher.AttackTarget);
    }
}
