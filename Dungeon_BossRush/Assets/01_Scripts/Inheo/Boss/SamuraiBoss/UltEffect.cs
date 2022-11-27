using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UltEffect : MonoBehaviour
{
    private void Update()
    {
        GameObject goImage = GameObject.Find("Canvas/Image");
        Color color = goImage.GetComponent<Image>().color;
        color.a += 1f * Time.deltaTime;
        goImage.GetComponent<Image>().color = color;
    }
}
