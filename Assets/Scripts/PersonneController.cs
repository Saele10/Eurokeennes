using UnityEngine;

public class PersonneController : MonoBehaviour
{
    public int nbPerso;
    public int nbPersoSec = 1;

    private float countdown = 1f;


    private void Update()
    {
        if (countdown <= 0)
        {
            AddPersonne(nbPersoSec);
            countdown = 1f;
        }
        else
            countdown -= Time.deltaTime;
    }

    public void AddPersonne(int amount)
    {
        nbPerso += amount;
    }
}
