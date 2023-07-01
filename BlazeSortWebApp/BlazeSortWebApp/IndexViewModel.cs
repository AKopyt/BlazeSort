using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using BlazeSortWebApp.Pages;
using MudBlazor;


namespace BlazeSortWebApp
{
    public class IndexViewModel : IViewModel
    {
        IDialogService _dialogService;
        public IndexViewModel(IDialogService dialog)
        {
            _dialogService = dialog;
        }
        public string NumbersToSort { get; set; }

        public string Spliter { get; set; }
        
        public TimeSpan TimeSorted { get; set; }

        public SortAlgorithmType SortMethod { get; set; }
        public TypeOfList TypeOfList { get; set; }

        public string SortedNumbers { get; set; }

        public int ListSize { get; set; }

        DialogOptions DialogOptions = new DialogOptions() { CloseButton = true };

        private void OpenErrorDialog(DialogOptions options)
        {
            _dialogService.Show<DialogError>("Syntax error", options);
        }

        private void OpenSortedSuccessfullyDialog()
        {
            var parameters = new DialogParameters { { "Time", TimeSorted } };
            _dialogService.Show<DialogSortedSuccessfully>("Sorting time",parameters);
        }


        public async Task Sort()
        {
            try
            {
                var splittedString = NumbersToSort.Split(Spliter);
                var ints = Array.ConvertAll(splittedString, s => int.Parse(s)).ToList();
                Stopwatch stopWatch = Stopwatch.StartNew();
                List<int> sortedList = new List<int>();
                
                if (SortMethod == SortAlgorithmType.BubbleSort)
                {
                    sortedList = BubbleSort.Sort(ints);
                }
                if (SortMethod == SortAlgorithmType.InsertionSort)
                {
                    sortedList = InsertionSort.Sort(ints);
                }
                if (SortMethod == SortAlgorithmType.QuickSort)
                {
                    sortedList = QuickSort.Sort(ints,0, ints.Count-1);
                }
                
                stopWatch.Stop();
                TimeSorted = stopWatch.Elapsed;
                OpenSortedSuccessfullyDialog();
                string[] sortedListToString = sortedList.Select(i => i.ToString()).ToArray();
                SortedNumbers = string.Join(Spliter, sortedListToString);
            }
            catch (Exception e)
            {
                OpenErrorDialog(DialogOptions);

            }
        }

       

        public async Task CreateList()
        {
            List<int> createdList = new List<int>();

            switch(TypeOfList)
            {
                case TypeOfList.IncreasingList:
                    createdList = GenerateList.CreateIncreasingList(ListSize);
                    break;
                case TypeOfList.DescendingList:
                    createdList = GenerateList.CreateDescendingList(ListSize);
                    break;
                case TypeOfList.ConstantList:
                    createdList = GenerateList.CreateConstantList(ListSize);
                    break;
                case TypeOfList.RandomList:
                    createdList = GenerateList.CreateRandomList(ListSize);
                    break;

            }

            NumbersToSort = "";

            for (int i=0; i<createdList.Count; i++)
            {
                if (i == createdList.Count - 1)
                    NumbersToSort += createdList[i].ToString();
                else
                    NumbersToSort += createdList[i].ToString() + Spliter;

            }

        }

    }
}
