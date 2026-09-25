using UnityEngine;

public class PipeMiddleScript : MonoBehaviour
{
    public LogicScript Logic;

    void Start()
    {
        // Automatically find the LogicScript in the scene
        Logic = GameObject.FindGameObjectWithTag("logic").GetComponent<LogicScript>();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // This will print to your Console window every time ANYTHING enters the middle trigger
        Debug.Log("Something hit the middle trigger: " + collision.gameObject.name);

        if (collision.CompareTag("Player"))
        {
            Logic.AddScore(1);
        }
    
}
}