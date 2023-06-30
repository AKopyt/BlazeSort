namespace BlazeSortWebApp
{
    public class QuickSort
    {
        public static List<int> Sort(List<int> listToSort, int leftIndex, int rightIndex)
        {
            int i = leftIndex;
            int j = rightIndex;
            var pivot = listToSort[leftIndex];

            while (i <= j)
            {
                while (listToSort[i] < pivot)
                {
                    i++;
                }

                while (listToSort[j] > pivot)
                {
                    j--;
                }
                if (i <= j)
                {
                    int temp = listToSort[i];
                    listToSort[i] = listToSort[j];
                    listToSort[j] = temp;
                    i++;
                    j--;
                }
            }


            if (leftIndex < j)
                Sort(listToSort, leftIndex, j);
            if (i < rightIndex)
                Sort(listToSort, i, rightIndex);




            return listToSort;

        }
    }
}
