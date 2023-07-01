using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using BlazeSortWebApp.Pages;
using MudBlazor;


namespace BlazeSortWebApp
{
    public class IndexViewModel
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
     
        public string CreatedList { get; set; }

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

        public List<int> CreateIncreasingList()
        {
            List<int> createdList = new List<int>();
            for (int i = 1; i <= ListSize; i++)
            {
                createdList.Add(i);
            }
            return createdList;
        }
        public List<int> CreateDescendingList()
        {
            List<int> createdList = new List<int>();
            for (int i = ListSize; i >= 1; i--)
            {
                createdList.Add(i);

            }
            return createdList;
        }

        public List<int> CreateConstantList()
        {
            List<int> createdList = new List<int>();
            for (int i = 1; i <= ListSize; i++)
            {
                createdList.Add(1);
            }
            return createdList;
        }

        public List<int> CreateRandomList()
        {
            List<int> createdList = new List<int>();
            Random rnd = new Random();
            for (int i = 1; i <= ListSize; i++)
            {
                createdList.Add(rnd.Next());    
            }
            return createdList;
        }

        public async Task CreateList()
        {
            List<int> createdList = new List<int>();

            switch(TypeOfList)
            {
                case TypeOfList.IncreasingList:
                    createdList = CreateIncreasingList();
                    break;
                case TypeOfList.DescendingList:
                    createdList = CreateDescendingList();
                    break;
                case TypeOfList.ConstantList:
                    createdList = CreateConstantList();
                    break;
                case TypeOfList.RandomList:
                    createdList = CreateRandomList();
                    break;

            }
            
            for(int i=0; i<createdList.Count; i++)
            {
                if (i == createdList.Count - 1)
                    CreatedList += createdList[i].ToString();
                else
                    CreatedList += createdList[i].ToString() + Spliter;

            }

            NumbersToSort = CreatedList;

        }

    }
}
