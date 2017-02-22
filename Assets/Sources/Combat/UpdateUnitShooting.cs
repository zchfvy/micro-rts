using System;
using Entitas;
using System.Linq;

public class UpdateUnitShooting : IExecuteSystem {

    private const string TARGETS_INDEX_NAME = "TARGETS_INDEX";
    private IGroup<UnitEntity> _shooters;
    private UnitContext _units;

    public UpdateUnitShooting(UnitContext unitContext) {
        var idx = new EntityIndex<UnitEntity, int>(
            unitContext.GetGroup(UnitMatcher.Team),
            (entity, component) => {
                var team = component as Team;
                return team != null ? team.id : entity.team.id;
            });
        unitContext.AddEntityIndex(TARGETS_INDEX_NAME, idx);

        _units = unitContext;
        _shooters = unitContext.GetGroup(UnitMatcher.Team);
    }

    public void Execute() {
        foreach(var shooter in _shooters.GetEntities()) {
            if (shooter.hasShootingCooldown) {
                continue;
            }

            var enemyTeam = shooter.team.id == 0 ? 1 : 0;
            var targetIndex = _units.GetEntityIndex(TARGETS_INDEX_NAME) as EntityIndex<UnitEntity, int>;
            var target = targetIndex.GetEntities(enemyTeam).FirstOrDefault();

            if (target != null) {
                shooter.ReplaceAttackTarget(target);  // TODO : Add instead of replace ??
            }
        }
    }
}
