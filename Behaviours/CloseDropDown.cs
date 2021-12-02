using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Interactivity;
using System.Windows.Media;
using Telerik.Windows.Controls;

namespace HAF.Behaviors {
  public class CloseDropDown: Behavior<ButtonBase> {
    protected override void OnAttached() {
      this.AssociatedObject.Click += Button_Click;
    }

    protected override void OnDetaching() {
      this.AssociatedObject.Click -= Button_Click;
    }

    private void Button_Click(object sender, RoutedEventArgs e) {
      var button = this.AssociatedObject.ParentOfType<RadDropDownButton>();
      if (button != null) {
        button.IsOpen = false;
      }
    }
  }
}
