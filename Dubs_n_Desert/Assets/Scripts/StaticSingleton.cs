using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StaticSingleton : MonoBehaviour
{
    private static StaticSingleton _instance;
    public Slider DifficultySlider;
    private int difficulty = 1;
    private int Level = 1;
    private int[] collectables = new int[2];

    public static StaticSingleton instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<StaticSingleton>();

                //Tell unity not to destroy this object when loading a new scene!
                DontDestroyOnLoad(_instance.gameObject);
            }

            return _instance;
        }
    }

    void Awake()
    {
        if (_instance == null)
        {
            //If I am the first instance, make me the Singleton
            _instance = this;
            DifficultySlider.onValueChanged.AddListener(delegate { ValueChangeCheck(); });
            DontDestroyOnLoad(this);
        }
        else
        {
            //If a Singleton already exists and you find
            //another reference in scene, destroy it!
            if (this != _instance)
                Destroy(this.gameObject);
        }
    }

    void ValueChangeCheck()
    {
        setDifficulty((int)DifficultySlider.value);
    }
    public void setDifficulty(int difficulty)
    {
        this.difficulty = difficulty;
    }
    public int GetMaxHealth()
    {
        if (difficulty==0)
                    return 200;
        if (difficulty==1)
                    return 100;
        if (difficulty==2)
                    return 50;
        return 9031;
               
    }
    public int getLevel()
    {
        return Level;
    }
    public void setLevel(int level)
    {
        this.Level = level;
    }
    public void delCollected()
    {
        collectables[0] = 0;
        collectables[1] = 0;
    }
    public void incCollected()
    {
        collectables[0]++;
    }
    public void incNumberOfCollectables()
    {
        collectables[1]++;
    }
    public int getCollected()
    {
        return collectables[0];
    }
    public int getNrOfCollectables()
    {
        return collectables[1];
    }
    public int getDifficulty()
    {
        return difficulty;
    }
}