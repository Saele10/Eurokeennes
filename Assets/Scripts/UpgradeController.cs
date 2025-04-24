using UnityEngine;

public class UpgradeController : MonoBehaviour
{
    [SerializeField] private UpgradeData data;
    [SerializeField] private MoneyController _moneyController;
    [SerializeField] private SpriteRenderer _spriteRenderer;

    [SerializeField] private PersonneController _personneController;


    [SerializeField] private int _id;
    //private string name;



    private void Start()
    {
        data = DatabaseManager.Instance.GetDataUpgrade(_id);
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _spriteRenderer.color = Color.clear;
    }

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.E))
        {
            BuyUpgrade();
        }



    }

    public void BuyUpgrade()
    {
        if (data.bought)
            Debug.Log("déjà acheté");


        else if (_moneyController._money >= data.cost) // si on a assez d'argent...
        {
            _moneyController._money -= data.cost;
            _personneController.nbPerso += data.persoGain;
            data.bought = true;
            _spriteRenderer.color = Color.white;

        }

        else
        {
            Debug.Log("pas assez d'argent");
        }

    }

}
