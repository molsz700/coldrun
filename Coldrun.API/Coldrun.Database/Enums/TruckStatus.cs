namespace Coldrun.Database.Enums
{
    [Flags]
    public enum TruckStatus
    {
        OutOfService,
        Loading,
        ToJob,
        AtJob,
        Returning
    }
}
