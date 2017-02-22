using System;
using System.Collections.Generic;
using Entitas;

public class ProcessInputDestination : ReactiveSystem<InputEntity> {
    public ProcessInputDestination(IContext<InputEntity> context) : base(context) {
    }

    protected override void Execute(List<InputEntity> entities) {
        foreach (var entity in entities) {
            entity.inputUnitTarget.target.ReplaceDestination(entity.setUnitDestination.newDestination);
        }
    }

    protected override bool Filter(InputEntity entity) {
        return true;
    }

    protected override Collector<InputEntity> GetTrigger(IContext<InputEntity> context) {
        return context.CreateCollector(Matcher<InputEntity>.AllOf(
                InputMatcher.InputUnitTarget,
                InputMatcher.SetUnitDestination
            ));
    }
}
