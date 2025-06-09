using UnityEngine;

public class FacingCamera : MonoBehaviour
{
    Transform[] Children;
    public Camera Camera;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Children = new Transform[transform.childCount];
        for (int i = 0; i< transform.childCount; i++)
        {
            Children[i] = transform.GetChild(i);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Camera.main != null)
        {
            for (int i = 0; i <  Children.Length; i++)
            {
                Children[i].transform.rotation = Camera.main.transform.rotation;
            }
        }

    }
}
