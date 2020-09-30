using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameControllerScript : MonoBehaviour
{
    //tabakları public olarak al
    //tabakların içinde bool olarak isSelected olacak
    public GameObject tabak1;
    public GameObject tabak2;
    public GameObject tabak3;
    public GameObject tabak4;
    public GameObject tabak5;
    public GameObject sendButton;

    string currentValues_str;
    string result;

    string[] currentValues = new string[5];
    GameObject[] tabaklar = new GameObject[5];

    /****** GAME MANAGEMENT ********/

    int Money = 200;
    int health = 3;
    public GameObject kalp1;
    public GameObject kalp2;
    public GameObject kalp3;
    public Text moneyObj;

    /****** SPRITES *******/
    static int numberofSprites = 20;
    public SpriteRenderer spriteRenderer;
    int currentIndex;

    public Sprite[] burgerSprite = new Sprite[numberofSprites];
    public string[,] num = new string[numberofSprites, 1];    // num[0,0] = 10000

    public int isAnimatingRED = 0;
    public int isAnimatingGREEN = 0;

    public Sprite[] karaTabakArr = new Sprite[5];
    public Sprite[] tabakArr = new Sprite[5];
    public Sprite butonbasik;
    public Sprite butonbasikdegil;

    /*********************/

    void Start()
    {
        //tabak1.GetComponent<ObjectClickerScript>().isSelected = 1;

        tabaklar[0] = tabak1;
        tabaklar[1] = tabak2;
        tabaklar[2] = tabak3;
        tabaklar[3] = tabak4;
        tabaklar[4] = tabak5;

        //array of Burger positions
        num[0, 0] = "01000";            // 1 KöFTE, 2 DOMATES, 3 PEYNIR
        num[1, 0] = "00010";            // 4 MARUL, 5 EKMEK
        num[2, 0] = "10000";
        num[3, 0] = "00100";
        num[4, 0] = "00001";
        num[5, 0] = "00001";
        num[6, 0] = "01010";
        num[7, 0] = "01001";
        num[8, 0] = "01100";
        num[9, 0] = "01001";
        num[10, 0] = "10010";
        num[11, 0] = "00110";
        num[12, 0] = "00011";
        num[13, 0] = "10100";
        num[14, 0] = "10001";
        num[15, 0] = "10010";
        num[16, 0] = "11010";
        num[17, 0] = "01110";
        num[18, 0] = "11100";
        num[19, 0] = "10010";

        //select random burger
        currentIndex = Random.Range(0, numberofSprites - 1);
        spriteRenderer.sprite = burgerSprite[currentIndex];
    }


    void Update()
    {
        //göndere basıldığında Tek tek objelerin tabak1.isSelected değerlerini alıp arraye atılacak
        //currentValues arrayi burger.array ine eşitse DOĞRU uyuşmuyorsa YANLIŞ
        
        if(health == 2)
        {
            kalp1.transform.localScale = new Vector3(0, 0, 0);
        }
        else if(health == 1)
        {
            kalp2.transform.localScale = new Vector3(0, 0, 0);
        }else if(health == 0)
        {
            SceneManager.LoadScene("GameOver");
        }

        if(Money == 0)
        {
            SceneManager.LoadScene("WIN");
        }

        /** IS HOVER 1 ***/
        for (int i = 0; i < 5; i++)
        {
            if (tabaklar[i].GetComponent<TabakScript>().isHover == "1")
            {
                tabaklar[i].GetComponent<SpriteRenderer>().sprite = karaTabakArr[i];
            }
        }

        /** IS HOVER 0 ***/
        for (int i = 0; i < 5; i++)
        {
            if (tabaklar[i].GetComponent<TabakScript>().isHover == "0")
            {
                tabaklar[i].GetComponent<SpriteRenderer>().sprite = tabakArr[i];
            }
        }

        /*** IS SELECTED 1 ***/
        for (int i = 0; i < 5; i++)
        {
            if (tabaklar[i].GetComponent<TabakScript>().isSelected == "1")
            {
                tabaklar[i].GetComponent<SpriteRenderer>().sprite = karaTabakArr[i];
            }
        }





        if (sendButton.GetComponent<SendButtonScript>().isClicked == 1){
            //find current array
            //change button sprite to butonbasik;
            sendButton.GetComponent<SpriteRenderer>().sprite = butonbasik;
            Invoke("butonplay", 1);
                


            for (int i=0; i< 5; i++)
            {
               if(tabaklar[i].GetComponent<TabakScript>().isSelected == "1")
                {
                    currentValues[i] = "1";
                }
                else
                {
                    currentValues[i] = "0";
                } 
            }

            //isHover == 0;
            if (tabak1.GetComponent<TabakScript>().isHover == "1")
            {
                tabak1.GetComponent<SpriteRenderer>().sprite = tabakArr[0];
                tabak1.GetComponent<TabakScript>().isHover = "0";
            }
            if (tabak2.GetComponent<TabakScript>().isHover == "1")
            {
                tabak2.GetComponent<SpriteRenderer>().sprite = tabakArr[1];
                tabak2.GetComponent<TabakScript>().isHover = "0";
            }
            if (tabak3.GetComponent<TabakScript>().isHover == "1")
            {
                tabak3.GetComponent<SpriteRenderer>().sprite = tabakArr[2];
                tabak3.GetComponent<TabakScript>().isHover = "0";
            }
            if (tabak4.GetComponent<TabakScript>().isHover == "1")
            {
                tabak4.GetComponent<SpriteRenderer>().sprite = tabakArr[3];
                tabak4.GetComponent<TabakScript>().isHover = "0";
            }
            if (tabak5.GetComponent<TabakScript>().isHover == "1")
            {
                tabak5.GetComponent<SpriteRenderer>().sprite = tabakArr[4];
                tabak5.GetComponent<TabakScript>().isHover = "0";
            }

            //pass array to string
            currentValues_str = string.Join("", currentValues);
            Debug.Log("Current Array: "+ currentValues_str);

            //test for num != currentValues
            string result = num[currentIndex, 0];
            Debug.Log("Result Array: " + result);
            if (result == currentValues_str)
            {
                Debug.Log("DOĞRU CEVAP!");
                //para azalıcak
                //animation GREEN olacak
                isAnimatingGREEN = 1;
                
                //delay 0.1 sec
                Money -= 10;
                moneyObj.text = "-"+Money;

                currentIndex = Random.Range(0, numberofSprites - 1);
                spriteRenderer.sprite = burgerSprite[currentIndex];

                Arraysifirla();
                selectsifirla();
                sendButton.GetComponent<SendButtonScript>().isClicked = 0;

            }
            else
            {
                Debug.Log("YANLIŞ CEVAP");
                //para artacak
                //animation RED olacak
                isAnimatingRED = 1;
                //delay 0.1 sec
                health--;
                Money += 10;
                moneyObj.text = "-"+Money;


                currentIndex = Random.Range(0, numberofSprites - 1);
                spriteRenderer.sprite = burgerSprite[currentIndex];

                //current array sıfırla
                Arraysifirla();
                selectsifirla();
                sendButton.GetComponent<SendButtonScript>().isClicked = 0;

            }
        }
    }


    public void butonplay()
    {
        sendButton.GetComponent<SpriteRenderer>().sprite = butonbasikdegil;
    }

    void Arraysifirla()
    {
        for (int i = 0; i < 5; i++)
        {
                currentValues[i] = "0";
        }
    }
    void selectsifirla()
    {
        for (int i = 0; i < 5; i++)
        {
            tabaklar[i].GetComponent<TabakScript>().isSelected = "0";
        }
    }
}
