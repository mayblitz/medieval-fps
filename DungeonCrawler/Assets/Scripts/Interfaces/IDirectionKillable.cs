public interface IDirectionKillable
{
    bool IsDead { get; }

    void Kill(int force, Direction direction);
}
