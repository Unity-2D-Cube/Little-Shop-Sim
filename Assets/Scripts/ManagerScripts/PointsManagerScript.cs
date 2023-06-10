using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PointsManagerScript : MonoBehaviour
{
    public static int appleAmount, blueFlowerAmount, roseFlowerAmount, yellowFlowerAmount, blueMushroomAmount, roseMushroomAmount, yellowMushroomAmount;
    public TextMeshProUGUI applePoints_txt, blueFlower_txt, roseFlower_txt, yellowFlower_txt, blueMushroom_txt, roseMushroom_txt, yellowMushroom_txt;

    private bool itemIsBought;

   [SerializeField] private Button blueCloth_btn;

    private void Start()
    {



        LoadData();
        
        if(itemIsBought ==  false)
        {
            StartCoroutine(CheckUnlockCoroutine());
        }
        else
        {
            StopCoroutine(CheckUnlockCoroutine());
        }



        
    }

    public void Update()
    {
        applePoints_txt.text = appleAmount.ToString();

        blueFlower_txt.text = blueFlowerAmount.ToString();
        roseFlower_txt.text = roseFlowerAmount.ToString();
        yellowFlower_txt.text = yellowFlowerAmount.ToString();

        blueMushroom_txt.text = blueMushroomAmount.ToString();
        roseMushroom_txt.text = roseMushroomAmount.ToString();
        yellowMushroom_txt.text = yellowMushroomAmount.ToString();

    }

    IEnumerator CheckUnlockCoroutine()
    {       

        while (true)
        {

            yield return new WaitForSecondsRealtime(.1f);

            
            
             if (blueFlowerAmount <= 100 | blueMushroomAmount <= 200)
             {
                 
                 blueCloth_btn.interactable = false;
             }
             else
             {

                blueCloth_btn.interactable = true;
             }
        }
        

    }

    public void BuyBlueFlower(int amount)
    {
        appleAmount -= amount;
        blueFlowerAmount += 5;
        SaveData();
    }

    public void BuyRoseFlower(int amount)
    {
        appleAmount -= amount;
        roseFlowerAmount += 10;
        SaveData();
    }

    public void BuyYellowFlower(int amount)
    {
        appleAmount -= amount;
        yellowFlowerAmount += 15;
        SaveData();
    }

    public void BuyBlueMushroom(int amount)
    {
        appleAmount -= amount;
        blueMushroomAmount += 5;
        SaveData();
    }

    public void BuyRoseMushroom(int amount)
    {
        appleAmount -= amount;
        roseMushroomAmount += 10;
        SaveData();
    }

    public void BuyYellowMushroom(int amount)
    {
        appleAmount -= amount;
        yellowMushroomAmount += 15;
        SaveData();
    }

    public void BuyBlueCloth(int amount)
    {
        itemIsBought = true;
        Debug.Log("" + itemIsBought);

        blueCloth_btn.interactable = false;
        blueFlowerAmount -= amount;
        blueMushroomAmount -= 200;
        SaveData();
    }


    public void AddPoints(int amount)
    {

        appleAmount = amount;

        blueFlowerAmount = amount;
        roseFlowerAmount = amount;
        yellowFlowerAmount = amount;

        blueMushroomAmount = amount;
        roseMushroomAmount = amount;
        yellowMushroomAmount = amount;

        SaveData();
    }


    public void RemovePoints()
    {

        appleAmount = 0;

        blueFlowerAmount = 0;
        roseFlowerAmount = 0;
        yellowFlowerAmount = 0;

        blueMushroomAmount = 0;
        roseMushroomAmount = 0;
        yellowMushroomAmount = 0;

        SaveData();
    }
    public void SaveData()
    {
        PlayerPrefs.SetInt("applePoints", appleAmount);

        PlayerPrefs.SetInt("blueFlowerPoints", blueFlowerAmount);
        PlayerPrefs.SetInt("roseFlowerPoints", roseFlowerAmount);
        PlayerPrefs.SetInt("yellowFlowerPoints", yellowFlowerAmount);

        PlayerPrefs.SetInt("blueMushroomPoints", blueMushroomAmount);
        PlayerPrefs.SetInt("roseMushroomPoints", roseMushroomAmount);
        PlayerPrefs.SetInt("yellowleMushroomPoints", yellowMushroomAmount);
    }
    public void LoadData()
    {
        appleAmount = PlayerPrefs.GetInt("applePoints");

        blueFlowerAmount = PlayerPrefs.GetInt("blueFlowerPoints");
        roseFlowerAmount = PlayerPrefs.GetInt("roseFlowerPoints");
        yellowFlowerAmount = PlayerPrefs.GetInt("yellowFlowerPoints");

        blueMushroomAmount = PlayerPrefs.GetInt("blueMushroomPoints");
        roseFlowerAmount = PlayerPrefs.GetInt("roseMushroomPoints");
        yellowFlowerAmount = PlayerPrefs.GetInt("yellowMushroomPoints");
    }




} // Class
