using UnityEngine;
using System.Collections;

public class UnlockDoorBehaviour : MonoBehaviour
{
    public UnlockDoorManager manager;
    public bool isOpen = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag.Equals("BoxUnlockDoor"))
        {
            isOpen = true;
            manager.unlockDoor();
        }
    }
}
