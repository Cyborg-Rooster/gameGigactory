﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

class UIManager
{
    public static void SetBeltButtonAction(GameObject button, ShedController controller)
    {
        button.GetComponent<Button>().onClick.AddListener(delegate { controller.Addbelt(); });
    }

    public static void SetText(GameObject text, object value) 
    {
        text.GetComponent<Text>().text = value.ToString();
    }

    public static void SetSliderValue(GameObject slider, float value)
    {
        slider.GetComponent<Slider>().value = value;
    }

    public static void SetImage(GameObject container, Sprite sprite)
    {
        var image = container.GetComponent<Image>();

        image.sprite = sprite;
        image.SetNativeSize();
    }
}
