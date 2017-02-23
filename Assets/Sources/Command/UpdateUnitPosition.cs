using System;
using Entitas;
using NLog;

public class UpdateUnitPosition : IExecuteSystem {
    private Logger log = LoggerFactory.GetLogger("UnitUpdate");

    private IGroup<UnitEntity> _movingUnits;
    private GlobalsContext _globals;

    public UpdateUnitPosition(Context<UnitEntity> unitContext, GlobalsContext globals) {
        _movingUnits = unitContext.GetGroup(Matcher<UnitEntity>.AllOf(UnitMatcher.Position, UnitMatcher.Destination, UnitMatcher.MoveSpeed));
        _globals = globals;
    }

    public void Execute() {
        foreach (var unit in _movingUnits.GetEntities()) {
            var direction = (unit.destination.position - unit.position.value).normalized;
            var distance = unit.moveSpeed.value * _globals.clock.SecondsPerTick;
            var distanceRemaining = (unit.destination.position - unit.position.value).magnitude;


            if (distance > distanceRemaining) {
                distance = distanceRemaining;
                unit.RemoveDestination();
            }

            var newPos = unit.position.value + direction * distance;
            log.Trace("Update Unit Position: {0} -> {1}", unit.position.value, newPos);
            unit.ReplacePosition(newPos);
        }
    }
}
