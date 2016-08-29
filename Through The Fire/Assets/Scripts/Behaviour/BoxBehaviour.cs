using UnityEngine;
using System.Collections;

public class BoxBehaviour : MonoBehaviour {

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag.Equals("Player"))
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }
    }
}
