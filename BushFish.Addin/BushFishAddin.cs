using System.Runtime.InteropServices;

namespace BushFish.Addin;

[ComVisible(true)]
[Guid("24902F91-206E-4BA3-831F-CDAD46AA8C8D")]
[ProgId("BushFish.Addin.BushFishAddin")]
public sealed partial class BushFishAddin : SolidEdgeAddIn
{
    public const string EnglishTitle = "BushFish";
    public const string EnglishDescription = "A general toolkits addin for SolidEdge and other oem version.";
    public const string ChineseDescription = "BishFish是一个适用于SolidEdge和其他OEM版本的通用工具集";

    public override void OnConnection(
        Application application,
        SeConnectMode ConnectMode, 
        AddIn AddInInstance)
    {
        base.OnConnection(application, ConnectMode, AddInInstance);

        AddIn.GuiVersion = 1;

        // Put your custom OnConnection code here.
        var applicationEvents = (ISEApplicationEvents_Event)application.ApplicationEvents;
        applicationEvents.AfterWindowActivate += ApplicationEvents_AfterWindowActivate; ;
    }

    private void ApplicationEvents_AfterWindowActivate(object theWindow)
    {
    }

    public override void OnDisconnection(
        SeDisconnectMode DisconnectMode)
    {
        base.OnDisconnection(DisconnectMode);
    }
}
