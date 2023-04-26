using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Navecitas.Variables;

public class BossController : MonoBehaviour
{
    [SerializeField] IntReference hp;
    [SerializeField] BossEnemy Boss;
    [SerializeField] Pattern[] PatternList;

    bool shootInCd = false;


    void Awake()
    {
        hp.Value = Boss.InitialHp;
        gameObject.GetComponent<SpriteRenderer>().sprite = Boss.Sprite;
        transform.Translate(0, 0, 0);
    }



    void Update()
    {
        Shoot();
        CheckHp();
    }



    void Shoot()
    {
        if (!shootInCd)
        {
            if (hp.Value >= Boss.InitialHp * 0.7) placeholderPattern();
            if (hp.Value >= Boss.InitialHp * 0.3 && hp.Value < Boss.InitialHp * 0.7) StarPattern();
            else placeholderPattern();
        }
    }

    void StarPattern()
    {
        //VER SI ESTOY LO HAGO COMO UN SCRIPTABLE OBJECT
        float shootCd = 0.9f;
        int bulletAmount = 40;
        int dividier = 5;
        float x = 360 / bulletAmount; //angulo
        
        for (int i = 0; i < bulletAmount; i++)
        {
            float resultado = Mathf.Abs(Mathf.Sin((dividier * x*i * Mathf.PI) / 360));
  
            
            GameObject instance = Instantiate(Boss.Bullet, transform.position, Quaternion.Euler(0, 0, x * i));
            BulletController bc = instance.GetComponent<BulletController>();
            bc.perspective = gameObject.tag;
            bc.Substract = resultado; //Esta ultima linea, es para generar el patron

        }
        StartCoroutine(ShootCoroutine(shootCd));

    }

    void placeholderPattern()
    {
        float shootCd = PatternList[1].ShootCD;
        int bulletAmount = PatternList[1].BulletAmount;
        float x = 360 / bulletAmount;

        for (int i = 0; i < bulletAmount; i++)
        {
            GameObject instance = Instantiate(Boss.Bullet, transform.position, Quaternion.Euler(0, 0, x * i));
            BulletController bc = instance.GetComponent<BulletController>();
            bc.perspective = gameObject.tag;
            bc.Multiplier = PatternList[1].VelocityMultiplier;
            bc.changeThisName = PatternList[1].VelocityReducer ;

        }
        StartCoroutine(ShootCoroutine(shootCd));
    }

    IEnumerator ShootCoroutine(float time)
    {
        shootInCd = true;
        yield return new WaitForSeconds(time);
        shootInCd = false;
    }

    
    void CheckHp()
    {
        if (hp.Value <= 0) Destroy(gameObject);
    }

    public void TakeDamage(int damage)
    {
        hp.Value -= damage;
    }

}
