using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BlockUIScript : MonoBehaviour
{
    public static BlockUIScript Instance;
    public Button block2, block3 ,block4;
    public Button restartBtn;
    public enum Blocks
    {
        block2,block3,block4
    }
    public Blocks blocks;

    private void Awake()
    {
        Instance = this;   
    }

    void Start()
    {
        block2.onClick.AddListener(Block2Btn);
        block3.onClick.AddListener(Block3Btn);
        block4.onClick.AddListener(Block4Btn);
        restartBtn.onClick.AddListener(Rest);
    }

    void Block2Btn()
    {
        blocks = Blocks.block2;
    }
    void Block3Btn()
    {
        blocks = Blocks.block3;
    } 
    void Block4Btn()
    {
        blocks = Blocks.block4;
    }
    void Rest()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
