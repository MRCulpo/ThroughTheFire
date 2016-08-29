using UnityEngine;
using System.Collections;

public class CheckPointManager : Singleton<CheckPointManager>
{
    private Vector3 m_positionCheckPoint;

    public void checkPointSave(Vector3 _position)
    {
        m_positionCheckPoint = _position;
    }

    public Vector3 checkPointLoad()
    {
        return m_positionCheckPoint;
    }
}
