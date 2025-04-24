using UnityEngine;

public class UpgradeController : MonoBehaviour
{
    [SerializeField] private UpgradeData data;
    [SerializeField] private MoneyController _moneyController;

    [SerializeField] private PersonneController _personneController;


    [SerializeField] private int _id;
    //private string name;



    private void Start()
    {
        data = DatabaseManager.Instance.GetDataUpgrade(_id);
    }

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.E))
        {
            BuyUpgrade();
        }

    }

    private void BuyUpgrade()
    {
        if (data.bought)
            Debug.Log("déjà acheté");


        else if (_moneyController._money >= data.cost) // si on a assez d'argent...
        {
            _moneyController._money -= data.cost;
            _personneController.nbPerso += data.persoGain;
            data.bought = true;
        }

        else
        {
            Debug.Log("pas assez d'argent");
        }

    }

}
