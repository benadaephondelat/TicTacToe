namespace TicTacToe.Computer.Constants
{
    using TicTacToeCommon.Constants;

    public static class ComputerConstants
    {
        public static readonly int CenterPosition = TileConstants.MiddleMiddleTile;

        public static readonly int[] BestStartingPositions = new int[]
        {
            TileConstants.TopLeftTile,
            TileConstants.TopRightTile,
            TileConstants.MiddleMiddleTile,
            TileConstants.BottomLeftTile,
            TileConstants.BottomRightTile
        };
    }
}
