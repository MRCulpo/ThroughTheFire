using UnityEngine;
using System.Collections;

public class TorchManager : Singleton<TorchManager>
{
    public TorchBehaviour[] vectorTorch;

    /// <summary>
    /// Verifica se todas as tochas estão acesas
    /// </summary>
    /// <returns></returns>
    public bool torchComplet()
    {
        for (int i = 0; i < vectorTorch.Length; i++)
        {
            if (!vectorTorch[i].isTouchOn())
                return false;
        }
        return true;
    }

}
