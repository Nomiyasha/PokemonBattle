namespace PokemonBattle.GUI.TextBoxes;

public class MessageBox : TextBox
{
    
    protected override Symbol BorderUnselected
        => new Symbol(BorderChar, ConsoleColor.DarkGray);
    
    protected override Symbol BorderSelected 
        => new Symbol(BorderChar); 
    public MessageBox(int width, int height, string content, Position position)
        :base(width, height, "", content, position) {}
    
    /// <summary>
    /// Generates content to display
    /// </summary>
    /// <param name="isSelected">Changes the text color and the border color</param>
    protected override void GenerateContent(bool isSelected)
    {
        ConsoleColor color = ConsoleColor.White;
        
        int a = (int)Math.Ceiling((double)Description.Length / Width);
        int length = (a > 1) ? a : 1;

        string[] text = new string[length];

        for (int i = 0; i < text.Length; i++)
        {
            int startIndex = i * (Width-4);

            int substringLength = Math.Min((Width-4), Description.Length - startIndex);

            text[i] = Description.Substring(startIndex, substringLength);
        }
        
        if (isSelected)
        {
            color = ConsoleColor.White;
        }
        else
        {
            color = ConsoleColor.Gray;
        }
        
        for (int i = 0; i < Height; i++)
        {
            for (int j = 0; j < Width; j++)
            {
                if (i == 0 || j == 0 || j == Width - 1 || i == Height - 1)
                {
                    Content[i, j] = (isSelected) ? BorderSelected : BorderUnselected;
                }
                else if (j == Width - 2 || j == 1)
                {
                    Content[i, j] = new Symbol(' ', color);
                }else
                {
                    try
                    {
                        Content[i, j] = new Symbol(text[i-1][j-2], color);
                    }
                    catch
                    {
                        Content[i, j] = new Symbol(' ', color);
                        
                    }
                        
                }
                
            }
        }
        
    }
}