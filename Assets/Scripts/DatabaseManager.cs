using UnityEngine;

public class DatabaseManager : MonoBehaviour
{
    private static DatabaseManager _instance;
    public static DatabaseManager Instance => _instance;

    [SerializeField] private UpgradeDatabase upgradeDatabase;
    private void Awake()
    {
        if (_instance == null)
            _instance = this;
        else
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject.transform.root);
    }
    public UpgradeData GetDataUpgrade(int id) => upgradeDatabase.GetData(id);

}
