using UnityEngine;
using System.Collections;

public class CheckPointBehaviour : MonoBehaviour
{
    /// <summary>
    /// 
    /// </summary>
    private bool isCheck = false;
    /// <summary>
    /// 
    /// </summary>
    [SerializeField]
    Transform position;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag.Equals("Player") && !isCheck)
        {
            CheckPointManager.instance.checkPointSave(position.position);
            isCheck = true;
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag.Equals("Player") && !isCheck)
        {
            CheckPointManager.instance.checkPointSave(position.position);
            isCheck = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag.Equals("Player") && isCheck)
        {
            isCheck = false;
        }
    }
}
