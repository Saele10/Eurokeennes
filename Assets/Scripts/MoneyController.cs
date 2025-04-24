using UnityEngine;

public class MoneyController : MonoBehaviour
{
    public int _money = 0;
    public int _moneyPerSecond = 1;

    private float _countdown = 1f;


    private void Update()
    {
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


