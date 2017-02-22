using Entitas;
using Entitas.CodeGenerator.Api;

[Globals]
[Unique]
public class Clock : IComponent {
    public int TicksPerSecond;
    public float SecondsPerTick { get { return 1f/TicksPerSecond; } }
}
