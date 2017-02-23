using System;
using Entitas;

public class UpdateShootingCooldown : IExecuteSystem {
    private IGroup<UnitEntity> _cooldownUnits;
    private GlobalsContext _globals;

    public UpdateShootingCooldown(UnitContext units, GlobalsContext globals) {
        _cooldownUnits = units.GetGroup(UnitMatcher.ShootingCooldown);
        _globals = globals;
    }

    public void Execute() {
        foreach (var unit in _cooldownUnits.GetEntities()) {
            var currentCd = unit.shootingCooldown.seconds;
            currentCd -= _globals.clock.SecondsPerTick;

            if (currentCd < 0) {
                unit.RemoveShootingCooldown();
            } else {
                unit.ReplaceShootingCooldown(currentCd);
            }
        }
    }
}
