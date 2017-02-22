using Entitas;
using System;

class Universe : IDisposable {
    public readonly Contexts Contexts;
    public readonly Systems Systems;

    private bool _started = false;
    private bool _ended = false;

    public Universe() {
        Contexts = Contexts.sharedInstance;
        Contexts.SetAllContexts();

        Systems = DefaultSystems();
    }

    public void Start() {
        if (_started) {
            throw new Exception("Universe already started");
        } else if (_ended) {
            throw new Exception("Universe ended, please create a new one to run again");
        }
        Systems.Initialize();
        Contexts.globals.SetClock(60);
        _started = true;
    }

    public void Update() {
        if (!_started || _ended) {
            throw new Exception("Universe not running");
        }
        Systems.Execute();
        Systems.Cleanup();
    }

    public void Dispose() {
        if (_started) {
            Systems.TearDown();
        }
        _ended = true;
    }

    public Systems DefaultSystems() {
        var systems = new Feature("Systems");

        systems.Add(new ProcessInputDestination(Contexts.input));

        systems.Add(new AddUnitView(Contexts.unit));
        systems.Add(new UpdateUnitViewPosition(Contexts.unit));
        systems.Add(new UpdateUnitPosition(Contexts.unit, Contexts.globals));

        return systems;
    }
}