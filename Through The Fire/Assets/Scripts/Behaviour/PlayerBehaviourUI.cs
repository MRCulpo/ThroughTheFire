using UnityEngine;
using UnityEngine.UI;

public class PlayerBehaviourUI : MonoBehaviour
{
    /// <summary>
    /// Referencia do playerBehaviour
    /// </summary>
    [SerializeField]
    private PlayerBehaviour player;
    /// <summary>
    /// Referencia da imagem que representa o fogo
    /// </summary>
    [SerializeField]
    private Image fire;

    /// <summary>
    /// Texto referente ao porcentual
    /// </summary>
    [SerializeField]
    private Text percetualText;

    /// <summary>
    /// Tamanho da imagem normal
    /// </summary>
    private Vector2 size;

    void Awake()
    {
        if (fire != null)
            size = fire.rectTransform.sizeDelta;
    }

    void Update()
    {
        updateFireUI();
    }

    /// <summary>
    /// Update da tocha
    /// </summary>
    public void updateFireUI()
    {
        if(fire != null)
            fire.rectTransform.sizeDelta = new Vector2((size.x * player.fire.percentualFire()) / 100, size.y);


        if (percetualText != null)
            percetualText.text = player.fire.percentualFire().ToString("00") + "%";
    }
}
