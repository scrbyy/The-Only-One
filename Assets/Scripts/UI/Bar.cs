using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(Image))]
public class Bar : MonoBehaviour
{
    protected Image _barImage;
    private void Start()
    {
        _barImage = GetComponent<Image>();
    }
    public void ChangeValue(float value)
    {
        _barImage.fillAmount = value;
    }
}
