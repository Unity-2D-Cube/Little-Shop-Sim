using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PointsManagerScript : MonoBehaviour
{
    public static int appleAmount, blueFlowerAmount, purpleFlowerAmount, yellowFlowerAmount, blueMushroomAmount, purpleMushroomAmount, yellowMushroomAmount;
    public TextMeshProUGUI applePoints_txt, blueFlower_txt, purpleFlower_txt, yellowFlower_txt, blueMushroom_txt, purpleMushroom_txt, yellowMushroom_txt;

    private void Start()
    {
        Load();
    }

    public void Update()
    {
        applePoints_txt.text = appleAmount.ToString();

        blueFlower_txt.text = blueFlowerAmount.ToString();
        purpleFlower_txt.text = purpleFlowerAmount.ToString();
        yellowFlower_txt.text = yellowFlowerAmount.ToString();

        blueMushroom_txt.text = blueMushroomAmount.ToString();
        purpleMushroom_txt.text = purpleMushroomAmount.ToString();
        yellowMushroom_txt.text = yellowMushroomAmount.ToString();


    }

    public void BuyBlueFlower(int amount)
    {
        appleAmount -= amount;
        blueFlowerAmount += 10;
        Save();
    }
    public void SubtractScore(int amount)
    {

        appleAmount -= amount;
        Save();
    }
    public void Save()
    {
        PlayerPrefs.SetInt("applePoints", appleAmount);

        PlayerPrefs.SetInt("blueFlowerPoints", blueFlowerAmount);
        PlayerPrefs.SetInt("purpleFlowerPoints", purpleFlowerAmount);
        PlayerPrefs.SetInt("yellowFlowerPoints", yellowFlowerAmount);

        PlayerPrefs.SetInt("blueMushroomPoints", blueMushroomAmount);
        PlayerPrefs.SetInt("purpleMushroomPoints", purpleMushroomAmount);
        PlayerPrefs.SetInt("yellowleMushroomPoints", yellowMushroomAmount);
    }
    public void Load()
    {
        appleAmount = PlayerPrefs.GetInt("applePoints");

        blueFlowerAmount = PlayerPrefs.GetInt("blueFlowerPoints");
        purpleFlowerAmount = PlayerPrefs.GetInt("purpleFlowerPoints");
        yellowFlowerAmount = PlayerPrefs.GetInt("yellowFlowerPoints");

        blueMushroomAmount = PlayerPrefs.GetInt("blueMushroomPoints");
        purpleFlowerAmount = PlayerPrefs.GetInt("purpleMushroomPoints");
        yellowFlowerAmount = PlayerPrefs.GetInt("yellowMushroomPoints");
    }




} // Class
