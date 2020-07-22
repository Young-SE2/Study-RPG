using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerState
{
    Walk,
    Attack,
    Interact
}
public class PlayerMovement : MonoBehaviour
{
    public PlayerState currentState;
    public float speed;
    private Rigidbody2D myRigidbody;
    private Vector3 change;
    private Animator animator;


    // Use this for initialization
    void Start()
    {
        currentState = PlayerState.Walk;
        animator = GetComponent<Animator>();
        myRigidbody = GetComponent<Rigidbody2D>();
        animator.SetFloat("MoveY", 0);
        animator.SetFloat("MoveX", -1);
    }

    // Update is called once per frame
    void Update()
    {       
        change = Vector3.zero;
        change.x = Input.GetAxisRaw("Horizontal");
        change.y = Input.GetAxisRaw("Vertical");
        if (Input.GetButton("Attack") && (currentState != PlayerState.Attack))
        {
            StartCoroutine(AttackCo());
        }
        else if (currentState == PlayerState.Walk)
        {
            UpdateAnimationsAndMove();
        }
    }

    private IEnumerator AttackCo()
    {
        animator.SetBool("Attacking", true);
        currentState = PlayerState.Attack;
        yield return null;
        animator.SetBool("Attacking", false);
        yield return new WaitForSeconds(.3f);
        currentState = PlayerState.Walk;
    }
    void UpdateAnimationsAndMove()
    {
        change = Vector3.zero;
        change.x = Input.GetAxisRaw("Horizontal");
        change.y = Input.GetAxisRaw("Vertical");
        if (change != Vector3.zero)
        {
            MoveCharacter();
            animator.SetFloat("MoveX", change.x);
            animator.SetFloat("MoveY", change.y);
            animator.SetBool("Moving", true);
        }
        else
            animator.SetBool("Moving", false);
    }

    void MoveCharacter()
    {
        change.Normalize();
        myRigidbody.MovePosition(
                transform.position + change * speed * Time.deltaTime
            );
    }

}
