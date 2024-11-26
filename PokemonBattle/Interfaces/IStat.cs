namespace PokemonBattle.Interfaces
{
    public interface IStat
    {
        int DefaultStat { get; }
        int CurrentStat { get; }
        void UpdateStat(int change);
        void ResetStat();
    }
}
