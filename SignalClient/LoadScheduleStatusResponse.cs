namespace SignalClient;

public class LoadScheduleStatusResponse
{
    public int LoadId { get; set; }
    public string? VehiclePlate { get; set; }
    public CenterManagementStatus Status { get; set; }
    public DateTime Date { get; set; }
}