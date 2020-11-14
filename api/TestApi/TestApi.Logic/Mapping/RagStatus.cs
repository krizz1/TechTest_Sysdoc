namespace TestApi.Logic
{
    public static partial class Mapping
    {
        public static class RagStatus
        {
            public static Domain.RagStatus MapOne(Data.Models.RagStatus ragStatus) =>
                new Domain.RagStatus()
                {
                    Id = (int)ragStatus,
                    Description = ragStatus.ToString()
                };
        }
    }
}
