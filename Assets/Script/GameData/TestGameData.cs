using System;

[Serializable]
public class TestData
{
    public string Key1 { get; set; }
    public string Key2 { get; set; }
    public string Key3 { get; set; }
}

[Serializable]
public class TestDataList
{
    public TestData[] data;
}
