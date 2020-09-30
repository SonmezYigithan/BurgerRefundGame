using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SendButtonScript : MonoBehaviour
{
    // 
    public int isClicked = 0;
    public AudioSource audioSrc;
    private void OnMouseDown()
    {
        isClicked = 1;
        audioSrc.Play();

        //highlight object
    }


}
