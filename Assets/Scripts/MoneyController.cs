using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;

public class MoneyController : MonoBehaviour
{
    public float _money = 0f;
    public float _moneyPerSecond = 1f;
    private float _countdown = 1f;
    public float _target = 0f;
    
    [SerializeField] private PersonneController _personneController;
    [SerializeField] private TextMeshProUGUI _compteur;
    [SerializeField] private Canvas _pause;


    private void Update()
    {
        _moneyPerSecond = (int)Mathf.Round(_personneController.nbPerso / 10);
        //ajout money par seconde en fonction du nombre de personne 10 = 1�


        if (_money < _target)
        {
            float ScoreIncrement = Time.deltaTime * _moneyPerSecond;
            _money += ScoreIncrement;
            _compteur.text = Mathf.RoundToInt(_money).ToString();
            

        }
        if (_money > _target)
        {
            _money = _target;
            _compteur.text = _money.ToString();
        }

        if (_countdown <= 0)
        {
            AddMoney(_moneyPerSecond);
            //_compteur.text = _money.ToString();

            _countdown = 1f;
        }

        else
            _countdown -= Time.deltaTime;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void AddRand()
    {
        AddMoney(Random.Range(0, 21));
    }

    public void AddMoney(float amount)
    {
        _target += amount;
    }





}


