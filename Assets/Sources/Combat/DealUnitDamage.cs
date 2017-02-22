using System;
using System.Collections.Generic;
using Entitas;

public class DealUnitDamage : ReactiveSystem<UnitEntity> {
    public DealUnitDamage(UnitContext units) : base (units) { }

    protected override void Execute(List<UnitEntity> entities) {
        foreach (var entity in entities) {
            if (UnityEngine.Random.Range(0f, 1f) < entity.dealDamage.chance) { // TODO - make deterministic
                entity.isDestroy = true;
            }
        }
    }

    protected override bool Filter(UnitEntity entity) {
        return true;
    }

    protected override Collector<UnitEntity> GetTrigger(IContext<UnitEntity> context) {
        return context.CreateCollector(UnitMatcher.DealDamage);
    }
}
