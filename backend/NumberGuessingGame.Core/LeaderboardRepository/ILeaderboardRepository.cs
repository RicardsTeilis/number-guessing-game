using System.Collections.Generic;

namespace NumberGuessingGame.Core.LeaderboardRepository
{
    public interface ILeaderboardRepository<T>
    {
        public T Create(string name);
        public T Get(int id);
        public List<T> GetAll();
        public void Add(Game.Game entity);
    }
}