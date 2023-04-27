using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Manager : MonoBehaviour
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
    public Player_Manager playerScript;

    // Start is called before the first frame update
    void Start()
    {
        isAttacking = false;
        enemy = GameObject.FindGameObjectWithTag("Enemy");
        playerScript = GetComponent<Player_Manager>();
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

        if (Input.GetKeyDown(KeyCode.S))
        {
            transform.Rotate(0, 180, 0);
        }


        if(enemyScript.curHP == 0)
        {
            anim.GetComponent<Animator>().enabled = false;
            playerScript.enabled = false;
        }
    }
    private void FixedUpdate()
    {

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.D))
        {
            PlayerRun();
            isRunning = true;
            anim.SetBool("isAttacking", false);
            anim.SetBool("isRolling", false);
            anim.SetBool("isIdle", false);
            anim.SetBool("isRunning", true);
        }
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

        if (distance < 10 && Input.GetKeyUp(KeyCode.Mouse0))
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
