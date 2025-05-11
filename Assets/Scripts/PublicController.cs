using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PublicController : MonoBehaviour
{
    public enum TYPE
    {
        Valide,
        Fauteuil,
        Gilet,
        Casque
    }
    [field: SerializeField] public TYPE Type { get; private set; }
    [SerializeField] private List<GameObject> _perso = new List<GameObject>();


    [SerializeField] private UpgradeData data;


    private void Start()
    {
        switch (Type) {

            case TYPE.Fauteuil:
                data = DatabaseManager.Instance.GetDataUpgrade(0);
                break;
            case TYPE.Gilet:
                data = DatabaseManager.Instance.GetDataUpgrade(5);
                break;
            case TYPE.Casque:
                data = DatabaseManager.Instance.GetDataUpgrade(4);
                break;
        }

         
    }
    private void Update()
    {
       if (data.bought)
        {
            foreach (var item in _perso)
            {
                item.SetActive(true);
                Instantiate(item); 
            }
        }

    }




}