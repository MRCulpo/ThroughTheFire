using UnityEngine;
using System.Collections;

public class CheckVoidBehaviour : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag.Equals("Player"))
        {
            PlayerBehaviour.instance.offPlayer();
            Game_Director.instance.OnMenu(1f);
        }
    }
}
