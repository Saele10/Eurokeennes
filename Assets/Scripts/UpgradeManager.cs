using System.Collections.Generic;
using NUnit.Framework.Constraints;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    public List<bool> upgradeBought = new List<bool>();


    private void Awake()
    {
        for (int i = 0; i < 8; i++)
        {
            upgradeBought.Add(false);
        }
    }

}
