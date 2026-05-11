using UnityEngine;
using System.Collections.Generic;

public class Avatar : MonoBehaviour
{
    [System.Serializable]
    public class AvatarData
    {
        public int id;
        public string avatarName;
        public Sprite icon;
        public GameObject avatarPrefab;
    }

    public static Avatar Instance { get; private set; }

    [SerializeField] private List<AvatarData> avatars = new List<AvatarData>();

    private readonly Dictionary<int, AvatarData> avatarById = new Dictionary<int, AvatarData>();

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        BuildIndex();
    }

    public AvatarData GetAvatarById(int id)
    {
        AvatarData avatarData;
        return avatarById.TryGetValue(id, out avatarData) ? avatarData : null;
    }

    public bool HasAvatar(int id)
    {
        return avatarById.ContainsKey(id);
    }

    public int GetFirstAvatarId()
    {
        return avatars.Count > 0 ? avatars[0].id : -1;
    }

    private void OnValidate()
    {
        BuildIndex();
    }

    private void BuildIndex()
    {
        avatarById.Clear();

        for (int i = 0; i < avatars.Count; i++)
        {
            AvatarData data = avatars[i];
            if (data == null)
            {
                continue;
            }

            if (avatarById.ContainsKey(data.id))
            {
                Debug.LogWarning("Duplicate avatar id: " + data.id + " on " + gameObject.name, this);
                continue;
            }

            avatarById.Add(data.id, data);
        }
    }
}
