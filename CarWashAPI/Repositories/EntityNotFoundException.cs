namespace CarWashAPI.Repositories
{
    internal class EntityNotFoundException<T> : Exception
    {
        public EntityNotFoundException()
        {
        }

        public EntityNotFoundException(string message) : base(message)
        {
        }

        public EntityNotFoundException(long id)
            : base($"Сущность типа {typeof(T).Name} с идентификатором {id} не найдена.")
        {
        }

        public EntityNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
