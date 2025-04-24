using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "UpgradeDatabase", menuName = "data/Upgrade", order = 1)]
public class UpgradeDatabase : ScriptableObject
{
    [SerializeField] private List<UpgradeData> data = new();

    public UpgradeData GetData(int id, bool randomAllow = false)
    {
        if (randomAllow && (id < 0 || id >= data.Count))
            id = Random.Range(0, data.Count);
        else
            id = Mathf.Clamp(id, 0, data.Count - 1);

        return data[id];
    }
}
