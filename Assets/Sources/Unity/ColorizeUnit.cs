using System;
using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class ColorizeUnit : ReactiveSystem<UnitEntity> {
    public ColorizeUnit(IContext<UnitEntity> context) : base(context) {
    }

    protected override void Execute(List<UnitEntity> entities) {
        foreach (var entity in entities) {
            var sprite = entity.view.gameObject.GetComponent<SpriteRenderer>();

            switch (entity.team.id) {
                case 0:
                    sprite.color = Color.blue;
                    break;
                case 1:
                    sprite.color = Color.red;
                    break;
                default:
                    sprite.color = Color.white;
                    break;
            }
        }
    }

    protected override bool Filter(UnitEntity entity) {
        return(entity.hasTeam && entity.hasView);
    }

    protected override Collector<UnitEntity> GetTrigger(IContext<UnitEntity> context) {
        return context.CreateCollector(Matcher<UnitEntity>.AnyOf(UnitMatcher.Team, UnitMatcher.View));
    }
}
