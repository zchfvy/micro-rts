using System.Collections.Generic;
using Entitas;

class DestroyUnits : ReactiveSystem<UnitEntity> {
    private UnitContext _bullets;

    public DestroyUnits(UnitContext bullets) : base (bullets) {
        _bullets = bullets;
    }

    protected override void Execute(List<UnitEntity> entities) {
        foreach (var bullet in entities) {
            _bullets.DestroyEntity(bullet);
        }
    }

    protected override bool Filter(UnitEntity entity) {
        return true;
    }

    protected override Collector<UnitEntity> GetTrigger(IContext<UnitEntity> context) {
        return context.CreateCollector(UnitMatcher.Destroy);
    }
}
