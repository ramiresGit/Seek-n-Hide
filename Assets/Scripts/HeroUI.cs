using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeroUI : MonoBehaviour
{
    [SerializeField] 
    private GameObject image;

    private Image FearStatus;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeFearValue(float value)
    {
        if (image != null)
        {
            FearStatus = image.GetComponent<Image>();
            float val = Math.Abs(1 - ((float)value / 10) + 0.2f);
            Debug.Log(val);
            if(value != 0)
                FearStatus.fillAmount = val;
            else 
                FearStatus.fillAmount = 0;
        }
    }

}
