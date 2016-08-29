using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CircleCollider2D))]
public class CampfireBehaviour : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        PlayerBehaviour _player = other.GetComponent<PlayerBehaviour>();
        if (_player != null)
        {
            _player.fire.isBurning = false;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        PlayerBehaviour _player = other.GetComponent<PlayerBehaviour>();
        if (_player != null)
        {
            _player.fire.isBurning = true;
        }
    }
}
