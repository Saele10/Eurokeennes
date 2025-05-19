using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class PersonneController : MonoBehaviour
{
    public float nbPerso = 10f;
    public int nbPersoSec = 1;
    private float countdown = 1f;
    public float _target = 10f;


    [SerializeField] private TextMeshProUGUI _compteur;


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
            _compteur.text = Mathf.RoundToInt(nbPerso).ToString();


        }
        if (nbPerso > _target)
        {
            nbPerso = _target;
            _compteur.text = nbPerso.ToString();
        }

    }

    public void AddPersonne(int amount)
    {
        _target += amount;
    }



}
