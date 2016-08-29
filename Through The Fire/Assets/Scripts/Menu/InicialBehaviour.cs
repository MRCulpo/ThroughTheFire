using UnityEngine;
using UnityEngine.UI;

public class InicialBehaviour : MonoBehaviour {

    public string[] content;
    public string scene;
    public Text texto;
    public Animator anim;

    public void chargeText(int i)
    {
        if (i < content.Length)
            texto.text = content[i];
        else
        {
            anim.enabled = false;
            Game_Director.instance.loadSceneFade(scene, 1);
        }
    }

}
