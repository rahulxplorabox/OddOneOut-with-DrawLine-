using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System;

using LitJson;
using System.Collections.Generic;
using System.Linq;

public class AssetesBundleLoadingScripts : MonoBehaviour
{
    public int maxNum = 9;
    //public List<int> randomList;
    public GridLayoutGroup myimagegrid;

    GameObject Imageicons;

    public GameObject ImgPrefab;

    public Sprite[] myassetsobject;

    private System.Random _random = new System.Random();
    public List<int> indexdata = new List<int>();

    void Start()
    {
        var myLoadedAssetBundle = AssetBundle.LoadFromFile(Path.Combine(Application.streamingAssetsPath, "sunil.images"));

        //Generating a Random Number
        int randnum = UnityEngine.Random.Range(0, 10);
        print("Random Number" +randnum);

        //Checking Random Number is even or Odd
        bool ifevenNumber = randnum % 2 == 0 ? true : false;
        if(ifevenNumber)
        {
            for (int i=0;i<9;i++)
            {
                if(i%2 == 0)
                    indexdata.Add(Convert.ToInt32(i));
            }
        }
        else
        {
            for (int i = 0; i <= 9; i++)
            {
                if (i % 2 != 0 || i==4)
                {
                    indexdata.Add(Convert.ToInt32(i));
                }
            }
        }

        foreach(int i in indexdata)
        {
            print(i);
        }
        if (myLoadedAssetBundle != null)
        {
            print("Bundle found");
            myassetsobject = myLoadedAssetBundle.LoadAllAssets<Sprite>();
            //All image is store in GameManager List MyAssetImagesObject 
            GameManager.GameManagerinstance.MyAssetImagesObject = myassetsobject;
            Shuffle(myassetsobject);
            setImageOnGrid(myassetsobject);

        }
    }
   
    public void setImageOnGrid(Sprite[] myLoadedAssetBundle)
    {
        int Count = 0;
        print("Instantiate Image Prefab");
        for(int i = 0;i<9;i++)
        {
            Imageicons = Instantiate(ImgPrefab);
            Imageicons.transform.SetParent(myimagegrid.transform, false);
            Imageicons.name = i.ToString();
                if (indexdata.Contains(i))
                {
                    print("Yeds");
                    Imageicons.GetComponent<Image>().sprite = myassetsobject[Count++];
               
                    //if (Imageicons.GetComponent<Image>().sprite.name == "3")
                    //{
                    //    GameManager.GameManagerinstance.wrongAnswer = Imageicons.GetComponent<GameObject>().transform.gameObject;
                    //}
                }
                else
                {
                    Imageicons.GetComponent<Image>().enabled = false;         
                }
        }
    }

    // Shuffle given image array 
    void Shuffle(Sprite[] array)
    {
        int p = array.Length;
        for (int n = p - 1; n > 0; n--)
        {
            int r = _random.Next(1, n);
            Sprite t = array[r];
            array[r] = array[n];
            array[n] = t;
        }
    }
}
