using UnityEngine;
using System.Collections;

[System.Serializable]
public class Fire
{
    /// <summary>
    /// Contador de quantides unitarias de fogo
    /// </summary>
    [SerializeField]
    private int m_countFire;

    /// <summary>
    /// Tempo que o fogo dura para apagar
    /// </summary>
    [SerializeField]
    private float m_realFire;

    /// <summary>
    /// Variavel para verificar se o fogo está queimando
    /// </summary>
    [SerializeField]
    private bool m_isBurning;

    /// <summary>
    /// Contrutor
    /// </summary>
    /// <param name="m_countFire"></param>
    /// <param name="m_realFire"></param>
    /// <param name="m_isBurning"></param>
    public Fire(int m_countFire, float m_realFire, bool m_isBurning)
    {
        this.m_countFire = m_countFire;
        this.m_realFire = m_realFire;
        this.m_isBurning = m_isBurning;
    }


    #region ENCAPSULAMENTO

    /// <summary>
    /// 
    /// </summary>
    public int countFire
    {
        get
        {
            return m_countFire;
        }

        set
        {
            m_countFire = value;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public float realFire
    {
        get
        {
            return m_realFire;
        }

        set
        {
            m_realFire = value;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public bool isBurning
    {
        get
        {
            return m_isBurning;
        }

        set
        {
            m_isBurning = value;
        }
    }
    #endregion

    /// <summary>
    /// metodo de update da logica do fogo
    /// </summary>
    public void UpdateFire()
    {
        if (isBurning)
            burningFire();
        else
            restoreFire();
    }
    
    /// <summary>
    /// Metodo para queimar o fogo
    /// </summary>
    public void burningFire()
    {
        if (Game_Director.instance.state != GAMESTATE.START) return;

        if (realFire > 0)
            realFire -= Time.deltaTime;
        else
        {
            realFire = 0;
            PlayerBehaviour.instance.offPlayer();
            Game_Director.instance.OnMenu(1f);
        }
    }

    /// <summary>
    /// Metodo para restaurar o fogo
    /// </summary>
    public void restoreFire()
    {

        if (Game_Director.instance.state != GAMESTATE.START) return;

        if (realFire <= countFire)
            realFire += 5 * Time.deltaTime;
        else
            realFire = countFire;
    }

    /// <summary>
    /// Verifica se o fogo está apagando, está verificação é feita quando ele chega aos 40% de contagem
    /// </summary>
    /// <returns></returns>
    public bool isErasing()
    {
        return realFire <= countFire * 0.4f ? true : false;
    }

    /// <summary>
    /// Retorna o % de fogo que está ativo no momento
    /// </summary>
    /// <returns></returns>
    public float percentualFire()
    {
        return (realFire * 100) / countFire;
    }
}
