namespace SignalServer;

public enum CenterManagementStatus
{
    WaitingForVehicle = 1,
    Queue = 2,
    WaitingForLoading = 3,
    Loading = 4,
    WaitingForInvoice = 5,
    WaitingForManifest = 6,
    ManifestIssued = 7,
    LoadReleased = 8
}