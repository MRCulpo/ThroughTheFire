using UnityEngine;
using System.Collections;

public class EndLevelBehaviour : MonoBehaviour
{
    public string nameScene;

    public GameObject Unlock;
    public GameObject Lock;

    bool isEnter = false;

    void OnEnable()
    {
        InputController.instance.ev_leftControl_left_DOWN += HandleTouchDown;
    }

    void OnDisable()
    {
        if(InputController.instance)
            InputController.instance.ev_leftControl_left_DOWN -= HandleTouchDown;
    }

    private void HandleTouchDown()
    {
        if (Unlock.activeSelf && isEnter)
            Game_Director.instance.loadSceneFade(nameScene, 1f);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag.Equals("Player"))
        {
            FinalPuzzleManager finalManager = FindObjectOfType<FinalPuzzleManager>();
            if (finalManager)
            {
                if(finalManager.verifyDoor())
                    Unlock.SetActive(true);
                else
                    Lock.SetActive(true);
            }
            else
            {
                if (TorchManager.instance.torchComplet())
                    Unlock.SetActive(true);
                else
                    Lock.SetActive(true);
            }
            
            isEnter = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag.Equals("Player"))
        {
            Unlock.SetActive(false);
            Lock.SetActive(false);
        }

        isEnter = false;
    }
}
