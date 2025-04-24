using UnityEngine;

public class UpgradeController : MonoBehaviour
{
    [SerializeField] private UpgradeData data;
    [SerializeField] private GameObject moneyController;

    [SerializeField] private int _id;



    private void Start()
    {
        moneyController = GameObject.Find("MoneyController");
        data = DatabaseManager.Instance.GetDataUpgrade(_id);

    }


    public void BuyUpgrade()
    {
        if (data.bought)
            return;
        var money = moneyController.GetComponent<MoneyController>();
        if (money._money >= data.cost)
        {
            money._money -= data.cost;
            data.bought = true;
        }
    }
}
