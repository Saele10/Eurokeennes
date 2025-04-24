using UnityEngine;

public class UpgradeController : MonoBehaviour
{
    [SerializeField] private UpgradeData data;
    [SerializeField] private GameObject moneyController;

    [SerializeField] private int _id;
    private string name;



    private void Start()
    {
        moneyController = GameObject.Find("MoneyController");
        data = DatabaseManager.Instance.GetDataUpgrade(_id);

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            BuyUpgrade();
        }
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
