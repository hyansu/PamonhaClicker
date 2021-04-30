using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ControleJogo : MonoBehaviour
{
    //Coin quantity System
    public GameObject pamoneyWalletObj;
    public GameObject pamoneyCoinfab;
    public GameObject startCoinObj;  
    public GameObject cardReward;
    public GameObject cardRewardFinish;
    public GameObject cardTitleObj;
    public GameObject cardTextObj;
    public GameObject bronzeBadge;
    public GameObject silverBadge;
    public GameObject goldBadge;
    public GameObject btnNextObj;
    public GameObject textPamoneyEarnObj;
    public GameObject btnCloseCardObj;
    public GameObject rewardPlate;
    public GameObject rewardMillionPlate;
    public GameObject pauseGameObj;
    public AudioSource replayAudio;

    private Text cardTitle;
    private Text cardText;    
    private Text textPamoneyWallet;
    private Transform startCoin;
    public float coinSpeed;
    
    private int textNumber = 1;
  

    [Header("Bronze")] 
    public string bronzeTitle;
    public string[] bronzeText;
    public int bronzePlusCoins;
    public GameObject checkBronze;
    public AudioSource bronzeAudio;
            

    [Header("Silver")] 
    public string silverTitle;
    public string[] silverText;
    public int silverPlusCoins;
    public GameObject checkSilver;
    public AudioSource silverAudio;
        

    [Header("Gold")] 
    public string goldTitle;
    public string[] goldText;
    public int goldPlusCoins;
    public GameObject checkGold;
    public AudioSource goldAudio;

    [Header("Million")] 
    public GameObject checkMillion;
    public AudioSource millionAudio;

    [Space(20)]
    
    
    //Store Information
    private int pamoneyWallet;
    private int pamoneyEarn;

    // Start is called before the first frame update
    void Start()
    {
        pamoneyWallet = 0;
        pamoneyEarn = 1;
        textPamoneyWallet = pamoneyWalletObj.GetComponent<Text>();
        startCoin = startCoinObj.GetComponent<Transform>();
        cardTitle = cardTitleObj.GetComponent<Text>();
        cardText = cardTextObj.GetComponent<Text>();

    }
    // Update is called once per frame
    void Update()
    {    

    }

    public void ButtonPamonha()
    {
        if(!cardReward.activeSelf){
            ShowCoin();
            setPamoney();
        }

        switch(pamoneyWallet){
            case 100:
                textNumber = 1;
                cardTitle.text = bronzeTitle;
                cardText.text = bronzeText[0];
                btnNextObj.SetActive(true);
                btnCloseCardObj.SetActive(false);
                bronzeBadge.SetActive(true);
                pamoneyEarn =+ bronzePlusCoins;
                checkBronze.SetActive(true);
                ShowCardReward();
                bronzeAudio.Play(0);                
                break;
            case 300: 
                textNumber = 1;
                cardTitle.text = silverTitle;
                cardText.text = silverText[0];   
                btnNextObj.SetActive(true);
                btnCloseCardObj.SetActive(false);             
                bronzeBadge.SetActive(false);
                silverBadge.SetActive(true);
                pamoneyEarn =+ silverPlusCoins;
                checkSilver.SetActive(true);
                ShowCardReward();
                silverAudio.Play(0);                
                break;
            case 900:
                textNumber = 1;
                cardTitle.text = goldTitle;
                cardText.text = goldText[0];
                btnNextObj.SetActive(true);
                btnCloseCardObj.SetActive(false);
                silverBadge.SetActive(false);
                goldBadge.SetActive(true);
                pamoneyEarn =+ goldPlusCoins;
                checkGold.SetActive(true);
                ShowCardReward();
                goldAudio.Play(0);
                break;

            case 990900:
                pamoneyWallet -= 900;
                break;
            case 1000000:
                checkMillion.SetActive(true);
                ShowCardRewardFinish();          
                millionAudio.Play(0);
                break;
            }
    }
    
    public void ShowCoin(){
        GameObject Coin = Instantiate(pamoneyCoinfab, startCoin);
        string textplus = "+ " + pamoneyEarn.ToString();
        Coin.GetComponentInChildren<Text>().text = textplus;
        Destroy(Coin, 0.5f);
    }  

    public void setPamoney()
    {        
        pamoneyWallet = pamoneyWallet + pamoneyEarn;
        textPamoneyWallet.text = pamoneyWallet.ToString(); 
    } 

    public void ShowCardReward()
    {
        cardReward.SetActive(true);
    }

    public void ShowCardRewardFinish()
    {
        cardRewardFinish.SetActive(true);
    }

    public void CloseCardReward()
    {
        cardReward.SetActive(false);

        if(goldBadge.activeSelf){
            ChangeReward();
        }
    }

    public void ChangeReward()
    {
        rewardPlate.GetComponent<Animator>().Play("HideReward");
        //rewardPlate.SetActive(false);
        rewardMillionPlate.SetActive(true);
    }

    public void Replay()
    {
        replayAudio.Play(0);
        Invoke("ReloadScene", 2.16f);
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene("ClickerGame");
    }
    public void QuitGame()
    {
        Application.Quit();
    }

    public void ButtonPauseGame()
    {
        pauseGameObj.SetActive(true);
        Camera.main.GetComponent<AudioSource>().mute = true;
    }

    public void ButtonContinueGame()
    {
        pauseGameObj.SetActive(false);        
        Camera.main.GetComponent<AudioSource>().mute = false;
    }

    public void NextDialog()
    {
        if(bronzeBadge.activeSelf)
        {
            cardText.text = bronzeText[textNumber];
            textNumber++;
            if(textNumber >= bronzeText.Length)
            {
                btnCloseCardObj.SetActive(true);
                btnNextObj.SetActive(false);
            }
        }

        else if(silverBadge.activeSelf)
        {
            cardText.text = silverText[textNumber];
            textNumber++;
            if(textNumber >= silverText.Length)
            {
                btnCloseCardObj.SetActive(true);
                btnNextObj.SetActive(false);
            }
        }

        else if(goldBadge.activeSelf)
        {
            cardText.text = goldText[textNumber];
            textNumber++;
            if(textNumber >= goldText.Length)
            {
                btnCloseCardObj.SetActive(true);
                btnNextObj.SetActive(false);
            }
        }

    }

}
