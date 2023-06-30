using FluentAssertions;
using BlazeSortWebApp;


namespace BlazeSortTest
{
    public class SortTests
    {
        [Fact]
        public void BubbleSortTest()
        {
            //arrange
            List<int> listToSort = new List<int>() { 3, 7, 2, 9, 8, 10, 15, 5 };
            List<int> sortedList = new List<int>() { 2, 3, 5, 7, 8, 9, 10, 15 };
            
            //act
            var sut = BubbleSort.Sort(listToSort);

            //assert
            for (int i = 0; i < listToSort.Count - 1; i++)
            {
                sortedList[i].Should().Be(sut[i]);
            }
        }

        [Fact]
        public void InsertionSortTest()
        {
            //arrange
            List<int> listToSort = new List<int>() { 3, 7, 2, 9, 8, 10, 15, 5 };
            List<int> sortedList = new List<int>() { 2, 3, 5, 7, 8, 9, 10, 15 };

            //act
            var sut = InsertionSort.Sort(listToSort);

            //assert
            for (int i = 0; i < listToSort.Count - 1; i++)
            {
                sortedList[i].Should().Be(sut[i]);
            }
        }

        [Fact]
        public void QuickSortTest()
        {
            //arrange
            List<int> listToSort = new List<int>() { 3, 7, 2, 9, 8, 10, 15, 5 };
            List<int> sortedList = new List<int>() { 2, 3, 5, 7, 8, 9, 10, 15 };
           
            //act
            var sut = QuickSort.Sort(listToSort, 0, listToSort.Count-1);

            //assert
            for (int i = 0; i < listToSort.Count - 1; i++)
            {
                sortedList[i].Should().Be(sut[i]);
            }
        }
        [Fact]
        public void QuickSortTest2()
        {
            //arrange
            List<int> listToSort = new List<int>() { 7,2,9,10,4,3,5,11,21,2};
            List<int> sortedList = new List<int>() { 2,2,3,4,5,7,9,10, 11,21};

            //act
            var sut = QuickSort.Sort(listToSort, 0, listToSort.Count-1);

            //assert
            for (int i = 0; i < listToSort.Count - 1; i++)
            {
                sortedList[i].Should().Be(sut[i]);
            }
        }
    }
}