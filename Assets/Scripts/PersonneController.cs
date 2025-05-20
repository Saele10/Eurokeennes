using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class PersonneController : MonoBehaviour
{
    public float nbPerso = 10f;
    public int nbPersoSec = 1;
    private float countdown = 1f;
    public float _target = 10f;
    public List<GameObject> _buttons;
    [SerializeField] private List<int> _nbPersButton;

    [SerializeField] private TextMeshProUGUI _compteur;

    private void Start()
    {
        _nbPersButton.Add(Random.Range(20, 201));
        _nbPersButton.Add(Random.Range(20, 201));
        _nbPersButton.Add(Random.Range(20, 201));
        
    }


    private void Update()
    {
        if (countdown <= 0)
        {
            AddPersonne(nbPersoSec);
            countdown = 1f;

        }
        else
            countdown -= Time.deltaTime;

        if (nbPerso < _target)
        {
            float ScoreIncrement = Time.deltaTime * nbPersoSec;
            nbPerso += ScoreIncrement;
            foreach (var nb in _nbPersButton)
            {
                if (nbPerso >= nb)
                {
                    _buttons[_nbPersButton.IndexOf(nb)].SetActive(true);
                    _nbPersButton[_nbPersButton.IndexOf(nb)] = 999999999;
                    break;
                }
            }
            _compteur.text = Mathf.RoundToInt(nbPerso).ToString();


        }
        if (nbPerso > _target)
        {
            nbPerso = _target;
            _compteur.text = nbPerso.ToString();
        }

    }

    public void AddRand()
    {
        AddPersonne(Random.Range(0, 11));
    }

    public void AddPersonne(int amount)
    {
        _target += amount;
    }

}
