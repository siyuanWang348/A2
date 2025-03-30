using UnityEngine;

public class MeshDeformer : MonoBehaviour
{
    public float noiseStrength = 0.5f; // 形变强度
    public float noiseScale = 2f; // Perlin Noise 缩放

    void Start()
    {
        // 获取 MeshFilter 组件
        MeshFilter meshFilter = GetComponent<MeshFilter>();
        if (meshFilter != null)
        {
            // **克隆 Prefab 的 Mesh**，确保它不会被重置
            meshFilter.mesh = Instantiate(meshFilter.sharedMesh);
            Mesh mesh = meshFilter.mesh;

            // 获取顶点数组
            Vector3[] vertices = mesh.vertices;

            for (int i = 0; i < vertices.Length; i++)
            {
                // 获取顶点的世界坐标
                Vector3 worldPos = transform.TransformPoint(vertices[i]);

                // 计算 Perlin 噪声值
                float noise = Mathf.PerlinNoise(worldPos.x * noiseScale, worldPos.y * noiseScale);

                // 沿着法线方向扰动顶点
                vertices[i] += vertices[i].normalized * noise * noiseStrength;
            }

            // 重新应用修改后的顶点数据
            mesh.vertices = vertices;
            mesh.RecalculateNormals(); // 重新计算法线，保证光照正确
            mesh.RecalculateBounds();  // 重新计算包围盒
        }
    }
}
