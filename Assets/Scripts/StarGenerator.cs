using UnityEngine;
using UnityEngine.UIElements;

public class StarGenerator : MonoBehaviour
{
    public GameObject Star;
    public int MaxStars;

    Color[] starColors =
    {
        new Color(0.5f, 0.5f, 1f),
        new Color(0, 1f, 1f),
        new Color(1f, 1f, 0),
        new Color(1f, 0, 0)
    };

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Vector2 min = Camera.main.ViewportToWorldPoint(Vector2.zero);
        Vector2 max = Camera.main.ViewportToWorldPoint(Vector2.one);
        for (int i = 0; i < MaxStars; i++)
        {
            GameObject star = Instantiate(Star);
            star.GetComponent<SpriteRenderer>().color = starColors[i % starColors.Length];
            star.transform.position = new Vector2(Random.Range(min.x, max.x), Random.Range(min.y, max.x));
            star.GetComponent<Star>().speed = -(1f * Random.value + 0.5f);
            star.transform.parent = transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
