using System.Collections.Generic;
using Entitas;

class DestroyBullets : ReactiveSystem<BulletEntity> {
    private BulletContext _bullets;

    public DestroyBullets(BulletContext bullets) : base (bullets) {
        _bullets = bullets;
    }

    protected override void Execute(List<BulletEntity> entities) {
        foreach (var bullet in entities) {
            _bullets.DestroyEntity(bullet);
        }
    }

    protected override bool Filter(BulletEntity entity) {
        return true;
    }

    protected override Collector<BulletEntity> GetTrigger(IContext<BulletEntity> context) {
        return context.CreateCollector(BulletMatcher.Destroy);
    }
}