using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabakScript : MonoBehaviour
{
    //tabakların içinde bool olarak isSelected olacak
    //Seçilen Tabak highlightlanacak

    public string isSelected = "0";
    public string isHover = "0";

    private void OnMouseDown()
    {
        isSelected = "1";
        //hover spirte
        Debug.Log(transform.name+"-"+isSelected);
        //highlight object
    }

    void OnMouseEnter()
    {
        Debug.Log("Mouse is over "+transform.name);
        isHover = "1";
    }

    void OnMouseExit()
    {
        isHover = "0";
    }





}
