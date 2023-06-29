namespace BlazeSortWebApp
{
    public class InsertionSort
    {

        public static List<int> Sort(List<int> listToSort)
        {

            for (int i = 1; i < listToSort.Count; i++)
            {
                int key = listToSort[i];
                int j = i - 1;

                while (j >= 0 && listToSort[j] > key)
                {
                    listToSort[j + 1] = listToSort[j];
                    j = j - 1;
                }

                listToSort[j + 1] = key;
            }

            return listToSort; 
        }
    }
}
