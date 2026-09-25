using UnityEngine;

public class pipespawnscript : MonoBehaviour
{
    public GameObject pipe;
    public float spwanRate = 2;
    public float timer = 0;
    public float heightOffset = 10;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Spawnpipe();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < spwanRate)
        {
            timer = timer + Time.deltaTime;
        }
        else
        {
            Spawnpipe();
            timer = 0;
        }
        
    }
    void Spawnpipe()
    {
        float lowestpoint = transform.position.y - heightOffset;
        float highestpoint = transform.position.y + heightOffset;
        Instantiate(pipe,new Vector3(transform.position.x,Random.Range(lowestpoint,highestpoint),0), transform.rotation);
    }
}
