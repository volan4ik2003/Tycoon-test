using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasController : MonoBehaviour
{
    public GameObject BuildingPanel, BuildingPanelBlock1,
        BuildingPanelHouse2, BuildingPanelHouse3, BuildingPanelStadium, MovePanel;
    public Text CurrentBalance;

    private void LateUpdate()
    {
        UpdateCurrentBalance();
    }

    public void CloseBuildingPanel() 
    {
        LeanTween.moveLocalY(MovePanel, 840f, 0.5f).setEaseOutBack().setOnComplete(() => {
            BuildingPanel.SetActive(false);
        });
    }
    public void CloseBuildingPanelHouse2()
    {
        LeanTween.moveLocalY(MovePanel, 840f, 0.5f).setEaseOutBack().setOnComplete(() => {
            BuildingPanelHouse2.SetActive(false);
        });
        
    }
    public void CloseBuildingPanelHouse3()
    {
        LeanTween.moveLocalY(MovePanel, 840f, 0.5f).setEaseOutBack().setOnComplete(() => {
            BuildingPanelHouse3.SetActive(false);
        });
        
    }

    public void CloseBuildingPanelBlock1()
    {
        LeanTween.moveLocalY(MovePanel, 840f, 0.5f).setEaseOutBack().setOnComplete(() => {
            BuildingPanelBlock1.SetActive(false);
        });
        
    }
    public void CloseBuildingPanelStadium()
    {
        LeanTween.moveLocalY(MovePanel, 840f, 0.5f).setEaseOutBack().setOnComplete(() => {
            BuildingPanelStadium.SetActive(false);
        });
        
    }

    private void UpdateCurrentBalance()
    {
        CurrentBalance.text = GameManager.Instance.GetTotalBalance().ToString();
    }
}
