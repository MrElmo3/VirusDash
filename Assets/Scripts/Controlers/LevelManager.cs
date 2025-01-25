using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [System.Serializable]
    public class LevelDTO{
        public string id;
        public string name;
        public float heightTube;
        public float speedTube;
        public float speedArrow;
        public float enemiesCount;
    }
    public static LevelManager Instance{ get;set;}

    public LevelDTO[] levels;
  
    void Awake()
    {
        if(Instance != null && Instance != this){
            Destroy(gameObject);
            return;
        }

        Instance = this;
        Awakee();
        DontDestroyOnLoad(gameObject);
    }

    void Awakee(){
    }
    
    public int GetLevel(){
        return PlayerPrefs.GetInt("level", 0);
    }

    public void SetLevel(int value = 0){
        int new_level = value;
        if(value == 0){
            new_level = GetLevel()+1;
        }
        Debug.Log("Setting level to " + new_level);
        PlayerPrefs.SetInt("level",new_level);
    }

    public LevelDTO GetCurrentLevelDTO(){
        int level = GetLevel();
        return levels[level];
    }
    public bool CheckEndLevels(){
        return GetLevel() >= levels.Length;
    }
}
