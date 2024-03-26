using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private float incomePerSecond = 0f;
    private int totalPopulation = 0;
    private float currentBalance = 1000;

    public int Block1CurrentLevel;
    public float Block1UpgradingPrice;

    private static GameManager instance;


    private void Start()
    {
        StartCoroutine(Income());
    }
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<GameManager>();
                if (instance == null)
                {
                    GameObject singletonObject = new GameObject(typeof(GameManager).Name);
                    instance = singletonObject.AddComponent<GameManager>();
                }
            }
            return instance;
        }
    }

    public void SaveToJson(int Block1CurrentLevel = 0, float Block1UpgradingPrice = 0f)
    { 
        GameData gameData = new GameData();
        gameData.CurrentBalance = currentBalance;
        gameData.IncomePerSecond = incomePerSecond;
        gameData.Block1CurrentLevel = Block1CurrentLevel;
        gameData.Block1UpgradingPrice = Block1UpgradingPrice;

        string json = JsonUtility.ToJson(gameData, true);
        File.WriteAllText(Application.dataPath + "/GameDataFile.json", json);
    }

    public void LoadFromJson()
    {
        string json = File.ReadAllText(Application.dataPath + "/GameDataFile.json");
        GameData gameData = JsonUtility.FromJson<GameData>(json);

        currentBalance = gameData.CurrentBalance;
        incomePerSecond = gameData.IncomePerSecond;
        Block1CurrentLevel = gameData.Block1CurrentLevel;
        Block1UpgradingPrice = gameData.Block1UpgradingPrice;
    }

    IEnumerator Income() {
        yield return new WaitForSeconds(1);
        currentBalance += incomePerSecond;
        StartCoroutine(Income());
    }

    public float GetTotalBalance()
    {
        return currentBalance;
    }

    public void DecreaseCurrentBalance(float price)
    {
        currentBalance -= price;
    }

    public void IncreasePopulation(int populationAmount)
    {
        totalPopulation += populationAmount;
    }

    public void IncreaseIncomePerSecond(float income)
    {
        incomePerSecond += income;
    }

    public int GetTotalPopulation()
    {
        return totalPopulation;
    }
}
