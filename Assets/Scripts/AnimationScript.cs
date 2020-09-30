using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationScript : MonoBehaviour
{
    public Animator anim;
    public GameObject GameController;

    private int isAnimatingGREEN;
    private int isAnimatingRED;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        isAnimatingGREEN = GameController.GetComponent<GameControllerScript>().isAnimatingGREEN;
        isAnimatingRED = GameController.GetComponent<GameControllerScript>().isAnimatingRED;

        Debug.Log(isAnimatingGREEN);
        Debug.Log(isAnimatingRED);

        if (isAnimatingGREEN == 1)
        {
            Debug.Log("GREEN ANIMASYON OLMALI");
            anim.SetInteger("isTriggerd",1);
            anim.SetInteger("isTriggerd", 0);

            //delay

            GameController.GetComponent<GameControllerScript>().isAnimatingGREEN = 0;

        }
        if (isAnimatingRED == 1)
        {
            Debug.Log("RED ANIMASYON OLMALI");
            anim.SetInteger("isTriggerd", 1);
            anim.SetInteger("isTriggerd", 0);
            //anim.Play("GREEN");

            GameController.GetComponent<GameControllerScript>().isAnimatingGREEN = 0;
        }
    }

    void delay()
    {

    }
}
