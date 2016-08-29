using UnityEngine;
using System.Collections;

public class UnlockDoorManager : MonoBehaviour
{
    public GameObject myDoor;

    public AudioClip shot;

    public UnlockDoorBehaviour[] unlockBehaviour;

    public void unlockDoor()
    {
        for (int i = 0; i < unlockBehaviour.Length; i++)
        {
            if (!unlockBehaviour[i].isOpen)
                return;
        }
        AudioManager.instance.audioOnShot(shot);
        myDoor.SetActive(false);
    }
 }
