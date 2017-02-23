using System;
using Entitas;
using NLog;

public class UpdateBulletPosition : IExecuteSystem {
    private Logger log = LoggerFactory.GetLogger("BulletUpdate");

    private IGroup<BulletEntity> _bullets;
    private GlobalsContext _globals;

    public UpdateBulletPosition(BulletContext bullets, GlobalsContext globals) {
        _bullets = bullets.GetGroup(BulletMatcher.Target);
        _globals = globals;
    }
    public void Execute() {
        foreach (var bullet in _bullets.GetEntities()) {

            if (! bullet.target.target.hasPosition) {
                //TODO handle this case better
                bullet.isDestroy = true;
                continue;
            }

            var direction = (bullet.target.target.position.value - bullet.position.value).normalized;
            var distance = bullet.moveSpeed.value * _globals.clock.SecondsPerTick;
            var distanceRemaining = (bullet.target.target.position.value - bullet.position.value).magnitude;


            if (distance > distanceRemaining) {
                distance = distanceRemaining;
                bullet.isDestroy = true;
                bullet.target.target.ReplaceDealDamage(bullet.dealDamage.chance); //TODO - shouldnt replace
            }

            var newPos = bullet.position.value + direction * distance;
            log.Trace("Update Bullet Position: {0} -> {1}", bullet.position.value, newPos);
            bullet.ReplacePosition(newPos);
        }
    }
}
