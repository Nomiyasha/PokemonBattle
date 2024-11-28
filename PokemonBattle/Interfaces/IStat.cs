namespace PokemonBattle.Interfaces
{
    public interface IStat
    {
        int DefaultStat { get; }
        Level Level { get; }
        int CalculatedStat { get; }
        int CurrentStat { get; }
        void UpdateStat(int change);
        void ResetStat();
    }
}
