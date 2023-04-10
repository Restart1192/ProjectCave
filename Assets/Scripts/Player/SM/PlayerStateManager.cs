using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerStateManager : MonoBehaviour
{
    //Estado atual do player
    PlayerBaseState currentState;

    //Estado parado,andar e run
    [SerializeField] public PlayerIdleState idleState = new PlayerIdleState();
    [SerializeField] public PlayerWalkState walkState = new PlayerWalkState();
    [SerializeField] public PlayerRunState runState = new PlayerRunState();
    [SerializeField] public PlayerJumpState jumpState = new PlayerJumpState();

    //Animação do player
    [SerializeField] public Animator animator;

    //Move Player
    Rigidbody m_Rigidbody;
    [SerializeField] private float m_Speed = 5f;
    [SerializeField] private float walkSpeed = 5f;
    [SerializeField] private float runSpeed = 10f;
    [SerializeField] private float rotateSpeed;
    [SerializeField] private float jumpAmount = 10;
    [SerializeField] private int jumpTimeTolerance = 50;

    private int jumpTime = 0;

    private bool isMove = false;
    private bool isRun = false;
    private bool isJump = false;
    private bool isCanJump = true;

    // Start is called before the first frame update
    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
        currentState = idleState;
        currentState.EnterState(this);
    }

    // Update is called once per frame
    void Update()
    {
        currentState.updateState(this);
    }

    void FixedUpdate()
    {
        InputControl();
    }

    //Alterar o estado
    public void SwitchState(PlayerBaseState state)
    {
        currentState = state;
        state.EnterState(this);
    }

    //Obter informação do estado
    public string GetInfoState()
    {
        return currentState.getInfoState(this);
    }

    //Alterar condições de animação
    public void ChangeConditionMove(bool isWalking, bool isRunning, bool isJumping)
    {
        animator.SetBool("isWalking", isWalking);
        animator.SetBool("isRunning", isRunning);
        animator.SetBool("isJumping", isJumping);
    }

    public void ChangeConditionAction(bool isAtack)
    {
        animator.SetBool("isAtack", isAtack);
    }

    public bool CheckMove()
    {
        return isMove;
    }

    public bool CheckRun()
    {
        return isRun;
    }

    public bool CheckJump()
    {
        return isJump;
    }

    public void InputControl()
    {
        //Store user input as a movement vector
        Vector3 m_Input = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        //CheckMove
        if (m_Input.x != 0 || m_Input.z != 0)
        {
            isMove = true;
        }
        else
        {
            isMove = false;
        }

        //Jump
        if (Input.GetKeyDown(KeyCode.Space) && isCanJump == true)
        {
            isCanJump = false;
            isJump = true;
            m_Rigidbody.AddForce(Vector2.up * jumpAmount, ForceMode.Impulse);
        }

        //JumpTolerance
        if (jumpTime >= jumpTimeTolerance)
        {
            jumpTime = 0;
            isCanJump = true;
            isJump = false;
        } 
        else if(jumpTime < jumpTimeTolerance)
        {
            jumpTime += 1;
        }

        //Sprint
        if (Input.GetKey(KeyCode.LeftShift))
        {
            m_Speed = runSpeed;
            isRun = true;
        }
        else
        {
            m_Speed = walkSpeed;
            isRun = false;
        }

        Debug.Log("Speed: "+ m_Speed);

        //Apply the movement vector to the current position, which is
        //multiplied by deltaTime and speed for a smooth MovePosition
        m_Rigidbody.MovePosition(transform.position + m_Input * Time.deltaTime * m_Speed);

        m_Input.Normalize();

        if (m_Input != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(m_Input, Vector3.up);

            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotateSpeed * Time.deltaTime);
        }
    }
}
