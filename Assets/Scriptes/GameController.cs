using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.AI;
using Pathfinding;


namespace MayaGame
{  
    [System.Serializable]
    public class ObjG
    {
        public string nameObj, task,prodName;
        public Sprite spt,prodspt;
        public GameObject go,prodGo;
        public CustomCursor cc;
        
    }
    public class GameController : MonoBehaviour
    {
        public static GameController Instance;
        [SerializeField] ObjG[] _objG;
        public GameObject panel,grid;
        public TextMeshProUGUI text,catsSelect,targetSelect;
        int clickNum;
        GameObject Barrack;
        private Building buildingtoplace, newBuildingtoplace;
        public CustomCursor customCursor;
        public Tile[] tiles;
        [SerializeField] List<Building> Go = new List<Building>() ;
        private void Awake()
        {
            Instance = this;
        }
        private void Update()
        {

            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit2D bar = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
                if (bar.collider != null&&bar.transform.tag == "Barrack")
                {
                    Barrack = bar.transform.gameObject;
                    catsSelect.gameObject.SetActive(true);
                    Invoke("txtvis", 1.0f);
                }
                if (buildingtoplace != null)
                {
                    Tile nearsTile = null;
                    float nearsDistance = float.MaxValue;
                    foreach (Tile tile in tiles)
                    {
                        float dist = Vector2.Distance(tile.transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition));
                        if (dist < nearsDistance)
                        {
                            nearsDistance = dist;
                            nearsTile = tile;
                        }
                    }
                    if (nearsTile.inappropriate == false)
                    {
                        newBuildingtoplace = Instantiate(buildingtoplace, nearsTile.transform.position, Quaternion.identity, GameObject.FindGameObjectWithTag("Ins").transform);
                        newBuildingtoplace.name = buildingtoplace.name;
                        Go.Add(newBuildingtoplace);
                        AstarPath.active.Scan();


                        //Destroy( GameObject.FindGameObjectWithTag("Navmesh").GetComponent<NavMeshSurface2d>().navMeshData);


                        buildingtoplace = null;
                        nearsTile.inappropriate = true;
                        grid.SetActive(false);
                        customCursor.gameObject.SetActive(false);
                        Cursor.visible = true;
                    }
                    else if (nearsTile.inappropriate == true)
                    {
                        text.gameObject.SetActive(true);
                        Invoke("txtvis", 1.0f);
                    }
                }
            }

            if (Input.GetMouseButtonDown(1))
            {
                RaycastHit2D nesne = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
                if (Barrack != null)
                {
                    for (int i = 0; i < 5; i++)
                    {
                        Barrack.GetComponent<CatBreeding>().Cats[i].GetComponent<AIDestinationSetter>().target = nesne.transform;
                       
                    } 
                    targetSelect.gameObject.SetActive(true);
                    Invoke("txtvis", 1.0f);
                }
                
               
            }
        }
        void txtvis()
        {
            text.gameObject.SetActive(false);
            targetSelect.gameObject.SetActive(false);
            catsSelect.gameObject.SetActive(false);
        }
        
        public void OnclickBtn(Button btn)
        {
            for (int i = 0; i < _objG.Length; i++)
            {
                if (_objG[i].nameObj==btn.name)
                {
                    clickNum = i;
                }
            }
            panel.SetActive(true);
            PanelController.Instance.objImg.sprite = _objG[clickNum].spt;
            PanelController.Instance.objTsk.text = _objG[clickNum].task;
            if (_objG[clickNum].prodspt != null)
            {
                PanelController.Instance.prodGo.gameObject.SetActive(true);
                PanelController.Instance.prodImg.sprite = _objG[clickNum].prodspt;
                PanelController.Instance.prodName.text = _objG[clickNum].prodName;
            }
            else
            {
                PanelController.Instance.prodGo.gameObject.SetActive(false);

            }
        }

        public void BuildingToPlace(Building building)
        {

            customCursor.gameObject.SetActive(true);
            customCursor.GetComponent<SpriteRenderer>().sprite = _objG[clickNum].spt;
            Cursor.visible = false;

            buildingtoplace = building;
            grid.SetActive(true);
        }


    }

 


}