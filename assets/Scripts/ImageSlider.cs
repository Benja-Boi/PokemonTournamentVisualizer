using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageSlider : MonoBehaviour
{
    public float speed = 1f; // Define the speed of the movement
    public bool moveRightToLeft = false; // Define the direction of the movement

    private RectTransform _rectTransform;
    private float _imageWidth;

    // Start is called before the first frame update
    void Start()
    {
        _rectTransform = GetComponent<RectTransform>();
        _imageWidth = _rectTransform.rect.width;
    }

    // Update is called once per frame
    void Update()
    {
        if (moveRightToLeft)
        {
            _rectTransform.anchoredPosition -= new Vector2(speed * Time.deltaTime, 0);

            if (_rectTransform.anchoredPosition.x <= -_imageWidth)
            {
                _rectTransform.anchoredPosition += new Vector2(_imageWidth * 2, 0);
            }
        }
        else
        {
            _rectTransform.anchoredPosition += new Vector2(speed * Time.deltaTime, 0);

            if (_rectTransform.anchoredPosition.x >= _imageWidth)
            {
                _rectTransform.anchoredPosition -= new Vector2(_imageWidth * 2, 0);
            }
        }
    }
}