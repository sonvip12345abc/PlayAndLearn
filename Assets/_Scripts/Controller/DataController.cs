using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataController : Singleton<DataController>
{
    
    public string NamePlayer 
    {
        get
        {
            return PlayerPrefs.GetString(CONSTANT.NamePlayer, "User");
        }
        set
        {
            PlayerPrefs.SetString(CONSTANT.NamePlayer, value);
        }
    }

    public int MusicOn
    {
        get
        {
            return PlayerPrefs.GetInt(CONSTANT.MusicOn, 1);
        }
        set
        {
            PlayerPrefs.SetInt(CONSTANT.MusicOn, value);
        }
    }

    public int SoundOn
    {
        get
        {
            return PlayerPrefs.GetInt(CONSTANT.SoundOn, 1);
        }
        set
        {
            PlayerPrefs.SetInt(CONSTANT.SoundOn, value);
        }
    }

    public int VibrationOn
    {
        get
        {
            return PlayerPrefs.GetInt(CONSTANT.VibrationOn, 1);
        }
        set
        {
            PlayerPrefs.SetInt(CONSTANT.VibrationOn, value);
        }
    }


    public int IdAvatar
    {
        get
        {
            return PlayerPrefs.GetInt(CONSTANT.IdAvatar, 0);
        }
        set
        {
            PlayerPrefs.SetInt(CONSTANT.IdAvatar, value);
        }
    }

    public int ScoreChallenge
    {
        get
        {
            return PlayerPrefs.GetInt(CONSTANT.ScoreChallenge, 0);
        }
        set
        {
            PlayerPrefs.SetInt(CONSTANT.ScoreChallenge, value);
        }
    }
    public int DataGrade1
    {
        get
        {
            return PlayerPrefs.GetInt(CONSTANT.DataGrade1, 0);
        }
        set
        {
            PlayerPrefs.SetInt(CONSTANT.DataGrade1, value);
        }
    }

    public int DataGrade2
    {
        get
        {
            return PlayerPrefs.GetInt(CONSTANT.DataGrade2, 0);
        }
        set
        {
            PlayerPrefs.SetInt(CONSTANT.DataGrade2, value);
        }
    }
    public int DataGrade3
    {
        get
        {
            return PlayerPrefs.GetInt(CONSTANT.DataGrade3, 0);
        }
        set
        {
            PlayerPrefs.SetInt(CONSTANT.DataGrade3, value);
        }
    }

    public int DataGrade4
    {
        get
        {
            return PlayerPrefs.GetInt(CONSTANT.DataGrade4, 0);
        }
        set
        {
            PlayerPrefs.SetInt(CONSTANT.DataGrade4, value);
        }
    }

    public int DataGrade5
    {
        get
        {
            return PlayerPrefs.GetInt(CONSTANT.DataGrade5, 0);
        }
        set
        {
            PlayerPrefs.SetInt(CONSTANT.DataGrade5, value);
        }
    }

    


}
