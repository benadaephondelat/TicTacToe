using TicTacToe.DataLayer.Data;

namespace TicTacToe.ServiceLayer.DataLayerService
{
    public class DataLayerService : IDataLayerService
    {
        private ITicTacToeData data;

        public DataLayerService(ITicTacToeData data)
        {
            this.data = data;
        }
    }
}