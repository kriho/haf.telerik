using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HAF.SettingsDrawers {
  [Export(typeof(ISettingsDrawer)), PartCreationPolicy(CreationPolicy.NonShared)]
  [ExportMetadata("AssociatedType", typeof(ISetting<int>))]
  [ExportMetadata("Features", "min,max,unit")]
  public partial class NumericUpDown : UserControl, ISettingsDrawer {
    public NumericUpDown() {
      InitializeComponent();
    }

    public string DisplayName => null;

    public string Description => null;
  }
}