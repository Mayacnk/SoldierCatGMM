using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatBreeding : MonoBehaviour
{
    public static CatBreeding Instance;
  [SerializeField] GameObject CatGo,cat;
     public List<GameObject> Cats = new List<GameObject>();
    private void Start()
    {
        Instance = this;
        StartCoroutine(CatB());
    }

    IEnumerator CatB()
    {
        while (Cats.Count < 5)
        {
            CatGo = Instantiate(cat,transform.position,Quaternion.identity,transform);
            Cats.Add(CatGo);
            yield return new WaitForSeconds(1);

        }
        
    }
}
