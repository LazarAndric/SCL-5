using UnityEngine;
using PathCreation;
public class PointSpawner : MonoBehaviour
{
    public PathCreator pathCreator;
    public Vector3 offset;

    poin pointPooler;
    Vector3 pom;
    bool pooler = true;
    int korak=0;
    float x;
    float step=0.5f;

    public void changeBool() 
    {
        pooler = true;
    }
    void Start()
    {
        pointPooler = poin.Instance;
    }
    private void FixedUpdate()
    {
        if (pooler)
        {
                Vector3 lookDirection = pathCreator.path.GetPoint(korak=korak+30) - transform.position;//tacke pojavaljinja prepreka
                Quaternion rot = Quaternion.LookRotation(lookDirection, Vector3.up);
                transform.rotation = Quaternion.Lerp(transform.rotation, rot, Time.deltaTime);//kreira utisak dinamike
                transform.position = pathCreator.path.GetPointAtDistance(korak) + offset;//centriranje
                pom = transform.position;
                x = transform.position.x;
                for (int i = 0; i < pointPooler.sizeCount(); i++)
                {
                    pom = new Vector3(x + step, pom.y, pom.z);
                    step += 0.5f;//izmedju kocki
                    pointPooler.SpawmFromPool("Point", pom, Quaternion.identity);
                    pooler = false;
                }
             step = 0.5f;
        }
    }
}
