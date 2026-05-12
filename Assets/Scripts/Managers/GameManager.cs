using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager instance
    {
        get
        {
            if(_instance == null)
            {
                _instance = FindFirstObjectByType<GameManager>();
            }
            if (_instance == null)
            {
                GameObject obj = new GameObject();
                _instance = obj.AddComponent<GameManager>();
            }
            return instance;
        }
    }

    private void Awake()
    {
        if(_instance != this)
        {
            Destroy(gameObject);
        }
    }
}
