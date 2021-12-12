using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HAF.SettingsDrawers {
  [Export(typeof(ISettingsDrawer)), PartCreationPolicy(CreationPolicy.NonShared)]
  [ExportMetadata("AssociatedType", typeof(ISetting<bool>))]
  [ExportMetadata("Features", "")]
  public partial class CheckBox : UserControl, ISettingsDrawer {
    public CheckBox() {
      InitializeComponent();
    }

    public CheckBox(string text, object source, string path, string description = null): this() {
      this.nameRun.Text = text;
      this.descriptionTextBlock.Text = description;
      // set IsChecked binding
      var isCheckedBinding = new Binding(path) {
        Source = source,
        Mode = BindingMode.TwoWay,
      };
      BindingOperations.SetBinding(this.checkBox, ToggleButton.IsCheckedProperty, isCheckedBinding);
    }
  }
}
