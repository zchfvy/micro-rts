using System;
using System.Collections.Generic;
using Entitas;

public class AddUnitView : ReactiveSystem<UnitEntity> {

    private IContext _context;

    public AddUnitView(IContext<UnitEntity> context) : base(context) {
        _context = context;
    }

    protected override void Execute(List<UnitEntity> entities) {
        foreach (var unit in entities) {
            unit.AddView(ViewManager.CreateAndLinkView(unit, _context, unit.asset.name));

            if (unit.hasPosition) {
                unit.view.gameObject.transform.position = unit.position.value;
            }
        }
    }

    protected override bool Filter(UnitEntity entity) {
        return true;
    }

    protected override Collector<UnitEntity> GetTrigger(IContext<UnitEntity> context) {
        return context.CreateCollector(UnitMatcher.Asset);
    }
}
