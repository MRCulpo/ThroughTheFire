using UnityEngine;
using System.Collections;
using System;

public class Character2D : Singleton<Character2D>
{
    /// <summary>
    /// 
    /// </summary>
    private InputController inputController { set; get;}

    /// <summary>
    /// 
    /// </summary>
    private new Rigidbody2D rigidbody2D { set; get; }

    /// <summary>
    /// 
    /// </summary>
    public Transform transform2D { set; get; }

    /// <summary>
    /// 
    /// </summary>
    public Animator anim;

    /// <summary>
    /// Render
    /// </summary>
    public GameObject render;

    /// <summary>
    /// 
    /// </summary>
    [SerializeField]
    private float velocityWalk;

    /// <summary>
    /// 
    /// </summary>
    [SerializeField]
    private float jumpForce;

    /// <summary>
    /// Verficiar se está no chão ou não
    /// </summary>
    [SerializeField]
    bool checkIsGround = false;

    /// <summary>
    /// Verifica se está movimentando
    /// </summary>
    bool isMove = false;

    /// <summary>
    /// 
    /// </summary>
    bool isJump = false;

    /// <summary>
    /// parte inferior que enconsta no chão
    /// </summary>
    public Transform isGroundPerson;

    /// <summary>
    /// Layer da Ground
    /// </summary>
    public LayerMask layerIsGround;

    private Vector3 scale;
    void Awake()
    {
        inputController = FindObjectOfType<InputController>();
        rigidbody2D = GetComponent<Rigidbody2D>();
        transform2D = GetComponent<Transform>();
        scale = transform2D.localScale;
    }

    /// <summary>
    /// 
    /// </summary>
    void OnEnable()
    {
        inputController.ev_rightControl_right_DOWN += handleRCRDown;
        inputController.ev_rightControl_left_DOWN += handleRCLDown;

        inputController.ev_rightControl_right += handleRCR;
        inputController.ev_rightControl_left += handleRCL;

        inputController.ev_rightControl_right_UP += handleRCRUp;
        inputController.ev_rightControl_left_UP += handleRCLUp;

        inputController.ev_rightControl_up_DOWN += handleRCU;

    }

    /// <summary>
    /// 
    /// </summary>
    void OnDisable()
    {
        inputController.ev_rightControl_right_DOWN -= handleRCRDown;
        inputController.ev_rightControl_left_DOWN -= handleRCLDown;

        inputController.ev_rightControl_right -= handleRCR;
        inputController.ev_rightControl_left -= handleRCL;
        inputController.ev_rightControl_up_DOWN -= handleRCU;

        inputController.ev_rightControl_right_UP -= handleRCRUp;
        inputController.ev_rightControl_left_UP -= handleRCLUp;
    }

    private void handleRCRDown()
    {
        //flip();
    }

    private void handleRCLDown()
    {
        //flip();
    }

    void Update()
    {
        if (!isMove && rigidbody2D.velocity.x != 0)
            stopVelocity();

        if (checkIsGround && rigidbody2D.velocity.y <= 0)
        {
            isJump = false;
            if (!isMove && rigidbody2D.velocity.y == 0)
            {
                anim.SetTrigger("idle");
                anim.SetInteger("id", 0);
            }
        }
    }

    void FixedUpdate()
    {
        if(rigidbody2D.velocity.y < 0)
            checkIsGround = Physics2D.OverlapCircle(isGroundPerson.position, 0.2f, layerIsGround);
    }

    /// <summary>
    /// Reduzir Movimento
    /// </summary>
    private void handleRCRUp()
    {
        if (Game_Director.instance.state != GAMESTATE.START) return;
        stopVelocity();
    }

    /// <summary>
    /// Reduzir Movimento
    /// </summary>
    private void handleRCLUp()
    {
        if (Game_Director.instance.state != GAMESTATE.START) return;
        stopVelocity();
    }


    /// <summary>
    /// Pular
    /// </summary>
    private void handleRCU()
    {
        if (Game_Director.instance.state != GAMESTATE.START) return;

        if (checkIsGround)
        {
            Vector2 _force = new Vector2(0, jumpForce);
            rigidbody2D.AddForce(_force, ForceMode2D.Force);
            checkIsGround = false;
            isJump = true;
            anim.SetInteger("id", 1);
        }
    }

    /// <summary>
    /// Movimentar pra Esquerda
    /// </summary>
    private void handleRCL()
    {
        if (Game_Director.instance.state != GAMESTATE.START) return;

        Vector2 _velocity = new Vector2(-velocityWalk, rigidbody2D.velocity.y);
        render.transform.localScale = new Vector3(-1, render.transform.localScale.y);
        rigidbody2D.velocity = _velocity;
        isMove = true;
        if (!isJump)
            anim.SetInteger("id", 2);

    }

    /// <summary>
    /// Movimentar pra direita
    /// </summary>
    private void handleRCR()
    {
        if (Game_Director.instance.state != GAMESTATE.START) return;

        Vector2 _velocity = new Vector2(velocityWalk, rigidbody2D.velocity.y);
        render.transform.localScale = new Vector3(1, render.transform.localScale.y);
        rigidbody2D.velocity = _velocity;
        isMove = true;
        if(!isJump)
            anim.SetInteger("id", 2);
    }

    void stopVelocity()
    {
        if (Game_Director.instance.state != GAMESTATE.START) return;

        rigidbody2D.velocity = new Vector2(0, rigidbody2D.velocity.y);
        isMove = false;
    }
}
