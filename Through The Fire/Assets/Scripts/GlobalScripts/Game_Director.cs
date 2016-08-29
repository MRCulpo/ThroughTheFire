using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Game_Director: Singleton<Game_Director>
{
    public GAMESTATE state { set; get; }

    public GameObject menuContent;

    public float time;

    /// <summary>
    /// Load scene in Game
    /// </summary>
    /// <param name="_scene"></param>
    public void loadScene(string _scene)
    {
        StartCoroutine(ILoadScene(_scene, time));
    }

    /// <summary>
    /// Load scene in Game
    /// </summary>
    /// <param name="_scene"></param>
    public void loadScene(string _scene, float time)
    {
        StartCoroutine(ILoadScene(_scene, time));
    }

    /// <summary>
    /// Load scene in Game
    /// </summary>
    /// <param name="_scene"></param>
    public void loadSceneFade(string _scene, float time)
    {
        Game_Fade.instance.FadeIn();
        StartCoroutine(ILoadScene(_scene, time));
    }

    public void StandGame()
    {
        state = GAMESTATE.STANDBY;
        if(Game_Actions.instance.stopGame != null)
            Game_Actions.instance.stopGame();
    }

    public void PlayGame()
    {
        state = GAMESTATE.START;
        Debug.Log(Game_Actions.instance);
        Debug.Log(Game_Actions.instance.startGame);
        if (Game_Actions.instance.startGame != null)
            Game_Actions.instance.startGame();
    }

    /// <summary>
    /// Metodo para continuar o jogo quando morrer
    /// </summary>
    public void continueGameDie()
    {
        PlayGame();
        menuContent.SetActive(false);
        Game_Fade.instance.fadeOut();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="time"></param>
    public void OnMenu(float time)
    {
        StandGame();
        Game_Fade.instance.FadeIn();
        StartCoroutine(IOnMenu(time));
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="_time"></param>
    /// <returns></returns>
    IEnumerator IOnMenu(float _time)
    {
        yield return new WaitForSeconds(_time);
        menuContent.SetActive(true);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="_scene"></param>
    /// <param name="_time"></param>
    /// <returns></returns>
    IEnumerator ILoadScene(string _scene, float _time)
    {
        yield return new WaitForSeconds(_time);

         SceneManager.LoadScene(_scene);

    }

}
