using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Navecitas.Variables;


[CreateAssetMenu(fileName = "New Enemy", menuName = "ScriptableObject/Enemy/Basic")]
public class BasicEnemy : ScriptableObject
{
    public float VelocityX;
    public float VelocityY;
    public GameObject Bullet;
    public Sprite Sprite;
    public int InitialHp;
    public float ShootCooldown;
    //public bool CanShoot = true;
    public float  rotationSpeed;
    public int Pattern;



    //buscar coso para que se destruya al salir de la camara.
}
