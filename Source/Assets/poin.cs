using System.Collections.Generic;
using UnityEngine;

public class poin : MonoBehaviour
{
    [System.Serializable]
    public class Pool 
    {
        public string tag;
        public int size;
        public GameObject prefab;
    }
    #region Singleton
    public static poin Instance;//pravljenje instance
    private void Awake()
    {
        Instance = this;
    }
    #endregion
    public List<Pool> pools;
    public Dictionary<string, Queue<GameObject>> poolDictionary;
    int colorPoints = 1;
    // Start is called before the first frame update
    void Start()
    {
        poolDictionary = new Dictionary<string, Queue<GameObject>>();

        foreach (Pool pool in pools) 
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();
            for (int i = 0; i < pool.size; i++) 
            {
                GameObject obj = Instantiate(pool.prefab);//Dodala instancu prefab
                obj.SetActive(false);
                objectPool.Enqueue(obj);//dodaje element na kraj
            }
            poolDictionary.Add(pool.tag, objectPool);//dodajes ime i objekat u poolDictionary
        }
    }
    public GameObject SpawmFromPool(string tag, Vector3 position, Quaternion rotation)
    {
        if (!poolDictionary.ContainsKey(tag))
        {
            Debug.LogWarning("pool with tag" + tag + "doesn't exist");
            return null;
        }
        GameObject objectToSpawn = poolDictionary[tag].Dequeue();//Uzima iz liste
        objectToSpawn.SetActive(true);
        objectToSpawn.transform.position = position;
        objectToSpawn.transform.rotation = rotation;
        colorPoints = Random.Range(1, 4);
        switch (colorPoints)
        {
            case 1:
                objectToSpawn.GetComponent<Renderer>().material.SetColor("_Color", Color.blue);
                break;
            case 2:
                objectToSpawn.GetComponent<Renderer>().material.SetColor("_Color", Color.green);
                break;
            default:
                objectToSpawn.GetComponent<Renderer>().material.SetColor("_Color", Color.black);
                break;
        }
        poolDictionary[tag].Enqueue(objectToSpawn);//sve objekte
        return objectToSpawn;
    }
    public int sizeCount() 
    {
        int size=0;
        foreach (Pool pool in pools)
            for (int i = 0; i < pool.size; i++) 
            {
                size++;
            }
        return size;
    }
}
