using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct ExperimentInfo
{
    public List<ExperimentStage> stages;
    public int ProgressingStageIndex;
    public bool Proceed()
    {
        ProgressingStageIndex++;
        if (ProgressingStageIndex >= stages.Count)
            return true;
        return false;
    }

    public ExperimentStage GetProgressingStage()
    {
        return stages[ProgressingStageIndex];
    }
}
public struct ExperimentStage
{
    public string StageName, StagePurpose, Description;
    public GameObject DetailGraphObj;
    public static ExperimentStage Create(string name, string purpose, string descript, GameObject graphobj = null)
    {
        ExperimentStage e = new ExperimentStage();
        e.StageName = name;
        e.StagePurpose = purpose;
        e.Description = descript;
        e.DetailGraphObj = graphobj;
        return e;
    }
}

public class StageUIManager : MonoBehaviour
{
    [SerializeField]
    GameObject StageUIPrefab, ConnectionUIPrefab;
    public List<GameObject> StageUIList, ConnectionUIList;
    public Vector3 Origin;
    public Vector3 Direction = new Vector3(1, 0, 0);  // Normalized Vector3
    public float Interval = 1f;
    public Vector2 UISize = new Vector2(1, 1);
    public ExperimentInfo experimentInfo;

    // Start is called before the first frame update
    private void Start()
    {
        experimentInfo = new ExperimentInfo();
        experimentInfo.stages = new List<ExperimentStage>();
        experimentInfo.stages.Add(ExperimentStage.Create("Stage0", "PurPose", "Desc"));
        experimentInfo.stages.Add(ExperimentStage.Create("Stage1", "PurPose", "Desc"));
        experimentInfo.stages.Add(ExperimentStage.Create("Stage2", "PurPose", "Desc"));
        experimentInfo.stages.Add(ExperimentStage.Create("Stage3", "PurPose", "Desc"));
        Initialize(experimentInfo);
    }

    public void Initialize(ExperimentInfo info)
    {
        StageUIList = new List<GameObject>();
        ConnectionUIList = new List<GameObject>();
        experimentInfo = info;
        for (int i = 1; i < info.stages.Count; i++)
        {
            ConnectionUIList.Add(Instantiate(ConnectionUIPrefab, transform));
        }
        StageUIList.Add(Instantiate(StageUIPrefab, Origin, Quaternion.Euler(90, 0, 0), transform)); //RootUI
        for (int s = 1; s < info.stages.Count; s++)
        {
            GenerateStageUI(info.stages[s]);
        }
    }

    public void GenerateStageUI(ExperimentStage stage)
    {
        Vector3 prevpos = StageUIList[StageUIList.Count - 1].transform.position;
        Vector3 newpos = prevpos + Direction * Interval;
        GameObject obj = ConnectionUIList[StageUIList.Count - 1];
        obj.transform.position = (prevpos + newpos) / 2 - new Vector3(0, (prevpos.y + newpos.y) / 4, 0);
        obj.transform.right = Direction;
        obj.transform.up = StageUIList[StageUIList.Count - 1].transform.up;
        obj.transform.localScale = new Vector3(Interval,obj.transform.localScale.y,obj.transform.localScale.z);
        StageUIList.Add(Instantiate(StageUIPrefab, newpos, Quaternion.Euler(90, 0, 0), transform));
    }
}
