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
    }
}