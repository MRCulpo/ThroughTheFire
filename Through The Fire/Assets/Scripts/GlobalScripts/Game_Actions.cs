using UnityEngine;
using System.Collections;

//Implementation types delegates

public class Game_Actions: Singleton<Game_Actions>
{

    public delegate T GameActions<T>();
    public delegate T GameActionsParameters<T, U>(U u);

    public GameActions<bool> stopGame;
    public GameActions<bool> startGame;

    public GameActions<bool> resetPuzzle;

}
