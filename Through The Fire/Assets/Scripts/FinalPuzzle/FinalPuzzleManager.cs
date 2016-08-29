using UnityEngine;
using System.Collections.Generic;

public class FinalPuzzleManager : MonoBehaviour {

    public List<GameObject> puzzle;
    public List<GameObject> emptyPuzzle; 

    public bool verifyDoor()
    {
        if (emptyPuzzle.Count == puzzle.Count)
        {
            for (int i = 0; i < emptyPuzzle.Count; i++)
            {
                if (emptyPuzzle[i].gameObject.GetInstanceID() != puzzle[i].gameObject.GetInstanceID())
                {
                    if(Game_Actions.instance)
                        Game_Actions.instance.resetPuzzle();
                    emptyPuzzle.Clear();
                    return false;
                }
            }
        }
        else
            return false;

        return true;
    }

}
