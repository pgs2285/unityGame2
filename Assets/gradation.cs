using UnityEngine;
using UnityEngine.UI;

public class GradientBackground : Graphic
{
    public Color TopColor = Color.white;
    public Color BottomColor = Color.black;

    protected override void OnPopulateMesh(VertexHelper vh)
    {
        vh.Clear();

        var rect = GetComponent<RectTransform>();
        var width = rect.rect.width;
        var height = rect.rect.height;

        var v0 = UIVertex.simpleVert;
        v0.color = TopColor;
        v0.position = new Vector3(0, 0, 0);

        var v1 = UIVertex.simpleVert;
        v1.color = TopColor;
        v1.position = new Vector3(0, height, 0);

        var v2 = UIVertex.simpleVert;
        v2.color = BottomColor;
        v2.position = new Vector3(width, height, 0);

        var v3 = UIVertex.simpleVert;
        v3.color = BottomColor;
        v3.position = new Vector3(width, 0, 0);

        vh.AddVert(v0);
        vh.AddVert(v1);
        vh.AddVert(v2);
        vh.AddVert(v3);

        vh.AddTriangle(0, 1, 2);
        vh.AddTriangle(2, 3, 0);
    }
}
