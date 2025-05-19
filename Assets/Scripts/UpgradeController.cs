using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UpgradeController : MonoBehaviour
{
    [SerializeField] private UpgradeData data;
    [SerializeField] private UpgradeManager _upgradeManager;
    [SerializeField] private MoneyController _moneyController;
    [SerializeField] private SpriteRenderer _spriteRenderer;

    [SerializeField] private PersonneController _personneController;
    [SerializeField] private List<PublicController> _publicController = new();
    [SerializeField] private List<GameObject> _visuals = new();
    [SerializeField] private GameObject _menu;
    [SerializeField] private Button _button;

    private bool _good = false;
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


        else if (_moneyController._target >= data.cost && _personneController.nbPerso >= data.constraint) // si on a assez d'argent...
        {
            _moneyController._target -= data.cost;
            _personneController.nbPerso += data.persoGain;
            data.bought = true;
            _spriteRenderer.color = Color.white;
            foreach (var publicController in _publicController)
                publicController.bought = true;
            foreach (var visual in _visuals)
                visual.SetActive(true);
            _menu.SetActive(false);

            _upgradeManager.upgradeBought[_id] = true;
            _button.interactable = false;

            foreach (var bought in _upgradeManager.upgradeBought)
            {
                if (bought == false)
                    _good = false;
                else
                    _good = true;
            }
            if (_good)
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        }

        else
        {
            Debug.Log("pas assez d'argent");
        }

    }

}
