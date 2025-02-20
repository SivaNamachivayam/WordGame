﻿using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Collections.Generic;

public class Alphabet : MonoBehaviour
{
    [System.Serializable]
    public class Letters
    {
        public string letter;
        public int qty;
        public int score;
    }


    public List<Letters> LettersList;
    public List<string> LettersFeed;

    public List<GameObject> TileGameObject;
 
    public static Alphabet data;

	void Awake () {
        data = this;
    }

    void FillLettersFeed() {
        foreach(Letters letterItem in LettersList)
        {
            LettersFeed.Add(letterItem.letter);
            //for (int i = 1; i <= letterItem.qty; i++)
            //{
            //    Debug.Log("SYED_RA-1111");
            //    LettersFeed.Add(letterItem.letter);
            //}
        }
        //int index = TileGameObject.IndexOf();
    }

    public string GetRandomLetter() {
        int rand = UnityEngine.Random.Range(0,LettersFeed.Count);
        string result = LettersFeed[rand]; 
        //LettersFeed.RemoveAt(rand);
        return result;
    }

    public int GetLetterScore(string letter)
    {
        foreach(Letters letterItem in LettersList)
        {
            if (letterItem.letter == letter)
                return letterItem.score;
        }
        return 0;
    }

    public void ResetFeed()
    {
        //LettersFeed.Clear();
        FillLettersFeed();
    }
}
