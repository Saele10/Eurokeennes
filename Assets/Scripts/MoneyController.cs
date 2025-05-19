using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;

public class MoneyController : MonoBehaviour
{
    public int _money = 0;
    public int _moneyPerSecond = 1;

    private float _countdown = 1f;
    
    [SerializeField] private PersonneController _personneController;
    [SerializeField] private TextMeshProUGUI _compteur;
    private float _duration = 0.9f;
    private float _time = 0;
    private bool _anim = false;
    private int target = 0;


    private void Update()
    {
        _moneyPerSecond = (int)Mathf.Round(_personneController.nbPerso / 10);
        //ajout money par seconde en fonction du nombre de personne 10 = 1€


        if (_countdown <= 0)
        {
            AddMoney(_moneyPerSecond);
            //_compteur.text = _money.ToString();
            _anim = true;
            _countdown = 1f;
        }

        else
            _countdown -= Time.deltaTime;

        //if (_money < target)
        //{
        //    int ScoreIncrement = ((int)Time.deltaTime) * _moneyPerSecond;
        //    _money += ScoreIncrement;
        //    _compteur.text = _money.ToString();

        //    if (_money > target)
        //    {
        //        _money = target;
        //        _compteur.text = _money.ToString();
        //    }

        //}

        if (_anim)
        {

            float ratio = _time / _duration;
            float easedRatio = EaseOutElastic(ratio * ratio);
            _compteur.text = Mathf.Lerp(_money - _moneyPerSecond, _money, easedRatio).ToString("0");

            _time += Time.unscaledDeltaTime;
            if (_time > _duration)
            {
                _time = 0;
                _anim = false;
            }
        }

    }




    public void AddMoney(int amount)
    {
        _money += amount;
        target += amount;
    }

    float EaseOutElastic(float x)
    {
        float c4 = (2f * Mathf.PI) / 3f;

        if (x == 0f)
            return 0f;
        if (x == 1f)
            return 1f;

        return Mathf.Pow(2f, -10f * x) * Mathf.Sin((x * 10f - 0.75f) * c4) + 1f;
    }

}


