using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ClickableObject : MonoBehaviour, IPointerClickHandler
{
    public GameObject buildPanel, MovePanel;
    public GameObject house;
    public float BuildingPrice;
    public Text Price;
    private void BuildingPanel()
    { 
        buildPanel.SetActive(true);
        if(Price != null)
        Price.text = BuildingPrice.ToString();
        LeanTween.moveLocalY(MovePanel, 0f, 0.5f).setEaseOutBack();
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        BuildingPanel();
    }

    public void CreateBuildingButton()
    {
        if (GameManager.Instance.GetTotalBalance() > BuildingPrice)
        {
            house.SetActive(true);
            LeanTween.moveLocalY(MovePanel, 840f, 0.5f).setEaseOutBack().setOnComplete(() => {
                buildPanel.SetActive(false);
            });
            this.gameObject.SetActive(false);
            GameManager.Instance.DecreaseCurrentBalance(BuildingPrice);
            GameManager.Instance.IncreaseIncomePerSecond(1f);
        }
    }
}
