using System;
using System.Collections.Generic;
using Entitas;

public class UpdateUnitViewPosition : ReactiveSystem<UnitEntity> {
    public UpdateUnitViewPosition(IContext<UnitEntity> context) : base(context) { }

    protected override void Execute(List<UnitEntity> entities) {
        foreach (var unit in entities) {
            unit.view.gameObject.transform.position = unit.position.value;
        }
    }

    protected override bool Filter(UnitEntity entity) {
        return true;
    }

    protected override Collector<UnitEntity> GetTrigger(IContext<UnitEntity> context) {
        return context.CreateCollector(Matcher<UnitEntity>.AllOf(UnitMatcher.View, UnitMatcher.Position));
    }
}
