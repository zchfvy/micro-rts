using System.Collections.Generic;
using Entitas;
using Entitas.Unity;
using UnityEngine;

class RemoveUnitView : ReactiveSystem<UnitEntity> {

    public RemoveUnitView(UnitContext bullets) : base (bullets) {
    }

    protected override void Execute(List<UnitEntity> entities) {
        foreach (var bullet in entities) {
            bullet.view.gameObject.Unlink();
            GameObject.Destroy(bullet.view.gameObject);
        }
    }

    protected override bool Filter(UnitEntity entity) {
        return entity.hasView;
    }

    protected override Collector<UnitEntity> GetTrigger(IContext<UnitEntity> context) {
        return context.CreateCollector(UnitMatcher.Destroy);
    }
}
