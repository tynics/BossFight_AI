using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int health = 10;
    public int damage = 1;

    public float playerRunSpeed = 6.0f;
    public float playerSprintSpeed = 13.0f;
    public float playerRollSpeed = 5.0f;
    public bool isRunning = false;
    public float rotationSpeed = 50.0f;

    public Animator anim;

    public bool isAttacking = false;
    public EnemyManager enemyScript;
    public GameObject enemy;

    // Start is called before the first frame update
    void Start()
    {
        isAttacking = false;
        enemy = GameObject.FindGameObjectWithTag("Enemy");
    }

    private void Update()
    {
        PlayerRotate();
        PlayerRoll();
        PlayerAttack();
        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.S))
        {
            isRunning = false;
            anim.SetBool("isAttacking", false);
            anim.SetBool("isRunning", false);
            anim.SetBool("isRolling", false);
            anim.SetBool("isIdle", true);
        }
        
        if (Input.GetKeyUp(KeyCode.LeftAlt) && (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.S)))
        {
            anim.SetBool("isAttacking", false);
            anim.SetBool("isRunning", false);
            anim.SetBool("isRolling", false);
            anim.SetBool("isSprint", false);
            anim.SetBool("isIdle", true);

        }
    }
    private void FixedUpdate()
    {

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.S))
        {
            PlayerRun();
            isRunning = true;
            anim.SetBool("isAttacking", false);
            anim.SetBool("isRolling", false);
            anim.SetBool("isIdle", false);
            anim.SetBool("isSprint", false);
            anim.SetBool("isRunning", true);
        }
        
        if (Input.GetKey(KeyCode.LeftAlt) && (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.S)) )
        {
            PlayerSprint();
            anim.SetBool("isAttacking", false);
            anim.SetBool("isRolling", false);
            anim.SetBool("isIdle", false);
            anim.SetBool("isRunning", false);
            anim.SetBool("isSprint", true);
        }
    }

    private void PlayerSprint()
    { 
        //float horizontalMovement = Input.GetAxis("Horizontal") * playerRunSpeed * Time.deltaTime;
        float verticalSprintMovement = Input.GetAxis("Vertical") * playerSprintSpeed * Time.deltaTime;

        Vector3 movement = new Vector3(0, 0, verticalSprintMovement);
        transform.Translate(movement);
    }

    private void PlayerRun()
    {
        //float horizontalMovement = Input.GetAxis("Horizontal") * playerRunSpeed * Time.deltaTime;
        float verticalRunMovement = Input.GetAxis("Vertical") * playerRunSpeed * Time.deltaTime;

        Vector3 movement = new Vector3(0, 0, verticalRunMovement);
        transform.Translate(movement);
    }

    private void PlayerRotate()
    {
        float rotation = Input.GetAxisRaw("Horizontal") * rotationSpeed;

        rotation *= Time.deltaTime;

        // Rotate around our y-axis
        transform.Rotate(0, rotation, 0);
    }

    private void PlayerAttack()
    {
        float distance = Vector3.Distance(transform.position, enemy.transform.position);
        if (Input.GetKey(KeyCode.Mouse0))
        {
            anim.SetBool("isRolling", false);
            anim.SetBool("isRunning", false);
            anim.SetBool("isIdle", false);
            anim.SetBool("isAttacking", true);
        }

        if (distance < 5 && Input.GetKeyUp(KeyCode.Mouse0))
        {
            enemyScript.curHP -= damage;
           Debug.Log("enemy health: " + enemyScript.curHP);
        }
    }



    private void PlayerRoll()
    {
        if (Input.GetKey(KeyCode.LeftShift) && ((Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.S))))
        {
            float horizontalRollMovement = Input.GetAxis("Horizontal") * playerRollSpeed * Time.deltaTime;
            float verticalRollMovement = Input.GetAxis("Vertical") * playerRollSpeed * Time.deltaTime;

            Vector3 movement = new Vector3(horizontalRollMovement, 0, verticalRollMovement);
            transform.Translate(movement);


            anim.SetBool("isRunning", false);
            anim.SetBool("isIdle", false);
            anim.SetBool("isAttacking", false);
            anim.SetBool("isRolling", true);
        }
    }
}




