using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyManager : MonoBehaviour
{
    public Image hpBar;
    public float maxHP;
    public float curHP;

    public ParticleSystem MeleePs;
    public ParticleSystem HeavyAttackPs;
    public ParticleSystem RangeAttackPs;
    public ParticleSystem SpellAttackPs;

    public int meleeCounter;
    public int rangeCounter;

    public Transform player;
    public float speed = 15;
    public bool isLookingAtPlayer;

    public float timer;
    public GameObject tornadoPrefab;
    public GameObject TornadoClone;
    public bool IsTornadoSpawned;
    public bool IsMonsterDead;
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        curHP = maxHP;
        animator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("player").transform;
        isLookingAtPlayer = false;
        IsTornadoSpawned = false;
        IsMonsterDead = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (isLookingAtPlayer == true)
        {
            transform.LookAt(player.transform.position);
        }
        hpBar.fillAmount = curHP / maxHP;

        if (curHP <= 30  && !IsTornadoSpawned && !IsMonsterDead)
        {
            animator.SetBool("IsSpecialAttack", true);
            animator.SetBool("IsSpellAttack", false);
            animator.SetBool("IsRangeAttack", false);
            animator.SetBool("IsMelee", false);
            animator.SetBool("IsHeavyAttack", false);
            animator.SetBool("IsChase", false);
        }

        if(curHP <= 0 && !IsMonsterDead && IsTornadoSpawned)
        {
            animator.SetBool("IsDead", true);
            animator.SetBool("IsSpecialAttack", false);
            animator.SetBool("IsSpellAttack", false);
            animator.SetBool("IsRangeAttack", false);
            animator.SetBool("IsMelee", false);
            animator.SetBool("IsHeavyAttack", false);
            animator.SetBool("IsChase", false);
        }
    }

    public void MeleeAttackExplosion()
    {
        MeleePs.Play();
    }
    public void HeavyAttackExplosion()
    {
        HeavyAttackPs.Play();
    }
    public void RangeAttackParticleExplosion()
    {
        RangeAttackPs.Play();
    }
    public void SpellAttackParticleExplosion()
    {
        SpellAttackPs.Play();
    }
    public void GoLookAtPlayer()
    {
        isLookingAtPlayer = true;
    }
    public void MeleeAttackCounter()
    {
        meleeCounter ++;
    }
    public void RangeAttackCounter()
    {
        rangeCounter ++;
    }

    public void spawnTornado()
    {
        IsTornadoSpawned = true;
        TornadoClone = Instantiate(tornadoPrefab, transform.position, Quaternion.identity) as GameObject;
    }

    public void MonsterDead()
    {
        IsMonsterDead = true;
/*        animator.SetBool("IsDead", false);
        animator.SetBool("IsSpecialAttack", false);
        animator.SetBool("IsSpellAttack", false);
        animator.SetBool("IsRangeAttack", false);
        animator.SetBool("IsMelee", false);
        animator.SetBool("IsHeavyAttack", false);
        animator.SetBool("IsChase", false);
*/
       
    }
}
