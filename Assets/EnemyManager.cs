using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyManager : MonoBehaviour
{
    public Image hpBar;
    public float maxHP;
    public float curHP;
    public ParticleSystem ps;
    public int meleeCounter;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        hpBar.fillAmount = curHP / maxHP;
    }

    public void MeleeAttackExplosion()
    {
        ps.Play();
    }

    public void MeleeAttackCounter()
    {
        meleeCounter ++;
    }
}
