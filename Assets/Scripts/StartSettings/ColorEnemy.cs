using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorEnemy : MonoBehaviour
{
    private List<Color> trueColors = new List<Color>()
    {
        Color.red,
        Color.green,
        Color.blue,
        Color.white,
        Color.yellow,
        Color.cyan,
       
    };

    private List<Color> falseColor = new List<Color>();
    private Color colorEnemy;
    private int listnum = 0;
    public void ColorForEnemy()
    {
        colorEnemy = trueColors[listnum];
        listnum++;
        falseColor.Add(colorEnemy);
        
           gameObject.GetComponent<Image>().color = colorEnemy;
        if (listnum >= trueColors.Count) { listnum = 0; }
    }
}
