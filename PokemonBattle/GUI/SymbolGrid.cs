using System.Drawing;

namespace PokemonBattle.GUI;
/// <summary>
/// Class for displaying Symbols on a grid.
/// </summary>
public class SymbolGrid
{
    public readonly Symbol[,] Grid;
    
    public int Height { get; }
    public int Width { get; }

    /// <summary>
    /// Constructor that also initializes the grid with default space characters.
    /// </summary>
    /// <param name="height">amount of rows</param>
    /// <param name="width">amount of columns</param>
    public SymbolGrid(int height, int width)
    {
        Height = height;
        Width = width;
        Grid = new Symbol[Height, Width];

        Clear();
    }
    
    /// <summary>
    /// Fills the grid with spaces.
    /// </summary>
    public void Clear()
    {
        for(int i = 0; i < Height; i++){
            for(int j = 0; j < Width; j++){
                DrawToGrid(new Symbol('#', ConsoleColor.DarkGray), new Position(j,i));
            }
        }
    }
    
    /// <summary>
    /// Displays the grid to the console through the Symbol.Draw() function.
    /// </summary>
    public void Display()
    {
        for (int i = 0; i < Height; i++)
        {
            for (int j = 0; j < Width; j++)
            {
                try
                { Grid[i, j].Draw(); }
                catch { }
            }
            Console.WriteLine();
        }
    }
    
    /// <summary>
    /// Adds a Symbol on the grid at the coordinates of Position.
    /// If the coordinates are out of bounds the Symbol will not be added. 
    /// </summary>
    /// <param name="symbol"></param>
    /// <param name="position"></param>
    public void DrawToGrid(Symbol symbol, Position position)
    {
        try
        { Grid[position.Y, position.X] = symbol; }
        catch
        { /* >>Do nothing - symbol out of bounds of the grid<< */ }
    }
}