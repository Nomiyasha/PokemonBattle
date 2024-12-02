namespace PokemonBattle.GUI;
using PokemonBattle.Enums;
using PokemonBattle.GUI.TextBoxes;

public class MenuUi
{
    /// <summary>
    /// The width of one item in the UI
    /// </summary>
    private const int Width = (int)Sizes.ItemWidth;
    /// <summary>
    /// The height of on item in the UI
    /// </summary>
    private const int Height = (int)Sizes.ItemHeight;

    private string TitleContent { get; }
    private string[] MenuItems { get; }

    public MenuUi(string titleContent, string[] menuItems)
    {
        TitleContent = titleContent;
        MenuItems = menuItems;
    }
    
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public int DisplayMenu()
    {
        Console.Clear();
        int cursorPosLeft = Console.CursorLeft;
        int cursorPosTop = Console.CursorTop;
        SymbolGrid grid = new SymbolGrid((int)Sizes.FullHeight, (int)Sizes.FullWidth);

        
        MessageBox title = new MessageBox((int)Sizes.FullWidth, Height, TitleContent, new Position(0,0));
        
        
        MessageBox[] menuBoxes = new MessageBox[MenuItems.Length];
        for (int i = 0; i < MenuItems.Length; i++)
        {
            menuBoxes[i] = new MessageBox(Width, Height, MenuItems[i], new Position(Width/2, Height*(i+1)));
        }
        
        
        int selectedItem = 0;
        bool doneChoice = false;
        while (!doneChoice)
        {
            Console.SetCursorPosition(cursorPosLeft,cursorPosTop);
            title.Draw(grid, true);
            
            for (int i = 0; i < menuBoxes.Length; i++)
            {
                if (selectedItem == i)
                {
                    menuBoxes[i].Draw(grid, true);
                }
                else
                {
                    menuBoxes[i].Draw(grid, false);
                }
            }
            
            grid.Display();

            switch (Input.GetInput())
            {
                case 1: // up
                    selectedItem --;
                    if(selectedItem < 0){
                        selectedItem = menuBoxes.Length -1;
                    }
                    doneChoice = false;
                    break;
                case 2: // down
                    selectedItem ++;
                    selectedItem = selectedItem%menuBoxes.Length;
                    doneChoice = false;
                    break;
                case 5: // enter
                    doneChoice = true;
                    break;
            }
        }
        return selectedItem;

    }
    
    
    
    
}