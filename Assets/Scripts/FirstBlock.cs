using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static UnityEngine.UIElements.UxmlAttributeDescription;

public class FirstBlock : MonoBehaviour, IPointerClickHandler
{
    public GameObject UpgradePanel, MovePanel, UpgradeButtonObject;
    public GameObject[] Houses;
    public Text Price, Desc;

    [SerializeField] private int currentLevel = 1;
    [SerializeField] private float upgradingPrice;

    private void Start()
    {
        GameManager.Instance.LoadFromJson();
        currentLevel = GameManager.Instance.Block1CurrentLevel;
        upgradingPrice = GameManager.Instance.Block1UpgradingPrice;
        for (int i = 0; i < currentLevel; i++)
        {
            Houses[i].SetActive(true);
        }
    }

    private void UpgradingPanel()
    {
        UpgradePanel.SetActive(true);
        Price.text = upgradingPrice.ToString();
        if (currentLevel - 1 == Houses.Length)
        {
            Desc.text = "You have fully upgraded this block";
            UpgradeButtonObject.SetActive(false);
            Price.gameObject.SetActive(false);
        }
        LeanTween.moveLocalY(MovePanel, 0f, 0.5f).setEaseOutBack();
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        UpgradingPanel();
    }

    public void UpgradeButton()
    {
        if (GameManager.Instance.GetTotalBalance() > upgradingPrice)
        {
            GameManager.Instance.DecreaseCurrentBalance(upgradingPrice);
            upgradingPrice *= 2f;
            Houses[currentLevel - 1].gameObject.SetActive(true);
            currentLevel++;
            GameManager.Instance.SaveToJson(currentLevel, upgradingPrice);
            LeanTween.moveLocalY(MovePanel, 840f, 0.5f).setEaseOutBack().setOnComplete(() => {
                UpgradePanel.SetActive(false);
            });
            GameManager.Instance.IncreaseIncomePerSecond(1f);
        }
    }
}
