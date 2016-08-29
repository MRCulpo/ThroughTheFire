using UnityEngine;
using System.Collections;
using System;

public class FinalPuzzleBehaviour : MonoBehaviour
{

    void OnEnable()
    {
        Game_Actions.instance.resetPuzzle += HandResetPuzzle;
    }

    void OnDisable()
    {
        Game_Actions.instance.resetPuzzle -= HandResetPuzzle;
    }

    private bool HandResetPuzzle()
    {
        TorchBehaviour _torch = GetComponent<TorchBehaviour>();
        if (_torch)
        {
            _torch.IsEnter = false;
            _torch.Torch = false;
            _torch.Lights.SetActive(false);
            _torch.ObjectOn.SetActive(false);
        }
        return true;
    }

    public void addToPuzzle()
    {
        FinalPuzzleManager manager = FindObjectOfType<FinalPuzzleManager>();
        if (manager)
            manager.emptyPuzzle.Add(gameObject);
    }
}
