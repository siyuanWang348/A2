using UnityEngine;

public class ScaleController : MonoBehaviour
{
    public void IncreaseSize()
    {
        transform.localScale += new Vector3(0.1f, 0.1f, 0.1f);
    }

    public void DecreaseSize()
    {
        transform.localScale -= new Vector3(0.1f, 0.1f, 0.1f);
    }
}
