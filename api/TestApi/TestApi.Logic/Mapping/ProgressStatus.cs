namespace TestApi.Logic
{
    public static partial class Mapping
    {
        public static class ProgressStatus
        {
            public static Domain.ProgressStatus MapOne(Data.Models.ProgressStatus progressStatus) =>
                new Domain.ProgressStatus()
                {
                    Id = (int)progressStatus,
                    Description = progressStatus.ToString()
                };
        }
    }
}
