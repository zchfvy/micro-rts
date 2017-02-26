using System;
using Entitas;
using NLog;

public class UpdateBulletPosition : IExecuteSystem {

    private IGroup<BulletEntity> _bullets;
    private GlobalsContext _globals;

    public UpdateBulletPosition(BulletContext bullets, GlobalsContext globals) {
        _bullets = bullets.GetGroup(BulletMatcher.Target);
        _globals = globals;
    }
    public void Execute() {
        foreach (var bullet in _bullets.GetEntities()) {
            if (bullet.hasTimeToHit) {
                var new_tth = bullet.timeToHit.value - _globals.clock.SecondsPerTick;
                if (new_tth > 0) {
                    bullet.timeToHit.value = new_tth; //Do not replace here, as an optimization
                } else {
                    bullet.RemoveTimeToHit();
                }
            }
        }
    }
}
