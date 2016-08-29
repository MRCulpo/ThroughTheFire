using UnityEngine;
using System.Collections;

public class MenuBehaviour : MonoBehaviour
{
    public GameObject playObject;
    public Animator anim;

    public void play()
    {
        playObject.SetActive(false);
        anim.SetTrigger("fire");
    }

    public void load()
    {
        Game_Director.instance.loadSceneFade("Level1", 1);
    }

    public void sound(AudioClip audio)
    {
        AudioManager.instance.audioOnShot(audio);
    }
}
