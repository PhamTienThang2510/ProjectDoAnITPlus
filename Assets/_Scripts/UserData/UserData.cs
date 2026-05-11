using UnityEngine;

public class UserData : MonoBehaviour
{
    [System.Serializable]
    public class UserProfile
    {
        public int gold = 0;
        public int avatarId = 0;
        public int currentLevel = 1;
        public int energy = 20;
    }

    public static UserData Instance { get; private set; }

    private const string SaveKey = "USER_PROFILE_DATA";

    [Header("Default Data")]
    [SerializeField] private UserProfile defaultProfile = new UserProfile();

    public UserProfile Profile { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadData();
    }

    public void SaveData()
    {
        if (Profile == null)
        {
            return;
        }

        string json = JsonUtility.ToJson(Profile);
        PlayerPrefs.SetString(SaveKey, json);
        PlayerPrefs.Save();
    }

    public void LoadData()
    {
        if (PlayerPrefs.HasKey(SaveKey))
        {
            string json = PlayerPrefs.GetString(SaveKey);
            Profile = JsonUtility.FromJson<UserProfile>(json);
        }
        else
        {
            Profile = new UserProfile
            {
                gold = defaultProfile.gold,
                avatarId = defaultProfile.avatarId,
                currentLevel = defaultProfile.currentLevel,
                energy = defaultProfile.energy
            };
            SaveData();
        }
    }

    public void ResetData()
    {
        PlayerPrefs.DeleteKey(SaveKey);
        Profile = new UserProfile
        {
            gold = defaultProfile.gold,
            avatarId = defaultProfile.avatarId,
            currentLevel = defaultProfile.currentLevel,
            energy = defaultProfile.energy
        };
        SaveData();
    }

    public void SetGold(int amount)
    {
        Profile.gold = Mathf.Max(0, amount);
        SaveData();
    }

    public void SetAvatar(int id)
    {
        if (id < 0)
        {
            return;
        }

        Profile.avatarId = id;
        SaveData();
    }

    public void SetCurrentLevel(int level)
    {
        Profile.currentLevel = Mathf.Max(1, level);
        SaveData();
    }

    public void SetEnergy(int amount)
    {
        Profile.energy = Mathf.Max(0, amount);
        SaveData();
    }

    private void OnApplicationPause(bool pauseStatus)
    {
        if (pauseStatus)
        {
            SaveData();
        }
    }

    private void OnApplicationQuit()
    {
        SaveData();
    }
}
