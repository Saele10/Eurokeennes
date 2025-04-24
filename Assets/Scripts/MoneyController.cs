using Unity.VisualScripting;
using UnityEngine;

public class MoneyController : MonoBehaviour
{
    public int _money = 0;
    public int _moneyPerSecond = 1;

    private float _countdown = 1f;
    
    [SerializeField] private PersonneController _personneController;

 

    private void Update()
    {
        _moneyPerSecond = (int)Mathf.Round(_personneController.nbPerso / 10);
        //ajout money par seconde en fonction du nombre de personne 10 = 1€


        if (_countdown <= 0)
        {
            AddMoney(_moneyPerSecond);
            _countdown = 1f;
        }
        else
            _countdown -= Time.deltaTime;


        
    }



    public void AddMoney(int amount)
    {
        _money += amount;
    }



}


