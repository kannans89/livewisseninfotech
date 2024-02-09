namespace GameCoreLib
{
    public interface IBoard
    {
        Cell[] Cells { get; }

        Cell GetCell(int index);
        bool IsBoardFull();
        bool IsEmpty();
        void MarkCell(int index, MarkType mark);
    }
}