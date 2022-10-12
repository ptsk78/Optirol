using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace Optirol.Properties
{
  [DebuggerNonUserCode]
  [CompilerGenerated]
  [GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
  internal class Resources
  {
    private static ResourceManager resourceMan;
    private static CultureInfo resourceCulture;

    internal Resources()
    {
    }

    [EditorBrowsable(EditorBrowsableState.Advanced)]
    internal static ResourceManager ResourceManager
    {
      get
      {
        if (object.ReferenceEquals((object) Optirol.Properties.Resources.resourceMan, (object) null))
          Optirol.Properties.Resources.resourceMan = new ResourceManager("Optirol.Properties.Resources", typeof (Optirol.Properties.Resources).Assembly);
        return Optirol.Properties.Resources.resourceMan;
      }
    }

    [EditorBrowsable(EditorBrowsableState.Advanced)]
    internal static CultureInfo Culture
    {
      get
      {
        return Optirol.Properties.Resources.resourceCulture;
      }
      set
      {
        Optirol.Properties.Resources.resourceCulture = value;
      }
    }
  }
}
