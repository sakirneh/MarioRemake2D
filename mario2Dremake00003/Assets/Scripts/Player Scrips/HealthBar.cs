using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] public PlayerHealthScript playerhealth;
    [SerializeField] private Image totalhealthbar;
    [SerializeField] private Image currenthealthbar;

    

    private void Start()
    {
        totalhealthbar.fillAmount = playerhealth.playerH / 10f;
    }

    private void Update()
    {
        currenthealthbar.fillAmount = playerhealth.playerH / 10f;
    }


}
