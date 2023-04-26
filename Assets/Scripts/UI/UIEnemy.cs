using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Navecitas.Variables;
using UnityEngine.UI;

public class UIEnemy : MonoBehaviour
    
{
    [SerializeField] IntReference bossHp;

    //esto lo hago asi porque ya me pudri (?)
    [SerializeField] GameObject Boss;


    void Update()
    { 
      gameObject.GetComponent<Text>().text = Boss.activeSelf ? bossHp.Value + " :Enemy HP" : "";
    }
}
