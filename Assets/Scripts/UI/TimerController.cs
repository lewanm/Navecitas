using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Navecitas.Variables;

public class TimerController : MonoBehaviour
{
    Text text;
    [SerializeField] FloatReference timer;
    void Start()
    {

        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = $"Tiempo: {Mathf.RoundToInt(timer.Value)}";
    }
}
