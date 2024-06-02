using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class PhotoViewer : UdonSharpBehaviour
{
    [SerializeField] private Texture2D[] photoList; // 表示する写真の配列
    [SerializeField] private float transitionTime = 2.0f; // 写真の切り替え時間（秒）

    private Material material;
    private int currentPhotoIndex = 0; // 現在の写真のインデックス
    private float timer = 0f; // 時間を計測するためのタイマー

    void Start()
    {
        if (photoList.Length == 0) // 配列が空かどうかのチェック
        {
            Debug.LogError("Photo list is empty!");
            return;
        }

        material = GetComponent<Renderer>().material;
        material.mainTexture = photoList[currentPhotoIndex]; // 最初の写真を設定
    }

    void Update()
    {
        if (photoList.Length > 1) // 写真が1枚以上ある場合のみ切り替えを行う
        {
            timer += Time.deltaTime;

            if (timer >= transitionTime)
            {
                timer = 0f; // タイマーをリセット
                currentPhotoIndex = (currentPhotoIndex + 1) % photoList.Length; // 次の写真のインデックスを計算
                material.mainTexture = photoList[currentPhotoIndex]; // マテリアルのテクスチャを更新
            }
        }
    }
}
