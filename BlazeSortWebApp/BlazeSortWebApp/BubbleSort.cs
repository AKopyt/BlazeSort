namespace BlazeSortWebApp
{
    public class BubbleSort
    {

        public static List<int> Sort(List<int> listToSort)
        {
            for (int i = 0; i < listToSort.Count - 1; i++)
            {
                for (int j = 0; j < listToSort.Count - 1; j++)
                {
                    if (listToSort[j] > listToSort[j + 1])
                    {
                        int temporary = listToSort[j];
                        listToSort[j] = listToSort[j + 1];
                        listToSort[j + 1] = temporary;
                    }
                }
            }

            return listToSort;
        }
    }
}
