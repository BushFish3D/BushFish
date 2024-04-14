using System.Globalization;
using System.Runtime.InteropServices;

namespace BushFish.Addin;

public partial class BushFishAddin
{
    [ComRegisterFunction]
    public static void OnRegister(Type t)
    {
        // See http://www.codeproject.com/Articles/839585/Solid-Edge-ST-AddIn-Architecture-Overview#Registration for registration details.
        // The following code helps write registry entries that Solid Edge needs to identify an addin. You can omit this code and
        // user installer logic if you'd like. This is simply here to help.
        try
        {
            var settings = new RegistrationSettings(t)
            {
                Enabled = true
            };
            // settings.Environments.Add(SolidEdgeSDK.EnvironmentCategories.Application);
            settings.Environments.Add(SolidEdgeSDK.EnvironmentCategories.AllDocumentEnvrionments);

            // See http://msdn.microsoft.com/en-us/goglobal/bb964664.aspx for LCID details.
            var englishCulture = CultureInfo.GetCultureInfo(1033);

            // Title & Summary are Locale specific. 
            settings.Titles.Add(englishCulture, EnglishTitle);
            settings.Summaries.Add(englishCulture, EnglishDescription);

            var spanishCultere = CultureInfo.GetCultureInfo("zh-CN");
            settings.Titles.Add(spanishCultere, EnglishTitle);
            settings.Summaries.Add(spanishCultere, ChineseDescription);

            Register(settings);
        }
        catch (Exception ex)
        {
            System.Windows.MessageBox.Show(ex.StackTrace, ex.Message);
        }
    }

    [ComUnregisterFunction]
    public static void OnUnregister(Type t) => Unregister(t);
}
