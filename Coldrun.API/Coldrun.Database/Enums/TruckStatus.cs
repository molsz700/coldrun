namespace Coldrun.Database.Enums
{
    [Flags]
    public enum TruckStatus
    {
        OutOfService = 1,
        Loading = 2,
        ToJob = 3,
        AtJob = 4,
        Returning = 5,
    }
}
