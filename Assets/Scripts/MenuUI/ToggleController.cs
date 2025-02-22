using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ToggleController : MonoBehaviour
{

    public TextMeshProUGUI TextToggle;
    public Image ImageOn;
    public Image ImageOff;

    public void ToggleUsing()
    {
        if (!ImageOff.IsActive())
        {
            ImageOn.gameObject.SetActive(false);
            ImageOff.gameObject.SetActive(true);
            TextToggle.text = "Off";
        }
        else if (!ImageOn.IsActive())
        {
            ImageOn.gameObject.SetActive(true);
            ImageOff.gameObject.SetActive(false);
            TextToggle.text = "On";
        }
    }
}
