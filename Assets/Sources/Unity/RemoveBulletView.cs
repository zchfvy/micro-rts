using System.Collections.Generic;
using Entitas;
using Entitas.Unity;
using UnityEngine;

class RemoveBulletView : ReactiveSystem<BulletEntity> {

    public RemoveBulletView(BulletContext bullets) : base (bullets) {
    }

    protected override void Execute(List<BulletEntity> entities) {
        foreach (var bullet in entities) {
            bullet.view.gameObject.Unlink();
            GameObject.Destroy(bullet.view.gameObject);
        }
    }

    protected override bool Filter(BulletEntity entity) {
        return entity.hasView;
    }

    protected override Collector<BulletEntity> GetTrigger(IContext<BulletEntity> context) {
        return context.CreateCollector(BulletMatcher.Destroy);
    }
}
