using UnityEngine;
using System;

using System.Collections;

public class UniPainter : MonoBehaviour
{
    Texture2D texture;
    string color_str = "000000";

    void Start()
    {
        texture = transform.GetComponent<GUITexture>().texture as Texture2D;
        if (texture == null)
        {
            texture = new Texture2D(350, 400);
            transform.GetComponent<GUITexture>().texture = texture;
        }
    }
    void OnGUI()
    {
        color_str = GUI.TextField(new Rect(0, 0, 100, 20), color_str);
    }

    bool write = false;
    Vector3 beforeMousePos;
    void Update()
    {
        if (write)
        {
            Vector3 v = Input.mousePosition;
            lineTo(beforeMousePos, v, getColor());
            beforeMousePos = v;
            texture.Apply();
        }
    }

    public Color getColor()
    {
        try
        {
            float r = Convert.ToInt32(color_str.Substring(0, 2), 16);
            float g = Convert.ToInt32(color_str.Substring(2, 2), 16);
            float b = Convert.ToInt32(color_str.Substring(4, 2), 16);
            return new Color(r, g, b);
        }
        catch (Exception e)
        {
            return Color.black;
        }
    }

    public void lineTo(Vector3 start, Vector3 end, Color color)
    {
        float x = start.x, y = start.y;
        // color of pixels
        Color[] wcolor = { color };

        if (Mathf.Abs(start.x - end.x) >= Mathf.Abs(start.y - end.y))
        {
            float dy = end.x == start.x ? 0 : (end.y - start.y) / (end.x - start.x);
            float dx = start.x < end.x ? 1 : -1;
            //draw line loop
            while (x >= 0 && x < texture.width && y >= 0 && y < texture.height)
            {
                try
                {
                    texture.SetPixels((int)x, (int)y, 1, 1, wcolor);
                    x += dx;
                    y += dx * dy;
                    if (start.x <= end.x && x >= end.x ||
                        start.x >= end.x && x <= end.x)
                    {
                        break;
                    }
                }
                catch (Exception e)
                {
                    Debug.LogException(e);
                    break;
                }
            }
        }
        else if (Mathf.Abs(start.x - end.x) < Mathf.Abs(start.y - end.y))
        {
            float dx = start.y == end.y ? 0 : (end.x - start.x) / (end.y - start.y);
            float dy = start.y < end.y ? 1 : -1;
            while (x >= 0 && x < texture.width && y >= 0 && y < texture.height)
            {
                try
                {
                    texture.SetPixels((int)x, (int)y, 1, 1, wcolor);
                    x += dx * dy;
                    y += dy;
                    if (start.y <= end.y && y >= end.y ||
                        start.y >= end.y && y <= end.y)
                    {
                        break;
                    }
                }
                catch (Exception e)
                {
                    Debug.LogException(e);
                    break;
                }
            }
        }
    }

    void OnMouseDown()
    {
        beforeMousePos = Input.mousePosition;
        write = true;
    }
    void OnMouseUp()
    {
        write = false;
    }
}

