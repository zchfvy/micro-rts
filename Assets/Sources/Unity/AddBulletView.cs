using System;
using System.Collections.Generic;
using Entitas;

public class AddBulletView : ReactiveSystem<BulletEntity> {

    private IContext _context;

    public AddBulletView(IContext<BulletEntity> context) : base(context) {
        _context = context;
    }

    protected override void Execute(List<BulletEntity> entities) {
        foreach (var unit in entities) {
            unit.AddView(ViewManager.CreateAndLinkView(unit, _context, unit.asset.name));

            if (unit.hasPosition) {
                unit.view.gameObject.transform.position = unit.position.value;
            }
        }
    }

    protected override bool Filter(BulletEntity entity) {
        return true;
    }

    protected override Collector<BulletEntity> GetTrigger(IContext<BulletEntity> context) {
        return context.CreateCollector(BulletMatcher.Asset);
    }
}
