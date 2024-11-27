﻿using PokemonBattle.Enums;

namespace PokemonBattle;

class Program
{
    
    static void Main(string[] args)
    {
        Console.CursorVisible = false;
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        
        IMove[] moves = [
            MovesLib.healthMoves["Scratch"],
            MovesLib.healthMoves["Scratch"],
            MovesLib.healthMoves["Scratch"],
            MovesLib.healthMoves["Scratch"]
        ];
        
        Pokemon p = new Pokemon("Charizard", 220, moves.ToList(), Elements.Fire);
        Pokemon enemy = new Pokemon("Test", 120, moves.ToList(), Elements.Grass);

        Battle battle = new Battle(p,enemy);
    }
}
