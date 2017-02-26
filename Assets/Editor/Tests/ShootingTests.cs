using NUnit.Framework;
using Entitas;
using UnityEngine;

[TestFixture]
class ShootingTests {
    Contexts contexts;

    private const float EPSILON = 0.001f;

    [SetUp]
    public void Init() {
        contexts = Contexts.sharedInstance;
        contexts.SetAllContexts();
        contexts.globals.SetClock(1);
    }

    [TestCase]
    public void BulletKillsUnit() {
        var systems = new Systems()
            .Add(new UpdateBulletPosition(contexts.bullet, contexts.globals))
            .Add(new DealUnitDamage(contexts.bullet));

        var testUnit = contexts.unit.CreateEntity();
        testUnit.AddPosition(new Vector2(0, 0));

        var testBullet = contexts.bullet.CreateEntity();
        testBullet.AddPosition(new Vector2(0, 0));
        testBullet.AddTarget(testUnit);
        testBullet.AddTimeToHit(0.0f);
        testBullet.AddDealDamage(1);

        systems.Execute();

        Assert.IsTrue(testUnit.isDestroy);
    }

    [TestCase]
    public void BulletTimeToHit() {
        var systems = new Systems()
            .Add(new UpdateBulletPosition(contexts.bullet, contexts.globals))
            .Add(new DealUnitDamage(contexts.bullet));

        var testUnit = contexts.unit.CreateEntity();
        testUnit.AddPosition(new Vector2(0, 0));

        var testBullet = contexts.bullet.CreateEntity();
        testBullet.AddPosition(new Vector2(0, 0));
        testBullet.AddTarget(testUnit);
        testBullet.AddDealDamage(1);
        testBullet.AddTimeToHit(1.1f);

        systems.Execute();
        Assert.IsFalse(testUnit.isDestroy);
        systems.Execute();
        Assert.IsTrue(testUnit.isDestroy);

    }
}
