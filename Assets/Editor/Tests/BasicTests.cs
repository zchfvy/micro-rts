using NUnit.Framework;
using Entitas;
using UnityEngine;

[TestFixture]
class BasicTests {

    private float EPSILON = 0.001f;

    private Contexts contexts;

    [SetUp]
    public void Init() {
        contexts = Contexts.sharedInstance;
        contexts.SetAllContexts();
        contexts.globals.SetClock(1);
    }

    [TearDown]
    public void Dispose() {
    }
    
    [TestCase]
    public void UnitMoves() {
        var systems = new Systems()
            .Add(new UpdateUnitPosition(contexts.unit, contexts.globals));

        var testUnit = contexts.unit.CreateEntity();
        testUnit.AddPosition(new Vector2(0, 0));
        testUnit.AddDestination(new Vector2(2, 2));
        testUnit.AddMoveSpeed(1);

        for (int i = 0; i < 4; i++) {
            systems.Execute();
        }

        AssertTools.AreEqual(testUnit.position.value, new Vector2(2, 2), EPSILON);
    }

    [TestCase]
    public void UnitOrderedMoves() {
        var systems = new Systems()
            .Add(new UpdateUnitPosition(contexts.unit, contexts.globals))
            .Add(new ProcessInputDestination(contexts.input));

        var testUnit = contexts.unit.CreateEntity();
        testUnit.AddPosition(new Vector2(0, 0));
        testUnit.AddMoveSpeed(1);

        var testInput = contexts.input.CreateEntity();
        testInput.AddInputUnitTarget(testUnit);
        testInput.AddSetUnitDestination(new Vector2(2, 2));

        for (int i = 0; i < 4; i++) {
            systems.Execute();
        }

        AssertTools.AreEqual(testUnit.position.value, new Vector2(2, 2), EPSILON);
    }
}

public static class AssertTools {
    public static void AreEqual(Vector2 a, Vector2 b, float delta) {
        var dist = (a - b).magnitude;
        if (dist > delta) {
            throw new AssertionException(
                string.Format("{0} != {1}", a, b));
        }
    }
}