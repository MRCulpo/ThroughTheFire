using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LoadAnimationManager : MonoBehaviour 
{
	void load (string scene, float time) 
    {
        Game_Director.instance.loadScene(scene, time);
	}
}
