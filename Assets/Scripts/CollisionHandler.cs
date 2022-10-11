using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    void OnCollisionEnter(Collision other)
    {
        switch (other.gameObject.tag) // variable here
        {
            case "Friendly":
            Debug.Log("this thing is friendly");
            break;
            case "Finish":
            Debug.Log("You've finished!");
            break;
            case "Fuel":
            Debug.Log("You gain points!");
            break;
            default:
            Debug.Log("Sorry, I'm terrible");
            break;
        }
    }
}
