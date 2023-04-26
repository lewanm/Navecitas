using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Navecitas.Variables;


public class UiTest : MonoBehaviour
{
    [SerializeField] IntReference playerHp;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<Text>().text = $"Player HP: {playerHp.Value}";
    }
}
