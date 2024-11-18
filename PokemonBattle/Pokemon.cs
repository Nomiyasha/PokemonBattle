namespace PokemonBattle;

public class Pokemon
{
    public string Name { get; }
    public int Hp { get; set; }
    private int MaxHealth { get; }
    public bool IsAlive => Hp > 0;
    public int Atk { get; set; }
    public int Defence { get; set; }
    
    public string Message {get; private set;}

    public List<IMove> moves = new List<IMove>();

    public Pokemon(string name, int hp, List<IMove> moves)
    {
        Name = name;
        Hp = hp;
        MaxHealth = hp;
        this.moves = moves;
        Message = "";
    }

    public void Attack(Pokemon target, int moveIndex)
    {
        IMove move = moves[moveIndex];
        if (move.IsSelfTarget)
        {
            move.Use(this);
        } else
        {
            move.Use(target);
        }
        this.Message = $"{Name} used {move.Name}";
    }


}