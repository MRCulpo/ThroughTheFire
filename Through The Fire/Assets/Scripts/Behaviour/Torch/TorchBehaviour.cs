using UnityEngine;
using System.Collections;
using System;

public class TorchBehaviour : MonoBehaviour {

    private bool torch = false;
    private bool isEnter = false;

    [SerializeField]
    AudioClip audio;

    [SerializeField]
    private GameObject lights;

    [SerializeField]
    private GameObject objectOn;

    public bool Torch
    {
        get
        {
            return torch;
        }

        set
        {
            torch = value;
        }
    }

    public bool IsEnter
    {
        get
        {
            return isEnter;
        }

        set
        {
            isEnter = value;
        }
    }

    public GameObject Lights
    {
        get
        {
            return lights;
        }

        set
        {
            lights = value;
        }
    }

    public GameObject ObjectOn
    {
        get
        {
            return objectOn;
        }

        set
        {
            objectOn = value;
        }
    }

    void OnEnable()
    {
        InputController.instance.ev_leftControl_left_DOWN += HandleTouchDown;
    }

    void OnDisable()
    {
        if(InputController.instance)
            InputController.instance.ev_leftControl_left_DOWN -= HandleTouchDown;
    }

    private void HandleTouchDown()
    {
        if(IsEnter && !Torch)
        {
            Torch = true;
            IsEnter = false;
            OnTorch();
        }
    }

    void OnTorch()
    {
        Lights.SetActive(true);
        ObjectOn.SetActive(false);
        AudioManager.instance.audioOnShot(audio);
        if (GetComponent<FinalPuzzleBehaviour>())
            GetComponent<FinalPuzzleBehaviour>().addToPuzzle();
    }

    /// <summary>
    /// Verifica se a tocha está acesa
    /// </summary>
    /// <returns></returns>
    public bool isTouchOn()
    {
        return Torch;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!Torch && other.tag.Equals("Player") && !IsEnter)
        {
            IsEnter = true;
            ObjectOn.SetActive(true);
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (!Torch && other.tag.Equals("Player") && !IsEnter)
        {
            IsEnter = true;
            ObjectOn.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (!Torch && other.tag.Equals("Player"))
        {
            IsEnter = false;
            ObjectOn.SetActive(false);
        }
    }
}
