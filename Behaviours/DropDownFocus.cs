using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Interactivity;
using Telerik.Windows.Controls;

namespace HAF.Behaviors {
  public class DropDownFocus: Behavior<RadDropDownButton> {
    public static readonly DependencyProperty TargetProperty = DependencyProperty.Register("Target", typeof(FrameworkElement), typeof(DropDownFocus), new PropertyMetadata(null));
    public FrameworkElement Target {
      get { return (FrameworkElement)this.GetValue(DropDownFocus.TargetProperty); }
      set { this.SetValue(DropDownFocus.TargetProperty, value); }
    }

    protected override void OnAttached() {
      this.AssociatedObject.DropDownOpened += this.AssociatedObject_DropDownOpened;
    }

    protected override void OnDetaching() {
      this.AssociatedObject.DropDownOpened -= this.AssociatedObject_DropDownOpened;
    }
    
    private void AssociatedObject_DropDownOpened(object sender, RoutedEventArgs e) {
      this.Target.Focus();
    }
  }
}
