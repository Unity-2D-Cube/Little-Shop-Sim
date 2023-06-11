using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PointsManagerScript : MonoBehaviour
{
    public static int appleAmount, blueFlowerAmount, roseFlowerAmount, greenFlowerAmount, blueMushroomAmount, roseMushroomAmount, greenMushroomAmount;
    public TextMeshProUGUI applePoints_txt, blueFlower_txt, roseFlower_txt, greenFlower_txt, blueMushroom_txt, roseMushroom_txt, greenMushroom_txt;

    private bool blueClothIsBought = false;
    private bool roseClothIsBought = false;
    private bool greenClothIsBought = false;


    public GameObject blueCloth_obj;
    public GameObject roseCloth_obj;
    public GameObject greenCloth_obj;

    [SerializeField] private Button ultimate_btn_01;
    [SerializeField] private Button ultimate_btn_02;
    [SerializeField] private Button ultimate_btn_03;
    [SerializeField] private Button ultimate_btn_04;
    [SerializeField] private Button ultimate_btn_05;
    [SerializeField] private Button ultimate_btn_06;

    [SerializeField] private Button buyBlueCloth_btn;
    [SerializeField] private Button buyRoseCloth_btn;
    [SerializeField] private Button buyGreenCloth_btn;


    [SerializeField] private Button sellBlueCloth_btn;
    [SerializeField] private Button sellRoseCloth_btn;
    [SerializeField] private Button sellGreenCloth_btn;


    private void Start()
    {
        LoadData();

        StartCoroutine(CheckUnlockCoroutine());

        UpdateButtonInteractability();

    }

    public void Update()
    {
       
        applePoints_txt.text = appleAmount.ToString();

        blueFlower_txt.text = blueFlowerAmount.ToString();
        roseFlower_txt.text = roseFlowerAmount.ToString();
        greenFlower_txt.text = greenFlowerAmount.ToString();

        blueMushroom_txt.text = blueMushroomAmount.ToString();
        roseMushroom_txt.text = roseMushroomAmount.ToString();
        greenMushroom_txt.text = greenMushroomAmount.ToString();

    }

    IEnumerator CheckUnlockCoroutine()
    {

        while (true)
        {

            yield return new WaitForSecondsRealtime(.1f);

            

            if (appleAmount <= 0)
            {

                ultimate_btn_01.interactable = false;
                ultimate_btn_02.interactable = false;
                ultimate_btn_03.interactable = false;
                ultimate_btn_04.interactable = false;   
                ultimate_btn_05.interactable = false;
                ultimate_btn_06.interactable = false;
            }
            else
            {

                ultimate_btn_01.interactable = true;
                ultimate_btn_02.interactable = true;
                ultimate_btn_03.interactable = true;
                ultimate_btn_04.interactable = true;
                ultimate_btn_05.interactable = true;
                ultimate_btn_06.interactable = true;
            }

        }
    }



    private void UpdateButtonInteractability()
    {       
        buyBlueCloth_btn.interactable = !blueClothIsBought && !(blueFlowerAmount < 9 || blueMushroomAmount < 4);

        buyRoseCloth_btn.interactable = !roseClothIsBought && !(roseFlowerAmount < 9 || roseMushroomAmount < 4);

        buyGreenCloth_btn.interactable = !greenClothIsBought && !(greenFlowerAmount < 9 || greenMushroomAmount < 4);


        sellBlueCloth_btn.interactable = blueClothIsBought;

        sellRoseCloth_btn.interactable = roseClothIsBought;

        sellGreenCloth_btn.interactable = greenClothIsBought;
    }


    public void BuyBlueFlower(int amount)
    {
        UpdateButtonInteractability();
        appleAmount -= amount;
        blueFlowerAmount += 1;
        SaveData();
    }

    public void BuyRoseFlower(int amount)
    {
        UpdateButtonInteractability();
        appleAmount -= amount;
        roseFlowerAmount += 1;
        SaveData();
    }

    public void BuyGreenFlower(int amount)
    {
        UpdateButtonInteractability();
        appleAmount -= amount;
        greenFlowerAmount += 1;
        SaveData();
    }

    public void BuyBlueMushroom(int amount)
    {
        UpdateButtonInteractability();
        appleAmount -= amount;
        blueMushroomAmount += 1;
        SaveData();
    }

    public void BuyRoseMushroom(int amount)
    {
        UpdateButtonInteractability();
        appleAmount -= amount;
        roseMushroomAmount += 1;
        SaveData();
    }

    public void BuyGreenMushroom(int amount)
    {
        UpdateButtonInteractability();
        appleAmount -= amount;
        greenMushroomAmount += 1;
        SaveData();
    }

    public void BuyBlueCloth(int amount)
    {
        blueClothIsBought = true;

        UpdateButtonInteractability();

        blueCloth_obj.SetActive(true);
        roseCloth_obj.SetActive(false);
        greenCloth_obj.SetActive(false);


        blueFlowerAmount -= amount;
        blueMushroomAmount -= 5;
        SaveData();
    }
    public void BuyRoseCloth(int amount)
    {
        roseClothIsBought = true;

        UpdateButtonInteractability();

        blueCloth_obj.SetActive(false);
        roseCloth_obj.SetActive(true);
        greenCloth_obj.SetActive(false);


        roseFlowerAmount -= amount;
        roseMushroomAmount -= 5;
        SaveData();
    }
    public void BuyGreenCloth(int amount)
    {
        greenClothIsBought = true;

        UpdateButtonInteractability();

        blueCloth_obj.SetActive(false);
        roseCloth_obj.SetActive(false);
        greenCloth_obj.SetActive(true);


        greenFlowerAmount -= amount;
        greenMushroomAmount -= 5;
        SaveData();
    }


    public void SellBlueCloth()
    {

        UpdateButtonInteractability();

        blueClothIsBought = false;
        blueCloth_obj.SetActive(false);
        sellBlueCloth_btn.interactable = false;
        buyBlueCloth_btn.interactable = true;    


        blueFlowerAmount += 1;
        blueMushroomAmount += 1;
        SaveData();
    }   
    public void SellRoseCloth()
    {
        UpdateButtonInteractability();

        roseClothIsBought = false;
        roseClothIsBought = false;
        roseCloth_obj.SetActive(false);
        sellRoseCloth_btn.interactable = false;

       
        roseFlowerAmount += 1;
        roseMushroomAmount += 1;
        SaveData();
    }    
    public void SellGreenCloth()
    {
        UpdateButtonInteractability();

        greenClothIsBought = false;
        greenClothIsBought = false;
        greenCloth_obj.SetActive(false);
        sellGreenCloth_btn.interactable = false;

         
        greenFlowerAmount += 1;
        greenMushroomAmount += 1;
        SaveData();
    }

    public void BuyUltimateButton()
    {
        UpdateButtonInteractability();
    }

    public void AddPoints(int amount)
    {
        appleAmount = amount;

        blueFlowerAmount = amount;
        roseFlowerAmount = amount;
        greenFlowerAmount = amount;

        blueMushroomAmount = amount;
        roseMushroomAmount = amount;
        greenMushroomAmount = amount;
        UpdateButtonInteractability();
        SaveData();
    }


    public void RemovePoints()
    {
        appleAmount = 0;

        blueFlowerAmount = 0;
        roseFlowerAmount = 0;
        greenFlowerAmount = 0;

        blueMushroomAmount = 0;
        roseMushroomAmount = 0;
        greenMushroomAmount = 0;
        UpdateButtonInteractability();
        SaveData();
    }
    public void SaveData()
    {
        PlayerPrefs.SetInt("applePoints", appleAmount);

        PlayerPrefs.SetInt("blueFlowerPoints", blueFlowerAmount);
        PlayerPrefs.SetInt("roseFlowerPoints", roseFlowerAmount);
        PlayerPrefs.SetInt("greenFlowerPoints", greenFlowerAmount);

        PlayerPrefs.SetInt("blueMushroomPoints", blueMushroomAmount);
        PlayerPrefs.SetInt("roseMushroomPoints", roseMushroomAmount);
        PlayerPrefs.SetInt("greenleMushroomPoints", greenMushroomAmount);
    }
    public void LoadData()
    {
        appleAmount = PlayerPrefs.GetInt("applePoints");

        blueFlowerAmount = PlayerPrefs.GetInt("blueFlowerPoints");
        roseFlowerAmount = PlayerPrefs.GetInt("roseFlowerPoints");
        greenFlowerAmount = PlayerPrefs.GetInt("greenFlowerPoints");

        blueMushroomAmount = PlayerPrefs.GetInt("blueMushroomPoints");
        roseFlowerAmount = PlayerPrefs.GetInt("roseMushroomPoints");
        greenFlowerAmount = PlayerPrefs.GetInt("greenMushroomPoints");
    }
} // Class
