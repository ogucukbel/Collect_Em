using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CanvasController : MonoBehaviour
{
    [Header ("Variables")]
    [SerializeField] private IntVariable currencyAmount;
    [SerializeField] private FloatVariable stackAmount;
    [SerializeField] private IntVariable upgradeLevel;

    [Header ("UI Objects")]
    [SerializeField] private GameObject winPanel;
    [SerializeField] private Button nextLevelButton;
    [SerializeField] private Button upgradeButton;
    [SerializeField] private Text upgradeButtonValueText;
    [SerializeField] private Text currencyText;
    [SerializeField] private RectTransform levelCountUI;
    [SerializeField] private RectTransform currencyUI;
    [SerializeField] private RectTransform restartUI;
    [SerializeField] private GameObject tapToStart;
    [SerializeField] private Text levelNumberText;
    private InputManager inputManager;
    private int level;
    
    private void OnEnable() 
    {
        inputManager = GetComponentInChildren<InputManager>();

        if(PlayerPrefs.HasKey("upgrade"))
        {
            upgradeLevel.SetValue(PlayerPrefs.GetInt("upgrade"));
            if(upgradeLevel.GetValue() <= 0)
            {
                upgradeLevel.SetValue(1);
            }
        }
        else
        {
            upgradeLevel.SetValue(1);
        }

        if(PlayerPrefs.HasKey("currency"))
        {
            currencyAmount.SetValue(PlayerPrefs.GetInt("currency"));
            
            
        }
        else 
        {
            currencyAmount.SetValue(0);
        }
        
        if(PlayerPrefs.HasKey("level"))
        {
            level = PlayerPrefs.GetInt("level");
            
            
        }
        else 
        {
            level = 1;
        }

        levelNumberText.text = "Level " + level;
        stackAmount.Increase(upgradeLevel.GetValue() * 10);
        upgradeButtonValueText.text = ((upgradeLevel.GetValue() * 100) + 100).ToString();
    }
    private void Update() 
    {
        if(inputManager.touched)
        {
            levelCountUI.LeanMoveY(-250, 0.5f);
            currencyUI.LeanMoveX(-25, 0.5f);
            restartUI.LeanMoveX(125, 0.5f);
            tapToStart.SetActive(false);
            upgradeButton.gameObject.SetActive(false);
        }    
        currencyText.text = currencyAmount.GetValue().ToString();
        if(PlayerPrefs.HasKey("currency"))
        {
            currencyAmount.SetValue(PlayerPrefs.GetInt("currency"));
            
        }
        else 
        {
            currencyAmount.SetValue(0);
        }
    }

    public void UpgradeButton()
    {
        if(currencyAmount.GetValue() >= (upgradeLevel.GetValue() * 100) + 100)
        {
            currencyAmount.Decrease((upgradeLevel.GetValue() * 100) + 100);
            stackAmount.Increase(upgradeLevel.GetValue() * 10);
            upgradeLevel.Increase(1);
            upgradeButtonValueText.text = ((upgradeLevel.GetValue() * 100) + 100).ToString();

            PlayerPrefs.SetInt("upgrade", upgradeLevel.GetValue());
            PlayerPrefs.SetInt("currency", currencyAmount.GetValue());
        }
    }

    public void NextLevelButton()
    {
        level ++;
        PlayerPrefs.SetInt("level", level);
        if(SceneManager.GetActiveScene().buildIndex < 1)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else
        {
            int sceneBuildIndex = Random.Range(0, 1);
            SceneManager.LoadScene(sceneBuildIndex);
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Win()
    {
        winPanel.SetActive(true);
        nextLevelButton.gameObject.SetActive(true);
    }

}
