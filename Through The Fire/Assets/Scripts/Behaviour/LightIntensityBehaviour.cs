using UnityEngine;
using System.Collections;

public class LightIntensityBehaviour : MonoBehaviour
{
    public Light m_light;

    public float multiple = 1;
    public float max, min;

    bool isFlip = true;

    void Update()
    {
        updateIntensity();
    }

    void updateIntensity()
    {
        if(m_light.intensity <= min && !isFlip)
            isFlip = true;
        else if (m_light.intensity >= max && isFlip)
            isFlip = false;

        if (isFlip)
            m_light.intensity += Time.deltaTime * multiple;
        else
            m_light.intensity -= Time.deltaTime * multiple;
    }
}
