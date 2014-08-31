using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class PersistentData : MonoBehaviour {

    public string[] playersNameArray    = new string[ 10 ];
    public string[] playersCRMArray     = new string[ 10 ];
    public float[] playersTimeArray    = new float[ 10 ];
    private string[] checkArray    = new string[ 10 ];
    Dictionary<string, float> initialDictionary = new Dictionary<string, float>( );
    Dictionary<Dictionary<string,string>, string> finalDictionary = new Dictionary<Dictionary<string, string>, string>( );
    private List<string> names = new List<string>( );
    private List<float> times = new List<float>( );
    private string name =   " ";
    private string crm =    " ";

    public List<KeyValuePair<string, float>> rankingList;
    public string time;

    private PersistentData( ) { }

    private static PersistentData instance;

    public static PersistentData Instance
    {
        get
        {
            return instance;
        }
    }

    void Start()
    {
        instance = this;
        checkArray = PlayerPrefsX.GetStringArray(GameConstants.USERS_NAME_ARRAY);
        if (checkArray.Length == 0)
        {
            PlayerPrefsX.SetStringArray(GameConstants.USERS_NAME_ARRAY, playersNameArray);
            PlayerPrefsX.SetStringArray(GameConstants.USERS_CRM_ARRAY, playersCRMArray);
            PlayerPrefsX.SetFloatArray(GameConstants.USERS_TIME_ARRAY, playersTimeArray);
            playersNameArray = PlayerPrefsX.GetStringArray(GameConstants.USERS_NAME_ARRAY);
            playersCRMArray = PlayerPrefsX.GetStringArray(GameConstants.USERS_CRM_ARRAY);
            playersTimeArray = PlayerPrefsX.GetFloatArray(GameConstants.USERS_TIME_ARRAY);
        }
        else
        {
            playersNameArray = PlayerPrefsX.GetStringArray(GameConstants.USERS_NAME_ARRAY);
            playersCRMArray = PlayerPrefsX.GetStringArray(GameConstants.USERS_CRM_ARRAY);
            playersTimeArray = PlayerPrefsX.GetFloatArray(GameConstants.USERS_TIME_ARRAY);
            
            for (int i = 0; i < playersNameArray.Length; i++)
            {
                if (!initialDictionary.ContainsKey(playersNameArray[i]))
                {
					if (playersNameArray[i] != "" && playersTimeArray[i] > 0)
                    {
                        initialDictionary.Add(playersNameArray[i], playersTimeArray[i]);
                    }
                }
            }
            List<KeyValuePair<string, float>> myList = initialDictionary.ToList();

            myList.Sort((firstPair, nextPair) =>
            {
                return firstPair.Value.CompareTo(nextPair.Value);
            }
            );
        }
    }

    public void SaveNameAndCRM()
    {
        name    = FirstScreen.Instance.name + "-" + FirstScreen.Instance.crm;
        crm     = FirstScreen.Instance.crm;
    }

    public void CheckRanking()
    {
        if (!initialDictionary.ContainsKey(name))
        {
            SaveRanking();
        }
        else
        {
            float value = initialDictionary[name];
            if (value > System.Convert.ToInt64(time))
            {
                initialDictionary.Remove(name);
                SaveRanking();
            }
            else
            {
                rankingList = initialDictionary.ToList();
                rankingList.Sort((firstPair, nextPair) =>
                {
                    return firstPair.Value.CompareTo(nextPair.Value);
                }
               );
            }
        }
    }

    private void SaveRanking()
    {
        initialDictionary.Add(name, System.Convert.ToInt64(time));
        foreach (KeyValuePair<string, float> item in initialDictionary)
        {
            names.Add(item.Key);
            times.Add(item.Value);
        }
        rankingList = initialDictionary.ToList();
        rankingList.Sort((firstPair, nextPair) =>
        {
            return firstPair.Value.CompareTo(nextPair.Value);
        }
       );
        playersNameArray = names.ToArray();
        playersTimeArray = times.ToArray();
        PlayerPrefsX.SetStringArray(GameConstants.USERS_NAME_ARRAY, playersNameArray);
        PlayerPrefsX.SetFloatArray(GameConstants.USERS_TIME_ARRAY, playersTimeArray);

        PlayerPrefs.Save();
    }

    public void ListRanking()
    {
        checkArray = PlayerPrefsX.GetStringArray(GameConstants.USERS_NAME_ARRAY);
        if (checkArray.Length == 0)
        {
            PlayerPrefsX.SetStringArray(GameConstants.USERS_NAME_ARRAY, playersNameArray);
            PlayerPrefsX.SetStringArray(GameConstants.USERS_CRM_ARRAY, playersCRMArray);
            PlayerPrefsX.SetFloatArray(GameConstants.USERS_TIME_ARRAY, playersTimeArray);
            playersNameArray = PlayerPrefsX.GetStringArray(GameConstants.USERS_NAME_ARRAY);
            playersCRMArray = PlayerPrefsX.GetStringArray(GameConstants.USERS_CRM_ARRAY);
            playersTimeArray = PlayerPrefsX.GetFloatArray(GameConstants.USERS_TIME_ARRAY);
        }
        else
        {
            playersNameArray = PlayerPrefsX.GetStringArray(GameConstants.USERS_NAME_ARRAY);
            playersCRMArray = PlayerPrefsX.GetStringArray(GameConstants.USERS_CRM_ARRAY);
            playersTimeArray = PlayerPrefsX.GetFloatArray(GameConstants.USERS_TIME_ARRAY);

            for (int i = 0; i < playersNameArray.Length; i++)
            {
                if (!initialDictionary.ContainsKey(playersNameArray[i]))
                {
                    initialDictionary.Add(playersNameArray[i], playersTimeArray[i]);
                }
            }
            List<KeyValuePair<string, float>> myList = initialDictionary.ToList();

            myList.Sort((firstPair, nextPair) =>
            {
                return firstPair.Value.CompareTo(nextPair.Value);
            }
            );
        }
        rankingList = initialDictionary.ToList();
        rankingList.Sort((firstPair, nextPair) =>
        {
            return firstPair.Value.CompareTo(nextPair.Value);
        }
       );
    }
}
