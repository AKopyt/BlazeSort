namespace BlazeSortWebApp;

public class SortRecordsView
{
    public List<SortRecord> ListOfSortRecord { get; set; }

    public SortRecordsView()
    {
        ListOfSortRecord = new List<SortRecord>();
    }

    public void AddToList(SortRecord record)
    {
        ListOfSortRecord.Add(record);
    }


}