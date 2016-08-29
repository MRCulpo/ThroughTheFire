using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Game_Fade : Singleton<Game_Fade> 
{
    private Animator anim;

    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public void FadeIn()
    {
        anim.SetTrigger("FadeIn");
    }
    public void fadeOut()
    {
        anim.SetTrigger("FadeOut");
    }
}
