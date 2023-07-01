namespace BlazeSortWebApp
{
    public static  class GenerateList
    {

        public static List<int> CreateIncreasingList(int listSize)
        {
            List<int> createdList = new List<int>();
            for (int i = 1; i <= listSize; i++)
            {
                createdList.Add(i);
            }
            return createdList;
        }
        public static List<int> CreateDescendingList(int listSize)
        {
            List<int> createdList = new List<int>();
            for (int i = listSize; i >= 1; i--)
            {
                createdList.Add(i);

            }
            return createdList;
        }

        public static List<int> CreateConstantList(int listSize)
        {
            List<int> createdList = new List<int>();
            for (int i = 1; i <= listSize; i++)
            {
                createdList.Add(1);
            }
            return createdList;
        }

        public static List<int> CreateRandomList(int listSize)
        {
            List<int> createdList = new List<int>();
            Random rnd = new Random();
            for (int i = 1; i <= listSize; i++)
            {
                createdList.Add(rnd.Next());
            }
            return createdList;
        }
    }
}
