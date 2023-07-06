namespace BlazeSortWebApp
{
    public record SortRecord
    {
        public TypeOfList TypeOfList { get; set; }

        public SortAlgorithmType SortAlgorithmType { get; set; }

        public TimeSpan Time { get; set; }

        public int SizeList { get; set; }

        public int Number { get; set; }

    }
}
