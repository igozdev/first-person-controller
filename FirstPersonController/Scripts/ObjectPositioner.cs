using UnityEngine;

public class ObjectPositioner : MonoBehaviour
{
    [System.Serializable]
    private struct posObjs
    {
        // Gameobject to be moved
        public GameObject obj;
        // Modifier applied to "obj" when moving it
        public float positionModifier;
    }

    [SerializeField] private CharacterController playerController;
    // List of objects to be moved
    [SerializeField] private posObjs[] objects;

    void Start()
    {
        // Cache transform
        Vector3 playerPos = transform.position;
        // Get distance from center to bottom of player bounds
        float yDist = playerController.bounds.extents.y;

        // For each Gameobject in "objects" move it according to the position modifier along the y of the player mesh
        foreach(posObjs posObj in objects)
            posObj.obj.transform.position = new Vector3(playerPos.x, playerPos.y + (yDist * posObj.positionModifier), playerPos.z);
    }
}