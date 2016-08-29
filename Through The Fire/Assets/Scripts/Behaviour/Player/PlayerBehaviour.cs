using UnityEngine;
using System.Collections;
using System;

public class PlayerBehaviour : Singleton<PlayerBehaviour>
{
    public Fire fire;

    // Use this for initialization
    void OnEnable()
    {
        Game_Actions.instance.startGame += OnloadGame;
    }

    void OnDisable()
    {
        if(Game_Actions.instance != null)
        Game_Actions.instance.startGame -= OnloadGame;
    }


    /// <summary>
    /// 
    /// </summary>
    void Update()
    {
        fire.UpdateFire();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    private bool OnloadGame()
    {
        Character2D.instance.transform2D.position = CheckPointManager.instance.checkPointLoad();
        OnPlayer();
        return true;
    }

    /// <summary>
    /// 
    /// </summary>
    public void offPlayer()
    {
        GetComponent<Rigidbody2D>().isKinematic = true;
    }

    /// <summary>
    /// 
    /// </summary>
    public void OnPlayer()
    {
        GetComponent<Rigidbody2D>().isKinematic = false;
    }

}
